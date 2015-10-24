using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyReflectionTests
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class TestAttributeA : Attribute
    {
    }
}
