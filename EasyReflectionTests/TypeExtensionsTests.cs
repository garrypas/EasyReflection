using System;
using NUnit.Framework;
using System.Reflection;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using EasyReflection;

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

        #region Static Properties (Groups)
        [Test]
        public void GetsPublicStaticGetters()
        {
            var propertyInfo = this.publicClassType.GetPublicStaticGetters();
            propertyInfo.GetNames().Should().Contain("PublicStaticProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateStaticGetters()
        {
            var propertyInfo = this.publicClassType.GetPrivateStaticGetters();
            propertyInfo.GetNames().Should().Contain("PrivateStaticProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsInternalStaticGetters()
        {
            var propertyInfo = this.publicClassType.GetInternalStaticGetters();
            propertyInfo.GetNames().Should().Contain("InternalStaticProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedStaticGetters()
        {
            var propertyInfo = this.publicClassType.GetProtectedStaticGetters();
            propertyInfo.GetNames().Should().Contain("ProtectedStaticProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsPublicStaticSetters()
        {
            var propertyInfo = this.publicClassType.GetPublicStaticSetters();
            propertyInfo.GetNames().Should().Contain("PublicStaticProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateStaticSetters()
        {
            var propertyInfo = this.publicClassType.GetPrivateStaticSetters();
            propertyInfo.GetNames().Should().Contain("PrivateStaticProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsInternalStaticSetters()
        {
            var propertyInfo = this.publicClassType.GetInternalStaticSetters();
            propertyInfo.GetNames().Should().Contain("InternalStaticProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedStaticSetters()
        {
            var propertyInfo = this.publicClassType.GetProtectedStaticSetters();
            propertyInfo.GetNames().Should().Contain("ProtectedStaticProperty").And.HaveCount(1);
        }

        [Test]
        public void GetsStaticGettersAndSetters()
        {
            var propertyInfo = this.publicClassType.GetStaticGettersAndSetters();
            var expectedProperties = new[] { "PublicStaticProperty", "PrivateStaticProperty", "InternalStaticProperty", "ProtectedStaticProperty" };
            propertyInfo.Select(pi => pi.Name).Should().Contain(expectedProperties).And.HaveCount(expectedProperties.Count());
        }
        #endregion

        #region Static Properties (Individual)
        [Test]
        public void GetsPublicStaticGetter()
        {
            var propertyInfo = this.publicClassType.GetPublicStaticGetter("PublicStaticProperty");
            Assert.AreEqual("PublicStaticProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsPrivateStaticGetter()
        {
            var propertyInfo = this.publicClassType.GetPrivateStaticGetter("PrivateStaticProperty");
            Assert.AreEqual("PrivateStaticProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsInternalStaticGetter()
        {
            var propertyInfo = this.publicClassType.GetInternalStaticGetter("InternalStaticProperty");
            Assert.AreEqual("InternalStaticProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsProtectedStaticGetter()
        {
            var propertyInfo = this.publicClassType.GetProtectedStaticGetter("ProtectedStaticProperty");
            Assert.AreEqual("ProtectedStaticProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsPublicStaticSetter()
        {
            var propertyInfo = this.publicClassType.GetPublicStaticSetter("PublicStaticProperty");
            Assert.AreEqual("PublicStaticProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsPrivateStaticSetter()
        {
            var propertyInfo = this.publicClassType.GetPrivateStaticSetter("PrivateStaticProperty");
            Assert.AreEqual("PrivateStaticProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsInternalStaticSetter()
        {
            var propertyInfo = this.publicClassType.GetInternalStaticSetter("InternalStaticProperty");
            Assert.AreEqual("InternalStaticProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsProtectedStaticSetter()
        {
            var propertyInfo = this.publicClassType.GetProtectedStaticSetter("ProtectedStaticProperty");
            Assert.AreEqual("ProtectedStaticProperty", propertyInfo.Name);
        }

        [Test]
        public void GetsAnyStaticProperty()
        {
            var propertyInfo = this.publicClassType.GetAnyStaticProperty("PrivateStaticProperty");
            Assert.AreEqual("PrivateStaticProperty", propertyInfo.Name);
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

        #region Static Fields (Groups)
        [Test]
        public void GetsPublicStaticFields()
        {
            var fieldInfo = this.publicClassType.GetPublicStaticFields();
            fieldInfo.GetNames().Should().Contain("publicStaticField").And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateStaticFields()
        {
            var fieldInfo = this.publicClassType.GetPrivateStaticFields();
            fieldInfo.GetNames().Should().Contain("privateStaticField").And.HaveCount(1);
        }

        [Test]
        public void GetsInternalStaticFields()
        {
            var fieldInfo = this.publicClassType.GetInternalStaticFields();
            fieldInfo.GetNames().Should().Contain("internalStaticField").And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedStaticFields()
        {
            var fieldInfo = this.publicClassType.GetProtectedStaticFields();
            fieldInfo.GetNames().Should().Contain("protectedStaticField").And.HaveCount(1);
        }
        #endregion

        #region Static Fields (Individual)
        [Test]
        public void GetsPublicStaticField()
        {
            var fieldInfo = this.publicClassType.GetPublicStaticField("publicStaticField");
            Assert.AreEqual("publicStaticField", fieldInfo.Name);
        }

        [Test]
        public void GetsPrivateStaticField()
        {
            var fieldInfo = this.publicClassType.GetPrivateStaticField("privateStaticField");
            Assert.AreEqual("privateStaticField", fieldInfo.Name);
        }

        [Test]
        public void GetsInternalStaticField()
        {
            var fieldInfo = this.publicClassType.GetInternalStaticField("internalStaticField");
            Assert.AreEqual("internalStaticField", fieldInfo.Name);
        }

        [Test]
        public void GetsProtectedStaticField()
        {
            var fieldInfo = this.publicClassType.GetProtectedStaticField("protectedStaticField");
            Assert.AreEqual("protectedStaticField", fieldInfo.Name);
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
            typeof(TestClass).GetPublicGetterAttributes<TestAttributeA>().Select(pair => pair.MemberInfo)
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
                .Contain(pair => pair.MemberInfo.Name == "PrivateProperty")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsInternalGetterAttributes()
        {
            typeof(TestClass).GetInternalGetterAttributes<TestAttributeB>()
                .Should()
                .Contain(pair => pair.MemberInfo.Name == "InternalProperty")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedGetterAttributes()
        {
            typeof(TestClass).GetProtectedGetterAttributes<TestAttributeA>()
                .Should()
                .Contain(pair => pair.MemberInfo.Name == "ProtectedProperty")
                .And.Contain(pair => pair.Attributes.Count() == 2)
                .And.HaveCount(1);
        }

        [Test]
        public void GetsPublicSetterAttributes()
        {
            typeof(TestClass).GetPublicSetterAttributes<TestAttributeA>()
                .Select(pair => pair.MemberInfo)
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
                .Contain(pair => pair.MemberInfo.Name == "PrivateProperty")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsInternalSetterAttributes()
        {
            typeof(TestClass).GetInternalSetterAttributes<TestAttributeB>()
                .Should()
                .Contain(pair => pair.MemberInfo.Name == "InternalProperty")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedSetterAttributes()
        {
            typeof(TestClass).GetProtectedSetterAttributes<TestAttributeA>()
                .Should()
                .Contain(pair => pair.MemberInfo.Name == "ProtectedProperty")
                .And.Contain(pair => pair.Attributes.Count() == 2)
                .And.HaveCount(1);
        }

        [Test]
        public void GetsPropertyAttributes()
        {
            var expectedNames = new [] { "PublicProperty", "PrivateProperty", "ProtectedProperty" };
            var propertyInfoAttributes = typeof(TestClass).GetPropertyAttributes<TestAttributeA>()
                .Select(pair => pair.MemberInfo)
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
        public void GetsPropertyAttribute()
        {
            typeof(TestClass).GetPropertyAttribute<TestAttributeA>("PrivateProperty")
                .Should()
                .OnlyContain(a => a.GetType() == typeof(TestAttributeA))
                .And.HaveCount(1);
        }
        #endregion        

        #region Fields (Groups)
        [Test]
        public void GetsPublicFieldAttributes()
        {
            typeof(TestClass).GetPublicFieldAttributes<TestAttributeA>().Select(pair => pair.MemberInfo)
                .GetNames()
                .Should()
                .Contain("publicField")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateFieldAttributes()
        {
            typeof(TestClass).GetPrivateFieldAttributes<TestAttributeA>()
                .Should()
                .Contain(pair => pair.MemberInfo.Name == "privateField")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsInternalFieldAttributes()
        {
            typeof(TestClass).GetInternalFieldAttributes<TestAttributeB>()
                .Should()
                .Contain(pair => pair.MemberInfo.Name == "internalField")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedFieldAttributes()
        {
            typeof(TestClass).GetProtectedFieldAttributes<TestAttributeA>()
                .Should()
                .Contain(pair => pair.MemberInfo.Name == "protectedField")
                .And.Contain(pair => pair.Attributes.Count() == 2)
                .And.HaveCount(1);
        }

        [Test]
        public void GetsFieldAttributes()
        {
            var expectedNames = new[] { "publicField", "privateField", "protectedField" };
            var fieldInfoAttributes = typeof(TestClass).GetFieldAttributes<TestAttributeA>()
                .Select(pair => pair.MemberInfo)
                .GetNames()
                .Should()
                .BeEquivalentTo(expectedNames)
                .And.HaveSameCount(expectedNames);
        }
        #endregion

        #region Fields (Individual)
        [Test]
        public void GetsPublicFieldAttribute()
        {
            typeof(TestClass).GetPublicFieldAttributes<TestAttributeA>("publicField")
                .Should()
                .HaveCount(1);
        }

        [Test]
        public void GetsPrivateFieldAttribute()
        {
            typeof(TestClass).GetPrivateFieldAttributes<TestAttributeA>("privateField")
                .Should()
                .HaveCount(1);
        }

        [Test]
        public void GetsInternalFieldAttribute()
        {
            typeof(TestClass).GetInternalFieldAttributes<TestAttributeB>("internalField")
                .Should()
                .HaveCount(1);
        }

        [Test]
        public void GetsProtectedFieldAttribute()
        {
            typeof(TestClass).GetProtectedFieldAttributes<TestAttributeA>("protectedField")
                .Should()
                .HaveCount(2);
        }

        [Test]
        public void GetsFieldAttribute()
        {
            typeof(TestClass).GetFieldAttribute<TestAttributeA>("privateField")
                .Should()
                .OnlyContain(a => a.GetType() == typeof(TestAttributeA))
                .And.HaveCount(1);
        }
        #endregion

        #region Methods (Groups)
        [Test]
        public void GetsPublicMethodAttributes()
        {
            typeof(TestClass).GetPublicMethodAttributes<TestAttributeA>().Select(pair => pair.MemberInfo)
                .GetNames()
                .Should()
                .Contain("PublicMethod")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsPrivateMethodAttributes()
        {
            typeof(TestClass).GetPrivateMethodAttributes<TestAttributeA>()
                .Should()
                .Contain(pair => pair.MemberInfo.Name == "PrivateMethod")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsInternalMethodAttributes()
        {
            typeof(TestClass).GetInternalMethodAttributes<TestAttributeB>()
                .Should()
                .Contain(pair => pair.MemberInfo.Name == "InternalMethod")
                .And.HaveCount(1);
        }

        [Test]
        public void GetsProtectedMethodAttributes()
        {
            typeof(TestClass).GetProtectedMethodAttributes<TestAttributeA>()
                .Should()
                .Contain(pair => pair.MemberInfo.Name == "ProtectedMethod")
                .And.Contain(pair => pair.Attributes.Count() == 2)
                .And.HaveCount(1);
        }

        [Test]
        public void GetsMethodAttributes()
        {
            var expectedNames = new[] { "PublicMethod", "PrivateMethod", "ProtectedMethod" };
            var methodInfoAttributes = typeof(TestClass).GetMethodAttributes<TestAttributeA>()
                .Select(pair => pair.MemberInfo)
                .GetNames()
                .Should()
                .BeEquivalentTo(expectedNames)
                .And.HaveSameCount(expectedNames);
        }
        #endregion

        #region Methods (Individual)
        [Test]
        public void GetsPublicMethodAttribute()
        {
            typeof(TestClass).GetPublicMethodAttributes<TestAttributeA>("PublicMethod")
                .Should()
                .HaveCount(1);
        }

        [Test]
        public void GetsPrivateMethodAttribute()
        {
            typeof(TestClass).GetPrivateMethodAttributes<TestAttributeA>("PrivateMethod")
                .Should()
                .HaveCount(1);
        }

        [Test]
        public void GetsInternalMethodAttribute()
        {
            typeof(TestClass).GetInternalMethodAttributes<TestAttributeB>("InternalMethod")
                .Should()
                .HaveCount(1);
        }

        [Test]
        public void GetsProtectedMethodAttribute()
        {
            typeof(TestClass).GetProtectedMethodAttributes<TestAttributeA>("ProtectedMethod")
                .Should()
                .HaveCount(2);
        }

        [Test]
        public void GetsMethodAttribute()
        {
            typeof(TestClass).GetMethodAttribute<TestAttributeA>("PrivateMethod")
                .Should()
                .OnlyContain(a => a.GetType() == typeof(TestAttributeA))
                .And.HaveCount(1);
        }
        #endregion

        #region All
        [Test]
        public void GetsAttributes()
        {
            var expected = new[] { "PublicProperty", "PrivateProperty", "ProtectedProperty", "publicField", "privateField", "protectedField", "PublicMethod", "PrivateMethod", "ProtectedMethod" };

            new TestClass().GetAttributes<TestAttributeA>()
                .Select(pair => pair.MemberInfo)
                .GetNames()
                .Should()
                .BeEquivalentTo(expected);
        }
        #endregion
        #endregion
    }
}