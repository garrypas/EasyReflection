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
    public class PropertyInfoAttributePairExtensionsTests
    {
        [Test]
        public void GetsAttributes()
        {
            var expectedNames = new[] { "PublicProperty", "PrivateProperty", "ProtectedProperty" };
            var propertyInfoAttributes = new TestClass().GetPropertyAttributes<TestAttributeA>()
                .Keyed()
                .Select(keyed => keyed.Key)
                .Should()
                .BeEquivalentTo(expectedNames)
                .And.HaveSameCount(expectedNames);
        }
    }
}