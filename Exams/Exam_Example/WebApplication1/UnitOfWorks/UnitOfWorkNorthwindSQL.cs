using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.UnitOfWorks
{
    public class UnitOfWorkNorthwindSQL : IUnitOfWorkNorthwind
    {
        private readonly NorthwindContext _context;

        private BaseRepositorySQL<Employee> _employeesRepository;

        public UnitOfWorkNorthwindSQL(NorthwindContext context)
        {
            this._context = context;
            this._employeesRepository = new BaseRepositorySQL<Employee>(context);
        }

        public IRepository<Employee> EmployeesRepository
        {
            get { return this._employeesRepository; }
        }
    }
}
