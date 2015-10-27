using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyReflection
{
    public class MemberInfoAttributePair<TAttribute, TMemberInfo>
        where TAttribute : Attribute
        where TMemberInfo : MemberInfo
    {
        public MemberInfoAttributePair(TMemberInfo memberInfo, IEnumerable<TAttribute> attributes)
        {
            this.MemberInfo = memberInfo;
            this.Attributes = attributes;
        }

        public TMemberInfo MemberInfo { get; private set; }

        public IEnumerable<TAttribute> Attributes { get; private set; }
    }
}
