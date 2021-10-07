using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataLoader.Service.Contract
{
    /// <summary>
    /// Тип частоты повторения поиска
    /// </summary>
    public enum RepeatIntervalType
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

    public static class RepeatIntervalTypeExtention
    {
        public static string ToString(RepeatIntervalType item)
        {
            return Enum.GetName(typeof(RepeatIntervalType), item);
        }
        public static RepeatIntervalType? GetEnum(string name)
        {
            if (Enum.TryParse(name, out RepeatIntervalType outVal))
                return outVal;

            return null;
        }

        public static IEnumerable<RepeatIntervalType> RepeatIntervalTypeList
        {
            get
            {
                yield return RepeatIntervalType.seconds;
                yield return RepeatIntervalType.minutes;
                yield return RepeatIntervalType.hours;
                yield return RepeatIntervalType.days;
            }
        }
    }
}
