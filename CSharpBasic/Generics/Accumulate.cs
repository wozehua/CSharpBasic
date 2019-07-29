using System;
using System.Collections.Generic;
using System.Linq;
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
            #region 下面的source.Aggregate等于这块代码
            //T2 sum = default;
            //foreach (var item in source)
            //{
            //    sum = action(item, sum);
            //}

            //return sum; 
            #endregion
            //对序列应用累加器函数 T2 seed=default=累加器的初始值 就是上块代码中的T2 sum=defalut;

            return source.Aggregate<T1, T2>(default, (current, item) => action(item, current));
        }
    }
}
