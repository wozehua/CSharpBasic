using System;
using Newtonsoft.Json;
using ShallowCopyDeepCopy.ExpressionTree;
using ShallowCopyDeepCopy.Model;
using ShallowCopyDeepCopy.Reflection;
using ShallowCopyDeepCopy.Serialize;

namespace ShallowCopyDeepCopy
{
    class Program
    {
        static void Main()
        {
            //var b = new DeepCloneSerialize();
            Student s = new Student() { Age = 20, Id = 1, Name = "Emi" };
            s.SetGrades(100, "数学");
            #region 序列化实现深复制(二进制序列化,Newtonsoft.json 实现)
            //Student v = b.DeepClone(s);
            //Student v =b.DeepCloneNewtonsoft(s);
            //JsonSerializerSettings mJsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            //StudentSecond v = b.DeepCloneExchange<Student, StudentSecond>(s);
            //Console.WriteLine($"二进制序列化深复制后的值v：{JsonConvert.SerializeObject(v)}");
            //Console.WriteLine("========改变深复制的值=========");
            //v.SetStudentSecond(200, "语文");
            //Console.WriteLine($"二进制序列化深复制改变后的值v:{JsonConvert.SerializeObject(v, mJsonSettings)}");
            //Console.WriteLine($"二进制序列化深复制改变后的值s:{JsonConvert.SerializeObject(s)}");
            //Console.WriteLine("========改变深复制的值=========");
            #endregion

            #region 反射实现深复制（注意对象间的调用导致栈溢出问题，互相引用对象的问题）

            #region DeepCopyReflection实现深反射
            //var deep = new ReflectionDeepCopy();
            //var second = new StudentSecond();
            //var student = deep.DeepCopyReflection(s,second);
            //student.SetStudentSecond(200, "语文");
            //var a = new ReflectionDeepCopy();
            ////Student student = a.DeepCopyReflection(s);
            //Console.WriteLine($"反射实现深复制{JsonConvert.SerializeObject(student)}");
            ////student.SetGrades(300, "英语");
            //student.Age = 100;
            //Console.WriteLine($"反射实现深复制改变后的值：{JsonConvert.SerializeObject(student)}");
            //Console.WriteLine($"反射实现深复制改变后的s的值：{JsonConvert.SerializeObject(s)}");


            #endregion
            #region 使用DeepCopyReflection<T> 来实现深反射
            //var deep = new ReflectionDeepCopy();
            //var student = deep.DeepCopyReflection(s);
            //student.SetGrades(200, "语文");
            //var a = new ReflectionDeepCopy();
            ////Student student = a.DeepCopyReflection(s);
            //Console.WriteLine($"反射实现深复制{JsonConvert.SerializeObject(student)}");
            ////student.SetGrades(300, "英语");
            //student.Age = 100;
            //Console.WriteLine($"反射实现深复制改变后的值：{JsonConvert.SerializeObject(student)}");
            //Console.WriteLine($"反射实现深复制改变后的s的值：{JsonConvert.SerializeObject(s)}"); 
            #endregion

            #region 使用DeepCopy<T>(T obj)实现深反射 完成（未实现类对象互相引用问题）

            //var student = ReflectionDeepCopy.DeepCopy<Student>(s);
            //student.SetGrades(200, "语文");
            //student.Name = "修改后";
            //Console.WriteLine($"反射实现深复制{JsonConvert.SerializeObject(student)}");
            //Console.WriteLine($"反射实现深复制改变后的值：{JsonConvert.SerializeObject(student)}");
            //Console.WriteLine($"反射实现深复制改变后的s的值：{JsonConvert.SerializeObject(s)}");

            #endregion


            #endregion
            #region 浅复制用.Net 自带接口ICloneable实现浅复制
            //Student sss = (Student)s.Clone();
            //Console.WriteLine($"浅复制后的值sss：{JsonConvert.SerializeObject(sss)}");
            //sss.SetGrades(200, "语文");
            //Console.WriteLine($"浅复制变化后的值sss,SetGrades变化后：{JsonConvert.SerializeObject(sss)}");
            //Console.WriteLine($"浅复制变化后的值s：{JsonConvert.SerializeObject(s)}"); 
            #endregion

            #region 用表达式树实现深反射

            //StudentSecond aa = ExpTransHelper<Student, StudentSecond>.Trans(s);
            StudentSecond aa = ExpressionDeepCopy.ExpressionConvert<StudentSecond, Student>(s);
            Console.WriteLine($"表达式树实现深复制{JsonConvert.SerializeObject(aa)}");
            aa.SetStudentSecond(200, "语文");
            Console.WriteLine($"表达式树实现深复制改变后的值：{JsonConvert.SerializeObject(aa)}");
            Console.WriteLine($"表达式树实现深复制改变后的s的值：{JsonConvert.SerializeObject(s)}");
            #endregion
            Console.Read();
        }
    }
}
