using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.DBCore
{
    public interface ILogError
    {
        Task LogAsync(string text, string group);

        Task ErrorAsync(string text, string place);

        Task ErrorAsync(Exception ex, string place);
    }
}
