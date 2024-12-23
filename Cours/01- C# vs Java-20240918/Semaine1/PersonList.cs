
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine1
{
    internal class PersonList
    {
        private static PersonList? _instance;
        private IDictionary<string, Person> _personMap;

        private PersonList()
        {
            _personMap = new Dictionary<string, Person>();
        }

        public static PersonList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PersonList();

                return _instance;
            }
        }

        public void AddPerson(Person person)
        {
            if (person == null)
                throw new Exception();

            _personMap.Add(person.Name, person);
        }

        public IEnumerator<Person> GetPersonList()
        {
            return _personMap.Values.GetEnumerator();
        }


    }
}
