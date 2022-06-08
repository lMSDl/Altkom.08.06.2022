using System;
using System.Collections.Generic;

namespace DAL.DFv6
{
    public partial class Address
    {
        public Address()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
