using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataLoader.Service.Contract
{
    /// <summary>
    /// Тип интервала поиска границ времени
    /// </summary>
    public enum BorderSeachIntervalType
    {
        /// <summary>
        /// Секунды
        /// </summary>
        [Description("Секунды")]
        seconds = 0,
        /// <summary>
        /// Минуты
        /// </summary>
        [Description("Минуты")]
        minutes = 1,
        /// <summary>
        /// Часы
        /// </summary>
        [Description("Часы")]
        hours = 2,
        /// <summary>
        /// Дни
        /// </summary>
        [Description("Дни")]
        days = 3
    }
    public static class BorderSeachIntervalTypeExtention
    {
        public static string ToString(BorderSeachIntervalType item)
        {
            return Enum.GetName(typeof(BorderSeachIntervalType), item);
        }
        public static BorderSeachIntervalType? GetEnum(string name)
        {
            if (Enum.TryParse(name, out BorderSeachIntervalType outVal))
                return outVal;

            return null;
        }
        public static IEnumerable<BorderSeachIntervalType> BorderSeachIntervalTypeList
        {
            get
            {
                yield return BorderSeachIntervalType.seconds;
                yield return BorderSeachIntervalType.minutes;
                yield return BorderSeachIntervalType.hours;
                yield return BorderSeachIntervalType.days;
            }
        }
    }
}
