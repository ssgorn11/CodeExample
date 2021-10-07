namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Привязка ТЭГа к группе
    /// </summary>
    public class Tag2TagGroupBO : BaseBO
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
