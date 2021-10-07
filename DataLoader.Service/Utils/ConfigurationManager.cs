using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataLoader.Service
{
    /// <summary>
    /// Работа с настройками приложения
    /// </summary>
    internal static class ConfigurationManager
    {
        /// <summary>
        /// Настройки приложения
        /// </summary>
        public static IConfiguration AppSettings { get; }

        /// <summary>
        /// Чтение настроек приложения
        /// </summary>
        static ConfigurationManager()
        {
            AppSettings = new ConfigurationBuilder()
                    //.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
    }
}
