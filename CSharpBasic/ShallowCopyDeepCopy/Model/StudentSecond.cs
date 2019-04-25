using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShallowCopyDeepCopy.Model
{
    public class StudentSecond
    {
        public StudentSecond()
        {
            Grades = new Grades();
        }

        public void SetStudentSecond(int grades, string name)
        {
            Grades.Math = grades;
            Grades.Name = name;
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }

        public DateTime BirthDay { get; set; }

        public Grades Grades { get; set; }
    }
}
