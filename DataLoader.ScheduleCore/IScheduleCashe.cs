using DataLoader.DBCore.BL;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataLoader.ScheduleCore
{
    public interface IScheduleCashe
    {
        IEnumerable<ScheduleBO> GetCache();

        /// <summary>
        /// Обновить кэш списка расписаний
        /// </summary>
        Task RefreshScheduleCashAsync(CancellationToken stoppingToken);
    }
}
