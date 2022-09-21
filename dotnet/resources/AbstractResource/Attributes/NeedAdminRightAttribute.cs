using System;

namespace AbstractResource.Annotations
{
    public class NeedAdminRightAttribute : Attribute
    {
        public int Level { get; }

        public NeedAdminRightAttribute(int level = 0)
        {
            Level = level;
        }
    }
}