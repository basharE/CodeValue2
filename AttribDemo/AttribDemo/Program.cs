using System;
using System.Reflection;

namespace AttribDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(AnalayzeAssembly(Assembly.GetExecutingAssembly()));
            Console.WriteLine(AnalayzeAssembly(Assembly.GetCallingAssembly()));
            Console.WriteLine(AnalayzeAssembly(Assembly.GetEntryAssembly()));
            // It's returns the same result when we pass other assembly 
            // like the result when we pass "Assembly.GetExecutingAssembly()"
        }

        public static bool AnalayzeAssembly(Assembly obj)
        {
            bool flag = true;
            var types = obj.GetTypes();
            
            foreach (var type in types)
            {
                if(type.IsDefined(typeof(CodeReviewAttribute)))
                {
                    var myAttribute = (CodeReviewAttribute)type.GetCustomAttribute(typeof(CodeReviewAttribute));
                    if (myAttribute.IsApproved)
                    {
                        Console.WriteLine(myAttribute.Name+" , "+ myAttribute.Date+" , "+ myAttribute.IsApproved);
                    }
                    else
                    {
                        flag = false;
                    }                   
                }
            }
            return flag;
        }
    }
}
