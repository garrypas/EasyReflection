using EasyReflection;
using System.Linq;

namespace System.Collections.Generic
{
    public static class IDictionaryExtensions
    {
        public static TTo ToObject<TTo>(this IDictionary<string, object> dictionary)
            where TTo : new()
        {
            return ToObject<TTo, object>(dictionary);
        }

        public static TTo ToObject<TTo, TValue>(this IDictionary<string, TValue> dictionary)
            where TTo : new()
        {
            var t = new TTo();
            foreach (var prop in typeof(TTo).GetPublicSetters().Select(p => p.Name))
            {
                if (dictionary.ContainsKey(prop))
                {
                    t.SetValue(prop, dictionary[prop]);
                }
            }
            return t;
        }
    }
}
