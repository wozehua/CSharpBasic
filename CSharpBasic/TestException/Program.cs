using System;
using System.Runtime.CompilerServices;

namespace TestException
{
    class Program
    {
        private int _someProperty;
        public int SomeProperty
        {
            get => _someProperty;
            set
            {
                Log();
                _someProperty = value;
            }
        }
        static void Main(string[] args)
        {
            var p = new Program();
            p.Log();
            p.SomeProperty = 33;
            void Action() => p.Log();
            Action();
        }

        public void Log([CallerLineNumber]int line = -1,[CallerFilePath] string path=null,[CallerMemberName] string name=null)
        {
            Console.WriteLine(line<0?"No line":"Line"+line);
            Console.WriteLine(path ?? "No file path");
            Console.WriteLine(name??"No member name");
            Console.WriteLine();
        }
    }
}
