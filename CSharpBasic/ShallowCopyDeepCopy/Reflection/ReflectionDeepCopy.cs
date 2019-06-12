using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShallowCopyDeepCopy.Reflection
{
    public  class ReflectionDeepCopy
    {
        public TOut DeepCopyReflection<TIn, TOut>(TIn tIn,TOut tOut1) where TOut:class where TIn:class
        {
            var tInType = tIn.GetType();
            //if (tIn is string || tInType.IsValueType) return tOut as tIn;
            var tOut = Activator.CreateInstance(tOut1.GetType());
            var a = tOut.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                                 BindingFlags.Static);
            foreach (var itemOut in a)
            {
                
                var itemIn = tInType.GetProperty(itemOut.Name);
                if (itemIn != null)
                {
                    itemOut.SetValue(tOut, itemIn.GetValue(tIn));
                }
            }

            return (TOut)tOut;
        }

        public T DeepCopyReflection<T>(T obj)
        {
            try
            {
                //如果是字符串或值类型则直接返回
                if (obj is string || obj.GetType().IsValueType) return obj;

                //var instance = Activator.CreateInstance<T>(); 这个方式是错误的。
                //关键点是在这一步 这边创建了一个新的实例
                var instance = Activator.CreateInstance(obj.GetType());
                var fieldInfos = instance.GetType().GetProperties();
                var fields = obj.GetType();
                foreach (var item in fieldInfos)
                {
                    var itemIn = fields.GetProperty(item.Name);
                    if (itemIn != null)
                    {
                        item.SetValue(instance, DeepCopyReflection(itemIn.GetValue(obj)));
                    }

                }

                return (T)instance;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(T);
            }
        }

        public static T DeepCopy<T>(T obj)
        {
            //如果是字符串或值类型则直接返回
            if (obj is string || obj.GetType().IsValueType) return obj;
            var newInstance = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var field in fields)
            {
                try { field.SetValue(newInstance, DeepCopy(field.GetValue(obj))); }
                catch { }
            }
            return (T)newInstance;
        }
    }
}
