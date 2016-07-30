using System;

namespace CustomerApp
{
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public Customer(string name, int id, string address)
        {
            Name = name;
            Id = id;
            Address = address;
        }

        public Customer(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public string Address { get; set; }


        public int CompareTo(Customer other)
        {
            if (other == null) return 1;
            string name1 = Name.ToLower();
            string name2 = other.Name.ToLower();
            return name1.CompareTo(name2);
        }

        public bool Equals(Customer other)
        {
            if (other == null)
                return false;
            string name1 = Name.ToLower();
            string name2 = other.Name.ToLower();
            if (name1 == name2)
            {
                if (Id == other.Id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}
