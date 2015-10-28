using System.Reflection;

namespace EasyReflection
{
    internal static class BackingFields
    {
        private const string BackingFieldStart = "<";

        private const string BackingFieldEnd = "__BackingField";

        internal static bool IsNotBackingField(FieldInfo fieldInfo)
        {
            return fieldInfo.Name.StartsWith(BackingFieldStart) == false && fieldInfo.Name.EndsWith(BackingFieldEnd) == false;
        }
    }
}