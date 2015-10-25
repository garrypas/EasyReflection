using System;
using NUnit.Framework;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using FluentAssertions;
using EasyReflection;

namespace EasyReflectionTests
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        private System.Type type;

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
            Assert.AreEqual("hello world", type.GetGetterSetter("PublicProperty").GetValue(inst, null));
        }

        [Test]
        public void SetsObjectProperty()
        {
            var inst = new TestClass();
            inst.SetValue("PrivateProperty", "hello world");
            Assert.AreEqual("hello world", type.GetGetterSetter("PrivateProperty").GetValue(inst, null));
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

        #region Generic Method Invokation

        [Test]
        public void InvokesInstanceGenericMethod()
        {
            var genericParameters = new Type[] { typeof(int) };
            string result = new TestClass().InvokeGeneric<string>("PublicGenericMethod", genericParameters, 123);
            Assert.AreEqual("PublicGenericMethod:" + typeof(int).ToString() + "123", result);
        }
    
        #endregion

        #region Attributes
        [Test]
        public void GetsAttributes()
        {
            var expectedNames = new[] { "PublicProperty", "PrivateProperty", "ProtectedProperty" };
            var propertyInfoAttributes = new TestClass().GetAttributes<TestAttributeA>()
                .Select(pair => pair.PropertyInfo)
                .GetNames()
                .Should()
                .BeEquivalentTo(expectedNames)
                .And.HaveSameCount(expectedNames);
        }

        [Test]
        public void GetsAttribute()
        {
            new TestClass().GetAttribute<TestAttributeA>("PrivateProperty")
                .Should()
                .OnlyContain(a => a.GetType() == typeof(TestAttributeA))
                .And.HaveCount(1);
        }
        #endregion
    }
}