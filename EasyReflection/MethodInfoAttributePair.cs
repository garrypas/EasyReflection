using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyReflection
{
    public class MethodInfoAttributePair<TAttribute> : MemberInfoAttributePair<TAttribute, MethodInfo>
        where TAttribute : Attribute
    {
        public MethodInfoAttributePair(MethodInfo methodInfo, IEnumerable<TAttribute> attributes)
            : base(methodInfo, attributes) { }

        public static implicit operator MemberInfoAttributePair<TAttribute, MemberInfo>(MethodInfoAttributePair<TAttribute> methodInfo)
        {
            return new MemberInfoAttributePair<TAttribute, MemberInfo>(methodInfo.MemberInfo, methodInfo.Attributes);
        }
    }
}
