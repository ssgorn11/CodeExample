using Microsoft.EntityFrameworkCore;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Интерфейс - источник данных. Инкапсулирует создание контекста при запросах в БД.
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Возвращает контекст базы данных. 
        /// </summary>
        /// <returns>Контекст базы данных</returns>
        DbContext GetContext();
    }
}
