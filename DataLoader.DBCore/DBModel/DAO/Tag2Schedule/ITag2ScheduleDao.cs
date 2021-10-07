using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Доступ к данным привязки ТЭГов к расписаниям
    /// </summary>
    internal interface ITag2ScheduleDao
    {
        /// <summary>
        /// Получить весь список привязки ТЭГов к расписаниям
        /// </summary>
        /// <returns>Список привязки ТЭГов к расписаниям</returns>
        IQueryable<Tag2ScheduleEntity> GetTag2Schedules(Expression<Func<Tag2ScheduleEntity, bool>> condition = null);

        Task AddRangeAsync(IEnumerable<Tag2ScheduleEntity> tag2s);

        Task RemoveRangeAsync(int idSchedule, IEnumerable<int> idTags);
        Task DeleteByScheduleAsync(int idSchedule);
        Task DeleteByTagAsync(int idTag);
    }
}
