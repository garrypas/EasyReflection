﻿using EasyReflection;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    using ReflectionTypeExtensions = System.TypeExtensions;

    public static class ObjectExtensions
    {
        private static readonly Type[] NotGenericParameters = { };

        public static void SetValue(this object obj, string memberName, object value, object[] indexer = null)
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
            return (T)obj.GetType().GetGetterSetter(memberName).GetValue(obj, indexer);
        }

        public static object GetValue(this object obj, string memberName, params object[] indexer)
        {
            return GetValue<object>(obj, memberName, indexer);
        }

        public static T Invoke<T>(this object obj, string methodName, IEnumerable<Type> argumentTypes, params object[] arguments)
        {
            return InvokeCommon<T>(obj, methodName, argumentTypes, NotGenericParameters, arguments);
        }

        public static void Invoke(this object obj, string methodName, IEnumerable<Type> argumentTypes, params object[] arguments)
        {
            InvokeCommon<object>(obj, methodName, argumentTypes, NotGenericParameters, arguments);
        }

        public static T InvokeGeneric<T>(this object obj, string methodName, IEnumerable<Type> argumentTypes, IEnumerable<Type> genericParameters, params object[] arguments)
        {
            return InvokeCommon<T>(obj, methodName, argumentTypes, genericParameters, arguments);
        }

        public static void InvokeGeneric(this object obj, string methodName, IEnumerable<Type> argumentTypes, IEnumerable<Type> genericParameters, params object[] arguments)
        {
            InvokeCommon<object>(obj, methodName, argumentTypes, genericParameters, arguments);
        }

        private static T InvokeCommon<T>(object obj, string methodName, IEnumerable<Type> argumentTypes, IEnumerable<Type> genericParameters, params object[] arguments)
        {
            var methodInfo = obj.GetType().GetAnyMethod(methodName, argumentTypes);
            if (genericParameters != null && genericParameters.Any())
            {
                methodInfo = methodInfo.MakeGenericMethod(genericParameters.ToArray());
            }
            return (T)methodInfo.Invoke(obj, arguments);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetAttributes<TAttribute>(this object obj)
            where TAttribute : Attribute
        {
            return obj.GetType().GetPropertyInfoAttributesWithPredicate<TAttribute>();
        }

        public static IEnumerable<TAttribute> GetAttribute<TAttribute>(this object obj, string propertyName)
            where TAttribute : Attribute
        {
            return obj.GetType().GetAttribute<TAttribute>(propertyName);
        }

        public static IDictionary<string, object> ToDictionary(this object obj)
        {
            return obj.GetType().GetPublicGetters().Select(p => p.Name).ToDictionary(prop => prop, prop => obj.GetValue(prop));
        }
    }
}