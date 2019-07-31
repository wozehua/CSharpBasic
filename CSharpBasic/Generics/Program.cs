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

            #region Queue例子
            //var dm = new DocumentManager();
            //ProcessDocuments.Start(dm);
            //for (int i = 0; i < 10; i++)
            //{
            //    var doc = new Document("content", $"Doc{i.ToString()}");
            //    dm.AddDocument(doc);
            //    Console.WriteLine($"Added document {doc.Title}");
            //    Thread.Sleep(new Random().Next(20));
            //} 
            #endregion

            #region Stack

            //var alphabet = new Stack<char>();
            //alphabet.Push('A');
            //alphabet.Push('B');
            //alphabet.Push('C');
            //foreach (var item in alphabet)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Second iteration:");
            //while (alphabet.Count>0)
            //{
            //    Console.WriteLine(alphabet.Pop());
            //}

            #endregion

            #region LinkList

            var pdm = new PriorityDocumentManager();
            pdm.AddDocument(new DocumentLinkedList("one", "Sample", 8));
            pdm.AddDocument(new DocumentLinkedList("two", "Sample", 3));
            pdm.AddDocument(new DocumentLinkedList("three", "Sample", 4));
            pdm.AddDocument(new DocumentLinkedList("four", "Sample", 8));
            pdm.AddDocument(new DocumentLinkedList("five", "Sample", 1));
            pdm.AddDocument(new DocumentLinkedList("six", "Sample", 9));
            pdm.AddDocument(new DocumentLinkedList("seven", "Sample", 1));
            pdm.AddDocument(new DocumentLinkedList("eight", "Sample", 1));

            pdm.DisplayAllNodes();

            #endregion
            Console.ReadKey();
        }
    }
}
