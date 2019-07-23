using System;

namespace Array数组
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 继承IComparable<T>实现比较
            Person[] persons =
                {
                new Person
                {
                    FirstName = "Damon", LastName = "Hill"
                },
                new Person
                {
                    FirstName = "Niki", LastName = "Lauda"
                },
                new Person
                {
                    FirstName = "Ayrton", LastName = "Senna"
                },
                new Person
                {
                    FirstName = "Graham", LastName = "Hill"
                },
            };
            //Array.Sort(persons);
            //foreach (var item in persons)
            //{
            //    Console.WriteLine($"{item.FirstName}:{item.LastName}");
            //} 
            #endregion

            #region 继承IComparer 实现自定义比较

            Array.Sort(persons, new PersonComparer(PersonCompareType.LastName));
            foreach (var item in persons)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
            #endregion

            int[] arr1 = {1, 4, 5, 11, 13, 18};
            int[] arr2 = {3, 4, 5, 18, 21, 27, 33};
            var segments = new ArraySegment<int>[2]
            {
                //部分数组
                new ArraySegment<int>(arr1, 0, 3),
                new ArraySegment<int>(arr2, 3, 3)
            };
            var sum = SumofSeqments(segments);
            //1+4+5  18+21+33
            Console.WriteLine(sum);
        }

        static int SumofSeqments(ArraySegment<int>[] segments)
        {
            int sum = 0;
            foreach (var segment in segments)
            {
                for (int i = segment.Offset; i < segment.Offset+segment.Count; i++)
                {
                    sum += segment.Array[i];
                }
            }

            return sum;
        }
    }
}
