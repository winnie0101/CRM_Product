using System;
using System.ComponentModel;

namespace CRM_side_project.Utility
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class InjectionAttribute : Attribute
    {
        [Description("sortting Index")]
        [DefaultValue(0)]
        public int Index;
        public InjectionAttribute() { }
        public InjectionAttribute(int index)
        {
            Index = index;
        }
    }
}
