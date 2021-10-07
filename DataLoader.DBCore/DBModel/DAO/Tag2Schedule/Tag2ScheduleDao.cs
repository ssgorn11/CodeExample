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
    internal class Tag2ScheduleDao : EntityDao<Tag2ScheduleEntity>, ITag2ScheduleDao
    {
        public Tag2ScheduleDao(IDataSource dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Получить весь список привязки ТЭГов к расписаниям
        /// </summary>
        /// <returns>Список привязки ТЭГов к расписаниям</returns>
        public IQueryable<Tag2ScheduleEntity> GetTag2Schedules(Expression<Func<Tag2ScheduleEntity, bool>> condition = null)
        {
            return Get(condition);
        }

        public async Task AddRangeAsync(IEnumerable<Tag2ScheduleEntity> tag2s)
        {
            await CreateRangeAsync(tag2s);
        }

        public async Task RemoveRangeAsync(int idSchedule, IEnumerable<int> idTags)
        {
            await this.DeleteAsync(x => x.IdSchedule == idSchedule && idTags.Contains(x.IdTag));
        }

        public async Task DeleteByScheduleAsync(int idSchedule)
        {
            await base.DeleteAsync(x => x.IdSchedule == idSchedule);
        }

        public async Task DeleteByTagAsync(int idTag)
        {
            await base.DeleteAsync(x => x.IdTag == idTag);
        }
    }
}
