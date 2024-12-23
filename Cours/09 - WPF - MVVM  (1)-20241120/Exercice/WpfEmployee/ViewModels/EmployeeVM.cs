using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeVM
    {
        private NorthwindContext dc = new NorthwindContext();
        private IList<EmployeeModel> _employeesList;
        private IList<string> _listOfTitles;

        public IList<EmployeeModel> EmployeesList {
            get { return _employeesList = loadEmployees(); } 
        }

        public IList<string> ListTitle
        {
            get { 
                return _listOfTitles = ListTitlesOfCourtesy();
            }
        }

        private List<EmployeeModel> loadEmployees()
        {
            List<EmployeeModel> list = new List<EmployeeModel>();
            foreach (var e in dc.Employees)
            {
                list.Add(new EmployeeModel(e));
            }
            return list;
        }

        private List<string> ListTitlesOfCourtesy()
        {
           return dc.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        }
    }
}
