﻿using EasyReflection;
using System.Collections.Generic;
using System.Linq;

namespace System
{
    using System.Reflection;
    using ReflectionTypeExtensions = System.TypeExtensions;
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

        public static object GetValue(this object obj, string memberName, params object[] indexer)
        {
            return GetValue<object>(obj, memberName, indexer);
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

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPropertyAttributes<TAttribute>(this object obj)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetPropertyInfoAttributesWithPredicate<TAttribute>(obj.GetType());
        }

        public static IEnumerable<TAttribute> GetPropertyAttribute<TAttribute>(this object obj, string propertyName)
            where TAttribute : Attribute
        {
            return obj.GetType().GetPropertyAttribute<TAttribute>(propertyName);
        }

        public static IEnumerable<FieldInfoAttributePair<TAttribute>> GetFieldAttributes<TAttribute>(this object obj)
         where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetFieldInfoAttributesWithPredicate<TAttribute>(obj.GetType());
        }

        public static IEnumerable<TAttribute> GetFieldAttribute<TAttribute>(this object obj, string fieldName)
            where TAttribute : Attribute
        {
            return obj.GetType().GetFieldAttribute<TAttribute>(fieldName);
        }

        public static IEnumerable<MethodInfoAttributePair<TAttribute>> GetMethodAttributes<TAttribute>(this object obj)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetMethodInfoAttributesWithPredicate<TAttribute>(obj.GetType());
        }

        public static IEnumerable<TAttribute> GetMethodAttribute<TAttribute>(this object obj, string methodName)
            where TAttribute : Attribute
        {
            return obj.GetType().GetMethodAttribute<TAttribute>(methodName);
        }

        public static IEnumerable<MemberInfoAttributePair<TAttribute, MemberInfo>> GetAttributes<TAttribute>(this object obj)
            where TAttribute : Attribute
        {
            var matches = new List<MemberInfoAttributePair<TAttribute, MemberInfo>>();
            var propertyAttributes = obj.GetType().GetPropertyAttributes<TAttribute>().Select(item => ToMemberInfoAttributePair<TAttribute>(item));
            var fieldAttributes = obj.GetType().GetFieldAttributes<TAttribute>().Select(item => ToMemberInfoAttributePair<TAttribute>(item));
            var methodAttributes = obj.GetType().GetMethodAttributes<TAttribute>().Select(item => ToMemberInfoAttributePair<TAttribute>(item));
            return propertyAttributes.Union(fieldAttributes).Union(methodAttributes);
        }

        private static MemberInfoAttributePair<TAttribute, MemberInfo> ToMemberInfoAttributePair<TAttribute>(MemberInfoAttributePair<TAttribute, MemberInfo> item)
            where TAttribute : Attribute
        {
            return item;
        }

        public static IDictionary<string, object> ToDictionary(this object obj)
        {
            var dictionary = new Dictionary<string, object>();
            foreach (var prop in obj.GetType().GetPublicGetters().Select(p => p.Name))
            {
                dictionary.Add(prop, obj.GetValue(prop));
            }
            return dictionary;
        }
    }
}