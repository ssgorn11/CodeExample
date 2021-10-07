using DataLoader.DBCore.BL;
using System;
using System.Threading.Tasks;

namespace DataLoader.ScheduleCore
{
    /// <summary>
    /// Класс запуска расписаний
    /// </summary>
    public interface IScheduleTaskExecutor
    {
        /// <summary>
        /// Асинхронный запуск выполнения расписания
        /// </summary>
        /// <param name="scedule"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        Task Run(ScheduleBO scedule, DateTime now);
    }
}
