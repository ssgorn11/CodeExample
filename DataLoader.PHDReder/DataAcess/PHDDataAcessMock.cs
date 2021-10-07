using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.PHDReder
{
    internal class PHDDataAcessMock : IPHDDataAcess
    {
        private Random _rnd = new Random(1000);
        public void Init(string readerConnectionString)
        {
            
        }
        public IList<PHDDataDto> ReadTagData(Tuple<int, string> tag, DateTime dateStart, DateTime dateEnd)
        {
            var res = new List<PHDDataDto>();

            var rnRes = _rnd.Next();
            if (rnRes < 50)
                throw new Exception("Some DataError 1233");
            else
            {
                res.Add(new PHDDataDto() { IdTag = tag.Item1, Tag = tag.Item2, Confidence = 100, DatePHD = DateTime.Now, ReadTime = DateTime.Now, Value = rnRes });
                Task.Delay(rnRes * 2);
            }

            return res;
        }
    }
}
