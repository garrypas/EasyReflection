using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReflectionTests
{
    public class TestClass
    {
        [TestAttributeA]
        [TestAttributeB]
        public string PublicProperty { get; set; }

        [TestAttributeB]
        internal string InternalProperty { get; set; }

        [TestAttributeA]
        private string PrivateProperty { get; set; }

        [TestAttributeA]
        [TestAttributeA]
        [TestAttributeB]
        protected string ProtectedProperty { get; set; }

        public string publicField;

        internal string internalField;

        private string privateField;

        protected string protectedField;

        public string PublicMethod(string concatenate, string to)
        {
            return concatenate + to;
        }

        private int PrivateMethod(int add, int to)
        {
            return add + to;
        }

        internal List<string> InternalMethod(string item1, string item2)
        {
            return new List<string> { item1, item2 };
        }

        protected void ProtectedMethod(List<string> addItemTo)
        {
            addItemTo.Add("newItem");
        }

        public static string PublicStaticMethod(string text, string replace, string with)
        {
            return text.Replace(replace, with);
        }

        private static int PrivateStaticMethod(int add, int to)
        {
            return add + to;
        }

        internal static List<string> InternalStaticMethod(string item1, string item2)
        {
            return new List<string> { item1, item2 };
        }

        protected static void ProtectedStaticMethod(List<string> addItemTo)
        {
            addItemTo.Add("newItemForStatic");
        }
    }
}
