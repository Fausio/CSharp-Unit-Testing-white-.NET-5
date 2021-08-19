using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.Models
{
    public class PersonManager
    {
        public Person CreatePerson(string fname, string lname, bool IsSupervisor)
        {
            Person person = null;

            if (!string.IsNullOrEmpty(fname))
            {
                if (IsSupervisor)
                {
                    person = new Supervisor();
                }
                else
                {
                    person = new Employee();
                }

                // generic props
                person.FirstName = "Fausio ";
                person.LastName = "Luis ";
            }

            return person;
        }
    }
}
