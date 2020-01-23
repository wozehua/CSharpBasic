using System;

namespace 字符串不可变性和驻留机制
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "abc";
            //string str1 = "abc";
            //string str2 = "a";
            //string str3 = "bc";
            string str4 = "";
            str4 = "a" + "bc";
            var result=string.ReferenceEquals(str, str4);
            Console.WriteLine(result);
        }
    }
}
