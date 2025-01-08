using WebAPI.Entities;
using WebAPI.Repositories;

namespace WebAPI.UnitOfWorks
{
    interface IUnitOfWorkSchool
    {
        IRepository<Student> StudentsRepository { get; }
        // IRepository<Section> SectionsRepository { get; }

    }
}
