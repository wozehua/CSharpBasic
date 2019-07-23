using System;
using System.Collections.Generic;
using System.Text;

namespace DeletegateExample
{
    /// <summary>
    /// 冒泡排序 适合于以小组数字小于10个
    /// </summary>
    class BubbleSort
    {
        static  void BubbleMethor(int[] array)
        {
            bool swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        /// <summary>
        /// Func<T, T, bool> 传递进来的方法要是有两个参数和返回类型时bool
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sortArray"></param>
        /// <param name="comparison"></param>
        public static void Sort<T>(IList<T> sortArray, Func<T, T, bool> comparison)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < sortArray.Count - 1; i++)
                {
                    if (comparison(sortArray[i + 1], sortArray[i]))
                    {
                        var temp = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}
