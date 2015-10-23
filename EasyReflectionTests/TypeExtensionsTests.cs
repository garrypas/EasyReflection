using System;
using NUnit.Framework;
using System.Reflection;
using System.Linq;

namespace EasyReflectionTests
{
    [TestFixture]
    public class TypeExtensionsTests
    {
        private Type publicClassType;

        [SetUp]
        public void SetUp()
        {
            this.publicClassType = typeof(PublicClass);
        }

        #region Properties (Groups)
        [Test]
        public void GetsPublicGetters()
        {
            var propertyInfo = this.publicClassType.GetPublicGetters();
            Assert.AreEqual(1, propertyInfo.Count());
            Assert.AreEqual("PublicProperty", propertyInfo.First().Name);
        }

        [Test]
        public void GetsPrivateGetters()
        {
            var propertyInfo = this.publicClassType.GetPrivateGetters();
            Assert.AreEqual(1, propertyInfo.Count());
            Assert.AreEqual("PrivateProperty", propertyInfo.First().Name);
        }

        [Test]
        public void GetsInternalGetters()
        {
            var propertyInfo = this.publicClassType.GetInternalGetters();
            Assert.AreEqual(1, propertyInfo.Count());
            Assert.AreEqual("InternalProperty", propertyInfo.First().Name);
        }

        [Test]
        public void GetsProtectedGetters()
        {
            var propertyInfo = this.publicClassType.GetProtectedGetters();
            Assert.AreEqual(1, propertyInfo.Count());
            Assert.AreEqual("ProtectedProperty", propertyInfo.First().Name);
        }

        [Test]
        public void GetsPublicSetters()
        {
            var propertyInfo = this.publicClassType.GetPublicSetters();
            Assert.AreEqual(1, propertyInfo.Count());
            Assert.AreEqual("PublicProperty", propertyInfo.First().Name);
        }

        [Test]
        public void GetsPrivateSetters()
        {
            var propertyInfo = this.publicClassType.GetPrivateSetters();
            Assert.AreEqual(1, propertyInfo.Count());
            Assert.AreEqual("PrivateProperty", propertyInfo.First().Name);
        }

        [Test]
        public void GetsInternalSetters()
        {
            var propertyInfo = this.publicClassType.GetInternalSetters();
            Assert.AreEqual(1, propertyInfo.Count());
            Assert.AreEqual("InternalProperty", propertyInfo.First().Name);
        }

        [Test]
        public void GetsProtectedSetters()
        {
            var propertyInfo = this.publicClassType.GetProtectedSetters();
            Assert.AreEqual(1, propertyInfo.Count());
            Assert.AreEqual("ProtectedProperty", propertyInfo.First().Name);
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
            Assert.AreEqual(1, fieldInfo.Count());
            Assert.AreEqual("publicField", fieldInfo.First().Name);
        }

        [Test]
        public void GetsPrivateFields()
        {
            var fieldInfo = this.publicClassType.GetPrivateFields();
            Assert.AreEqual(1, fieldInfo.Count());
            Assert.AreEqual("privateField", fieldInfo.First().Name);
        }

        [Test]
        public void GetsInternalFields()
        {
            var fieldInfo = this.publicClassType.GetInternalFields();
            Assert.AreEqual(1, fieldInfo.Count());
            Assert.AreEqual("internalField", fieldInfo.First().Name);
        }

        [Test]
        public void GetsProtectedFields()
        {
            var fieldInfo = this.publicClassType.GetProtectedFields();
            Assert.AreEqual(1, fieldInfo.Count());
            Assert.AreEqual("protectedField", fieldInfo.First().Name);
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
    }
}