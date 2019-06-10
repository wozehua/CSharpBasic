using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShallowCopyDeepCopy.ExpressionTree
{
    public static class ExpressionDeepCopy
    {
        public static TOut ExpressionConvert<TOut, TIn>(TIn tIn)
        {
            try
            {
                var tInTypeOf = typeof(TIn);
                var tOutTypeOf = typeof(TOut);
                //创建表达式数的节点，用于表示表达式树的参数或变量
                ParameterExpression parameterExpression = Expression.Parameter(tInTypeOf, "deepCopy");
                var memberBindings = new List<MemberBinding>();
                //绑定属性
                var properties = tOutTypeOf.GetProperties();
                foreach (var item in properties)
                {
                    var tInProp = tInTypeOf.GetProperty(item.Name);
                    if (tInProp != null)
                    {
                        if (item.PropertyType.IsClass)
                        {
                            //var a= ExpressionConvert<tOutTypeOf.Assembly.FullName, TIn>(item.GetValue(tIn));
                        }
                        //
                        //创建一个属性
                        MemberExpression memberExpression = Expression.Property(parameterExpression, tInProp);
                        //创建一个属性成员 内部新new 了一个对象
                        MemberBinding memberBinding = Expression.Bind(item, memberExpression);
                        memberBindings.Add(memberBinding);
                    }
                }
                //绑定字段
                var filed = tOutTypeOf.GetFields();
                foreach (var item in filed)
                {
                    var tInFiled = tInTypeOf.GetField(item.Name);
                    if (tInFiled != null)
                    {
                        var memberExpression = Expression.Field(parameterExpression, tInFiled);
                        var memberBinding = Expression.Bind(item, memberExpression);
                        memberBindings.Add(memberBinding);
                    }
                }

                var memberInitExpression = Expression.MemberInit(Expression.New(tOutTypeOf), memberBindings
                    .ToArray());
                var lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, parameterExpression);
                //编译为可执行代码
                var func = lambda.Compile();
                //调用
                return func.Invoke(tIn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
