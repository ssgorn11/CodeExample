using DataLoader.DBCore;
using DataLoader.PHDReder;
using DataLoader.ScheduleCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataLoader.Service
{
    public class Worker : IHostedService, IAsyncDisposable//: BackgroundService
    {
        private readonly Task _completedTask = Task.CompletedTask;

        private readonly ILogger<Worker> _logger;
        private readonly ApplicationSettings _settings;

        private readonly IDBCoreObjectFactory _dBCoreObjectFactory;
        private readonly IReaderObjectFactory _readerObjectFactory;

        private readonly IScheduleCashe _scheduleCashe;
        private readonly IScheduleManager _scheduleManager;
        

        private Timer _casheTimer;
        private Timer _scheduleTimer;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _settings = new ApplicationSettings();

            _dBCoreObjectFactory = new DBCoreObjectFactory(_settings);
            _readerObjectFactory = new ReaderObjectFactory(_settings, _dBCoreObjectFactory.Resolve<ILogError>());

            _scheduleCashe = new ScheduleCashe(_dBCoreObjectFactory);
            _scheduleManager = new ScheduleManager(new ScheduleTaskExecutor(_dBCoreObjectFactory, _readerObjectFactory), _scheduleCashe);
        }

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    var timeStart = DateTime.Now;

        //    _casheTimer = new Timer(async (s) => await _scheduleCashe.RefreshScheduleCashAsync(stoppingToken), null, 0, _settings.RefreshSceduleInterval);
        //    _scheduleTimer = new Timer(async (s) => await _scheduleManager.RunAsync(timeStart, stoppingToken), null, 0, _settings.RunSceduleInterval);

        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //        try
        //        {
        //            await Task.Delay(1000, stoppingToken);
        //        }
        //        catch (OperationCanceledException)
        //        {
        //            return;
        //        }
        //    }
        //}

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"DataLoader.Service is running.");
            _casheTimer = new Timer(async (s) => await _scheduleCashe.RefreshScheduleCashAsync(stoppingToken), null, 0, _settings.RefreshSceduleInterval);
            _scheduleTimer = new Timer(async (s) => await _scheduleManager.RunAsync(DateTime.Now, stoppingToken), null, 0, _settings.RunSceduleInterval);

            return _completedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                $"DataLoader.Service is stopping.");

            _casheTimer?.Change(Timeout.Infinite, 0);
            _scheduleTimer?.Change(Timeout.Infinite, 0);

            return _completedTask;
        }

        public async ValueTask DisposeAsync()
        {
            if (_casheTimer is IAsyncDisposable timer)
                await timer.DisposeAsync();

            _casheTimer = null;

            if (_scheduleTimer is IAsyncDisposable timer2)
                await timer2.DisposeAsync();

            _scheduleTimer = null;
        }
    }
}
