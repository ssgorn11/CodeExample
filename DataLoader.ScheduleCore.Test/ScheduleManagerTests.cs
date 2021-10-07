using DataLoader.DBCore;
using DataLoader.DBCore.BL;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataLoader.ScheduleCore.Test
{
    public class ScheduleManagerTests
    {
        IList<ScheduleBO> _schedules;
        IList<ScheduleBO> _schedulesChange;

        [SetUp]
        public void Setup()
        {
            _schedules = new List<ScheduleBO>()
            {
                new ScheduleBO() { Id = 1, RepeatInterval = 1, RepeatIntervalType = Service.Contract.RepeatIntervalType.seconds },
                new ScheduleBO() { Id = 2, RepeatInterval = 1, RepeatIntervalType = Service.Contract.RepeatIntervalType.seconds },
                new ScheduleBO() { Id = 3, RepeatInterval = 1, RepeatIntervalType = Service.Contract.RepeatIntervalType.seconds }
            };

            _schedulesChange = new List<ScheduleBO>()
            {
                new ScheduleBO() { Id = 2, RepeatInterval = 1, RepeatIntervalType = Service.Contract.RepeatIntervalType.seconds },
                new ScheduleBO() { Id = 3, RepeatInterval = 1, RepeatIntervalType = Service.Contract.RepeatIntervalType.seconds },
                new ScheduleBO() { Id = 4, RepeatInterval = 1, RepeatIntervalType = Service.Contract.RepeatIntervalType.seconds },
                new ScheduleBO() { Id = 5, RepeatInterval = 2, RepeatIntervalType = Service.Contract.RepeatIntervalType.seconds }
            };
        }

        [Test]
        public async Task RefreshCacheParallel()
        {
            var cts = new CancellationTokenSource();

            var mokTaskExec = new Mock<IScheduleTaskExecutor>();
            mokTaskExec.Setup(x => x.Run(It.IsAny<ScheduleBO>(), It.IsAny<DateTime>())).Returns(Task.Delay(500));

            var mokScheduleCol = new Mock<IScheduleCollection>();
            mokScheduleCol.Setup(x => x.GetActiveSchedulesAsync()).ReturnsAsync(_schedules);

            var mokObjectFactory = new Mock<IDBCoreObjectFactory>();
            mokObjectFactory.Setup(x => x.Resolve<IScheduleCollection>()).Returns(mokScheduleCol.Object);

            var cache = new ScheduleCashe(mokObjectFactory.Object);

            var manager = new ScheduleManager(mokTaskExec.Object, cache);

            var timeStart = DateTime.Now;

            await cache.RefreshScheduleCashAsync(cts.Token);
            manager.RunAsync(timeStart, cts.Token);

            mokScheduleCol.Reset();
            mokScheduleCol.Setup(x => x.GetActiveSchedulesAsync()).ReturnsAsync(_schedulesChange);

            cache.RefreshScheduleCashAsync(cts.Token);

            Assert.Pass();
        }
    }
}