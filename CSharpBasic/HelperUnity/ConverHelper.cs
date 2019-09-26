using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace HelperUnity
{
    public static class ConvertHelper<T> where T:new()
    {
        /// <summary>
        /// 将DataTable转换成Model,如果dataTable为空或没有任何行就返回空列表
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static IList<T> ToModels(DataTable dataTable)
        {
            if(dataTable == null || dataTable.Rows.Count<=0)
                return new List<T>();
            IList<T> objList = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T convertModel = new T();
                foreach (PropertyInfo prop in convertModel.GetType().GetProperties())
                {
                    string name = prop.Name;
                    if (dataTable.Rows.Contains(name) && prop.CanWrite)
                    {
                        object exchangeObj = row[name];
                        Type type = GetPropertyType(prop.PropertyType);
                        if (prop.PropertyType.IsEnum)
                            prop.SetValue(convertModel, Enum.Parse(type, exchangeObj.ToString().Trim(), true));
                        else
                            prop.SetValue(convertModel, Convert.ChangeType(exchangeObj, type), (object[]) null);
                    }
                }
                objList.Add(convertModel);
            }

            return objList;
        }

        /// <summary>
        /// 将DataTable的第一行 转为 Model,如果没数据则返回null
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T Model(DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0)
                return default;
            return ToModel(dt.Rows[0]);
        }
        /// <summary>
        /// 将DataRow 读取到的一行转换为Model
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ToModel(DataRow dr)
        {
            T obj1 = new T();
            PropertyInfo[] propertyInfos= obj1.GetType().GetProperties();
            DataTable dataTable = dr.Table;
            foreach (PropertyInfo prop in propertyInfos)
            {
                string name = prop.Name;
                if (dataTable.Rows.Contains(name) && prop.CanWrite)
                {
                    object obj2 = dr[name];
                    if (obj2 != null && obj2 != DBNull.Value)
                    {
                        Type type = ConvertHelper<T>.GetPropertyType(prop.PropertyType);
                        if (type.IsEnum)
                            prop.SetValue(obj1, Enum.Parse(type, obj2.ToString(), true),(object[])null);
                        else
                            prop.SetValue(obj1, Convert.ChangeType(obj2, type), null);
                    }
                }
            }

            return obj1;
        }

        /// <summary>
        /// 将DataReader读取的内容转为Model，结束后不会自动关闭Reader
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static IList<T> ToModels(IDataReader dr)
        {
            IList<T> objList = (IList<T>)new List<T>();
            while (dr.Read())
                objList.Add(ConvertHelper<T>.ToModel((IDataRecord)dr));
            return objList;
        }
        /// <summary>
        /// 将 SqlDataReader 转为Model, 如果 SqlDataReader.read() 有值 ，返回对象，否则返回Null
        /// </summary>
        /// <param name="dataRecord"></param>
        /// <returns></returns>
        public static T ToModel(IDataRecord dataRecord)
        {
            T obj1 = new T();
            PropertyInfo[] propertyInfos = obj1.GetType().GetProperties();
            int fieldCount = dataRecord.FieldCount;
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            for (int i = 0; i < fieldCount; i++)
            {
                string lower = dataRecord.GetName(i).ToLower();
                dictionary[lower] = dataRecord[i];
            }

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                string lower = propertyInfo.Name.ToLower();
                if (dictionary.ContainsKey(lower) && propertyInfo.CanWrite)
                {
                    object obj2 = dictionary[lower];
                    if (obj2 != DBNull.Value)
                    {
                        Type type = ConvertHelper<T>.GetPropertyType(propertyInfo.PropertyType);
                        if (type.IsEnum)
                            propertyInfo.SetValue(obj1, Enum.Parse(type, obj2.ToString(), true), (object[]) null);
                        else
                            propertyInfo.SetValue(obj1, Convert.ChangeType(obj2, type), (object[]) null);
                    }
                }
            }

            return obj1;

        }


        /// <summary>
        /// 获取包含泛型类型参数的数组
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Type GetPropertyType(Type type)
        {
            Type[] types = type.GetGenericArguments();
            if (types.Length != 0)
                return types[0];
            return type;
        }
    }
}
