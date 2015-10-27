using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyReflection
{
    public class PropertyInfoAttributePair<TAttribute> : MemberInfoAttributePair<TAttribute, PropertyInfo>
        where TAttribute : Attribute
    {
        public PropertyInfoAttributePair(PropertyInfo propertyInfo, IEnumerable<TAttribute> attributes)
            : base(propertyInfo, attributes) { }

        public static implicit operator MemberInfoAttributePair<TAttribute, MemberInfo>(PropertyInfoAttributePair<TAttribute> pi)
        {
            return new MemberInfoAttributePair<TAttribute,MemberInfo>(pi.MemberInfo, pi.Attributes);
        }
    }
}
