using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryBlendSpace
{
    public static class Extensions
    {
        /// <summary>
        /// Returns string representations of 0 for false and 1 for true
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String ToIntegerString(this bool value)
        {
            return Convert.ToInt32(value).ToString();
        }
    }
}
