using BenchmarkDotNet.Running;
using System;

namespace BenchmarkDotnet_测试代码性能_
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<TestBenchmark>();
            Console.ReadLine();
        }
    }
}
