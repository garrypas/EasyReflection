using EasyReflection;
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
        public static IEnumerable<PropertyInfo> GetGettersAndSetters(this Type t)
        {
            return t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }

        internal static IEnumerable<PropertyInfo> GetGettersAndSetters(Type t, Func<PropertyInfo, bool> whereClause)
        {
            return GetGettersAndSetters(t).Where(whereClause);
        }
        #endregion

        #region Properties (Individual)
        public static PropertyInfo GetGetterSetter(this Type t, string propertyName)
        {
            return GetGetterSetter(GetGettersAndSetters(t), propertyName);
        }

        internal static PropertyInfo GetGetterSetter(IEnumerable<PropertyInfo> propertyInfo, string propertyName)
        {
            return propertyInfo.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Static Properties (Groups)
        public static IEnumerable<PropertyInfo> GetStaticGettersAndSetters(this Type t)
        {
            return t.GetProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);
        }

        internal static IEnumerable<PropertyInfo> GetStaticGetterSetters(Type t, Func<PropertyInfo, bool> whereClause)
        {
            return GetStaticGettersAndSetters(t).Where(whereClause);
        }
        #endregion

        #region Static Properties (Individual)
        public static PropertyInfo GetAnyStaticProperty(this Type t, string propertyName)
        {
            return GetStaticGetterSetter(GetStaticGettersAndSetters(t), propertyName);
        }

        internal static PropertyInfo GetStaticGetterSetter(IEnumerable<PropertyInfo> propertyInfo, string propertyName)
        {
            return propertyInfo.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Fields (Groups)
        public static IEnumerable<FieldInfo> GetAllFields(this Type t)
        {
            var fields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var fieldsWithoutPropertyBackingFields = fields.Where(f => f.Name.StartsWith("<") == false && f.Name.EndsWith("k__BackingField") == false);
            return fieldsWithoutPropertyBackingFields;
        }

        internal static IEnumerable<FieldInfo> GetAllFields(Type t, Func<FieldInfo, bool> whereClause)
        {
            return GetAllFields(t).Where(whereClause);
        }
        #endregion

        #region Fields (Individual)
        public static FieldInfo GetAnyField(this Type t, string fieldName)
        {
            return GetAnyField(GetAllFields(t), fieldName);
        }

        internal static FieldInfo GetAnyField(IEnumerable<FieldInfo> fieldInfo, string fieldName)
        {
            return fieldInfo.First(f => f.Name.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Static Fields (Groups)
        public static IEnumerable<FieldInfo> GetStaticFields(this Type t)
        {
            var StaticFields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);
            var StaticFieldsWithoutPropertyBackingStaticFields = StaticFields.Where(f => f.Name.StartsWith("<") == false && f.Name.EndsWith("k__BackingField") == false);
            return StaticFieldsWithoutPropertyBackingStaticFields;
        }

        internal static IEnumerable<FieldInfo> GetAllStaticFields(Type t, Func<FieldInfo, bool> whereClause)
        {
            return GetStaticFields(t).Where(whereClause);
        }
        #endregion

        #region Static Fields (Individual)
        public static FieldInfo GetStaticField(this Type t, string StaticFieldName)
        {
            return GetAnyStaticField(GetStaticFields(t), StaticFieldName);
        }

        internal static FieldInfo GetAnyStaticField(IEnumerable<FieldInfo> StaticFieldInfo, string StaticFieldName)
        {
            return StaticFieldInfo.First(f => f.Name.Equals(StaticFieldName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Methods (Groups)
        public static IEnumerable<MethodInfo> GetAllMethods(Type t)
        {
            return t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }

        internal static IEnumerable<MethodInfo> GetAllMethods(Type t, Func<MethodInfo, bool> whereClause)
        {
            return GetAllMethods(t).Where(whereClause).Where(methodInfo => methodInfo.Name.StartsWith("get_") == false
                && methodInfo.Name.StartsWith("set_") == false);
        }
        #endregion

        #region Methods (Individual)
        public static MethodInfo GetAnyMethod(this Type t, string methodName)
        {
            return GetAnyMethod(GetAllMethods(t), methodName);
        }

        internal static MethodInfo GetAnyMethod(IEnumerable<MethodInfo> methodInfo, string methodName)
        {
            return methodInfo.First(m => m.Name.Equals(methodName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Static Methods (Groups)
        public static IEnumerable<MethodInfo> GetStaticMethods(Type t)
        {
            return t.GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);
        }

        internal static IEnumerable<MethodInfo> GetStaticMethods(Type t, Func<MethodInfo, bool> whereClause)
        {
            return GetStaticMethods(t).Where(whereClause).Where(methodInfo => methodInfo.Name.StartsWith("get_") == false
                && methodInfo.Name.StartsWith("set_") == false);
        }
        #endregion

        #region Static Methods (Individual)
        public static MethodInfo GetStaticMethod(this Type t, string methodName)
        {
            return GetStaticMethod(GetStaticMethods(t), methodName);
        }

        internal static MethodInfo GetStaticMethod(IEnumerable<MethodInfo> methodInfo, string methodName)
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
            var methodInfo = t.GetStaticMethod(methodName);
            if(genericParameters != null && genericParameters.Any())
            {
                methodInfo = methodInfo.MakeGenericMethod(genericParameters.ToArray());
            }
            return (T)methodInfo.Invoke(null, arguments as object[]);
        }
        #endregion

        #region Attributes
        #region Properties (Groups)
        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t);
        }

        internal static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPropertyInfoAttributesWithPredicate<TAttribute>(this Type t, Func<PropertyInfoAttributePair<TAttribute>, bool> predicate = null)
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
        public static IEnumerable<TAttribute> GetAttribute<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return GetAttributesWithPredicate<TAttribute>(t, propertyName);
        }

        internal static IEnumerable<TAttribute> GetAttributesWithPredicate<TAttribute>(this Type t, string propertyName, Func<PropertyInfoAttributePair<TAttribute>, bool> predicate = null)
            where TAttribute : Attribute
        {
            return GetPropertyInfoAttributesWithPredicate<TAttribute>(t, predicate).First(pair => pair.PropertyInfo.Name == propertyName).Attributes;
        }
        #endregion
        #endregion

    }
}

namespace EasyReflection
{
    using ReflectionTypeExtensions = System.Reflection.TypeExtensions;

    public static class TypeExtensions
    {
        private static readonly Type[] NotGenericParameters = { };

        #region Properties (Groups)
        public static IEnumerable<PropertyInfo> GetPublicGetters(this Type t)
        {
            return ReflectionTypeExtensions.GetGettersAndSetters(t, p => p.GetGetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> GetPublicSetters(this Type t)
        {
            return ReflectionTypeExtensions.GetGettersAndSetters(t, p => p.GetSetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> GetPrivateGetters(this Type t)
        {
            return ReflectionTypeExtensions.GetGettersAndSetters(t, p => p.GetGetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfo> GetPrivateSetters(this Type t)
        {
            return ReflectionTypeExtensions.GetGettersAndSetters(t, p => p.GetSetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfo> GetInternalGetters(this Type t)
        {
            return ReflectionTypeExtensions.GetGettersAndSetters(t, p => p.GetGetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfo> GetInternalSetters(this Type t)
        {
            return ReflectionTypeExtensions.GetGettersAndSetters(t, p => p.GetSetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfo> GetProtectedGetters(this Type t)
        {
            return ReflectionTypeExtensions.GetGettersAndSetters(t, p => p.GetGetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfo> GetProtectedSetters(this Type t)
        {
            return ReflectionTypeExtensions.GetGettersAndSetters(t, p => p.GetSetMethod(true).IsFamily);
        }
        #endregion

        #region Properties (Individual)
        public static PropertyInfo GetPublicGetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetGetterSetter(t.GetPublicGetters(), propertyName);
        }

        public static PropertyInfo GetPublicSetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetGetterSetter(t.GetPublicSetters(), propertyName);
        }

        public static PropertyInfo GetPrivateGetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetGetterSetter(t.GetPrivateGetters(), propertyName);
        }

        public static PropertyInfo GetPrivateSetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetGetterSetter(t.GetPrivateSetters(), propertyName);
        }

        public static PropertyInfo GetInternalGetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetGetterSetter(t.GetInternalGetters(), propertyName);
        }

        public static PropertyInfo GetInternalSetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetGetterSetter(t.GetInternalSetters(), propertyName);
        }

        public static PropertyInfo GetProtectedGetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetGetterSetter(t.GetProtectedGetters(), propertyName);
        }

        public static PropertyInfo GetProtectedSetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetGetterSetter(t.GetProtectedSetters(), propertyName);
        }
        #endregion

        #region Static Properties (Groups)
        public static IEnumerable<PropertyInfo> GetPublicStaticGetters(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetters(t, p => p.GetGetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> GetPublicStaticSetters(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetters(t, p => p.GetSetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> GetPrivateStaticGetters(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetters(t, p => p.GetGetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfo> GetPrivateStaticSetters(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetters(t, p => p.GetSetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfo> GetInternalStaticGetters(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetters(t, p => p.GetGetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfo> GetInternalStaticSetters(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetters(t, p => p.GetSetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfo> GetProtectedStaticGetters(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetters(t, p => p.GetGetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfo> GetProtectedStaticSetters(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetters(t, p => p.GetSetMethod(true).IsFamily);
        }
        #endregion

        #region Static Properties (Individual)
        public static PropertyInfo GetPublicStaticGetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetter(t.GetPublicStaticGetters(), propertyName);
        }

        public static PropertyInfo GetPublicStaticSetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetter(t.GetPublicStaticSetters(), propertyName);
        }

        public static PropertyInfo GetPrivateStaticGetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetter(t.GetPrivateStaticGetters(), propertyName);
        }

        public static PropertyInfo GetPrivateStaticSetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetter(t.GetPrivateStaticSetters(), propertyName);
        }

        public static PropertyInfo GetInternalStaticGetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetter(t.GetInternalStaticGetters(), propertyName);
        }

        public static PropertyInfo GetInternalStaticSetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetter(t.GetInternalStaticSetters(), propertyName);
        }

        public static PropertyInfo GetProtectedStaticGetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetter(t.GetProtectedStaticGetters(), propertyName);
        }

        public static PropertyInfo GetProtectedStaticSetter(this Type t, string propertyName)
        {
            return ReflectionTypeExtensions.GetStaticGetterSetter(t.GetProtectedStaticSetters(), propertyName);
        }
        #endregion

        #region Fields (Groups)
        public static IEnumerable<FieldInfo> GetPublicFields(this Type t)
        {
            return ReflectionTypeExtensions.GetAllFields(t, fieldInfo => fieldInfo.IsPublic);
        }

        public static IEnumerable<FieldInfo> GetPrivateFields(this Type t)
        {
            return ReflectionTypeExtensions.GetAllFields(t, fieldInfo => fieldInfo.IsPrivate);
        }

        public static IEnumerable<FieldInfo> GetInternalFields(this Type t)
        {
            return ReflectionTypeExtensions.GetAllFields(t, fieldInfo => fieldInfo.IsAssembly);
        }

        public static IEnumerable<FieldInfo> GetProtectedFields(this Type t)
        {
            return ReflectionTypeExtensions.GetAllFields(t, fieldInfo => fieldInfo.IsFamily);
        }
        #endregion

        #region Fields (Individual)
        public static FieldInfo GetPublicField(this Type t, string fieldName)
        {
            return ReflectionTypeExtensions.GetAnyField(t.GetPublicFields(), fieldName);
        }

        public static FieldInfo GetPrivateField(this Type t, string fieldName)
        {
            return ReflectionTypeExtensions.GetAnyField(t.GetPrivateFields(), fieldName);
        }

        public static FieldInfo GetInternalField(this Type t, string fieldName)
        {
            return ReflectionTypeExtensions.GetAnyField(t.GetInternalFields(), fieldName);
        }

        public static FieldInfo GetProtectedField(this Type t, string fieldName)
        {
            return ReflectionTypeExtensions.GetAnyField(t.GetProtectedFields(), fieldName);
        }
        #endregion

        #region Static Fields (Groups)
        public static IEnumerable<FieldInfo> GetPublicStaticFields(this Type t)
        {
            return ReflectionTypeExtensions.GetAllStaticFields(t, fieldInfo => fieldInfo.IsPublic);
        }

        public static IEnumerable<FieldInfo> GetPrivateStaticFields(this Type t)
        {
            return ReflectionTypeExtensions.GetAllStaticFields(t, fieldInfo => fieldInfo.IsPrivate);
        }

        public static IEnumerable<FieldInfo> GetInternalStaticFields(this Type t)
        {
            return ReflectionTypeExtensions.GetAllStaticFields(t, fieldInfo => fieldInfo.IsAssembly);
        }

        public static IEnumerable<FieldInfo> GetProtectedStaticFields(this Type t)
        {
            return ReflectionTypeExtensions.GetAllStaticFields(t, fieldInfo => fieldInfo.IsFamily);
        }
        #endregion

        #region Static Fields (Individual)
        public static FieldInfo GetPublicStaticField(this Type t, string StaticFieldName)
        {
            return ReflectionTypeExtensions.GetAnyStaticField(t.GetPublicStaticFields(), StaticFieldName);
        }

        public static FieldInfo GetPrivateStaticField(this Type t, string StaticFieldName)
        {
            return ReflectionTypeExtensions.GetAnyStaticField(t.GetPrivateStaticFields(), StaticFieldName);
        }

        public static FieldInfo GetInternalStaticField(this Type t, string StaticFieldName)
        {
            return ReflectionTypeExtensions.GetAnyStaticField(t.GetInternalStaticFields(), StaticFieldName);
        }

        public static FieldInfo GetProtectedStaticField(this Type t, string StaticFieldName)
        {
            return ReflectionTypeExtensions.GetAnyStaticField(t.GetProtectedStaticFields(), StaticFieldName);
        }
        #endregion

        #region Methods (Groups)
        public static IEnumerable<MethodInfo> GetPublicMethods(this Type t)
        {
            return ReflectionTypeExtensions.GetAllMethods(t, methodInfo => methodInfo.IsPublic);
        }

        public static IEnumerable<MethodInfo> GetPrivateMethods(this Type t)
        {
            return ReflectionTypeExtensions.GetAllMethods(t, methodInfo => methodInfo.IsPrivate);
        }

        public static IEnumerable<MethodInfo> GetInternalMethods(this Type t)
        {
            return ReflectionTypeExtensions.GetAllMethods(t, methodInfo => methodInfo.IsAssembly);
        }

        public static IEnumerable<MethodInfo> GetProtectedMethods(this Type t)
        {
            var isObjectMember = new Func<MethodInfo, bool>(mi => mi.DeclaringType != typeof(object));
            return ReflectionTypeExtensions.GetAllMethods(t, methodInfo => methodInfo.IsFamily && isObjectMember(methodInfo));
        }
        #endregion

        #region Methods (Individual)
        public static MethodInfo GetPublicMethod(this Type t, string methodName)
        {
            return ReflectionTypeExtensions.GetAnyMethod(t.GetPublicMethods(), methodName);
        }

        public static MethodInfo GetPrivateMethod(this Type t, string methodName)
        {
            return ReflectionTypeExtensions.GetAnyMethod(t.GetPrivateMethods(), methodName);
        }

        public static MethodInfo GetInternalMethod(this Type t, string fieldName)
        {
            return ReflectionTypeExtensions.GetAnyMethod(t.GetInternalMethods(), fieldName);
        }

        public static MethodInfo GetProtectedMethod(this Type t, string methodName)
        {
            return ReflectionTypeExtensions.GetAnyMethod(t.GetProtectedMethods(), methodName);
        }
        #endregion

        #region Static Methods (Groups)
        public static IEnumerable<MethodInfo> GetPublicStaticMethods(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticMethods(t, methodInfo => methodInfo.IsPublic);
        }

        public static IEnumerable<MethodInfo> GetPrivateStaticMethods(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticMethods(t, methodInfo => methodInfo.IsPrivate);
        }

        public static IEnumerable<MethodInfo> GetInternalStaticMethods(this Type t)
        {
            return ReflectionTypeExtensions.GetStaticMethods(t, methodInfo => methodInfo.IsAssembly);
        }

        public static IEnumerable<MethodInfo> GetProtectedStaticMethods(this Type t)
        {
            var isObjectMember = new Func<MethodInfo, bool>(mi => mi.DeclaringType != typeof(object));
            return ReflectionTypeExtensions.GetStaticMethods(t, methodInfo => methodInfo.IsFamily && isObjectMember(methodInfo));
        }
        #endregion

        #region Static Methods (Individual)
        public static MethodInfo GetPublicStaticMethod(this Type t, string methodName)
        {
            return ReflectionTypeExtensions.GetStaticMethod(t.GetPublicStaticMethods(), methodName);
        }

        public static MethodInfo GetPrivateStaticMethod(this Type t, string methodName)
        {
            return ReflectionTypeExtensions.GetStaticMethod(t.GetPrivateStaticMethods(), methodName);
        }

        public static MethodInfo GetInternalStaticMethod(this Type t, string fieldName)
        {
            return ReflectionTypeExtensions.GetStaticMethod(t.GetInternalStaticMethods(), fieldName);
        }

        public static MethodInfo GetProtectedStaticMethod(this Type t, string methodName)
        {
            return ReflectionTypeExtensions.GetStaticMethod(t.GetProtectedStaticMethods(), methodName);
        }
        #endregion

        #region Attributes
        #region Properties (Groups)
        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPublicGetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetGetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetProtectedGetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetGetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetInternalGetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetGetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPrivateGetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetGetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPublicSetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetSetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetProtectedSetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetSetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetInternalSetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetSetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfoAttributePair<TAttribute>> GetPrivateSetterAttributes<TAttribute>(this Type t)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetPropertyInfoAttributesWithPredicate<TAttribute>(t, pair => pair.PropertyInfo.GetSetMethod(true).IsPrivate);
        }
        #endregion

        #region Properties (Individual)
        public static IEnumerable<TAttribute> GetPublicGetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetGetMethod(true).IsPublic);
        }

        public static IEnumerable<TAttribute> GetProtectedGetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetGetMethod(true).IsFamily);
        }

        public static IEnumerable<TAttribute> GetInternalGetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetGetMethod(true).IsAssembly);
        }

        public static IEnumerable<TAttribute> GetPrivateGetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetGetMethod(true).IsPrivate);
        }

        public static IEnumerable<TAttribute> GetPublicSetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetSetMethod(true).IsPublic);
        }

        public static IEnumerable<TAttribute> GetProtectedSetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetSetMethod(true).IsFamily);
        }

        public static IEnumerable<TAttribute> GetInternalSetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetAttributesWithPredicate<TAttribute>(t, propertyName, pair => pair.PropertyInfo.GetSetMethod(true).IsAssembly);
        }

        public static IEnumerable<TAttribute> GetPrivateSetterAttributes<TAttribute>(this Type t, string propertyName)
            where TAttribute : Attribute
        {
            return ReflectionTypeExtensions.GetAttributesWithPredicate<TAttribute>(t, propertyName);
        }
        #endregion
        #endregion

    }
}