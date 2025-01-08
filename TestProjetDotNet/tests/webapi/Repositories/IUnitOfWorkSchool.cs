using question2.Entities;

namespace School_API.Repositories
{
    interface IUnitOfWorkSchool
    {
        IRepository<Student> StudentRepository { get; }
    }
}
