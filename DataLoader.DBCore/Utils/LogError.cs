using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.DBCore
{
    internal class LogError : ILogError
    {
        public async Task ErrorAsync(string text, string place)
        {
            
        }

        public async Task ErrorAsync(Exception ex, string place)
        {
            
        }

        public async Task LogAsync(string text, string group)
        {
            
        }
    }
}
