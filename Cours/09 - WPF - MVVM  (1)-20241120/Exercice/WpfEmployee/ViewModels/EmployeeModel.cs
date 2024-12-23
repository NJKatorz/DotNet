using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfEmployee.Models;
using System.Threading.Tasks;

namespace WpfEmployee.ViewModels
{
    class EmployeeModel
    {
        private readonly Employee _myEmployee;


        public EmployeeModel(Employee currentEmployee)
        {
            this._myEmployee = currentEmployee;
        }

        public Employee MyEmployee { 
            get { return _myEmployee; } 
        }

        public string LastName
        {
            get
            {
                return _myEmployee.LastName;
            }
            set
            {
                _myEmployee.LastName = value;

            }
        }

        public string FirstName
        {
            get
            {
                return _myEmployee.FirstName;
            }
            set
            {
                _myEmployee.FirstName = value;

            }
        }


        public string FullName
        {
            get
            {
                return _myEmployee.FirstName + " " + _myEmployee.LastName;
            }
        }

        public DateTime? BirthDate
        {
            get { return _myEmployee.BirthDate; }
            set
            {
                _myEmployee.BirthDate = value;

            }
        }

        public DateTime? HireDate
        {
            get { return _myEmployee.HireDate; }
            set
            {
                _myEmployee.HireDate = value;
             
            }
        }

        public string? TitleOfCourtesy
        {
            get
            {
                return _myEmployee.TitleOfCourtesy;
            }
            set
            {
                _myEmployee.TitleOfCourtesy = value;

            }
        }

        public string DisplayBirthDate
        {
            get
            {
                if (_myEmployee.BirthDate.HasValue)
                {
                    return _myEmployee.BirthDate.Value.ToString();
                }
                return "";
            }

        }

    }
}
