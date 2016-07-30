using System;
using System.Reflection;


namespace DynInvoke
{
    class Program
    {
        static void Main()
        {
            A a = new A();
            B b = new B();
            C c = new C();
            InvokeHello(a,"aA");
            InvokeHello(b, "bB");
            InvokeHello(c, "cC");
        }

        public static void InvokeHello(object a, string b)
        {
            Type type = a.GetType();
            object instance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod("Hello");
            Console.WriteLine(method.Invoke(instance,new object[]{b}));
        }
    }
}
