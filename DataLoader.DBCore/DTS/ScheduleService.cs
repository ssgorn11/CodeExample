using DataLoader.DBCore.BL;
using DataLoader.Service.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DTS
{
    internal class ScheduleService : IScheduleService
    {
        private readonly IScheduleCollection _scheduleCollection;

        public ScheduleService(IScheduleCollection scheduleCollection)
        {
            _scheduleCollection = scheduleCollection;
        }

        /// <summary>
        /// Получить список всех расписаний
        /// </summary>
        /// <returns>Список всех расписаний</returns>
        public async Task<IEnumerable<ScheduleDto>> GetAsync()
        {
            return await _scheduleCollection.GetAllSchedulesAsync();
        }

        public async Task AddAsync(ScheduleDto scheduleDto)
        {
            await _scheduleCollection.AddAsync(scheduleDto);
        }
        public async Task UpdateAsync(ScheduleDto scheduleDto)
        {
            await _scheduleCollection.UpdateAsync(scheduleDto);
        }
        public async Task DeleteAsync(int idSchedule)
        {
            await _scheduleCollection.DeleteAsync(idSchedule);
        }

        public async Task<IEnumerable<ScheduleDto>> GetSchedulesByTagAsync(int idTag)
        {
            return await _scheduleCollection.GetSchedulesByTagAsync(idTag);
        }
    }
}
