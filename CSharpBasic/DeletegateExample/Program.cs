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

            Action action = One;
            action += Two;
            try
            {
                //获取委托对象数组
                Delegate[] delegates = action.GetInvocationList();
                foreach (Action item in delegates)
                {
                    item();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.Read();
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
