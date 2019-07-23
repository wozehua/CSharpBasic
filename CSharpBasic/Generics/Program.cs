using System;
using System.Collections.Generic;

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

            var account = new List<Account>
            {
                new Account("2019", 10000),
                new Account("2021", 20000),
                new Account("2023", 30000),
            };

            decimal amount = Accumulate.Sum<Account, decimal>(account, (item, sum) => sum += item.Balance);
            Console.WriteLine(amount);
            Console.ReadKey();
        }
    }
}
