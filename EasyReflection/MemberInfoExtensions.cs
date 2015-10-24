using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Reflection
{
    public static class MemberInfoExtensions
    {
        public static IEnumerable<string> GetNames(this IEnumerable<MemberInfo> memberInfo)
        {
            return memberInfo.Select(pi => pi.Name);
        }
    }
}
