using SchoolApp.Repositories;
using SchoolApp.Models;

namespace SchoolApp.UnitOfWork
{
    interface IUnitOfWorkSchool
    {
        IRepository<Section> SectionsRepository { get; }

        IStudentRepository StudentsRepository { get; }
    }
}
