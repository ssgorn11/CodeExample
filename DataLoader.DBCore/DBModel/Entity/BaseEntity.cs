namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Базовый класс для сущности БД
    /// </summary> 
    internal abstract class BaseEntity
    {
        /// <summary>
        /// Ключ
        /// </summary>
        public int Id { get; set; }
    }
}
