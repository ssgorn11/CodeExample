using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Базовый функционал работы с БД
    /// </summary>
    internal class BaseDao
    {
        private IDataSource _dataSource;

        /// <summary>
        /// Контекст БД передается из DI-контейнера через реализацию IDataSource
        /// </summary>
        /// <param name="dataSource">поставщик контекста БД</param>
        public BaseDao(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        /// <summary>
        /// Возвращает контекст базы данных. 
        /// </summary>
        /// <returns>Контекст базы данных</returns>
        private DbContext GetContext()
        {
            return _dataSource.GetContext();
        }

        /// <summary>
        /// Чтение данных из контекста.
        /// </summary>
        /// <typeparam name="T">тип возвращаемого значения</typeparam>
        /// <param name="action">операция над контекстом</param>
        /// <returns>результат операции</returns>
        public T ReadContext<T>(Func<DbContext, T> action)
        {
            var db = GetContext();
            try
            {
                var result = action(db);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Обновление контекста без возвращаемого значения.
        /// </summary>
        /// <param name="action">операция над контекстом</param>
        /// <returns>результат операции</returns>
        public void UpdateContext(Action<DbContext> action)
        {
            var db = GetContext();
            try
            {
                action(db);
                db.SaveChanges();
            }
            catch (Exception e) when (e.InnerException is SqlException)
            {
                switch (((SqlException)e.InnerException).Number)
                {
                    //case 2601:
                        //throw new BLException(ServerErrorCode.ElementAlreadyExsist, null);
                    default:
                        throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Асинхронное обновление контекста
        /// </summary>
        /// <param name="action">операция над контекстом</param>
        /// <returns>результат операции</returns>
        public async Task UpdateContextAsync(Func<DbContext, Task> action)
        {
            var db = GetContext();
            try
            {
                await action(db);
                await db.SaveChangesAsync();
            }
            catch (Exception e) when (e.InnerException is SqlException)
            {
                switch (((SqlException)e.InnerException).Number)
                {
                    //case 2601:
                    //throw new BLException(ServerErrorCode.ElementAlreadyExsist, null);
                    default:
                        throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
