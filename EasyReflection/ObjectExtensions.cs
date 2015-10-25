using EasyReflection;
using System.Collections.Generic;
using System.Linq;

namespace System.Reflection
{
    using ReflectionTypeExtensions = System.Reflection.TypeExtensions;
    public static class ObjectExtensions
    {
        private static readonly Type[] NotGenericParameters = { };

        public static void SetValue(this object obj, string memberName, object value, params object[] indexer)
        {
            var property = obj.GetType().GetGetterSetter(memberName);
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
            return (T)obj.GetType().GetGetterSetter(memberName).GetValue(obj, indexer as object[]);
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

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetAttributes<TAttribute>(this object obj)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetPropertyInfoAttributesWithPredicate<TAttribute>(obj.GetType());
        }

        public static IEnumerable<TAttribute> GetAttribute<TAttribute>(this object obj, string propertyName)
            where TAttribute : Attribute
        {
            return obj.GetType().GetAttribute<TAttribute>(propertyName);
        }
    }
}