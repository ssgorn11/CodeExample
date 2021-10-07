using DataLoader.DBCore;
using DataLoader.DBCore.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataLoader.ScheduleCore
{
    public class ScheduleCashe : IScheduleCashe
    {
        private readonly IDBCoreObjectFactory _dBCoreObjectFactory;
        private readonly IScheduleCollection _scheduleCollection;

        private readonly object _lock = new object();

        public ScheduleCashe(IDBCoreObjectFactory dBCoreObjectFactory)
        {
            _dBCoreObjectFactory = dBCoreObjectFactory;
            _scheduleCollection = _dBCoreObjectFactory.Resolve<IScheduleCollection>();
        }

        /// <summary>
        /// Кэш расписаний для запуска
        /// </summary>
        private List<ScheduleBO> _schedulesCashe = new List<ScheduleBO>();

        public IEnumerable<ScheduleBO> GetCache()
        {
            return _schedulesCashe;
        }

        /// <summary>
        /// Обновить кэш списка расписаний
        /// </summary>
        public async Task RefreshScheduleCashAsync(CancellationToken stoppingToken)
        {
            try
            {
                await Task.Run(async () =>
                {
                    var scedules = await _scheduleCollection.GetActiveSchedulesAsync();
                    foreach (var ched in scedules)
                    {
                        var item = _schedulesCashe.FirstOrDefault(x => x.Id == ched.Id);
                        if (item != null)
                        {
                            if (!item.Equals(ched))
                                item.Refresh(ched);
                        }
                        else
                            lock (_lock)
                            {
                                _schedulesCashe.Add(ched);
                            }
                    }
                    lock (_lock)
                    {
                        _schedulesCashe.RemoveAll(x => !scedules.Any(z => z.Id == x.Id));
                    }


                }, stoppingToken);
                //if (refreshTask.Exception != null)
                //    throw refreshTask.Exception;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
