using DataLoader.Service.Contract;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Доступ к данным объектов расписаний
    /// </summary>
    internal interface IScheduleDao
    {
        /// <summary>
        /// Получить весь список расписаний
        /// </summary>
        /// <returns>Список расписаний</returns>
        IQueryable<ScheduleEntity> GetSchedules(Expression<Func<ScheduleEntity, bool>> condition = null);

        Task DeleteAsync(int idSchedule);
        Task AddAsync(ScheduleEntity schedule);
        Task UpdateAsync(ScheduleEntity schedule);
    }
}
