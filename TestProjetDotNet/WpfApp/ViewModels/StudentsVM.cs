using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Models;
using WpfApplication1.ViewModels;

namespace WpfApp.ViewModels
{
    class StudentsVM : INotifyPropertyChanged
    {
        private SchoolContext dc = new SchoolContext();

        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }

        private StudentsModel _selectedStudent;
        private ObservableCollection<StudentsModel> _studentsList;
        private ObservableCollection<StudentsModel> _students2020List;
        private ObservableCollection<long> _yearResultsList;

        private DelegateCommand _addCommand;
        private DelegateCommand _removeCommand;
        private DelegateCommand _saveCommand;

        public StudentsModel SelectedStudent
        {
            get
            {
            
                return _selectedStudent;
            }
            set 
            { 
                _selectedStudent = value;
                // OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public ObservableCollection<StudentsModel> StudentsList
        {
            get
            {
                if (_studentsList == null)
                {

                    _studentsList = loadStudents();
                }

                return _studentsList;

            }
        }

        public ObservableCollection<StudentsModel> Students2020List
        {
            get
            {
                if (_students2020List == null)
                {
                    _students2020List = loadStudents2020List();
                }

                return _students2020List;
            }
        }

        public ObservableCollection<long> YearResultsList
        {
            get
            {
                if (_yearResultsList == null)
                {
                    _yearResultsList = loadYearResults();
                }
                return _yearResultsList;
            }
        }




        private ObservableCollection<StudentsModel> loadStudents()
        {
            ObservableCollection<StudentsModel> students = new ObservableCollection<StudentsModel>();
            foreach (Student student in dc.Students)
            {
                students.Add(new StudentsModel(student));
            }
            return students;
        }

        private ObservableCollection<StudentsModel> loadStudents2020List()
        {
            ObservableCollection<StudentsModel> students2020List = new ObservableCollection<StudentsModel>();

            // Supposons que vous avez une collection source, par exemple dc.Students
            var query = dc.Students.Where(s => s.YearResult == 2020).ToList();

            foreach (var item in query)
            {
                students2020List.Add(new StudentsModel(item));
            }

            return students2020List;
        }

        private ObservableCollection<long> loadYearResults()
        {
            ObservableCollection<long> yearResults = new ObservableCollection<long>();
            // Supposons que vous avez une collection source, par exemple dc.Students
            var query = dc.Students.Select(s => s.YearResult).Distinct().ToList();
            foreach (var item in query)
            {
                yearResults.Add(item);
            }
            return yearResults;

        }



        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand = _addCommand ?? new DelegateCommand(AddStudent);
            }
        }

        private void AddStudent()
        {

            Student student = new Student
            {
                StudentId = 0, // Initialise l'ID à une valeur par défaut si nécessaire
                                // Initialise d'autres propriétés si besoin
                Name = "Nom",
                Firstname = "Prénom",
                YearResult = 0
            };
            StudentsModel studentModel = new StudentsModel(student);
            StudentsList.Add(studentModel);
            SelectedStudent = studentModel;
            MessageBox.Show("Ajout en base de données fait");

        }

        public DelegateCommand RemoveCommand
        {
            get
            {
                return _removeCommand = _removeCommand ?? new DelegateCommand(RemoveStudent);
            }
        }

        private void RemoveStudent()
        {
           Student student = dc.Students.Find(SelectedStudent.StudentId);
            if (student != null)
            {
                dc.Students.Remove(student);
                dc.SaveChanges();
                StudentsList.Remove(SelectedStudent);
            }
            MessageBox.Show("Suppression en base de données fait");
        }

        public DelegateCommand SaveCommand
        {
            get
            {
                return _saveCommand = _saveCommand ?? new DelegateCommand(SaveStudent);
            }
        }

        private void SaveStudent()
        {
            // Trace.Write($"llskkskdksddsssssss {SelectedStudent.StudentId}");
            Student student = dc.Students.Where(s => s.StudentId == SelectedStudent.StudentId).SingleOrDefault();
            Trace.Write($"llskkskdksddsssssss {SelectedStudent.Name} eeeeeeeeeeeeeeeeeeeeeeeee {SelectedStudent.Firstname}");
            if (student == null)
            {
                dc.Students.Add(SelectedStudent.GetStudent);
            }                
            dc.SaveChanges();
            MessageBox.Show("Mise à jour en base de données fait");
        }

    }
}
