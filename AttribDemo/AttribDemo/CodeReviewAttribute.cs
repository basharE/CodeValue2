using System;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]   
    public sealed class CodeReviewAttribute: Attribute
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public bool IsApproved { get; set; }

        public CodeReviewAttribute(string name, string date, bool isApproved)
        {
            Name = name;
            Date = date;
            IsApproved = isApproved;
        }
    }
}
