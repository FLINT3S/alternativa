using System;

namespace AbstractResource.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NeedAdminRightAttribute : Attribute
    {
        public int Level { get; }

        public NeedAdminRightAttribute(int level = 0)
        {
            Level = level;
        }
    }
}