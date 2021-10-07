using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.PHDReder
{
    public interface IPHDDataAcess
    {
        void Init(string readerConnectionString);
        IList<PHDDataDto> ReadTagData(Tuple<int, string> tag, DateTime dateStart, DateTime dateEnd);
    }
}
