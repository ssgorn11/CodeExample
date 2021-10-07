namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Простой справочник направлений поиска интервала
    /// Левее, правее, диапазон
    /// </summary>
    internal class TypeOfIntervalSearchEntity : BaseEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}
