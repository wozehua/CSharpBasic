using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Accumulate
    {
        /// <summary>
        /// 求和
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T2 Sum<T1, T2>(IEnumerable<T1> source, Func<T1, T2, T2> action)
        {
            T2 sum = default;
            foreach (var item in source)
            {
                sum = action(item, sum);
            }

            return sum;
        }
    }
}
