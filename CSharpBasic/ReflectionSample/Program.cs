using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace ReflectionSample
{
    class Program
    {
        private static StringBuilder _outputText = new StringBuilder();
        static void Main(string[] args)
        {
            #region 反射
            //Type t = typeof(double);
            //AnalyzeType(t);
            //Console.WriteLine($"Analysis of type{t.Name}");
            //Console.WriteLine(_outputText.ToString()); 
            #endregion

            #region DynamicObject

            //dynamic wroxDyn = new WroxDynamicObject();
            //wroxDyn.FirstName = "Bugs";
            //wroxDyn.LastName = "Bunny";
            //Console.WriteLine(wroxDyn.GetType());
            //Console.WriteLine($"{wroxDyn.FirstName} {wroxDyn.LastName}");

            //Func<DateTime, string> GetTomorrow = today => today.AddDays(1).ToShortDateString();
            //wroxDyn.GetTomorrowDate=GetTomorrow;
            //Console.WriteLine($"Tomorrow is {wroxDyn.GetTomorrowDate(DateTime.Now)}");


            #endregion

            #region ExpandoObject

            DoExpando();


            #endregion

        }

        static void AnalyzeType(Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            AddToOutput($"Type Name:{type.Name}");
            AddToOutput($"Full Name:{type.FullName}");
            AddToOutput($"Namespace :{type.Namespace}");
            Type tBase = type.BaseType;
            if (tBase != null)
            {
                AddToOutput($"Base Type:{tBase.Name}");
            }

            AddToOutput($"\n public number:");
            foreach (var memberInfo in type.GetMembers())
            {


#if DNXCORE
 AddToOutput($"{memberInfo.DeclaringType} {memberInfo.Name}");
#else
                AddToOutput($"{memberInfo.DeclaringType}    {memberInfo.MemberType}  {memberInfo.Name}");
#endif
            }
        }

        static void AddToOutput(string text)
        {
            _outputText.Append("\n" + text);
        }


        static void DoExpando()
        {
            dynamic expObj = new ExpandoObject();
            expObj.FirstName = "Daffy";
            expObj.LastName = 
"Duck";
            Console.WriteLine($"{expObj.FirstName}{expObj.LastName }");
            Func<DateTime, string> GetTomorrow = today => today.AddDays(1).ToShortDateString();
            expObj.GetTomorrowDate = GetTomorrow;
            Console.WriteLine($"Tomorrow is{expObj.GetTomorrowDate(DateTime.Now)}");
            expObj.Friends = new List<Person>();
            expObj.Friends.Add(new Person() {FirstName = "Bob", LastName = "Jones"});
            expObj.Friends.Add(new Person() {FirstName = "Robert", LastName = "Jones"});
            expObj.Friends.Add(new Person() {FirstName = "Bobbt", LastName = "Jones"});
            foreach (var friend in expObj.Friends)
            {
                Console.WriteLine($"{friend.FirstName} {friend.LastName}");
            }
        }
      
    }

    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
