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
        #region Properties (Groups)
        public static IEnumerable<PropertyInfo> GetPublicGetters(this Type t)
        {
            return GetAllProperties(t, p => p.GetGetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> GetPublicSetters(this Type t)
        {
            return GetAllProperties(t, p => p.GetSetMethod(true).IsPublic);
        }

        public static IEnumerable<PropertyInfo> GetPrivateGetters(this Type t)
        {
            return GetAllProperties(t, p => p.GetGetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfo> GetPrivateSetters(this Type t)
        {
            return GetAllProperties(t, p => p.GetSetMethod(true).IsPrivate);
        }

        public static IEnumerable<PropertyInfo> GetInternalGetters(this Type t)
        {
            return GetAllProperties(t, p => p.GetGetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfo> GetInternalSetters(this Type t)
        {
            return GetAllProperties(t, p => p.GetSetMethod(true).IsAssembly);
        }

        public static IEnumerable<PropertyInfo> GetProtectedGetters(this Type t)
        {
            return GetAllProperties(t, p => p.GetGetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfo> GetProtectedSetters(this Type t)
        {
            return GetAllProperties(t, p => p.GetSetMethod(true).IsFamily);
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(Type t)
        {
            return t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }

        private static IEnumerable<PropertyInfo> GetAllProperties(Type t, Func<PropertyInfo, bool> whereClause)
        {
            return GetAllProperties(t).Where(whereClause);
        }
        #endregion

        #region Properties (Individual)
        public static PropertyInfo GetPublicGetter(this Type t, string propertyName)
        {
            return GetAnyProperty(t.GetPublicGetters(), propertyName);
        }

        public static PropertyInfo GetPublicSetter(this Type t, string propertyName)
        {
            return GetAnyProperty(t.GetPublicSetters(), propertyName);
        }

        public static PropertyInfo GetPrivateGetter(this Type t, string propertyName)
        {
            return GetAnyProperty(t.GetPrivateGetters(), propertyName);
        }

        public static PropertyInfo GetPrivateSetter(this Type t, string propertyName)
        {
            return GetAnyProperty(t.GetPrivateSetters(), propertyName);
        }

        public static PropertyInfo GetInternalGetter(this Type t, string propertyName)
        {
            return GetAnyProperty(t.GetInternalGetters(), propertyName);
        }

        public static PropertyInfo GetInternalSetter(this Type t, string propertyName)
        {
            return GetAnyProperty(t.GetInternalSetters(), propertyName);
        }

        public static PropertyInfo GetProtectedGetter(this Type t, string propertyName)
        {
            return GetAnyProperty(t.GetProtectedGetters(), propertyName);
        }

        public static PropertyInfo GetProtectedSetter(this Type t, string propertyName)
        {
            return GetAnyProperty(t.GetProtectedSetters(), propertyName);
        }

        public static PropertyInfo GetAnyProperty(this Type t, string propertyName)
        {
            return GetAnyProperty(GetAllProperties(t), propertyName);
        }

        private static PropertyInfo GetAnyProperty(IEnumerable<PropertyInfo> propertyInfo, string propertyName)
        {
            return propertyInfo.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        #region Fields (Groups)
        public static IEnumerable<FieldInfo> GetPublicFields(this Type t)
        {
            return GetAllFields(t, p => p.IsPublic);
        }

        public static IEnumerable<FieldInfo> GetPrivateFields(this Type t)
        {
            var fields = GetAllFields(t, p => p.IsPrivate);
            var fieldsWithoutPropertyBackingFields = fields.Where(f => f.Name.StartsWith("<") == false && f.Name.EndsWith("k__BackingField") == false);
            return fieldsWithoutPropertyBackingFields;
        }

        public static IEnumerable<FieldInfo> GetInternalFields(this Type t)
        {
            return GetAllFields(t, p => p.IsAssembly);
        }

        public static IEnumerable<FieldInfo> GetProtectedFields(this Type t)
        {
            return GetAllFields(t, p => p.IsFamily);
        }

        public static IEnumerable<FieldInfo> GetAllFields(Type t)
        {
            return t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }

        private static IEnumerable<FieldInfo> GetAllFields(Type t, Func<FieldInfo, bool> whereClause)
        {
            return GetAllFields(t).Where(whereClause);
        }
        #endregion

        #region Fields (Individual)
        public static FieldInfo GetPublicField(this Type t, string propertyName)
        {
            return GetAnyField(t.GetPublicFields(), propertyName);
        }

        public static FieldInfo GetPrivateField(this Type t, string propertyName)
        {
            return GetAnyField(t.GetPrivateFields(), propertyName);
        }

        public static FieldInfo GetInternalField(this Type t, string propertyName)
        {
            return GetAnyField(t.GetInternalFields(), propertyName);
        }

        public static FieldInfo GetProtectedField(this Type t, string propertyName)
        {
            return GetAnyField(t.GetProtectedFields(), propertyName);
        }

        public static FieldInfo GetAnyField(this Type t, string propertyName)
        {
            return GetAnyField(GetAllFields(t), propertyName);
        }

        private static FieldInfo GetAnyField(IEnumerable<FieldInfo> fieldInfo, string propertyName)
        {
            return fieldInfo.First(p => p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
        }
        #endregion

        public static IEnumerable<MethodInfo> GetPublicMethods(this Type t)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<MethodInfo> GetPrivateMethods(this Type t)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<MethodInfo> GetInternalMethods(this Type t)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<string> GetPublicStaticMethods(this Type t)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<string> GetPrivateStaticMethods(this Type t)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<string> GetInternalStaticMethods(this Type t)
        {
            throw new NotImplementedException();
        }
    }
}
