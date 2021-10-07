using DataLoader.Service.Contract;
using System;

namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Расписание
    /// </summary>
    public class ScheduleBO : BaseBO
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
        public RepeatIntervalType RepeatIntervalType { get; set; }

        /// <summary>
        /// Граница поиска данных
        /// От переданного времени, например искать в диапазоне 1.
        /// </summary>
        public int BorderSeachInterval { get; set; }

        /// <summary>
        /// Тип границы поиска данных
        /// От переданного времени, например искать в диапазоне 1 минуты (секунды и т.д.).
        /// </summary>
        public BorderSeachIntervalType BorderSeachIntervalType { get; set; }

        /// <summary>
        /// Направление поиска интервала данных
        /// т.е. искать ранее(левее), или позднее(правее) или в диапазоне
        /// </summary>
        public BorderSeachIntervalDirection BorderSeachIntervalDirection { get; set; } = BorderSeachIntervalDirection.left;

        /// <summary>
        /// Признак активности расписания
        /// </summary>
        public int? IsActive { get; set; }

        /// <summary>
        /// Проверка на равенство основных параметров расписания
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Все основные поля совпадают по значению</returns>
        public override bool Equals(object obj)
        {
            var item = obj as ScheduleBO;
            return item != null
                && item.Id == Id
                && item.Name == Name
                && item.TimeStart == TimeStart
                && item.RepeatInterval == RepeatInterval
                && item.RepeatIntervalType == RepeatIntervalType
                && item.BorderSeachInterval == BorderSeachInterval
                && item.BorderSeachIntervalType == BorderSeachIntervalType
                && item.BorderSeachIntervalDirection == BorderSeachIntervalDirection;
        }

        /// <summary>
        /// Обновить текущее расписание, данными переданного расписания
        /// </summary>
        /// <param name="item">Даннве для обновленгия</param>
        public void Refresh(ScheduleBO item)
        {
            if (item != null)
            {
                Id = item.Id;
                Name = item.Name;
                TimeStart = item.TimeStart;
                RepeatInterval = item.RepeatInterval;
                RepeatIntervalType = item.RepeatIntervalType;
                BorderSeachInterval = item.BorderSeachInterval;
                BorderSeachIntervalType = item.BorderSeachIntervalType;
                BorderSeachIntervalDirection = item.BorderSeachIntervalDirection;
            }
        }

        /// <summary>
        /// Определяет границы поиска от заданной даты
        /// </summary>
        /// <param name="now">Дата для поиска</param>
        /// <returns>Дата начала и окончания интервала поиска</returns>
        public Tuple<DateTime, DateTime> GetSearchInterval(DateTime now)
        {
            DateTime timMin = now;
            DateTime timMax = now;

            switch(BorderSeachIntervalType)
            {
                case BorderSeachIntervalType.seconds:
                    if (BorderSeachIntervalDirection == BorderSeachIntervalDirection.left || BorderSeachIntervalDirection == BorderSeachIntervalDirection.all)
                        timMin = now.AddSeconds(-BorderSeachInterval);
                    if (BorderSeachIntervalDirection == BorderSeachIntervalDirection.right || BorderSeachIntervalDirection == BorderSeachIntervalDirection.all)
                        timMax = now.AddSeconds(BorderSeachInterval);
                    break;
                case BorderSeachIntervalType.minutes:
                    if (BorderSeachIntervalDirection == BorderSeachIntervalDirection.left || BorderSeachIntervalDirection == BorderSeachIntervalDirection.all)
                        timMin = now.AddMinutes(-BorderSeachInterval);
                    if (BorderSeachIntervalDirection == BorderSeachIntervalDirection.right || BorderSeachIntervalDirection == BorderSeachIntervalDirection.all)
                        timMax = now.AddMinutes(BorderSeachInterval);
                    break;
                case BorderSeachIntervalType.hours:
                    if (BorderSeachIntervalDirection == BorderSeachIntervalDirection.left || BorderSeachIntervalDirection == BorderSeachIntervalDirection.all)
                        timMin = now.AddHours(-BorderSeachInterval);
                    if (BorderSeachIntervalDirection == BorderSeachIntervalDirection.right || BorderSeachIntervalDirection == BorderSeachIntervalDirection.all)
                        timMax = now.AddHours(BorderSeachInterval);
                    break;
                case BorderSeachIntervalType.days:
                    if (BorderSeachIntervalDirection == BorderSeachIntervalDirection.left || BorderSeachIntervalDirection == BorderSeachIntervalDirection.all)
                        timMin = now.AddDays(-BorderSeachInterval);
                    if (BorderSeachIntervalDirection == BorderSeachIntervalDirection.right || BorderSeachIntervalDirection == BorderSeachIntervalDirection.all)
                        timMax = now.AddDays(BorderSeachInterval);
                    break;
                default:
                    break;
            }

            return new Tuple<DateTime, DateTime>(timMin, timMax);
        }
    }
}
