using System.Linq;
using EasyReflection;

namespace System.Collections.Generic
{
    public static class IDictionaryExtensions
    {
        public static object ToObject(this IDictionary<string, object> dictionary, Type typeTo)
        {
            var invokeGeneric = typeof(IDictionaryExtensions).GetPublicStaticMethod("ToObject", new[] { typeof(IDictionary<string, object>) });
            return invokeGeneric.MakeGenericMethod(new[] { typeTo }).Invoke(null, new object[] { dictionary });
        }

        public static TTo ToObject<TTo>(this IDictionary<string, object> dictionary)
            where TTo : new()
        {
            var obj = new TTo();
            ToObject<TTo, object>(dictionary, obj);
            return obj;
        }

        public static void ToObject<TTo>(this IDictionary<string, object> dictionary, TTo destination)
            where TTo : new()
        {
            ToObject<TTo, object>(dictionary, destination);
        }

        public static TTo ToObject<TTo, TValue>(this IDictionary<string, TValue> dictionary)
            where TTo : new()
        {
            var obj = new TTo();
            ToObject(dictionary, obj);
            return obj;
        }

        public static void ToObject<TTo, TValue>(this IDictionary<string, TValue> dictionary, TTo destination)
            where TTo : new()
        {
            foreach (var prop in typeof(TTo).GetProperties().Where(p => p.GetSetMethod(true).IsPublic))
            {
                if (dictionary.ContainsKey(prop.Name))
                {
                    prop.SetValue(destination, dictionary[prop.Name], null);
                }
            }
        }
    }
}
