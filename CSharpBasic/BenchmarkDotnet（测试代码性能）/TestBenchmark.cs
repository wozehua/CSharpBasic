using BenchmarkDotNet.Attributes;

namespace BenchmarkDotnet_测试代码性能_
{
    [ClrJob, CoreJob]
    public class TestBenchmark
    {
        [Benchmark]
        public void TestMethod1()
        {
            HashHelper.GetMD5("https://www.baidu.com/img/bd_logo1.png");
        }

        [Benchmark]
        public void TestMethod2()
        {
            HashHelper.GetSHA1("https://www.baidu.com/img/bd_logo1.png");
        }
    }
}
