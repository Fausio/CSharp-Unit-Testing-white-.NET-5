using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.Models
{
    public  class Supervisor : Person
    {
        public bool IsSupervisor { get; set; }
        public IEnumerable<Person> Properties()
        { 
            return new List<Person>() ;
        }
    }
}
