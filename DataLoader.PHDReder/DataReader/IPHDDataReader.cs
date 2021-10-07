using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.PHDReder
{
    public interface IPHDDataReader
    {
        Task<IEnumerable<PHDDataDto>> GetPHDDataAsync(IEnumerable<Tuple<int, string>> tags, DateTime dateStart, DateTime dateEnd);
    }
}
