using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            inst.Set("PublicProperty", "hello world");
            Assert.AreEqual("hello world", type.GetGetterSetter("PublicProperty").GetValue(inst, null));
        }

        [Test]
        public void SetsObjectProperty()
        {
            var inst = new TestClass();
            inst.Set("PrivateProperty", "hello world");
            Assert.AreEqual("hello world", type.GetGetterSetter("PrivateProperty").GetValue(inst, null));
        }

        [Test]
        public void GetsObjectField()
        {
            var inst = new TestClass();
            inst.Set("PublicField", "hello world");
            Assert.AreEqual("hello world", type.GetAnyField("PublicField").GetValue(inst));
        }

        [Test]
        public void SetsObjectField()
        {
            var inst = new TestClass();
            inst.Set("PrivateField", "hello world");
            Assert.AreEqual("hello world", type.GetAnyField("PrivateField").GetValue(inst));
        }

        #endregion Object Manipulation

        #region Method Invokation

        [Test]
        public void InvokesInstanceMethod()
        {
            string result = new TestClass().Call<string>("PublicMethod", new Type[] { typeof(string), typeof(string) }, new object[] { "a", "b" });
            Assert.AreEqual("ab", result);
        }

        [Test]
        public void ArgumentInstancePassedByReference()
        {
            var assignTo = new List<string>();
            var expectedList = new[] { "newItem" };
            new TestClass().Call("ProtectedMethod", null, assignTo);
            assignTo.Should().BeEquivalentTo(expectedList).And.HaveSameCount(expectedList);
        }

        #endregion Method Invokation

        #region Generic Method Invokation

        [Test]
        public void InvokesInstanceGenericMethod()
        {
            var genericParameters = new[] { typeof(int) };
            string result = new TestClass().CallGeneric<string>("PublicGenericMethod", null, genericParameters, 123);
            Assert.AreEqual("PublicGenericMethod:" + typeof(int) + "123", result);
        }

        #endregion Generic Method Invokation

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

        #endregion Attributes

        #region Functionality

        [Test]
        public void MapsToDictionary()
        {
            var testClass = new TestClass();
            testClass.PublicProperty = "Public Property";
            var dictionary = testClass.ToDictionary();
            dictionary.ShouldBeEquivalentTo(new Dictionary<string, object> { { "PublicProperty", testClass.PublicProperty } });
#if DEBUG
            dictionary.ExecutionTimeOf(d => d.ToObject(typeof(TestClass))).ShouldNotExceed(TimeSpan.FromMilliseconds(2));
#endif
        }

        #endregion Functionality
    }
}