using System.Configuration;

namespace DataLoader.Admin.HTTP
{
    /// <summary>
    /// Параметры приложения
    /// </summary>
    internal static class ApplicationSettings
    {
        public static string ApiUrl
        {
            get
            {
                var val = ConfigurationManager.AppSettings["apiUrl"];
                if (string.IsNullOrEmpty(val))
                    val = "http://localhost:5000/api/";

                return val;
            }
            set
            {
                ConfigurationManager.AppSettings["apiUrl"] = value;
            }
        }
    }
}
