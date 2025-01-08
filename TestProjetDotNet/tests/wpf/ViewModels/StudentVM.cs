using question1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.ViewModels;

namespace question1.ViewModels
{
    internal class StudentVM
    {
        private SchoolContext context = new SchoolContext();
        private StudentModel _selectedStudent;
        private ObservableCollection<StudentModel> _StudentList;
        private List<string> _sectionList;
        private DelegateCommand _updateStudent;
        private DelegateCommand _createStudent;

        public ObservableCollection<StudentModel> StudentList { get { return _StudentList = _StudentList ?? loadStudentList(); } }
        public List<string> SectionList { get { return _sectionList = _sectionList ?? loadSectionList(); } }

        private ObservableCollection<StudentModel> loadStudentList()
        {
            ObservableCollection<StudentModel> localCollection = new ObservableCollection<StudentModel>();
            foreach (var item in context.Students)
            {
                localCollection.Add(new StudentModel(item));
            }

            return localCollection;
        }

        private List<string> loadSectionList()
        {
            List<string> localCollection = new List<string>();
            foreach (var item in context.Sections)
            {
                localCollection.Add(item.Name);
            }
            localCollection.Add("Aucune Section");

            return localCollection;
        }


        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set { _selectedStudent = value; }
        }


        public DelegateCommand CreateStudent
        {
            get { return _createStudent = _createStudent ?? new DelegateCommand(createStudent); }
        }

        public DelegateCommand UpdateStudent
        {
            get { return _updateStudent = _updateStudent ?? new DelegateCommand(updateStudent); }
        }

        private void updateStudent()
        {
            var studentToUpdate = context.Students.FirstOrDefault(p => p.StudentId == SelectedStudent.StudentId);
            if (studentToUpdate != null)
            {
                studentToUpdate.Name = SelectedStudent.Name;
                studentToUpdate.Firstname = SelectedStudent.FirstName;
                studentToUpdate.Section.Name = SelectedStudent.SectionName;

                context.SaveChanges();
            }
        }

        private void createStudent()
        {
            var studentFound = context.Students.FirstOrDefault(p => p.Name.Equals("Vlaminck") && p.Firstname.Equals("Maxime"));
            if (studentFound == null)
            {
                Student SGlobal = new Student();
                StudentModel SModel = new StudentModel(SGlobal);
                SModel.Name = "Vlaminck";
                SModel.FirstName = "Maxime";
                SModel.Section = context.Sections.FirstOrDefault();
                StudentList.Add(SModel);
            }
        }




    }
}
