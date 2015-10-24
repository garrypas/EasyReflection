using System.Collections.Generic;
using System.Linq;

namespace System.Reflection
{
    public static class ObjectExtensions
    {
        private static readonly Type[] NotGenericParameters = { };

        public static void SetValue(this object obj, string memberName, object value, params object[] indexer)
        {
            var property = obj.GetType().GetAnyProperty(memberName);
            if (property != null)
            {
                property.SetValue(obj, value, indexer);
            }
            else
            {
                var field = obj.GetType().GetAnyField(memberName);
                field.SetValue(obj, value);
            }
        }

        public static T GetValue<T>(this object obj, string memberName, params object[] indexer)
        {
            return (T)obj.GetType().GetAnyProperty(memberName).GetValue(obj, indexer as object[]);
        }

        public static T Invoke<T>(this object obj, string methodName, params object[] arguments)
        {
            return InvokeCommon<T>(obj, methodName, NotGenericParameters, arguments);
        }

        public static void Invoke(this object obj, string methodName, params object[] arguments)
        {
            InvokeCommon<object>(obj, methodName, NotGenericParameters, arguments);
        }

        public static T InvokeGeneric<T>(this object obj, string methodName, IEnumerable<Type> genericParameters, params object[] arguments)
        {
            return InvokeCommon<T>(obj, methodName, genericParameters, arguments);
        }

        public static void InvokeGeneric(this object obj, string methodName, IEnumerable<Type> genericParameters, params object[] arguments)
        {
            InvokeCommon<object>(obj, methodName, genericParameters, arguments);
        }

        private static T InvokeCommon<T>(object obj, string methodName, IEnumerable<Type> genericParameters, object[] arguments)
        {
            var methodInfo = obj.GetType().GetAnyMethod(methodName);
            if(genericParameters != null && genericParameters.Any())
            {
                methodInfo = methodInfo.MakeGenericMethod(genericParameters.ToArray());
            }
            return (T)methodInfo.Invoke(obj, arguments as object[]);
        }
    }
}