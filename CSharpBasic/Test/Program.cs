using System;
using System.ComponentModel.DataAnnotations;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            #region 实现单例模式
            //实现单例模式
            var person = Person.CreateInstance();
            var body = new Body(3, 4);
            (int height, int weight) = body;
            Console.WriteLine(height + " " + weight);
            Console.WriteLine("======================");
            #endregion

            foreach (var item in Enum.GetNames(typeof(Color)))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("================");
            foreach (int item in Enum.GetValues(typeof(Color)))
            {
                Console.WriteLine(item);
            }
        }
    }

    class Body
    {
        public int Height { get; set; }
        public int Weight { get; set; }

        public Body(int height,int weight)
        {
            Height = height;
            Weight = weight;
        }
        public void Deconstruct(out int height, out int weight)
        {
            height = Height;
            weight= Weight;
        }
    }

    public enum Color
    {
        Red=1,
        Blue=2,
        Yellow=3
    }

    public static class StringExtension
    {
        public static int GetWordCount(this string str) => str.Split().Length;
    }
}
