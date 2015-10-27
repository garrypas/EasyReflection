using System.Collections.Generic;
using EasyReflection;
using NUnit.Framework;

namespace EasyReflectionTests
{
    [TestFixture]
    public class DictionaryExtensionsTests
    {
        [Test]
        public void MapsFromDictionary()
        {
            var dictionary = new Dictionary<string, object> { { "PublicProperty", "Public Property" }, { "IgnoreMe", "la la la"} };
            var testClass = dictionary.ToObject<TestClass>();
            Assert.AreEqual("Public Property", testClass.PublicProperty);
        }
    }
}
