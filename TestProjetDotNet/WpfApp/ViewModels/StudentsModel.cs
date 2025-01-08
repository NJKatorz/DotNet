using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    class StudentsModel : INotifyPropertyChanged
    {
        private readonly Student _student;

        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged;
        // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public StudentsModel(Student currentStudent)
        {
            this._student = currentStudent;
        }

        public Student GetStudent
        {
            get { return _student; }
        }

        public int StudentId
        {
            get => _student.StudentId;
            set
            {
                if (_student.StudentId != value)
                {
                    _student.StudentId = value;
                    OnPropertyChanged(nameof(StudentId));
                }
            }
        }

        public string Name
        {
            get => _student.Name;
            set
            {
                if (_student.Name != value)
                {
                    _student.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

         public string Firstname
       {
           get => _student.Firstname;
           set
           {
               if (_student.Firstname != value)
               {
                   _student.Firstname = value;
                   OnPropertyChanged(nameof(Firstname));
               }
           }
       }

       public long YearResult
       {
           get => _student.YearResult;
           set
           {
               if (_student.YearResult != value)
               {
                   _student.YearResult = value;
                   OnPropertyChanged(nameof(YearResult));
               }
           }
       }

    }
}
