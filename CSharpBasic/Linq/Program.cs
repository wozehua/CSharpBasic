using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinqQuery();
            //Console.WriteLine("Hello World!");

            #region 延迟加载和ToList()
            //var names = new List<string> {"Nino", "Alberto", "Juan", "Mike", "Phil"};
            //var namesWithJ = (from n in names where n.StartsWith("J") orderby n select n);
            //Console.WriteLine("First iteration");
            //foreach (string name in namesWithJ)
            //{
            //    Console.WriteLine(name);
            //}

            //Console.WriteLine();
            //names.Add("John");
            //names.Add("Jim");
            //names.Add("Jack");
            //names.Add("Denny");
            //Console.WriteLine("Second iteration");
            //foreach (var item in namesWithJ)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region Linq查询操作符

            #region Where 筛选
            //var racers = from r in Formulal.GetChampions() where r.Wins > 15 &&(r.Country == "USA" || r.Country == "UK") select r;
            //var racers2 = Formulal.GetChampions().Where(r => r.Wins > 15 && (r.Country == "USA" || r.Country == "UK")).Select(r=>r);
            //foreach (var r in racers2)
            //{
            //    Console.WriteLine($"{r:A}");
            //}
            #endregion

            #region 索引筛选
            //查询姓氏以A开头的所有赛车手,并且索引是奇数的赛车手
            //var racers3 = Formulal.GetChampions().Where((r, index) => r.LastName.StartsWith("A") && index % 2 != 0);
            //foreach (var racer in racers3)
            //{
            //    Console.WriteLine($"{racer:A}");
            //}


            #endregion

            #region 类型筛选

            //object[] data = {"one", 1, 3, "four", "five", 6};
            //var query = data.OfType<string>();
            //Console.WriteLine("输出string类型");
            //foreach (var s in query)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine("输出int类型");
            //var query2 = data.OfType<int>();
            //foreach (var q in query2)
            //{
            //    Console.WriteLine(q);
            //}


            #endregion

            #region 复合的from子句
            //如果需要根据对象的一个成员进行筛选，而该成员本身是一个系列，就可以使用复合的from子句
            //var ferrariDrivers = from r in Formulal.GetChampions()
            //    from c in r.Cars
            //    where c == "Ferrari"
            //    orderby r.LastName
            //    select r.FirstName + " " + r.LastName;
            //foreach (var item in ferrariDrivers)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("=====SelectMany查询方法======");
            //var ferrariDrivers1 = Formulal.GetChampions().SelectMany(r => r.Cars, (r, c) => new {Racer = r, Car = c}).Where(r=>r.Car=="Ferrari").OrderBy(r=>r.Racer.LastName).Select(r=>r.Racer.FirstName+" "+r.Racer.LastName+" " +r.Car);
            //foreach (var item in ferrariDrivers1)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region 排序
            //var racers = from r in Formulal.GetChampions()
            //    where r.Country == "Italy"
            //    orderby r.Wins descending
            //    select r;
            //foreach (var racer in racers)
            //{
            //    Console.WriteLine(racer);
            //}

            //Console.WriteLine();
            //var racers1 = Formulal.GetChampions().Where(r => r.Country == "Italy").OrderByDescending(r => r.Wins);
            //foreach (var racer in racers1)
            //{
            //    Console.WriteLine(racer);
            //}


            //var racers2 =
            //    (from r in Formulal.GetChampions() orderby r.Country, r.LastName, r.FirstName select r).Take(10);
            //foreach (var racer in racers2)
            //{
            //    Console.WriteLine(racer);
            //}

            //Console.WriteLine();

            //var racer3 = Formulal.GetChampions().OrderBy(r => r.Country).ThenBy(r => r.LastName)
            //    .ThenBy(r => r.FirstName).Take(10);
            //foreach (var racer in racer3)
            //{
            //    Console.WriteLine(racer);
            //}
            #endregion

            #region 分组-group子句
            //要根据一个关键字值对查询结果分组，可以使用group子句
            //一级方程式冠军按照国家分组，并列出一个国家的冠军数。
            //根据获得的冠军数降序排列 如果冠军数一样就按照关键字Key来排序 这里的Key=Country
            //var countries = from r in Formulal.GetChampions()
            //                group r by r.Country into g
            //                orderby g.Count() descending, g.Key
            //                where g.Count() >= 2
            //                select new
            //                {
            //                    Country = g.Key,
            //                    Count = g.Count()

            //                };

            //foreach (var item in countries)
            //{
            //    Console.WriteLine(value: $"{item.Country,-10} {item.Count}");
            //}

            //Console.WriteLine("==============");
            //var countries1 = Formulal.GetChampions().GroupBy(r => r.Country).OrderByDescending(g => g.Count()).ThenBy(g => g.Key).Where(g => g.Count() >= 2).Select(g => new { Country = g.Key, Count = g.Count() });
            //foreach (var c in countries1)
            //{
            //    Console.WriteLine($"{c.Country,-10}{c.Count}");
            //}
            #endregion

            #region Linq中的变量
            //在分组编写的Linq查询中，Count方法调用了多次，使用let子句可以改变这种方式，let允许在linq查询中定义变量
            //var countries4 = from r in Formulal.GetChampions()
            //                 group r by r.Country into g
            //                 let count = g.Count()
            //                 orderby count descending, g.Key
            //                 where count >= 2
            //                 select new
            //                 {
            //                     Country = g.Key,
            //                     Count = count
            //                 };
            //foreach (var item in countries4)
            //{
            //    Console.WriteLine($"{item.Country,-10}{item.Count}");
            //}

            //Console.WriteLine("=============");
            ////下面这个第一个Select 是用来创建匿名类型，这里创建了一个Group和Count属性的匿名类型
            ////带有这些属性的一组传递给OrderByDescending方法，基于匿名属性的Count进行排列
            ////不过这个要有一个注意点 应考虑根据let或select方法创建的临时对象的数量，查询大列表时，创建的大量对象需要以后进行垃圾收集，这可能对性能产生巨大的影响。
            //var countries5 = Formulal.GetChampions().GroupBy(r => r.Country)
            //    .Select(g => new { Group = g, Count = g.Count() }).OrderByDescending(c => c.Count)
            //    .ThenBy(g => g.Group.Key).Where(g => g.Count >= 2)
            //    .Select(g => new { Country = g.Group.Key, Count = g.Count });

            //foreach (var item in countries5)
            //{
            //    Console.WriteLine($"{item.Country,-10}{item.Count}");
            //}

            #endregion

            #region 对嵌套的对象分组
            //如果分组的对象包含嵌套的序列，就可以改变select子句创建的匿名类型
            //var countries = from r in Formulal.GetChampions()
            //                group r by r.Country into g
            //                let count = g.Count()
            //                orderby count descending, g.Key
            //                where count >= 2
            //                select new
            //                {
            //                    Country = g.Key,
            //                    Count = count,
            //                    Racers = from r1 in g orderby r1.LastName select r1.FirstName + " " + r1.LastName
            //                };
            //foreach (var item in countries)
            //{
            //    Console.WriteLine($"{item.Country,-10} {item.Count}");
            //    Console.WriteLine("====车手姓名====");
            //    foreach (var name in item.Racers)
            //    {
            //        Console.WriteLine($"{name}");
            //    }
            //}


            #endregion

            #region 内连接
            ////使用 join子句可以根据特定的条件合并两个数据源。
            //var racers = from r in Formulal.GetChampions()
            //    from y in r.Years
            //    select new
            //    {
            //        Year = y,
            //        Name = r.FirstName + " " + r.LastName
            //    };

            //var teams = from r in Formulal.GetContructorChampions()
            //    from y in r.Years
            //    select new
            //    {
            //        Year = y,
            //        Name = r.Name
            //    };
            ////通过join子句，根据赛车手获得的冠军的年份和车队活的冠军的年份进行连接。
            //var racersAndTeams =
            //    (from r in racers
            //        join t in teams on r.Year equals t.Year
            //        select new {r.Year, champion = r.Name, Constructor = t.Name}).Take(10);
            //Console.WriteLine("Year World Champion \t Constructor Title");
            //foreach (var item  in racersAndTeams)
            //{
            //    Console.WriteLine($"{item.Year}:{item.champion,-20} {item.Constructor}");
            //}


            //Console.WriteLine("==============");
            ////也可以合并为一个linq查询
            //var racersAndTeams1 = (from r in from r1 in                     Formulal.GetChampions()
            //    from y1 in r1.Years
            //    select new
            //    {
            //        Year=y1,
            //        Name=r1.FirstName +" "+r1.LastName
            //    } join t in from t1 in Formulal.GetContructorChampions() from y1 in t1.Years select new
            //{
            //    Year=y1,
            //    Name=t1.Name
            //} on r.Year equals t.Year orderby t.Year select new
            //{
            //    Year=r.Year,
            //    Racer=r.Name,
            //    Team=t.Name
            //}).Take(10);

            #endregion

            #region 左外连接
            //左外连接返回左边序列中的全部元素，即使它们在右边的序列中并没有匹配的元素
            //和sql 的左连接一样
            var racers = from r in Formulal.GetChampions()
                         from y in r.Years
                         select new
                         {
                             Year = y,
                             Name = r.FirstName + " " + r.LastName
                         };

            var teams = from r in Formulal.GetContructorChampions()
                        from y in r.Years
                        select new
                        {
                            Year = y,
                            Name = r.Name
                        };
            //使用左外连接 用join 子句和DefalutIfEmpty方法定义 如果查询的左侧没有匹配的车队冠军，那么就使用DefaultIfEmpty方法定义其右侧的默认值

            //var racersAndTeams = (from r in racers
            //    join t in teams on r.Year equals t.Year into rt
            //    from t in rt.DefaultIfEmpty()
            //    orderby r.Year
            //    select new
            //    {
            //        Year=r.Year,
            //        Champion=r.Name,
            //        Constructor =t==null?"no constructor championship":t.Name
            //    }).Take(10);

            //foreach (var item in racersAndTeams)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region 组连接

            //var racers2 = Formulal.GetChampionShips().SelectMany(cs => new List<RacerInfo>
            //{
            //    new RacerInfo
            //    {
            //        Year=cs.Year,
            //        Position=1,
            //        FirstName=cs.First.FirstName(),
            //        LastName=cs.First.LastName()
            //    },
            //    new RacerInfo
            //    {
            //        Year=cs.Year,
            //        Position=2,
            //        FirstName=cs.Second.FirstName(),
            //        LastName=cs.Second.LastName()
            //    },
            //    new RacerInfo
            //    {
            //        Year=cs.Year,
            //        Position=3,
            //        FirstName=cs.Third.FirstName(),
            //        LastName=cs.Third.LastName()
            //    }
            //});

            //var q = (from r in Formulal.GetChampions()
            //    join r2 in racers2 on new
            //    {
            //        FirstName=r.FirstName,
            //        LastName=r.LastName
            //    } equals new
            //    {
            //        FirstName=r2.FirstName,
            //        LastName=r2.LastName
            //    }into yearResults select new
            //    {
            //        FirstName=r.FirstName,
            //        LastName=r.LastName,
            //        Wins=r.Wins,
            //        Starts=r.Starts,
            //        Results=yearResults
            //    });

            //foreach (var r in q)
            //{
            //    Console.WriteLine($"{r.FirstName} {r.LastName}");
            //    foreach (var item in r.Results)
            //    {
            //        Console.WriteLine($"{item.Year} {item.Position}");
            //    }
            //}
            #endregion

            #region 集合操作
            //var ferrriDrivers = from r in Formulal.GetChampions()
            //                    from c in r.Cars
            //                    where c == "Ferrari"
            //                    orderby r.LastName
            //                    select r;

            //Console.WriteLine("World Champion with ferrari and Mclaren");
            //foreach (var racer in racerByCar("Ferrari").Intersect(racerByCar("Mclaren")))
            //{
            //    Console.WriteLine(racer);
            //}
            #endregion

            #region 合并操作
            //合并是对两个相关序列合并为一个， 第一个集合中的第一项与第二个集合中的第一项合并，第一个集合中的第二项会与第二个集合中的第二项合并。依此类推，如果两个序列的项数不同。Zip()方法就在达到最小集合的末尾时停止。

            //var racerNames = from r in Formulal.GetChampions()
            //    where r.Country == "Italy"
            //    orderby r.Wins descending
            //    select new
            //    {
            //        Name = r.FirstName + " " + r.LastName
            //    };
            //var racerNamesAndStarts = from r in Formulal.GetChampions()
            //    where r.Country == "Italy"
            //    orderby r.Wins descending
            //    select new
            //    {
            //        LastName = r.LastName,
            //        Starts = r.Starts
            //    };
            //var racers5 = racerNames.Zip(racerNamesAndStarts,
            //    (first, second) => first.Name + ",Starts:" + second.Starts);
            //foreach (var item in racers5)
            //{
            //    Console.WriteLine(item);
            //}



            //int[] numbers = { 1, 2, 3, 4 };
            //string[] words = { "one", "two", "three" };

            //var numbersAndWords = numbers.Zip(words, (first, second) => first + " " + second);

            //foreach (var item in numbersAndWords)
            //    Console.WriteLine(item);

            #endregion

            #region 分区/分页

            //int pageSize = 5;
            //int numberPages = (int) Math.Ceiling(Formulal.GetChampions().Count() / (double) pageSize);
            //for (int i = 0; i < numberPages; i++)
            //{
            //    Console.WriteLine($"Page :{i}");
            //    var racers6 = (from r in Formulal.GetChampions()
            //        orderby r.LastName, r.FirstName
            //        select r.FirstName + " " + r.LastName).Skip(i * pageSize).Take(numberPages);
            //    foreach (var item in racers6)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}


            //            string[] fruits = { "apple", "banana", "mango", "orange",
            //                "passionfruit", "grape" };

            //            IEnumerable<string> query =
            //                fruits.SkipWhile(fruit => String.Compare("orange", fruit, 
            //StringComparison.OrdinalIgnoreCase) != 0);

            //            foreach (string fruit in query)
            //            {
            //                Console.WriteLine(fruit);
            //            }

            #endregion

            #region 聚合操作符

            //var query = from r in Formulal.GetChampions()
            //    let numberYears = r.Years.Count()
            //    where numberYears >= 3
            //    orderby numberYears descending, r.LastName
            //    select new
            //    {
            //        Name = r.FirstName + " " + r.LastName,
            //        timesChampion = numberYears
            //    };
            //foreach (var r in query)
            //{
            //    Console.WriteLine($"{r.Name} {r.timesChampion}"); 
            //}


            #endregion


            #region 转换操作符

            //var racers7 = (from r in Formulal.GetChampions()
            //    from c in r.Cars
            //    select new
            //    {
            //        Car = c, Racer = r
            //    }).ToLookup(cr => cr.Car, cr => cr.Racer);
            //if (racers7.Contains("Ferrari"))
            //{
            //    foreach (var racer in racers7["Ferrari"])
            //    {
            //        Console.WriteLine(racer);
            //    }
            //}


            //var list = new ArrayList(Formulal.GetChampions() as ICollection ?? throw new InvalidOperationException());
            //var query = from r in list.Cast<Racer>() where r.Country == "USA" select r;
            //foreach (var racer in query)
            //{
            //    Console.WriteLine($"{racer:A}",racer);
            //}
            #endregion

            #region 生成操作符

            var values = Enumerable.Range(1, 20);
            foreach (var item in values)
            {
                Console.WriteLine($"{item}",item);
            }

            #endregion

            #endregion
            Console.ReadKey();
        }



        private static void LinqQuery()
        {
            var query = from r in Formulal.GetChampions()
                        where r.Country == "UK"
                        orderby r.Wins descending
                        select r;
            foreach (var racer in query)
            {
                Console.WriteLine($"r:{racer}");
            }
        }

        private static IEnumerable<Racer> GetRacersByCar(string car)
        {
            return from r in Formulal.GetChampions()
                   from c in r.Cars
                   where c == car
                   orderby r.LastName
                   select r;
        }

        private static Func<string, IEnumerable<Racer>> racerByCar = car => from r in Formulal.GetChampions()
                                                                            from c in r.Cars
                                                                            where c == car
                                                                            orderby r.LastName
                                                                            select r;



    }
}
