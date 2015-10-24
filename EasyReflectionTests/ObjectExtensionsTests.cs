using System;
using NUnit.Framework;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using FluentAssertions;

namespace EasyReflectionTests
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        private Type type;

        [SetUp]
        public void SetUp()
        {
            type = typeof(TestClass);
        }

        #region Object Manipulation
        [Test]
        public void GetsObjectProperty()
        {
            var inst = new TestClass();
            inst.SetValue("PublicProperty", "hello world");
            Assert.AreEqual("hello world", type.GetAnyProperty("PublicProperty").GetValue(inst, null));
        }

        [Test]
        public void SetsObjectProperty()
        {
            var inst = new TestClass();
            inst.SetValue("PrivateProperty", "hello world");
            Assert.AreEqual("hello world", type.GetAnyProperty("PrivateProperty").GetValue(inst, null));
        }

        [Test]
        public void GetsObjectField()
        {
            var inst = new TestClass();
            inst.SetValue("PublicField", "hello world");
            Assert.AreEqual("hello world", type.GetAnyField("PublicField").GetValue(inst));
        }

        [Test]
        public void SetsObjectField()
        {
            var inst = new TestClass();
            inst.SetValue("PrivateField", "hello world");
            Assert.AreEqual("hello world", type.GetAnyField("PrivateField").GetValue(inst));
        }
        #endregion

        #region Method Invokation

        [Test]
        public void InvokesInstanceMethod()
        {
            string result = new TestClass().Invoke<string>("PublicMethod", "a", "b");
            Assert.AreEqual("ab", result);
        }

        [Test]
        public void ArgumentInstancePassedByReference()
        {
            var assignTo = new List<string>();
            var expectedList = new[] { "newItem" };
            new TestClass().Invoke("ProtectedMethod", assignTo);
            assignTo.Should().BeEquivalentTo(expectedList).And.HaveSameCount(expectedList);
        }

        #endregion
    }
}