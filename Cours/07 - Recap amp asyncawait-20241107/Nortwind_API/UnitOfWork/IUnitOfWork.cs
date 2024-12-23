using Nortwind_API.Entities;

namespace Nortwind_API.Repositories
{
    interface IUnitOfWork
    {
        IRepository<Employee> EmployeesRepository { get; }
        IRepository<Order> OrdersRepository { get; }


    }
}
