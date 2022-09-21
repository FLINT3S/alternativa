using System;

namespace AbstractResource.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NeedVipRightsAttribute : Attribute
    {
        public int Level { get; }

        public NeedVipRightsAttribute(int level = 1)
        {
            Level = level;
        }
    }
}