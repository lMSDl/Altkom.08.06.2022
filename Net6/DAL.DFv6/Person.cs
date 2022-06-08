using System;
using System.Collections.Generic;

namespace DAL.DFv6
{
    public partial class Person
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
