using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Address : Entity
    {
        public string Street { get; set; } = "";
        public string City { get; set; } = "";


        public IEnumerable<Person> People { get; set; } = new List<Person>();
    }
}
