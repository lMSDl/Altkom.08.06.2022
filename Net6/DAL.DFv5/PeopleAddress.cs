using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DFv5
{
    public partial class PeopleAddress
    {
        public int PersonId { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Person Person { get; set; }
    }
}
