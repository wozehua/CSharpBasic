using System;

namespace DeletegateExample
{
    class Program
    {
        //方法一：
        //delegate double DoubleOp(double x);
        
        static void Main(string[] args)
        {
            //方法一
            //DoubleOp[] operation =
            //{
            //    MathOperations.MultiplyByTwo,
            //    MathOperations.Square
            //};

            //方法二
            //Func<double,double>[] operation =
            //{
            //    MathOperations.MultiplyByTwo,
            //    MathOperations.Square
            //}
            //;
            //foreach (var item in operation)
            //{
            //    Console.WriteLine($"Using operation:{item.Method.Name}");
            //    ProcessAndDisplayNumber(item, 2.0);
            //    ProcessAndDisplayNumber(item, 7.94);
            //    ProcessAndDisplayNumber(item, 1.414);
            //}

            #region func泛型委托
            //Employee[] employees =
            //  {
            //    new Employee("1",20000),
            //    new Employee("2",10000),
            //    new Employee("3",25000),
            //    new Employee("4",100000.38m),
            //    new Employee("5",23000),
            //    new Employee("6",50000),
            //};
            ////第二个参数定义了一个泛型委托 func<T,T,bool>() 有两个参数T,T,一个返回类型bool
            ////所以要传递的方法一定要有两个参数T,T,并且这个方法的返回类型时bool
            ////并且两个参数T的类型要一样。
            //BubbleSort.Sort(employees, Employee.CompareSalary);
            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region Action泛型委托
            //Action action = One;
            //action += Two;
            //try
            //{
            //    //获取委托对象数组
            //    Delegate[] delegates = action.GetInvocationList();
            //    foreach (Action item in delegates)
            //    {
            //        item();
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //} 
            #endregion

            #region 事件--现在需要连接事件发布程序和订阅器
            //通过+=创建一个订阅
            //消费这daniel 通过“+=”订阅了事件
            //接着消费者sebastian也订阅了事件
            //然后sebastain 通过“-=”取消订阅事件
            
            //CarDealer作为一个发布程序。
            //Consumer 作为一个侦听器（订阅器）
            var dealer = new CarDealer();
            var daniel = new Consumer("Daniel");
            dealer.NewCarInfo += daniel.NewCarIsHere;
            dealer.NewCar("Mercedes");
            var sebastian = new Consumer("sebastian");
            dealer.NewCarInfo += sebastian.NewCarIsHere;
            dealer.NewCar("Ferrari");
            dealer.NewCarInfo -= sebastian.NewCarIsHere;
            dealer.NewCar("Red Bull Racing");

            #endregion
            Console.Read();
        }

        private static void Dealer_NewCarInfo(object sender, CarInfoEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 方法一 委托DoubleOp action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="value"></param>
        static void ProcessAndDisplayNumber(Func<double,double> action, double value)
        {
            double result = action(value);
            Console.WriteLine($"Value is:{value},result of operation is:{result}");
        }
        static void One()
        {
            Console.WriteLine("One");
            throw new Exception("Error in one");
        }

        static void Two()
        {
            Console.WriteLine("Two");
        }
    }
}
