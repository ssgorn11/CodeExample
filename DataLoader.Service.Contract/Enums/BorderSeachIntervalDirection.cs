using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataLoader.Service.Contract
{
    /// <summary>
    /// Направления поиска интервала времени
    /// </summary>
    public enum BorderSeachIntervalDirection
    {
        /// <summary>
        /// Ранее и позднее
        /// </summary>
        [Description("Ранее и позднее")]
        all = 0,
        /// <summary>
        /// Ранее
        /// </summary>
        [Description("Ранее")]
        left = 1,
        /// <summary>
        /// Позднее
        /// </summary>
        [Description("Позднее")]
        right = 2
    }
    public static class BorderSeachIntervalDirectionExtention
    {
        public static string ToString(BorderSeachIntervalDirection item)
        {
            return Enum.GetName(typeof(BorderSeachIntervalDirection), item);
        }
        public static BorderSeachIntervalDirection? GetEnum(string name)
        {
            if (Enum.TryParse(name, out BorderSeachIntervalDirection outVal))
                return outVal;

            return null;
        }

        public static IEnumerable<BorderSeachIntervalDirection> BorderSeachIntervalDirectionList
        {
            get
            {
                yield return BorderSeachIntervalDirection.all;
                yield return BorderSeachIntervalDirection.left;
                yield return BorderSeachIntervalDirection.right;
            }
        }
    }
}
