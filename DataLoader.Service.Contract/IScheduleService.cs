using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.Service.Contract
{
    public interface IScheduleService
    {
        /// <summary>
        /// Получить список всех расписаний
        /// </summary>
        /// <returns>Список всех расписаний</returns>
        Task<IEnumerable<ScheduleDto>> GetAsync();

        Task AddAsync(ScheduleDto scheduleDto);
        Task UpdateAsync(ScheduleDto scheduleDto);
        /// <summary>
        /// Удалить расписание
        /// </summary>
        /// <param name="idSchedule"></param>
        /// <returns></returns>
        Task DeleteAsync(int idSchedule);
        Task<IEnumerable<ScheduleDto>> GetSchedulesByTagAsync(int idTag);
    }
}
