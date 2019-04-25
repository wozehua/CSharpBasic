using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace ShallowCopyDeepCopy.Serialize
{
    public class DeepCloneSerialize
    {
        /// <summary>
        /// 使用序列化实现深复制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T DeepClone<T>(T obj)
        {
            //if (!typeof(T).IsSerializable)
            //{
            //    return new ArgumentException("这个类型一定哟啊可序列化", obj);
                
            //}

            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("这个类型一定要可序列化(Serializable)", nameof(obj));
            }
            if (ReferenceEquals(obj, null))
            {
                return default(T);
            }
            using (var ms=new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                //ms.Position = 0;
                //这两种写法是一样的 都是设置其实位置为0
                //Seek 内部实现是 _position +offset=0+0;
                //_position 初始值为0
                //todo SeekOrigin.Current 和SeekOrigin.End 后面在看
                //SeekOrigin.Begin 要求offset 不能小于0和大于int.MaxValue且_position +offset不能小于0
                ms.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(ms);
            }
            
        }

        /// <summary>
        /// 用Newtonsoft.Json实现深复制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T DeepCloneNewtonsoft<T>(T obj) where T : class
        {
            try
            {
                if (obj == null)
                {
                    return default(T);
                }

                var ns = JsonConvert.SerializeObject(obj);
                return JsonConvert.DeserializeObject<T>(ns);
            }
            catch (Exception e)
            {
                Console.WriteLine("序列化深复制失败", e.Message);
                return default(T);
            }
        }

        public TOut DeepCloneExchange<TInt, TOut>(TInt tInt) where TInt : class where TOut : class
        {
            try
            {
                if (tInt == null)
                {
                    return default(TOut);
                }
                var ns = JsonConvert.SerializeObject(tInt, Formatting.None);
                return JsonConvert.DeserializeObject<TOut>(ns);
            }
            catch (Exception e)
            {
                Console.WriteLine("序列化深复制失败", e.Message);
                return default(TOut);
            }
        }
    }
}
