using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReflectionTests
{
    public class PublicClass
    {
        public string PublicProperty { get; set; }
        
        internal string InternalProperty { get; set; }

        private string PrivateProperty { get; set; }

        protected string ProtectedProperty { get; set; }
    }
}
