using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.Models
{
    public class PersonManager
    {

        public List<Person> GetPeople()
            => new List<Person>()
            {
                new Person(){FirstName="Joao",LastName="Carlos"},
                new Person(){FirstName="Ivan",LastName="Carlos"},
                new Person(){FirstName="Jose",LastName="Carlos"}

            };

        public List<Person> GetSupervisors()
      => new List<Person>()
      {
                CreatePerson("Joana","Carlos",true),
                CreatePerson("Carla","Carlos",true),
                CreatePerson("Nilza","Carlos",true)
      };

        public List<Person> GetEmployee()
        => new List<Person>()
        {
              CreatePerson("Fernando","Carlos",true),
              CreatePerson("Jorge","Carlos",true),
              CreatePerson("Carlos","Carlos",true)
        };

        public List<Person> GetSupervisorsAndEmployee()
        {
            var data = new List<Person>();
            data.AddRange(GetSupervisors());
            data.AddRange(GetEmployee());

          return  data;
        }



        public Person CreatePerson(
                                   string fname,
                                   string lname,
                                   bool IsSupervisor
                                   )
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
