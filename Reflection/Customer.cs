using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
     public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public Customer()
        {

        }
        public Customer(int id)
        {
            this.Id = id;
        }
        public bool Validate()
        {
            return true;
        }

    }
}
