using DataLoader.Service.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Интерйефс бизнес объкта работы с расписаниями
    /// </summary>
    public interface IScheduleCollection
    {
        /// <summary>
        /// Получить список всех расписаний
        /// </summary>
        /// <returns>Список всех расписаний</returns>
        Task<IEnumerable<ScheduleDto>> GetAllSchedulesAsync();

        /// <summary>
        /// Асинхронно получить список всех активных расписаний
        /// </summary>
        /// <returns>Список активных расписаний</returns>
        Task<IEnumerable<ScheduleBO>> GetActiveSchedulesAsync();

        Task DeleteAsync(int idSchedule);
        Task AddAsync(ScheduleDto scheduleDto);
        Task UpdateAsync(ScheduleDto scheduleDto);
        Task<IEnumerable<ScheduleDto>> GetSchedulesByTagAsync(int idTag);
    }
}
