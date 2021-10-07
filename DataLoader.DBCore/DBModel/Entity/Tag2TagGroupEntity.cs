namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Привязка ТЭГа к группе
    /// </summary>
    internal class Tag2TagGroupEntity : BaseEntity
	{
        /// <summary>
        /// Ключ ТЭГа
        /// </summary>
        public int IdTag { get; set; }

        /// <summary>
        /// Ключ группы
        /// </summary>
        public int IdTagGroup { get; set; }
    }
}
