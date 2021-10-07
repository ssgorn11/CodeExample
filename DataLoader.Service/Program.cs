using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using DataLoader.Service;

//using IHost host = Host.CreateDefaultBuilder(args)
//    .UseWindowsService(options =>
//    {
//        options.ServiceName = ".NetCore DataLoaderService2";
//    })
//    .ConfigureWebHostDefaults((builder) =>
//    {
//        builder.UseStartup<Startup>();
//    })
//    .ConfigureServices(services =>
//    {
//        services.AddHostedService<Worker>();
//    })
//    .Build();

//await host.RunAsync();

namespace DataLoader.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseWindowsService(options =>
                {
                    options.ServiceName = ".NetCore DataLoaderService2";
                })
                .ConfigureWebHostDefaults((builder) =>
                {
                    builder.UseStartup<Startup>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}
