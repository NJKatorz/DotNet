using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Semaine1
{
    [Serializable]
    internal class Person
    {
        private static readonly long serialVersionUID = 1L;

        private readonly string _name;
        private readonly string _firstname;
        private readonly DateTime _birthDate;

        public Person(string name, string firstname, DateTime birthDate)
        {
            _name = name;
            _firstname = firstname;
            _birthDate = birthDate;
        }

        public virtual string Name
        {
            get { return _name; }
        }

        public string FirstName
        {
            get { return _firstname; }
        }
        public string BirthDate => _birthDate.ToString("dd-MM-yyyy");

        public override string ToString()
        {
            return $"Person [name = {_name}, firstname = {_firstname}, birthDate = {BirthDate}]";

        }

    }

}
