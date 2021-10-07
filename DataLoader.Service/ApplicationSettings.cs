using DataLoader.DBCore;
using DataLoader.PHDReder;
using System;

namespace DataLoader.Service
{
    /// <summary>
    /// Параметры приложения
    /// </summary>
    internal class ApplicationSettings : IDBSettings, IReaderSettings
    {
        /// <summary>
        /// Проверять на запуск расписания каждые N секунд
        /// </summary>
        public int RunSceduleInterval
        {
            get
            {
                var val = ConfigurationManager.AppSettings["RunSceduleInterval"];
                if (string.IsNullOrEmpty(val))
                {
                    ConfigurationManager.AppSettings["RunSceduleInterval"] = val;
                }
                int res = 0;
                if (int.TryParse(val, out res))
                    return res;
                return 1;
            }
            set
            {
                ConfigurationManager.AppSettings["RunSceduleInterval"] = value.ToString();
            }
        }


        /// <summary>
        /// Проверять на обновление кэша расписаний каждые N минут
        /// </summary>
        public int RefreshSceduleInterval
        {
            get
            {
                var val = ConfigurationManager.AppSettings["RefreshSceduleInterval"];
                if (string.IsNullOrEmpty(val))
                {
                    ConfigurationManager.AppSettings["RefreshSceduleInterval"] = val;
                }
                int res = 0;
                if (int.TryParse(val, out res))
                    return res;
                return 1;
            }
            set
            {
                ConfigurationManager.AppSettings["RefreshSceduleInterval"] = value.ToString();
            }
        }

        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        public string ConnectionString
        {
            get
            {
                var val = ConfigurationManager.AppSettings["ConnectionStrings:MainSql"];
                if (string.IsNullOrEmpty(val))
                {
                    val = "Server=localhost;Database=PHDLoader;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true";
                    ConfigurationManager.AppSettings["ConnectionStrings:MainSql"] = val;
                }
                return val;
            }
            set
            {
                ConfigurationManager.AppSettings["ConnectionStrings:MainSql"] = value;
            }
        }


        /// <summary>
        /// Тип сервера
        /// </summary>
        public SourceType SourceType
        {
            get
            {
                string st = ConfigurationManager.AppSettings["SourceType"];
                SourceType sourceType;
                if (Enum.TryParse(st, out sourceType))
                    return sourceType;

                return SourceType.SQLServer;
            }
            set
            {
                ConfigurationManager.AppSettings["SourceType"] = value.ToString();
            }
        }

        public string ReaderConnectionString
        {
            get
            {
                var val = ConfigurationManager.AppSettings["ReaderConnectionString"];
                if (string.IsNullOrEmpty(val))
                {
                    val = "c-vgdphd022 3100";
                    ConfigurationManager.AppSettings["ReaderConnectionString"] = val;
                }
                return val;
            }
            set
            {
                ConfigurationManager.AppSettings["ReaderConnectionString"] = value;
            }
        }
    }
}
