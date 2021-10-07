using DataLoader.DBCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.PHDReder
{
    internal class PHDDataReader : IPHDDataReader
    {
        private IReaderSettings _readerSettings;
        private ILogError _logError;
        private IPHDDataAcess _dataAcess;

        public PHDDataReader(IReaderSettings readerSettings, ILogError logError, IPHDDataAcess dataAcess)
        {
            _readerSettings = readerSettings;
            _dataAcess = dataAcess;
        }

        public async Task<IEnumerable<PHDDataDto>> GetPHDDataAsync(IEnumerable<Tuple<int, string>> tags, DateTime dateStart, DateTime dateEnd)
        {
            return await Task.Run(() =>
            {
                var res = new List<PHDDataDto>();

                try
                {
                    _dataAcess.Init(_readerSettings.ReaderConnectionString);

                    foreach (var tag in tags)
                    {
                        try
                        {
                            res.AddRange(_dataAcess.ReadTagData(tag, dateStart, dateEnd));
                        }
                        catch (Exception ex)
                        {
                            _logError.ErrorAsync(ex, "DataLoader.PHDReder->PHDDataReader->GetPHDDataAsync");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logError.ErrorAsync(ex, "DataLoader.PHDReder->PHDDataReader->GetPHDDataAsync");
                }

                return res;
            });
        }


    }
}
