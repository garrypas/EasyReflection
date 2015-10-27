using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyReflection
{
    public class FieldInfoAttributePair<TAttribute> : MemberInfoAttributePair<TAttribute, FieldInfo>
        where TAttribute : Attribute
    {
        public FieldInfoAttributePair(FieldInfo fieldInfo, IEnumerable<TAttribute> attributes)
            : base(fieldInfo, attributes) { }

        public static implicit operator MemberInfoAttributePair<TAttribute, MemberInfo>(FieldInfoAttributePair<TAttribute> pi)
        {
            return new MemberInfoAttributePair<TAttribute, MemberInfo>(pi.MemberInfo, pi.Attributes);
        }
    }
}
