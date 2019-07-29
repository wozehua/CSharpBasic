using System;
using System.Collections.Generic;
using System.Threading;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 泛型迭代器
            //var list = new LinkedList<string>();
            //list.AddLast("oNEX");
            //list.AddLast("Two");
            //list.AddLast("Three");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region MyRegion
            //var account = new List<Account>
            //{
            //    new Account("2019", 10000),
            //    new Account("2021", 20000),
            //    new Account("2023", 30000),
            //};

            //decimal amount = Accumulate.Sum<Account, decimal>(account, (item, sum) => sum + item.Balance); 
            //Console.WriteLine(amount);
            #endregion

            var dm = new DocumentManager();
            ProcessDocuments.Start(dm);
            for (int i = 0; i < 1000; i++)
            {
                var doc = new Document("content", $"Doc{i.ToString()}");
                dm.AddDocument(doc);
                Console.WriteLine($"Added document {doc.Title}");
                Thread.Sleep(new Random().Next(20));
            }
            Console.ReadKey();
        }
    }
}
