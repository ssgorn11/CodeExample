using System;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Расписание
    /// </summary>
    internal class ScheduleEntity : BaseEntity
	{
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Время начала работы расписания
        /// Учитывается только время
        /// </summary>
        public DateTime TimeStart { get; set; }

        /// <summary>
        /// Повторять каждые
        /// </summary>
        public int RepeatInterval { get; set; }

        /// <summary>
        /// Тип интервала повторения (минуты, часы, дни)
        /// </summary>
        public string RepeatIntervalType { get; set; }

        /// <summary>
        /// Граница поиска данных
        /// От переданного времени, например искать в диапазоне 1.
        /// </summary>
        public int BorderSeachInterval { get; set; }

        /// <summary>
        /// Тип границы поиска данных
        /// От переданного времени, например искать в диапазоне 1 минуты (секунды и т.д.).
        /// </summary>
        public string BorderSeachIntervalType { get; set; }

        /// <summary>
        /// Направление поиска интервала данных
        /// т.е. искать ранее(левее), или позднее(правее) или в диапазоне
        /// </summary>
        public string BorderSeachIntervalDirection { get; set; } = "left";

        /// <summary>
        /// Признак активности расписания
        /// </summary>
		public int? IsActive { get; set; }
	}
}
