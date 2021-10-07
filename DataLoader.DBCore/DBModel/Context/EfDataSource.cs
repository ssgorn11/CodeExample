using Microsoft.EntityFrameworkCore;
using System;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Точка доступа к контексту БД
    /// При создании, решается какй контекст будет создан (под какой тип сервера)
    /// </summary>
    internal class EfDataSource : IDataSource
    {
        private DbContext _context;
        private IDBSettings _dbSettings;

        public EfDataSource(IDBSettings dbSettings)
        {
            _dbSettings = dbSettings;
            //Тип сервера
            switch (_dbSettings.SourceType)
            {
                case SourceType.SQLServer:
                    _context = PrepareSqlContext();
                    break;
                /*case SourceType.PostgreSQL:
                    services.AddDbContext<EfContext>(opt => opt.UseNpgsql(connection));
                    break;*/
                default:
                    _context = PrepareSqlContext();
                    break;
            }
        }

        /// <summary>
        /// Подготовить MS SQL контекст
        /// </summary>
        /// <returns>Контекст для работы с БД</returns>
        private DbContext PrepareSqlContext()
        {
            var bi = new DbContextOptionsBuilder();
            bi.UseSqlServer(_dbSettings.ConnectionString);
            return new EfContext(bi.Options);
        }

        /// <summary>
        /// Возвращает контекст базы данных. 
        /// </summary>
        /// <returns>Контекст базы данных</returns>
        public DbContext GetContext()
        {
            return _context;
        }
    }
}
