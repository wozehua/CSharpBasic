using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Generics.DictionarySample;

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

            //var pdm = new PriorityDocumentManager();
            //pdm.AddDocument(new DocumentLinkedList("one", "Sample", 8));
            //pdm.AddDocument(new DocumentLinkedList("two", "Sample", 3));
            //pdm.AddDocument(new DocumentLinkedList("three", "Sample", 4));
            //pdm.AddDocument(new DocumentLinkedList("four", "Sample", 8));
            //pdm.AddDocument(new DocumentLinkedList("five", "Sample", 1));
            //pdm.AddDocument(new DocumentLinkedList("six", "Sample", 9));
            //pdm.AddDocument(new DocumentLinkedList("seven", "Sample", 1));
            //pdm.AddDocument(new DocumentLinkedList("eight", "Sample", 1));

            //pdm.DisplayAllNodes();

            #endregion

            #region SortListSample

            //var books = new SortedList<string, string>();
            //books.Add("Professional WPF Programming", "978-0-470-04180-2");
            //books.Add("Professional ASP.NET 5", "978-1-470-04180-3");
            //books["Beginning Visual c# 2012"] = "978-1-31441-8";
            //books["Professional C# and .Net 4.5.1"] = "978-1-118-83303-2";
            //foreach (KeyValuePair<string,string> keyValue in books)
            //{
            //    Console.WriteLine($"{keyValue.Key},{keyValue.Value}");
            //}
            ////也可以使用Values和Keys属性访问值和键
            //foreach (var title in books.Keys)
            //{
            //    Console.WriteLine(title);
            //}

            //foreach (var isbn in books.Values)
            //{
            //    Console.WriteLine(isbn);
            //}

            //string title = "Professional WPF Programming";
            ////根据key获取列表中存在的value 返回类型是bool 有就是true 没有就是false
            //if (books.TryGetValue(title, out string isbn))
            //{
            //    Console.WriteLine($"{title} {isbn} not found");
            //}
            #endregion

            #region Dictionary 还有一部分代码未实现 请查看文档

            //var idTony = new EmployeeId("C3755");
            //var tony = new Employee("Tony Stewart", 379025.00m,idTony);
            //var idCarl = new EmployeeId("F3564");
            //var carl = new Employee("Carl Stewart", 456487.00m, idCarl);
            //var idKevin = new EmployeeId("K3564");
            //var kevin = new Employee("kevin Stewart", 4656487.00m, idKevin);
            //var idMatt = new EmployeeId("M3564");
            //var matt = new Employee("Matt Stewart", 6487.00m, idMatt);
            //var idBard = new EmployeeId("M3564");
            //var bard = new Employee("Bard Stewart", 6487.00m, idBard);

            //var employees = new Dictionary<EmployeeId, Employee>(31)
            //{
            //    [idTony] = tony,
            //    [idCarl] = carl,
            //    [idKevin] = kevin,
            //    [idMatt] = matt,
            //    [idBard] = bard
            //};
            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item); 
            //}
            #endregion

            #region ToLookup类
            //var races = new List<Racer>
            //{
            //    new Racer(11, "jack", "haha", "Moni"),
            //    new Racer(12, "jack2", "haha2", "Moni2"),
            //    new Racer(16, "jdad", "asd", "Moni2"),
            //    new Racer(13, "jack3", "haha3", "Moni3"),
            //    new Racer(14, "jack4", "haha4", "Moni4"),
            //    new Racer(15, "jack5", "haha5", "Moni5")
            //};
            //var lookupRacers = races.ToLookup(m => m.Country);
            //foreach (var racer in lookupRacers["Moni2"])
            //{
            //    Console.WriteLine(racer);
            //} 
            #endregion

            #region set 集

            //var companyTeams = new HashSet<string>{"Ferrari","McLaren","Mercedes"};
            //var traditionTeams = new HashSet<string>{ "Ferrari", "McLaren"};
            //var privateTeams = new HashSet<string> {"Red Bull", "Toro Rosso","Force India","Sauber"};
            //if (privateTeams.Add("Williams"))
            //{
            //    Console.WriteLine("Williams added");
            //}
            //if (!companyTeams.Add("McLaren"))
            //{
            //    Console.WriteLine("McLaren was already in this set");
            //}

            ////traditionTeams 是companyTeams 的子集
            //if (traditionTeams.IsSubsetOf(companyTeams))
            //{
            //    Console.WriteLine("traditionTeams is subset of companyTeams");
            //}
            //if (companyTeams.IsSupersetOf(traditionTeams))
            //{
            //    Console.WriteLine("companyTeams is subset of traditionTeams");
            //}
            #endregion

            #region 特殊集合

            //var bits1 = new BitArray(8);
            //bits1.SetAll(true);
            //bits1.Set(1, false);
            //bits1[5] = false;
            //bits1[7] = false;
            //Console.Write("Initialized:");
            //BitArraySample.DisplayBits(bits1);
            ////Not 取反
            //Console.Write("Not:");
            //bits1.Not();
            //BitArraySample.DisplayBits(bits1);
            //Or() 有true 则为true bits2.Or(bits1)
            //And() 两个同为true则为true bits2.And(bits1)
            //Xor()异或 相同取0 不同取1
            #endregion

            #region 不变的集合

            //ImmutableArray<string> a1 = ImmutableArray.Create<string>();
            //var a2 = a1.Add("Williams");
            //var a3 = a2.Add("Ferrari").Add("Mercedes").Add("Red Bull Racing");
            var accounts = new List<Account>()
            {
                new Account("Scrooge McDuck",667377678765m),
                new Account("Donald Duck",-200m),
                new Account("Ludwig von Drake",2000m),
            };
            //使用ToImmutableList扩展方案创建一个不变的集合。
            ImmutableList<Account> immutableList = accounts.ToImmutableList();
            foreach (var account in immutableList)
            {
                Console.WriteLine($"{account.Name} {account.Balance}");
            }

            Console.WriteLine("======================");
            accounts.ForEach(a => Console.WriteLine($"{a.Name} {a.Balance}"));

            //使用这个集合输出所有透支账户：
            Console.WriteLine("======================");
            ImmutableList<Account>.Builder builder = immutableList.ToBuilder();
            for (int i = 0; i < builder.Count; i++)
            {
                Account a = builder[i];
                if (a.Balance <= 0)
                {
                    builder.Remove(a);
                }
            }

            var overdrawnAccounts = builder.ToImmutable();
            overdrawnAccounts.ForEach(a => Console.WriteLine($"{a.Name} {a.Balance}"));
            immutableList.ForEach(a => Console.WriteLine($"{a.Name} {a.Balance}"));
            #endregion
            Console.ReadKey();
        }
    }
}
