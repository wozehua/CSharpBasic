using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent
{
    public class PipelineStages
    {
        public static Task ReadFileNamesAsync(string path, BlockingCollection<string> output)
        {
            //创建一个任务并马上执行
            //通过调用ContinueWhenAny方法, 创建一个任务, 该任务在数组中的任一任务完成后启动。
            //通过调用ContinueWhenAll方法，创建一个任务，该任务在数组中的所有任务完成后启动。
            return Task.Factory.StartNew(() =>
            {
                foreach (var filename in Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories))
                {
                    output.Add(filename);
                    ConsoleHelper.ColoredConsole.WirteLine($"stage 1:added{filename}");
                }

                //将 BlockingCollection<T> 实例标记为不任何更多的添加。
                //如果在写入器添加项的同时，读取器从BlockingCollection<T>中读取，那么调用CompleteAdding方法很重要，否则读取器会在foreach循环中等待更多的项被添加。
                output.CompleteAdding();
                
                //指定任务将是长时间运行的、粗粒度的操作，涉及比细化的系统更少、更大的组件。 它会向 TaskScheduler 提示，过度订阅可能是合理的。 可以通过过度订阅创建比可用硬件线程数更多的线程。 它还将提示任务计划程序：该任务需要附加线程，以使任务不阻塞本地线程池队列中其他线程或工作项的向前推动。
            }, TaskCreationOptions.LongRunning);
        }

        public static async Task LoadContentAsync(BlockingCollection<string> input, BlockingCollection<string> output)
        {
            //如果在填充集合的同时，使用读取器读取集合，则需要使用GetConsumingEnumerable方法获取阻塞集合的枚举器，而不是直接迭代集合。
            foreach (var item in input.GetConsumingEnumerable())
            {
                using (FileStream stream = File.OpenRead(item))
                {
                    var reader = new StreamReader(stream);

                    string line = null;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        output.Add(line);
                        ConsoleHelper.ColoredConsole.WirteLine($"stage 2: added{line}");
                    }
                }
            }
            output.CompleteAdding();
        }

        public static Task ProcessContentAsync(BlockingCollection<string> input,
            ConcurrentDictionary<string, int> output)
        {
            return Task.Factory.StartNew(() => {
                foreach (var line in input.GetConsumingEnumerable())
                {
                    string[] words = line.Split(' ', ';', '\t', '{', '}', '(', ')', ':', ',', '"');
                    foreach (var word in words.Where(w=>!string.IsNullOrEmpty(w)))
                    {
                        output.AddOrUpdate(key: word, addValue: 1, updateValueFactory: (s, i) => ++i);
                        ConsoleHelper.ColoredConsole.WirteLine($"stage 3: added{word}");
                    }
                }
            },TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// 从字典中获取数据，将其转换为Info类型，然后放到输出Blocking Collection<T>中。
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static Task TransferContentAsync(ConcurrentDictionary<string, int> input,
            BlockingCollection<Info> output)
        {
            return Task.Factory.StartNew(() => {
                foreach (var word in input.Keys)
                {
                    if (input.TryGetValue(word, out int value))
                    {
                        var info = new Info
                        {
                            Word = word,
                            Count = value
                        };
                        output.Add(info);
                        ConsoleHelper.ColoredConsole.WirteLine($"stage 4:added{info}");
                    }
                }

                output.CompleteAdding();
            },TaskCreationOptions.LongRunning);
        }

        public static Task AddColorAsync(BlockingCollection<Info> input, BlockingCollection<Info> output)
        {
            return Task.Factory.StartNew(() => {
                foreach (var item in input.GetConsumingEnumerable())
                {
                    if (item.Count > 40)
                    {
                        item.Color = "Red";
                    }
                    else if (item.Count>20)
                    {
                        item.Color = "Yellow";
                    }

                    else
                    {
                        item.Color = "Green";
                    }

                    output.Add(item);
                    ConsoleHelper.ColoredConsole.WirteLine($"stage 5:added color{item.Color} to {item}");
                }

                output.CompleteAdding();
            },TaskCreationOptions.LongRunning);
        }

        public static Task ShowContentAsync(BlockingCollection<Info> input)
        {
            return Task.Factory.StartNew(() => {
                foreach (var item in input.GetConsumingEnumerable())
                {
                    ConsoleHelper.ColoredConsole.WirteLine($"stage 6:{item}", item.Color);
                }
            },TaskCreationOptions.LongRunning);
        }
    }
}
