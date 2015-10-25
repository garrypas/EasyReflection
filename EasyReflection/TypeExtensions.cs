﻿using EasyReflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Reflection
{
    public static class TypeExtensions
    {
        private static readonly Type[] NotGenericParameters = { };

        #region Properties (Groups)
        public static IEnumerable<PropertyInfo> GetPublicGetters(this Type t)
        {
            return GetGettersAndSetters(t, p => p.GetGetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> GetPublicSetters(this Type t)
        {
            return GetGettersAndSetters(t, p => p.GetSetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> GetPrivateGetters(this Type t)
        {
            return GetGettersAndSetters(t, p => p.GetGetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfo> GetPrivateSetters(this Type t)
        {
            return GetGettersAndSetters(t, p => p.GetSetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfo> GetInternalGetters(this Type t)
        {
            return GetGettersAndSetters(t, p => p.GetGetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfo> GetInternalSetters(this Type t)
        {
            return GetGettersAndSetters(t, p => p.GetSetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfo> GetProtectedGetters(this Type t)
        {
            return GetGettersAndSetters(t, p => p.GetGetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfo> GetProtectedSetters(this Type t)
        {
            return GetGettersAndSetters(t, p => p.GetSetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfo> GetGettersAndSetters(this Type t)
        {
            return t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }

        private static IEnumerable<PropertyInfo> GetGettersAndSetters(Type t, Func<PropertyInfo, bool> whereClause)
        {
            return GetGettersAndSetters(t).Where(whereClause);
        }
        #endregion

        #region Properties (Individual)
        public static PropertyInfo GetPublicGetter(this Type t, string propertyName)
        {
            return GetGetterSetter(t.GetPublicGetters(), propertyName);
        }

        public static PropertyInfo GetPublicSetter(this Type t, string propertyName)
        {
            return GetGetterSetter(t.GetPublicSetters(), propertyName);
        }

        public static PropertyInfo GetPrivateGetter(this Type t, string propertyName)
        {
            return GetGetterSetter(t.GetPrivateGetters(), propertyName);
        }

        public static PropertyInfo GetPrivateSetter(this Type t, string propertyName)
        {
            return GetGetterSetter(t.GetPrivateSetters(), propertyName);
        }

        public static PropertyInfo GetInternalGetter(this Type t, string propertyName)
        {
            return GetGetterSetter(t.GetInternalGetters(), propertyName);
        }

        public static PropertyInfo GetInternalSetter(this Type t, string propertyName)
        {
            return GetGetterSetter(t.GetInternalSetters(), propertyName);
        }

        public static PropertyInfo GetProtectedGetter(this Type t, string propertyName)
        {
            return GetGetterSetter(t.GetProtectedGetters(), propertyName);
        }

        public static PropertyInfo GetProtectedSetter(this Type t, string propertyName)
        {
            return GetGetterSetter(t.GetProtectedSetters(), propertyName);
        }

        public static PropertyInfo GetAnyProperty(this Type t, string propertyName)
        {
            return GetGetterSetter(GetGettersAndSetters(t), propertyName);
        }

        private static PropertyInfo GetGetterSetter(IEnumerable<PropertyInfo> propertyInfo, string propertyName)
        {
            return propertyInfo.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Static Properties (Groups)
        public static IEnumerable<PropertyInfo> GetPublicStaticGetters(this Type t)
        {
            return GetStaticGettersAndStaticSetters(t, p => p.GetGetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> GetPublicStaticSetters(this Type t)
        {
            return GetStaticGettersAndStaticSetters(t, p => p.GetSetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> GetPrivateStaticGetters(this Type t)
        {
            return GetStaticGettersAndStaticSetters(t, p => p.GetGetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfo> GetPrivateStaticSetters(this Type t)
        {
            return GetStaticGettersAndStaticSetters(t, p => p.GetSetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfo> GetInternalStaticGetters(this Type t)
        {
            return GetStaticGettersAndStaticSetters(t, p => p.GetGetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfo> GetInternalStaticSetters(this Type t)
        {
            return GetStaticGettersAndStaticSetters(t, p => p.GetSetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfo> GetProtectedStaticGetters(this Type t)
        {
            return GetStaticGettersAndStaticSetters(t, p => p.GetGetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfo> GetProtectedStaticSetters(this Type t)
        {
            return GetStaticGettersAndStaticSetters(t, p => p.GetSetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfo> GetStaticGettersAndSetters(this Type t)
        {
            return t.GetProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);
        }

        private static IEnumerable<PropertyInfo> GetStaticGettersAndStaticSetters(Type t, Func<PropertyInfo, bool> whereClause)
        {
            return GetStaticGettersAndSetters(t).Where(whereClause);
        }
        #endregion

        #region Static Properties (Individual)
        public static PropertyInfo GetPublicStaticGetter(this Type t, string propertyName)
        {
            return GetStaticGetterSetter(t.GetPublicStaticGetters(), propertyName);
        }

        public static PropertyInfo GetPublicStaticSetter(this Type t, string propertyName)
        {
            return GetStaticGetterSetter(t.GetPublicStaticSetters(), propertyName);
        }

        public static PropertyInfo GetPrivateStaticGetter(this Type t, string propertyName)
        {
            return GetStaticGetterSetter(t.GetPrivateStaticGetters(), propertyName);
        }

        public static PropertyInfo GetPrivateStaticSetter(this Type t, string propertyName)
        {
            return GetStaticGetterSetter(t.GetPrivateStaticSetters(), propertyName);
        }

        public static PropertyInfo GetInternalStaticGetter(this Type t, string propertyName)
        {
            return GetStaticGetterSetter(t.GetInternalStaticGetters(), propertyName);
        }

        public static PropertyInfo GetInternalStaticSetter(this Type t, string propertyName)
        {
            return GetStaticGetterSetter(t.GetInternalStaticSetters(), propertyName);
        }

        public static PropertyInfo GetProtectedStaticGetter(this Type t, string propertyName)
        {
            return GetStaticGetterSetter(t.GetProtectedStaticGetters(), propertyName);
        }

        public static PropertyInfo GetProtectedStaticSetter(this Type t, string propertyName)
        {
            return GetStaticGetterSetter(t.GetProtectedStaticSetters(), propertyName);
        }

        public static PropertyInfo GetAnyStaticProperty(this Type t, string propertyName)
        {
            return GetStaticGetterSetter(GetStaticGettersAndSetters(t), propertyName);
        }

        private static PropertyInfo GetStaticGetterSetter(IEnumerable<PropertyInfo> propertyInfo, string propertyName)
        {
            return propertyInfo.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Fields (Groups)
        public static IEnumerable<FieldInfo> GetPublicFields(this Type t)
        {
            return GetAllFields(t, fieldInfo => fieldInfo.IsPublic);
        }

        public static IEnumerable<FieldInfo> GetPrivateFields(this Type t)
        {
            return GetAllFields(t, fieldInfo => fieldInfo.IsPrivate);
        }

        public static IEnumerable<FieldInfo> GetInternalFields(this Type t)
        {
            return GetAllFields(t, fieldInfo => fieldInfo.IsAssembly);
        }

        public static IEnumerable<FieldInfo> GetProtectedFields(this Type t)
        {
            return GetAllFields(t, fieldInfo => fieldInfo.IsFamily);
        }

        public static IEnumerable<FieldInfo> GetAllFields(this Type t)
        {
            var fields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var fieldsWithoutPropertyBackingFields = fields.Where(f => f.Name.StartsWith("<") == false && f.Name.EndsWith("k__BackingField") == false);
            return fieldsWithoutPropertyBackingFields;
        }

        private static IEnumerable<FieldInfo> GetAllFields(Type t, Func<FieldInfo, bool> whereClause)
        {
            return GetAllFields(t).Where(whereClause);
        }
        #endregion

        #region Fields (Individual)
        public static FieldInfo GetPublicField(this Type t, string fieldName)
        {
            return GetAnyField(t.GetPublicFields(), fieldName);
        }

        public static FieldInfo GetPrivateField(this Type t, string fieldName)
        {
            return GetAnyField(t.GetPrivateFields(), fieldName);
        }

        public static FieldInfo GetInternalField(this Type t, string fieldName)
        {
            return GetAnyField(t.GetInternalFields(), fieldName);
        }

        public static FieldInfo GetProtectedField(this Type t, string fieldName)
        {
            return GetAnyField(t.GetProtectedFields(), fieldName);
        }

        public static FieldInfo GetAnyField(this Type t, string fieldName)
        {
            return GetAnyField(GetAllFields(t), fieldName);
        }

        private static FieldInfo GetAnyField(IEnumerable<FieldInfo> fieldInfo, string fieldName)
        {
            return fieldInfo.First(f => f.Name.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Static Fields (Groups)
        public static IEnumerable<FieldInfo> GetPublicStaticFields(this Type t)
        {
            return GetAllStaticFields(t, fieldInfo => fieldInfo.IsPublic);
        }

        public static IEnumerable<FieldInfo> GetPrivateStaticFields(this Type t)
        {
            return GetAllStaticFields(t, fieldInfo => fieldInfo.IsPrivate);
        }

        public static IEnumerable<FieldInfo> GetInternalStaticFields(this Type t)
        {
            return GetAllStaticFields(t, fieldInfo => fieldInfo.IsAssembly);
        }

        public static IEnumerable<FieldInfo> GetProtectedStaticFields(this Type t)
        {
            return GetAllStaticFields(t, fieldInfo => fieldInfo.IsFamily);
        }

        public static IEnumerable<FieldInfo> GetAllStaticFields(this Type t)
        {
            var StaticFields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);
            var StaticFieldsWithoutPropertyBackingStaticFields = StaticFields.Where(f => f.Name.StartsWith("<") == false && f.Name.EndsWith("k__BackingField") == false);
            return StaticFieldsWithoutPropertyBackingStaticFields;
        }

        private static IEnumerable<FieldInfo> GetAllStaticFields(Type t, Func<FieldInfo, bool> whereClause)
        {
            return GetAllStaticFields(t).Where(whereClause);
        }
        #endregion

        #region Static Fields (Individual)
        public static FieldInfo GetPublicStaticField(this Type t, string StaticFieldName)
        {
            return GetAnyStaticField(t.GetPublicStaticFields(), StaticFieldName);
        }

        public static FieldInfo GetPrivateStaticField(this Type t, string StaticFieldName)
        {
            return GetAnyStaticField(t.GetPrivateStaticFields(), StaticFieldName);
        }

        public static FieldInfo GetInternalStaticField(this Type t, string StaticFieldName)
        {
            return GetAnyStaticField(t.GetInternalStaticFields(), StaticFieldName);
        }

        public static FieldInfo GetProtectedStaticField(this Type t, string StaticFieldName)
        {
            return GetAnyStaticField(t.GetProtectedStaticFields(), StaticFieldName);
        }

        public static FieldInfo GetAnyStaticField(this Type t, string StaticFieldName)
        {
            return GetAnyStaticField(GetAllStaticFields(t), StaticFieldName);
        }

        private static FieldInfo GetAnyStaticField(IEnumerable<FieldInfo> StaticFieldInfo, string StaticFieldName)
        {
            return StaticFieldInfo.First(f => f.Name.Equals(StaticFieldName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Methods (Groups)
        public static IEnumerable<MethodInfo> GetPublicMethods(this Type t)
        {
            return GetAllMethods(t, methodInfo => methodInfo.IsPublic);
        }

        public static IEnumerable<MethodInfo> GetPrivateMethods(this Type t)
        {
            return GetAllMethods(t, methodInfo => methodInfo.IsPrivate);
        }

        public static IEnumerable<MethodInfo> GetInternalMethods(this Type t)
        {
            return GetAllMethods(t, methodInfo => methodInfo.IsAssembly);
        }

        public static IEnumerable<MethodInfo> GetProtectedMethods(this Type t)
        {
            var isObjectMember = new Func<MethodInfo, bool>(mi => mi.DeclaringType != typeof(object));
            return GetAllMethods(t, methodInfo => methodInfo.IsFamily && isObjectMember(methodInfo));
        }

        public static IEnumerable<MethodInfo> GetAllMethods(Type t)
        {
            return t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }

        private static IEnumerable<MethodInfo> GetAllMethods(Type t, Func<MethodInfo, bool> whereClause)
        {
            return GetAllMethods(t).Where(whereClause).Where(methodInfo => methodInfo.Name.StartsWith("get_") == false
                && methodInfo.Name.StartsWith("set_") == false);
        }
        #endregion

        #region Methods (Individual)
        public static MethodInfo GetPublicMethod(this Type t, string methodName)
        {
            return GetAnyMethod(t.GetPublicMethods(), methodName);
        }

        public static MethodInfo GetPrivateMethod(this Type t, string methodName)
        {
            return GetAnyMethod(t.GetPrivateMethods(), methodName);
        }

        public static MethodInfo GetInternalMethod(this Type t, string fieldName)
        {
            return GetAnyMethod(t.GetInternalMethods(), fieldName);
        }

        public static MethodInfo GetProtectedMethod(this Type t, string methodName)
        {
            return GetAnyMethod(t.GetProtectedMethods(), methodName);
        }

        public static MethodInfo GetAnyMethod(this Type t, string methodName)
        {
            return GetAnyMethod(GetAllMethods(t), methodName);
        }

        private static MethodInfo GetAnyMethod(IEnumerable<MethodInfo> methodInfo, string methodName)
        {
            return methodInfo.First(m => m.Name.Equals(methodName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Static Methods (Groups)
        public static IEnumerable<MethodInfo> GetPublicStaticMethods(this Type t)
        {
            return GetAllStaticMethods(t, methodInfo => methodInfo.IsPublic);
        }

        public static IEnumerable<MethodInfo> GetPrivateStaticMethods(this Type t)
        {
            return GetAllStaticMethods(t, methodInfo => methodInfo.IsPrivate);
        }

        public static IEnumerable<MethodInfo> GetInternalStaticMethods(this Type t)
        {
            return GetAllStaticMethods(t, methodInfo => methodInfo.IsAssembly);
        }

        public static IEnumerable<MethodInfo> GetProtectedStaticMethods(this Type t)
        {
            var isObjectMember = new Func<MethodInfo, bool>(mi => mi.DeclaringType != typeof(object));
            return GetAllStaticMethods(t, methodInfo => methodInfo.IsFamily && isObjectMember(methodInfo));
        }

        public static IEnumerable<MethodInfo> GetAllStaticMethods(Type t)
        {
            return t.GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);
        }

        private static IEnumerable<MethodInfo> GetAllStaticMethods(Type t, Func<MethodInfo, bool> whereClause)
        {
            return GetAllStaticMethods(t).Where(whereClause).Where(methodInfo => methodInfo.Name.StartsWith("get_") == false
                && methodInfo.Name.StartsWith("set_") == false);
        }
        #endregion

        #region Static Methods (Individual)
        public static MethodInfo GetPublicStaticMethod(this Type t, string methodName)
        {
            return GetAnyStaticMethod(t.GetPublicStaticMethods(), methodName);
        }

        public static MethodInfo GetPrivateStaticMethod(this Type t, string methodName)
        {
            return GetAnyStaticMethod(t.GetPrivateStaticMethods(), methodName);
        }

        public static MethodInfo GetInternalStaticMethod(this Type t, string fieldName)
        {
            return GetAnyStaticMethod(t.GetInternalStaticMethods(), fieldName);
        }

        public static MethodInfo GetProtectedStaticMethod(this Type t, string methodName)
        {
            return GetAnyStaticMethod(t.GetProtectedStaticMethods(), methodName);
        }

        public static MethodInfo GetAnyStaticMethod(this Type t, string methodName)
        {
            return GetAnyStaticMethod(GetAllStaticMethods(t), methodName);
        }

        private static MethodInfo GetAnyStaticMethod(IEnumerable<MethodInfo> methodInfo, string methodName)
        {
            return methodInfo.First(m => m.Name.Equals(methodName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Static Methods (Functionality)
        public static T Invoke<T>(this Type t, string methodName, params object[] arguments)
        {
            return InvokeGenericCommon<T>(t, methodName, NotGenericParameters, arguments);
        }

        public static void Invoke(this Type t, string methodName, params object[] arguments)
        {
            InvokeGenericCommon<object>(t, methodName, NotGenericParameters, arguments);
        }

        public static T InvokeGeneric<T>(this Type t, string methodName, IEnumerable<Type> genericParameters, params object[] arguments)
        {
            return InvokeGenericCommon<T>(t, methodName, genericParameters, arguments);
        }

        public static void InvokeGeneric(this Type t, string methodName, IEnumerable<Type> genericParameters, params object[] arguments)
        {
            InvokeGenericCommon<object>(t, methodName, genericParameters, arguments);
        }

        private static T InvokeGenericCommon<T>(this Type t, string methodName, IEnumerable<Type> genericParameters, params object[] arguments)
        {
            var methodInfo = t.GetAnyStaticMethod(methodName);
            if(genericParameters != null && genericParameters.Any())
            {
                methodInfo = methodInfo.MakeGenericMethod(genericParameters.ToArray());
            }
            return (T)methodInfo.Invoke(null, arguments as object[]);
        }
        #endregion

        #region Attributes
        #region Properties (Groups)
        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPublicGetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetGetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetProtectedGetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetGetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetInternalGetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetGetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPrivateGetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetGetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPublicSetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetSetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetProtectedSetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetSetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetInternalSetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetSetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPrivateSetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetSetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t);
        }

        private static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPropertyInfoAttributesWithPredicate<TAttribute>(this Type t, Func<PropertyInfoAttributePair<TAttribute>, bool> predicate = null)
            where TAttribute : Attribute
        {
            var propertyAttributePairs = t.GetGettersAndSetters().Select(pi => new PropertyInfoAttributePair<TAttribute>(pi, pi.GetCustomAttributes(typeof(TAttribute), true).Select(attr => attr as TAttribute) )).Where(pair => pair.Attributes.Any());
            if (predicate != null)
            {
                propertyAttributePairs = propertyAttributePairs.Where(predicate);
            }
            return propertyAttributePairs;
        }
        #endregion

        #region Properties (Individual)
        public static IEnumerable<TAttribute> GetPublicGetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetGetMethod(true).IsPublic);
        }

        public static IEnumerable<TAttribute> GetProtectedGetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetGetMethod(true).IsFamily);
        }

        public static IEnumerable<TAttribute> GetInternalGetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetGetMethod(true).IsAssembly);
        }

        public static IEnumerable<TAttribute> GetPrivateGetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetGetMethod(true).IsPrivate);
        }

        public static IEnumerable<TAttribute> GetPublicSetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetSetMethod(true).IsPublic);
        }

        public static IEnumerable<TAttribute> GetProtectedSetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetSetMethod(true).IsFamily);
        }

        public static IEnumerable<TAttribute> GetInternalSetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetSetMethod(true).IsAssembly);
        }

        public static IEnumerable<TAttribute> GetPrivateSetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return GetAttributesWithPredicate<TAttribute>(t, propertyName);
        }

        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return GetAttributesWithPredicate<TAttribute>(t, propertyName);
        }

        private static IEnumerable<TAttribute> GetAttributesWithPredicate<TAttribute>(this Type t, string propertyName, Func<PropertyInfoAttributePair<TAttribute>, bool> predicate = null)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t, predicate).First(pair => pair.PropertyInfo.Name == propertyName).Attributes;
        }
        #endregion
        #endregion

    }
}
