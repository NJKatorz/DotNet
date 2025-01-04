using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.UnitOfWorks
{
    interface IUnitOfWorkNorthwind
    {
        IRepository<Employee> EmployeesRepository { get; }
    }
}
