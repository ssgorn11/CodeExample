namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Простой справочник типа временного интервала
    /// секунда/минута/час/день/неделя/месяц/год
    /// </summary>
    internal class TimeIntervalTypeEntity : BaseEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}
