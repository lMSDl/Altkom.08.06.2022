using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DFv5
{
    public partial class Person
    {
        public Person()
        {
            PeopleAddresses = new HashSet<PeopleAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PeopleAddress> PeopleAddresses { get; set; }
    }
}
