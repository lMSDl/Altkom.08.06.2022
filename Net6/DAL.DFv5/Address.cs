using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DFv5
{
    public partial class Address
    {
        public Address()
        {
            PeopleAddresses = new HashSet<PeopleAddress>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public virtual ICollection<PeopleAddress> PeopleAddresses { get; set; }
    }
}
