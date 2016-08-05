using System;

namespace AttribDemo
{
    //It is very likely that a class will be decorated by more than one of these, yet your implementation does not allow it
    //Consider: [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]   
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
