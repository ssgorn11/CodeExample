namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Настройка, определяющая, сколько хранить данные, загруженные по расписанию
    /// </summary>
    public class ScheduleStoreBO : BaseBO
    {
        /// <summary>
        /// Ключ расписания
        /// </summary>
        public int IdSchedule { get; set; }

        /// <summary>
        /// Интервал хранения
        /// </summary>
        public int? StoreInterval { get; set; }

        /// <summary>
        /// Тип интервала (дни, недели, месяцы, года)
        /// </summary>
        public string StoreIntervalType { get; set; }
    }
}
