using System.Collections.Generic;

namespace System.Reflection
{
    public static class ObjectExtensions
    {
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
            return (T)obj.GetType().GetAnyMethod(methodName).Invoke(obj, arguments as object[]);
        }

        public static void Invoke(this object obj, string methodName, params object[] arguments)
        {
            Invoke<object>(obj, methodName, arguments);
        }
    }
}