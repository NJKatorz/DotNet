using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ViewModels;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeVM : INotifyPropertyChanged
    {
        private NorthwindContext dc = new NorthwindContext();

        private EmployeeModel _selectedEmployee;

        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }



        private DelegateCommand _addCommand;
        private DelegateCommand _saveCommand;

        private ObservableCollection<EmployeeModel> _employeesList;
        private ObservableCollection<OrderModel> _ordersList;

        private ObservableCollection<string> _listOfTitles;

        public ObservableCollection<EmployeeModel> EmployeesList {
            get { return _employeesList = loadEmployees(); } 
        }

        public ObservableCollection<OrderModel> OrdersList
        {
            get
            {

                return _ordersList = loadOrders();

            }

        }

        public ObservableCollection<string> ListTitle
        {
            get { 
                return _listOfTitles = ListTitlesOfCourtesy();
            }
        }

        private ObservableCollection<EmployeeModel> loadEmployees()
        {
            ObservableCollection<EmployeeModel> list = new ObservableCollection<EmployeeModel>();
            foreach (var e in dc.Employees)
            {
                list.Add(new EmployeeModel(e));
            }
            return list;
        }

        private ObservableCollection<OrderModel> loadOrders()
        {
            ObservableCollection<OrderModel> localCollection = new ObservableCollection<OrderModel>();

            if (SelectedEmployee == null || SelectedEmployee.MyEmployee == null)
            {
                return localCollection; // Retourne une liste vide si aucun employé n'est sélectionné
            }

            var query = from Order o in dc.Orders
                        where (o.EmployeeId == SelectedEmployee.MyEmployee.EmployeeId)
                        orderby o.OrderDate descending
                        select o;

            int i = 0;
            foreach (var item in query)
            {
                decimal total = dc.OrderDetails.Where(od => od.OrderId == item.OrderId).Sum(od => od.UnitPrice);
                localCollection.Add(new OrderModel(item, total));
                i++;
                if (i == 3) break;
            }

            return localCollection;
        }


        private ObservableCollection<string> ListTitlesOfCourtesy()
        {
            // return dc.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        var list = new ObservableCollection<string>();
            foreach (var e in dc.Employees) {
                if (!list.Contains(e.TitleOfCourtesy))
                {
                   list.Add(e.TitleOfCourtesy);  
                }
            }
           return list;
        }

        public EmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value; OnPropertyChanged("OrdersList");  }

        }

        public DelegateCommand AddCommand
        {
            get { return _addCommand = _addCommand ?? new DelegateCommand(NewEmployee); }
        }

        private void NewEmployee()
        {
            Employee employee = new Employee
            {
                EmployeeId = 0, // Initialise l'ID à une valeur par défaut si nécessaire
                                // Initialise d'autres propriétés si besoin
            };
            EmployeeModel employeeModel = new EmployeeModel(employee);
            EmployeesList.Add(employeeModel);
            SelectedEmployee = employeeModel;
        }

        public DelegateCommand SaveCommand
        {
            get
            {
               return  _saveCommand = _saveCommand ?? new DelegateCommand(SaveEmployee);
            }
        }

        private void SaveEmployee()
        {
            // Extraire l'ID en mémoire avant d'exécuter la requête
            int employeeId = SelectedEmployee.MyEmployee.EmployeeId;

            // Rechercher directement dans la base de données avec l'ID
            Employee verif = dc.Employees.Where(e => e.EmployeeId == employeeId).SingleOrDefault();
            if (verif == null)
            {
                dc.Employees.Add(SelectedEmployee.MyEmployee);
            }
            dc.SaveChanges();
            MessageBox.Show("Enregistrement en base de données fait");
        }
    }
}
