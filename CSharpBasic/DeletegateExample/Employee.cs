using System;
using System.Collections.Generic;
using System.Text;

namespace DeletegateExample
{
    class Employee
    {
        public Employee(string name,decimal salary)
        {
            Name= name;
            Salary = salary;
        }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public override string ToString() => $"{Name},{Salary:C}";

        public static bool CompareSalary(Employee e1, Employee e2) => e1.Salary<e2.Salary;


    }

    class Employee2:Employee
    {
        public Employee2(string name, decimal salary) : base(name, salary)
        {
        }
    }
}
