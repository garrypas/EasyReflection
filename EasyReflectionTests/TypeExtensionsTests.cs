using System;
using NUnit.Framework;
using System.Reflection;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;

namespace EasyReflectionTests
{
    [TestFixture]
    public class TypeExtensionsTests
    {
        private Type publicClassType;

        [SetUp]
        public void SetUp()
        {
            this.publicClassType = typeof(TestClass);
        }

        #region Properties (Groups)
        [Test]
        public void GetsPublicGetters()
        {
            var propertyInfo = this.publicClassType.GetPublicGetters();
            propertyInfo.GetNames().Should().Contain("PublicProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateGetters()
        {
            var propertyInfo = this.publicClassType.GetPrivateGetters();
            propertyInfo.GetNames().Should().Contain("PrivateProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsInternalGetters()
        {
            var propertyInfo = this.publicClassType.GetInternalGetters();
            propertyInfo.GetNames().Should().Contain("InternalProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedGetters()
        {
            var propertyInfo = this.publicClassType.GetProtectedGetters();
            propertyInfo.GetNames().Should().Contain("ProtectedProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsPublicSetters()
        {
            var propertyInfo = this.publicClassType.GetPublicSetters();
            propertyInfo.GetNames().Should().Contain("PublicProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateSetters()
        {
            var propertyInfo = this.publicClassType.GetPrivateSetters();
            propertyInfo.GetNames().Should().Contain("PrivateProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsInternalSetters()
        {
            var propertyInfo = this.publicClassType.GetInternalSetters();
            propertyInfo.GetNames().Should().Contain("InternalProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedSetters()
        {
            var propertyInfo = this.publicClassType.GetProtectedSetters();
            propertyInfo.GetNames().Should().Contain("ProtectedProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsGettersAndSetters()
        {
            var propertyInfo = this.publicClassType.GetGettersAndSetters();
            var expectedProperties = new[] { "PublicProperty", "PrivateProperty", "InternalProperty", "ProtectedProperty" };
            propertyInfo.Select(pi => pi.Name).Should().Contain(expectedProperties).And.HaveCount(expectedProperties.Count());
        }
        #endregion

        #region Properties (Individual)
        [Test]
        public void GetsPublicGetter()
        {
            var propertyInfo = this.publicClassType.GetPublicGetter("PublicProperty");
            Assert.AreEqual("PublicProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsPrivateGetter()
        {
            var propertyInfo = this.publicClassType.GetPrivateGetter("PrivateProperty");
            Assert.AreEqual("PrivateProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsInternalGetter()
        {
            var propertyInfo = this.publicClassType.GetInternalGetter("InternalProperty");
            Assert.AreEqual("InternalProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsProtectedGetter()
        {
            var propertyInfo = this.publicClassType.GetProtectedGetter("ProtectedProperty");
            Assert.AreEqual("ProtectedProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsPublicSetter()
        {
            var propertyInfo = this.publicClassType.GetPublicSetter("PublicProperty");
            Assert.AreEqual("PublicProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsPrivateSetter()
        {
            var propertyInfo = this.publicClassType.GetPrivateSetter("PrivateProperty");
            Assert.AreEqual("PrivateProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsInternalSetter()
        {
            var propertyInfo = this.publicClassType.GetInternalSetter("InternalProperty");
            Assert.AreEqual("InternalProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsProtectedSetter()
        {
            var propertyInfo = this.publicClassType.GetProtectedSetter("ProtectedProperty");
            Assert.AreEqual("ProtectedProperty", propertyInfo.Name);
        }
        #endregion

        #region Fields (Groups)
        [Test]
        public void GetsPublicFields()
        {
            var fieldInfo = this.publicClassType.GetPublicFields();
            fieldInfo.GetNames().Should().Contain("publicField").And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateFields()
        {
            var fieldInfo = this.publicClassType.GetPrivateFields();
            fieldInfo.GetNames().Should().Contain("privateField").And.HaveCount(1);
        }

        [Test]
        public void GetsInternalFields()
        {
            var fieldInfo = this.publicClassType.GetInternalFields();
            fieldInfo.GetNames().Should().Contain("internalField").And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedFields()
        {
            var fieldInfo = this.publicClassType.GetProtectedFields();
            fieldInfo.GetNames().Should().Contain("protectedField").And.HaveCount(1);
        }
        #endregion

        #region Fields (Individual)
        [Test]
        public void GetsPublicField()
        {
            var fieldInfo = this.publicClassType.GetPublicField("publicField");
            Assert.AreEqual("publicField", fieldInfo.Name);
        }

        [Test]
        public void GetsPrivateField()
        {
            var fieldInfo = this.publicClassType.GetPrivateField("privateField");
            Assert.AreEqual("privateField", fieldInfo.Name);
        }

        [Test]
        public void GetsInternalField()
        {
            var fieldInfo = this.publicClassType.GetInternalField("internalField");
            Assert.AreEqual("internalField", fieldInfo.Name);
        }

        [Test]
        public void GetsProtectedField()
        {
            var fieldInfo = this.publicClassType.GetProtectedField("protectedField");
            Assert.AreEqual("protectedField", fieldInfo.Name);
        }

        #endregion

        #region Methods (Groups)
        [Test]
        public void GetsPublicMethods()
        {
            var expectedMethodNames = new[] { "PublicMethod", "PublicGenericMethod", "GetType", "ToString", "GetHashCode", "Equals" };
            var methodInfo = this.publicClassType.GetPublicMethods();
            methodInfo.GetNames().Should().BeEquivalentTo(expectedMethodNames).And.HaveSameCount(expectedMethodNames);
        }

        [Test]
        public void GetsPrivateMethods()
        {
            var expectedMethodNames = new[] { "PrivateMethod", "PrivateGenericMethod" };
            var methodInfo = this.publicClassType.GetPrivateMethods();
            methodInfo.GetNames().Should().BeEquivalentTo(expectedMethodNames).And.HaveSameCount(expectedMethodNames);
        }

        [Test]
        public void GetsInternalMethods()
        {
            var expectedMethodNames = new[] { "InternalMethod", "InternalGenericMethod" };
            var methodInfo = this.publicClassType.GetInternalMethods();
            methodInfo.GetNames().Should().BeEquivalentTo(expectedMethodNames).And.HaveSameCount(expectedMethodNames);
        }

        [Test]
        public void GetsProtectedMethods()
        {
            var expectedMethodNames = new[] { "ProtectedMethod", "ProtectedGenericMethod" };
            var methodInfo = this.publicClassType.GetProtectedMethods();
            methodInfo.GetNames().Should().BeEquivalentTo(expectedMethodNames).And.HaveSameCount(expectedMethodNames);
        }
        #endregion

        #region Methods (Individual)
        [Test]
        public void GetsPublicMethod()
        {
            var methodInfo = this.publicClassType.GetPublicMethod("PublicMethod");
            Assert.AreEqual("PublicMethod", methodInfo.Name);
        }

        [Test]
        public void GetsPrivateMethod()
        {
            var methodInfo = this.publicClassType.GetPrivateMethod("PrivateMethod");
            Assert.AreEqual("PrivateMethod", methodInfo.Name);
        }

        [Test]
        public void GetsInternalMethod()
        {
            var methodInfo = this.publicClassType.GetInternalMethod("InternalMethod");
            Assert.AreEqual("InternalMethod", methodInfo.Name);
        }

        [Test]
        public void GetsProtectedMethod()
        {
            var methodInfo = this.publicClassType.GetProtectedMethod("ProtectedMethod");
            Assert.AreEqual("ProtectedMethod", methodInfo.Name);
        }
        #endregion

        #region Static Methods (Groups)
        [Test]
        public void GetsPublicStaticMethods()
        {
            var StaticMethodInfo = this.publicClassType.GetPublicStaticMethods();
            StaticMethodInfo.GetNames().Should().Contain("PublicStaticMethod").And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateStaticMethods()
        {
            var StaticMethodInfo = this.publicClassType.GetPrivateStaticMethods();
            var expectedMethods = new[] { "PrivateStaticMethod", "PrivateStaticGenericMethod" };
            StaticMethodInfo.GetNames().Should().BeEquivalentTo(expectedMethods).And.HaveCount(2);
        }

        [Test]
        public void GetsInternalStaticMethods()
        {
            var StaticMethodInfo = this.publicClassType.GetInternalStaticMethods();
            StaticMethodInfo.GetNames().Should().Contain("InternalStaticMethod").And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedStaticMethods()
        {
            var StaticMethodInfo = this.publicClassType.GetProtectedStaticMethods();
            StaticMethodInfo.GetNames().Should().Contain("ProtectedStaticMethod").And.HaveCount(1);
        }
        #endregion

        #region Static Methods (Individual)
        [Test]
        public void GetsPublicStaticMethod()
        {
            var StaticMethodInfo = this.publicClassType.GetPublicStaticMethod("PublicStaticMethod");
            Assert.AreEqual("PublicStaticMethod", StaticMethodInfo.Name);
        }

        [Test]
        public void GetsPrivateStaticMethod()
        {
            var StaticMethodInfo = this.publicClassType.GetPrivateStaticMethod("PrivateStaticMethod");
            Assert.AreEqual("PrivateStaticMethod", StaticMethodInfo.Name);
        }

        [Test]
        public void GetsInternalStaticMethod()
        {
            var StaticMethodInfo = this.publicClassType.GetInternalStaticMethod("InternalStaticMethod");
            Assert.AreEqual("InternalStaticMethod", StaticMethodInfo.Name);
        }

        [Test]
        public void GetsProtectedStaticMethod()
        {
            var StaticMethodInfo = this.publicClassType.GetProtectedStaticMethod("ProtectedStaticMethod");
            Assert.AreEqual("ProtectedStaticMethod", StaticMethodInfo.Name);
        }
        #endregion

        #region Static Methods (Functionality)
        [Test]
        public void InvokesStaticMethod()
        {
            var inst = new TestClass();
            int result = typeof(TestClass).Invoke<int>("PrivateStaticMethod", 1, 2);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void InvokesStaticGenericMethod()
        {
            var inst = new TestClass();
            var genericParameters = new[] { typeof(int) };
            var result = typeof(TestClass).InvokeGeneric<string>("PrivateStaticGenericMethod", genericParameters, 123);
            Assert.AreEqual("PrivateStaticGenericMethod:" + typeof(int).ToString() + "123", result);
        }

        [Test]
        public void ArgumentStaticPassedByReference()
        {
            var assignTo = new List<string>();
            var expectedList = new[] { "newItemForStatic" };
            typeof(TestClass).Invoke("ProtectedStaticMethod", assignTo);
            assignTo.Should().BeEquivalentTo(expectedList).And.HaveSameCount(expectedList);
        }
        #endregion 

        #region Attributes
        #region Properties (Groups)
        [Test]
        public void GetsPublicGetterAttributes()
        {
            typeof(TestClass).GetPublicGetterAttributes<TestAttributeA>().Select(pair => pair.PropertyInfo)
                .GetNames()
                .Should()
                .Contain("PublicProperty")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateGetterAttributes()
        {
            typeof(TestClass).GetPrivateGetterAttributes<TestAttributeA>()
                .Should()
                .Contain(pair => pair.PropertyInfo.Name == "PrivateProperty")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsInternalGetterAttributes()
        {
            typeof(TestClass).GetInternalGetterAttributes<TestAttributeB>()
                .Should()
                .Contain(pair => pair.PropertyInfo.Name == "InternalProperty")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedGetterAttributes()
        {
            typeof(TestClass).GetProtectedGetterAttributes<TestAttributeA>()
                .Should()
                .Contain(pair => pair.PropertyInfo.Name == "ProtectedProperty")
                .And.Contain(pair => pair.Attributes.Count() == 2)
                .And.HaveCount(1);
        }

        [Test]
        public void GetsPublicSetterAttributes()
        {
            typeof(TestClass).GetPublicSetterAttributes<TestAttributeA>()
                .Select(pair => pair.PropertyInfo)
                .GetNames()
                .Should()
                .Contain("PublicProperty")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateSetterAttributes()
        {
            typeof(TestClass).GetPrivateSetterAttributes<TestAttributeA>()
                .Should()
                .Contain(pair => pair.PropertyInfo.Name == "PrivateProperty")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsInternalSetterAttributes()
        {
            typeof(TestClass).GetInternalSetterAttributes<TestAttributeB>()
                .Should()
                .Contain(pair => pair.PropertyInfo.Name == "InternalProperty")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedSetterAttributes()
        {
            typeof(TestClass).GetProtectedSetterAttributes<TestAttributeA>()
                .Should()
                .Contain(pair => pair.PropertyInfo.Name == "ProtectedProperty")
                .And.Contain(pair => pair.Attributes.Count() == 2)
                .And.HaveCount(1);
        }

        [Test]
        public void GetsAttributes()
        {
            var expectedNames = new [] { "PublicProperty", "PrivateProperty", "ProtectedProperty" };
            var propertyInfoAttributes = typeof(TestClass).GetAttributes<TestAttributeA>()
                .Select(pair => pair.PropertyInfo)
                .GetNames()
                .Should()
                .BeEquivalentTo(expectedNames)
                .And.HaveSameCount(expectedNames);
        }
        #endregion
        
        #region Properties (Individual)
        [Test]
        public void GetsPublicGetterAttribute()
        {
            typeof(TestClass).GetPublicGetterAttributes<TestAttributeA>("PublicProperty")
                .Should()
                .HaveCount(1);
        }

        [Test]
        public void GetsPrivateGetterAttribute()
        {
            typeof(TestClass).GetPrivateGetterAttributes<TestAttributeA>("PrivateProperty")
                .Should()
                .HaveCount(1);
        }

        [Test]
        public void GetsInternalGetterAttribute()
        {
            typeof(TestClass).GetInternalGetterAttributes<TestAttributeB>("InternalProperty")
                .Should()
                .HaveCount(1);
        }

        [Test]
        public void GetsProtectedGetterAttribute()
        {
            typeof(TestClass).GetProtectedGetterAttributes<TestAttributeA>("ProtectedProperty")
                .Should()
                .HaveCount(2);
        }

        [Test]
        public void GetsAttribute()
        {
            typeof(TestClass).GetAttributes<TestAttributeA>("PrivateProperty")
                .Should()
                .OnlyContain(a => a.GetType() == typeof(TestAttributeA))
                .And.HaveCount(1);
        }
        #endregion        
        #endregion
    }
}