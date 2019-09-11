using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLinqSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = SampleData();
            #region 并行查询
            //var res = data.AsParallel().Where(x => Math.Log(x) < 4).Select(x => x).Average();
            //var res = data.Where(x => Math.Log(x) < 4).Select(x => x).Average();
            //Console.WriteLine(res); 
            #endregion;

            #region 分区器

            //var result =
            //    (from x in Partitioner.Create(data.ToList(), true).AsParallel() where Math.Log(x) < 4 select x).Average();
            //Console.WriteLine(result);
            #endregion

            #region 取消

            var cts = new CancellationTokenSource();
            Task.Run(() => {
                try
                {
                    var res = (from x in data.AsParallel().WithCancellation(cts.Token) where Math.Log(x) < 4 select x)
                        .Average();
                    Console.WriteLine($"query finished,sum:{res}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }}, cts.Token);
            Console.WriteLine("query start");
            Console.Write("Cancel?");
            string input = Console.ReadLine();
            if (input != null && input.ToLower().Equals("y"))
            {
                cts.Cancel();
            }
            #endregion
            Console.ReadKey();

        }

        static IEnumerable<int> SampleData()
        {
            const int arraySize = 50000000;
            var r = new Random();
            return Enumerable.Range(0, arraySize).Select(x => r.Next(140)).ToList();
        }
    }
}
