namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Простой справочник направлений поиска
    /// Использутся для поиска данных в источнике, на определенном интервале от даты
    /// Имеет значения ранее даты, позднее даты или в диапазоне.
    /// </summary>
    internal class IntervalDirectionEntity : BaseEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}
