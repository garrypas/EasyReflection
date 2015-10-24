using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FluentAssertions;

namespace EasyReflectionTests
{
    [TestFixture]
    public class MemberInfoExtensionsTests
    {
        private Type type;

        [SetUp]
        public void SetUp()
        {
            this.type = typeof(TestClass);
        }

        [Test]
        public void PropertyInfoGetNamesReturnsNames()
        {
            var names = type.GetGettersAndSetters().GetNames();
            var expectedGettersAndSetters = new[] { "PublicProperty", "PrivateProperty", "ProtectedProperty", "InternalProperty" };
            names.Should().Contain(expectedGettersAndSetters).And.HaveCount(expectedGettersAndSetters.Count());
        }

        [Test]
        public void FieldInfoGetNamesReturnsNames()
        {
            var names = type.GetAllFields().GetNames();
            var expectedFields = new[] { "publicField", "privateField", "protectedField", "internalField" };
            names.Should().Contain(expectedFields).And.HaveCount(expectedFields.Count());
        }
    }
}
