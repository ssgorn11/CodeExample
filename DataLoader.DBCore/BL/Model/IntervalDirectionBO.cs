namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Простой справочник направлений поиска
    /// Использутся для поиска данных в источнике, на определенном интервале от даты
    /// Имеет значения ранее даты, позднее даты или в диапазоне.
    /// </summary>
    public class IntervalDirectionBO : BaseBO
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}
