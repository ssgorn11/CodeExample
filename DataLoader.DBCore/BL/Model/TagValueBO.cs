using System;

namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Данные ТЭГа полученные из источника
    /// </summary>
    public class TagValueBO : BaseBO
    {
        /// <summary>
        /// Ключ ТЭГа
        /// </summary>
        public int IdTag { get; set; }

        /// <summary>
        /// Ключ внешнего ключа
        /// Рудимент
        /// </summary>
        public int IdDirectoryParameter { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Дата из источника
        /// </summary>
        public DateTime DatePHD { get; set; }

        /// <summary>
        /// Дата получения данных
        /// </summary>
        public DateTime DateSave { get; set; }

        /// <summary>
        /// Достоверность (от 0 до 100)
        /// </summary>
        public int? Confidence { get; set; }
    }
}
