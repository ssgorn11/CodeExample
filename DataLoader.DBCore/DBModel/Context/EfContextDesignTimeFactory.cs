using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace DataLoader.DBCore.DBModel.Context
{
    /// <summary>
    /// Фабрика контекстов, для запуска во время разработки
    /// </summary>
    internal class EfContextDesignTimeFactory : IDesignTimeDbContextFactory<EfContext>
    {
        private IDBSettings _dbSettings;

        public EfContextDesignTimeFactory()
        {
            _dbSettings = new DesignTimeSettings();
        }

        public EfContextDesignTimeFactory(IDBSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public EfContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(_dbSettings.ConnectionString);
            return new EfContext(builder.Options);
        }
    }

    internal class DesignTimeSettings : IDBSettings
    {
        public SourceType SourceType => SourceType.SQLServer;

        public string ConnectionString => "Server=localhost;Database=PHDLoader;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true";
    }
}
