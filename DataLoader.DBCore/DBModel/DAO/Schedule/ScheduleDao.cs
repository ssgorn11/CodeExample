using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Доступ к данным объектов расписаний
    /// </summary>
    internal class ScheduleDao : EntityDao<ScheduleEntity>, IScheduleDao
    {
        public ScheduleDao(IDataSource dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Получить весь список расписаний
        /// </summary>
        /// <returns>Список расписаний</returns>
        public IQueryable<ScheduleEntity> GetSchedules(Expression<Func<ScheduleEntity, bool>> condition = null)
        {
            return Get(condition);
        }

        public async Task DeleteAsync(int idSchedule)
        {
            await base.DeleteAsync(idSchedule);
        }

        public async Task AddAsync(ScheduleEntity schedule)
        {
            await base.CreateAsync(schedule);
        }
        public async Task UpdateAsync(ScheduleEntity schedule)
        {
            await base.UpdateAsync(schedule);
        }
    }
}
