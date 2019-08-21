using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.DictionarySample
{
    public class Employee
    {
        private readonly string _name;
        private readonly decimal _salary;
        private readonly EmployeeId _id;

        public Employee(string name, decimal salary, EmployeeId id)
        {
            _name = name;
            _salary = salary;
            _id = id;
        }
        /// <summary>
        /// {_name,-20} 20的作用是往后加20个空格
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{_id}:{_name,-20} {_salary:C}";
    }
}
