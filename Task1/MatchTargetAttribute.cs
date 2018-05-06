using System;

namespace Task1
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MatchTargetAttribute : Attribute
    {
        public readonly string TargetPropertyName;
        public MatchTargetAttribute(string targetPropertyName)
        {
            TargetPropertyName = targetPropertyName;
        }
    }
}