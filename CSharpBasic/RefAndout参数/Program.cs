using System;

namespace RefAndout参数
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 值类型
            //当A是值类型的时候 按照值传递
            A a1 = new A { X = 1 };
            //方法change 得到堆栈中的变量a1在方法Change中修改和最后销毁,所以 a1的内容不变            
            var changeValue = Change(a1);
            Console.WriteLine($"值类型的X：{a1.X},{changeValue}");
            //当 ReferenceA 是引用类型的时候 a变量把堆上的同一个对象引用为ReferenceA,
            //他们都指向同一地址 当change中改变x的值 ReferenceA中的值也跟着改变了
            //所以referenceA.X=2
            int value = 20;
            ReferenceA referenceA = new ReferenceA{ X = 1 };
            var referenceValue = Change(referenceA);
            Console.WriteLine($"引用类型的X：{referenceA.X},{referenceValue},{referenceA.a}");
            #endregion
            Console.ReadKey();
        }
        public static int Change(A a)
        {
            a.X = 2;
            return a.X;
        }

        public static int Change(ReferenceA a)
        {
            a.X = 2;
            return a.X;
        }

    }
}
