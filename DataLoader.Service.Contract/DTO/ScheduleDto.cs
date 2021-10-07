using System;
using System.Collections;
using System.Collections.Generic;

namespace DataLoader.Service.Contract
{
    /// <summary>
    /// Расписание
    /// </summary>
    public class ScheduleDto
    {
        public ScheduleDto() { }

        public int Id { get; set; }

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
        public int RepeatInterval { get; set; } = 1;

        /// <summary>
        /// Тип интервала повторения (минуты, часы, дни)
        /// </summary>
        public RepeatIntervalType RepeatIntervalType { get; set; } = RepeatIntervalType.hours;

        /// <summary>
        /// Граница поиска данных
        /// От переданного времени, например искать в диапазоне 1.
        /// </summary>
        public int BorderSeachInterval { get; set; } = 5;

        /// <summary>
        /// Тип границы поиска данных
        /// От переданного времени, например искать в диапазоне 1 минуты (секунды и т.д.).
        /// </summary>
        public BorderSeachIntervalType BorderSeachIntervalType { get; set; } = BorderSeachIntervalType.seconds;

        /// <summary>
        /// Направление поиска интервала данных
        /// т.е. искать ранее(левее), или позднее(правее) или в диапазоне
        /// </summary>
        public BorderSeachIntervalDirection BorderSeachIntervalDirection { get; set; } = BorderSeachIntervalDirection.all;

        /// <summary>
        /// Признак активности расписания
        /// </summary>
        public int? IsActive { get; set; }
    }
}
