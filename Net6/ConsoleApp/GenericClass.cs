using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public abstract class GenericClass<T> where T : class?
    {
        public T? Value { get; set; }

    }

    public class StringClass : GenericClass<string?>
    {


        public StringClass(string value!!)
        {
            //if(value == null)
            //    throw new ArgumentNullException("value");

            Value = value;
        }

    }
}
