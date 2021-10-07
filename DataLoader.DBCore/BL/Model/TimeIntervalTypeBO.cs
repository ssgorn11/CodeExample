namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Простой справочник типа временного интервала
    /// секунда/минута/час/день/неделя/месяц/год
    /// </summary>
    public class TimeIntervalTypeBO : BaseBO
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}
