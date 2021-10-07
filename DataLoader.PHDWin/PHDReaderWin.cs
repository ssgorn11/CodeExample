using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.PHDWin
{
    public class PHDReaderWin
    {
        private Uniformance.PHD.PHDHistorian _phd;

        public PHDReaderWin(string connStr)
        {
            _phd = new Uniformance.PHD.PHDHistorian
            {
                DefaultServer = new Uniformance.PHD.PHDServer(GetServerName(connStr), Uniformance.PHD.SERVERVERSION.API200)
                {
                    Port = GetPort(connStr)
                },
                Sampletype = Uniformance.PHD.SAMPLETYPE.Raw,
                ReductionType = Uniformance.PHD.REDUCTIONTYPE.None
            };
        }

        public IList<PHDData> ReadTagData(Tuple<int, string> tag, DateTime dateStart, DateTime dateEnd)
        {
            var res = new List<PHDData>();

            var st = dateStart.ToString("MM.dd.yyyy HH:mm:ss");
            var et = dateEnd.ToString("MM.dd.yyyy HH:mm:ss");

            _phd.StartTime = st;
            _phd.EndTime = et;

            double[] timestamps = null;
            short[] confidences = null;

            var myTag = new Uniformance.PHD.Tag(tag.Item2);
            double[] values = null;
            _phd.FetchData(myTag, ref timestamps, ref values, ref confidences);

            if (values.Length <= 0)
                return null;

            string unit = "";
            try
            {
                var dataSet = _phd.TagDfn(tag.Item2);
                unit = dataSet.Tables["TagDefn"].Rows[0]["Units"]?.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            for (var indexValue = 0; indexValue < values.Length; indexValue++)
            {
                decimal val = 0;
                int conf = 0;
                var timeS = DateTime.MinValue;
                try
                {
                    timeS = DateTime.FromOADate(timestamps[indexValue]);
                }
                catch (Exception)
                {
                }

                if (decimal.TryParse(values[indexValue].ToString(), out val)
                    && int.TryParse(confidences[indexValue].ToString(), out conf))
                {
                    //if (isLog)
                    //    log.Add(new Tuple<string, string>(val.ToString(), "befoleListSave"));
                    res.Add(new PHDData() { IdTag = tag.Item1, Confidence = conf, DatePHD = timeS, ReadTime = DateTime.Now, Tag = tag.Item2, Unit = unit, Value = val });
                }
            }

            return res;
        }

        private string GetServerName(string con)
        {
            string res = "";

            foreach (var ch in con)
            {
                if (ch != ' ')
                    res += ch.ToString();
                else
                    break;
            }

            return res;
        }

        private int GetPort(string con)
        {
            string res = "";
            bool isSecond = false;
            for (int i = 0; i < con.Length; i++)
            {
                var ch = con[i];

                if (isSecond && ch != ' ')
                    res += ch.ToString();
                else if (ch == ' ' && !isSecond && res == "")
                    isSecond = true;
                else if (isSecond && ch == ' ' && res != "")
                    break;
            }

            return int.Parse(res);
        }
    }
}
