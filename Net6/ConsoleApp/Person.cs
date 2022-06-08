using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    //public record Person(string FirstName)
    public record class Person(string FirstName)
    {
        //public Person(string firstName)
        //{
        //    FirstName = firstName;
        //}
        //public string? FirstName { get; set; }
        public string? LastName { get; init; }

        public Class? SomeClass { get; set; }
    }

    public record struct Address 
    {
        public Address(string street)
        {
            Street = street;
            PostCode = null;
        }

        public string? Street { get; set; }
        public string? PostCode { get; init; }
    }
}
