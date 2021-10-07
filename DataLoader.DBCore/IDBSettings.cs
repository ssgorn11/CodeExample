using System;
using System.Collections.Generic;
using System.Text;

namespace DataLoader.DBCore
{
    public interface IDBSettings
    {
        SourceType SourceType { get; }

        string ConnectionString { get; }
    }
}
