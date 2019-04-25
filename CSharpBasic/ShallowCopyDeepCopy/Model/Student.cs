using System;

namespace ShallowCopyDeepCopy.Model
{
    public class Student:ICloneable
    {
        public string  Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public Grades Grades{ get; set; }

        public Student()
        {
            Grades = new Grades();
        }

        public void SetGrades(int math, string name)
        {
            Grades.Math = math;
            Grades.Name = name;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
