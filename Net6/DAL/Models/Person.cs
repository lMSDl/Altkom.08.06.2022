﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Person : Entity
    {

        public string Name { get; set; } = "";
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
    }
}
