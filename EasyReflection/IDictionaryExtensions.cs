using System.Linq;

namespace System.Collections.Generic
{
    public static class IDictionaryExtensions
    {
        public static object ToObject(this IDictionary<string, object> dictionary, Type typeTo)
        {
            var obj = Activator.CreateInstance(typeTo);
            ToObjectHelper(typeTo, dictionary, obj);
            return obj;
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
            ToObjectHelper(typeof(TTo), dictionary.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as object), destination);
        }

        private static void ToObjectHelper(Type t, IDictionary<string, object> dictionary, object destination)
        {
            foreach (var prop in t.GetProperties().Where(p => p.GetSetMethod(true).IsPublic))
            {
                if (dictionary.ContainsKey(prop.Name))
                {
                    prop.SetValue(destination, dictionary[prop.Name], null);
                }
            }
        }
    }
}