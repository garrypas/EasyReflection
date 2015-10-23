using System;
using NUnit.Framework;
using System.Reflection;
using System.Linq;

namespace EasyReflectionTests
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        #region object manipulation
        [Test]
        public void GetsObjectProperty()
        {
            var inst = new PublicClass();
            inst.SetValue("PublicProperty", "hello world");
            Assert.AreEqual("hello world", typeof(PublicClass).GetAnyProperty("PublicProperty").GetValue(inst, null));
        }

        [Test]
        public void SetsObjectProperty()
        {
            var inst = new PublicClass();
            inst.SetValue("PrivateProperty", "hello world");
            Assert.AreEqual("hello world", typeof(PublicClass).GetAnyProperty("PrivateProperty").GetValue(inst, null));
        }

        [Test]
        public void GetsObjectField()
        {
            var inst = new PublicClass();
            inst.SetValue("PublicField", "hello world");
            Assert.AreEqual("hello world", typeof(PublicClass).GetAnyField("PublicField").GetValue(inst));
        }

        [Test]
        public void SetsObjectField()
        {
            var inst = new PublicClass();
            inst.SetValue("PrivateField", "hello world");
            Assert.AreEqual("hello world", typeof(PublicClass).GetAnyField("PrivateField").GetValue(inst));
        }
        #endregion
    }
}