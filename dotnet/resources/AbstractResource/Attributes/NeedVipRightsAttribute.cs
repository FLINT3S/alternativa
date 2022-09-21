using System;

namespace AbstractResource.Annotations
{
    public class NeedVipRightsAttribute : Attribute
    {
        public int Level { get; }

        public NeedVipRightsAttribute(int level = 1)
        {
            Level = level;
        }
    }
}