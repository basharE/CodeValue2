using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CustomerApp
{
    internal delegate bool CustomerFilter(Customer customer);

    class Program
    {
        static void Main()
        {
            Customer[] a = new Customer[] { new Customer("ABC", 55), new Customer("abc", 12), new Customer("Zde", 13), new Customer("BCD", 5), new Customer("KbcD", 1) };

            foreach (Customer s in a)
            {
                Console.WriteLine(s.Name);
            }

            Array.Sort(a);

            Console.WriteLine("after sort :-----");

            foreach (Customer s in a)
            {
                Console.WriteLine(s.Name);
            }

            Console.WriteLine("-----");
            Console.WriteLine((new Customer("ABC", 12)).Equals(new Customer("abc", 12)));
            Console.WriteLine((new Customer("abc", 12)).Equals(new Customer("abc", 12)));
            Console.WriteLine((new Customer("ABC", 13)).Equals(new Customer("abc", 12)));
            Console.WriteLine("-----");
            IComparer<Customer> comp = new AnotherCustomerComparer();

            Array.Sort(a, comp);

            foreach (Customer s in a)
            {
                Console.WriteLine(s.Name);
            }


            ICollection<Customer> c = GetCustomers(a, AkFilter);
            foreach (Customer s in c)
            {
                Console.WriteLine(s.Name);
            }
        }

        static List<Customer> GetCustomers(Customer[] collection, CustomerFilter filter)
        {
            List<Customer> customers = new List<Customer> {};

            foreach (var a in collection)
            {
                CustomerFilter f1 =new CustomerFilter(AkFilter);
                CustomerFilter f2 = delegate(Customer customer)
                {
                    return Regex.IsMatch(customer.Name, "^[L-Z]");
                };
                CustomerFilter f3 = n => n.Id > 5 ;
                if (f3(a))
                {
                    customers.Add(a);
                }
            }
            return customers;
        }

        private static bool AkFilter(Customer customer)
        {
            return Regex.IsMatch(customer.Name, "^[A-K]");
        } 
    }
}
