using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using question1.Models;

namespace question1.ViewModels
{
    class StudentModel : INotifyPropertyChanged
    {
        private readonly Student _student;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        public StudentModel(Student student)
        {
            _student = student;
        }

        public int StudentId
        {
            get { return _student.StudentId; }
        }
        public string Name
        {
            get { return _student.Name; }
            set { _student.Name= value; OnPropertyChanged("FullName"); }
        }

        public string FirstName
        {
            get { return _student.Firstname; }
            set { _student.Firstname = value; OnPropertyChanged("FullName"); }
        }

        public string FullName
        {
            get { return Name + " " + FirstName; }
        }

        public Section Section
        {
            get { return _student.Section ?? null; }
            set 
            { 
                if(_student.Section != null)
                {
                    _student.Section = value;
                } else
                {
                    _student.Section = new Section();
                }
                OnPropertyChanged(SectionName);
            }
        }

        public string SectionName
        {
            get { return Section?.Name ?? "Aucune Section"; }
        }


    }
}
