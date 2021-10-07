using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataLoader.Service.Contract
{
    /// <summary>
    /// Какие данные выбирать на найденом диапазоне
    /// </summary>
    public enum TypeOfIntervalSearch
    {
        [Description("Максимальное")]
        max = 0,
        [Description("Минимальное")]
        min = 1,
        [Description("Первое")]
        first = 2,
        [Description("Последнее")]
        last = 3,
        [Description("Все")]
        all = 4
    }
    public static class TypeOfIntervalSearchExtention
    {
        public static string ToString(TypeOfIntervalSearch item)
        {
            return Enum.GetName(typeof(TypeOfIntervalSearch), item);
        }
        public static TypeOfIntervalSearch? GetEnum(string name)
        {
            if (Enum.TryParse(name, out TypeOfIntervalSearch outVal))
                return outVal;

            return null;
        }

        public static IEnumerable<TypeOfIntervalSearch> TypeOfIntervalSearchList
        {
            get
            {
                yield return TypeOfIntervalSearch.max;
                yield return TypeOfIntervalSearch.min;
                yield return TypeOfIntervalSearch.first;
                yield return TypeOfIntervalSearch.last;
                yield return TypeOfIntervalSearch.all;
            }
        }
    }
}
