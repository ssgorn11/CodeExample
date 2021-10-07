using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLoader.Service.Contract;
using DataLoader.DBCore.BL;

namespace DataLoader.ScheduleCore
{
    /// <summary>
    /// Отвечает за подбор списка расписаний, которые должны быть запущены в этот момент и запуск их черех Executor
    /// </summary>
    public class ScheduleManager : IScheduleManager
    {
        private readonly IScheduleCashe _scheduleCashe;

        private readonly IScheduleTaskExecutor _scheduleTaskExecutor;

        public ScheduleManager(IScheduleTaskExecutor scheduleTaskExecutor, IScheduleCashe scheduleCashe)
        {
            _scheduleCashe = scheduleCashe;
            _scheduleTaskExecutor = scheduleTaskExecutor;
        }

        /// <summary>
        /// Запуск работы расписаний загрузки данных
        /// </summary>
        /// <param name="stoppingToken">Токен отмены</param>
        /// <returns></returns>
        public async Task RunAsync(DateTime timeStart, CancellationToken stoppingToken)
        {
            try
            {
                var scedules2Run = GetScedules2Run(_scheduleCashe.GetCache());
                if (scedules2Run?.Count() > 0)
                {
                    foreach (var scedule in scedules2Run)
                    {
                        await Task.Run(async () =>
                        {
                            await _scheduleTaskExecutor.Run(scedule, DateTime.Now);
                        }, stoppingToken);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Получить список расписаний, которые должны быть запушены в текущий момент
        /// </summary>
        /// <returns>Список расписаний для запуска</returns>
        private IEnumerable<ScheduleBO> GetScedules2Run(IEnumerable<ScheduleBO> schedulesCash)
        {
            var res = new List<ScheduleBO>();
            var now = DateTime.Now;

            foreach (var item in schedulesCash)
            {
                if (item.RepeatInterval != 0)
                {
                    //Если надо повторять каждые N минут,
                    //то смотрим, что бы секунды были как у времени начала
                    //и проверяем кратность минут
                    if (item.RepeatIntervalType == RepeatIntervalType.minutes
                        && now.Second == item.TimeStart.Second
                        && ((item.TimeStart - now).Minutes % item.RepeatInterval) == 0)
                        res.Add(item);

                    //Если надо повторять каждые N часов,
                    //то смотрим, что бы секунды и минуты были как у времени начала
                    //и проверяем кратность часов
                    if (item.RepeatIntervalType == RepeatIntervalType.hours
                        && now.Second == item.TimeStart.Second
                        && now.Minute == item.TimeStart.Minute
                        && ((item.TimeStart - now).Hours % item.RepeatInterval) == 0)
                        res.Add(item);

                    //Если надо повторять каждые N дней,
                    //то смотрим, что бы секунды, минуты и часы были как у времени начала
                    //и проверяем кратность дней
                    if (item.RepeatIntervalType == RepeatIntervalType.days
                        && now.Second == item.TimeStart.Second
                        && now.Minute == item.TimeStart.Minute
                        && now.Hour == item.TimeStart.Hour
                        && ((item.TimeStart - now).Days % item.RepeatInterval) == 0)
                        res.Add(item);

                    //Если надо повторять каждые N секунд,
                    //и проверяем кратность секунд
                    if (item.RepeatIntervalType == RepeatIntervalType.seconds
                        && ((item.TimeStart - now).Seconds % item.RepeatInterval) == 0)
                        res.Add(item);
                }
            }
            return res;
        }
    }
}
