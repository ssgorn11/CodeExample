using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataLoader.ScheduleCore
{
    public interface IScheduleManager
    {
        Task RunAsync(DateTime timeStart, CancellationToken stoppingToken);
    }
}
