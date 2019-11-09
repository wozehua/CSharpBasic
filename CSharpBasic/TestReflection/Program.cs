using System;
using System.Reflection;

namespace TestReflection
{
    public class MyClass
    {
        public int myField =123;
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyClass myObject = new MyClass();
                // Get the type of the 'MyClass'.
                Type myType = typeof(MyClass);
                // Get the field information and the attributes associated with MyClass.
                FieldInfo myFieldInfo = myType.GetField("myField", BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine("\nChecking for the AnsiClass attribute for a field.\n");
                // Get and display the name, field, and the AnsiClass attribute.
                Console.WriteLine("Name of Class: {0} \nValue of Field: {1} \nIsAnsiClass = {2}", myType.FullName, myFieldInfo?.GetValue(myObject), myType.IsAnsiClass);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
        }
    }
}
