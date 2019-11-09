using System; 
using System.Threading.Tasks;

namespace Foundations
{
    class Program
    {
        static void Main(string[] args)
        {
            //MultipleAsyncMethodsWithCombinators2();
            //HandleOneError();
            //StartTwoTasks();
            //StartTwoTasksParallel();
            ShowAggregateException();
            Console.ReadKey();
        }
        static string  Greeting(string name)
        {
            Task.Delay(300).Wait();
            return $"Hello,{name}";
        }

        static Task<string> GreetingAsync(string name)
        {
            return Task.Run(()=>Greeting(name));
        }

        private static async void CallerWithAsync()
        {
            string result = await GreetingAsync("Stephanie");
            Console.WriteLine(result);
        }

        private static void CallerWithContinuationTask()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            t1.ContinueWith(t =>
            {
                string result = t1.Result;
                Console.WriteLine(result);
            });
        }

        private static async void MultipleAsyncMethodsWithCombinatorsl()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            await Task.WhenAll(t1, t2);
            Console.WriteLine($"Finished both Method  Result 1:{t1.Result}: Result 2:{t2.Result}");
        }

        private static async void MultipleAsyncMethodsWithCombinators2()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            string[] result=await Task.WhenAll(t1, t2);
            Console.WriteLine($"Finished both Method  Result 1:{result[0]}: Result 2:{result[1]}");
        }

        private  Func<string, string> greetingInvoker = Greeting;

        private  IAsyncResult BeginGreeting(string name, AsyncCallback asyncCallback, object state)
        {
            return greetingInvoker.BeginInvoke(name, asyncCallback, state);
        }

        private string EndGreeting(IAsyncResult asyncResult)
        {
            return greetingInvoker.EndInvoke(asyncResult);
        }

        private async void ConvertingAsyncPattern()
        {
            string s = await Task<string>.Factory.FromAsync(BeginGreeting,EndGreeting, "Angela", null);
            Console.WriteLine(s);
        }

        static async Task ThrowAfter(int ms, string message)
        {
            await Task.Delay(ms);
            throw new Exception(message);
        }

        private static void DontHandle()
        {
            try
            {
#pragma warning disable 4014
                ThrowAfter(200, "first");
#pragma warning restore 4014
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static async void HandleOneError()
        {
            try
            {
                await ThrowAfter(200, "first");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static async void StartTwoTasks()
        {
            try
            {
                await ThrowAfter(2000, "first");
                await ThrowAfter(1000, "Second");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Handled：{e.Message}");
            }
        }

        private static async void StartTwoTasksParallel()
        {
            try
            {
                var t1= ThrowAfter(2000, "first");
                var t2= ThrowAfter(1000, "Second");
                await Task.WhenAll(t1, t2);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Handled：{e.Message}");
            }
        }

        private static async void ShowAggregateException()
        {
            Task taskResult = null;
            try
            {
                var t1 = ThrowAfter(2000, "first");
                var t2 = ThrowAfter(1000, "Second");
                await (taskResult= Task.WhenAll(t1, t2));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Handled：{e.Message}");
                if (taskResult?.Exception.InnerExceptions != null)
                    foreach (var exception in taskResult.Exception.InnerExceptions)
                    {
                        Console.WriteLine($"inner exception {exception.Message}");
                    }
            }
        }

    }
}
