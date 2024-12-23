using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nortwind_API.DTO;
using Nortwind_API.Entities;
using Nortwind_API.Repositories;
using Nortwind_API.UnitOfWork;


namespace Nortwind_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        private readonly NorthwindContext _dbcontext;

        public EmployeeController()
        {
            _dbcontext = new NorthwindContext();
            _repo = new UnitOfWorkSQL(_dbcontext);
        }


        [HttpGet]
        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            IList<Employee> list = await _repo.EmployeesRepository.GetAllAsync();
            return list.Select(e => EmployeeToDTO(e)).ToList();
        }


        [HttpPost]
        public async Task CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            employeeDTO.EmployeeId = 0;
            Employee employee = DTOToEmployee(employeeDTO);
            await _repo.EmployeesRepository.InsertAsync(employee);
        }


        [HttpPut]
        public async Task UpdateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = DTOToEmployee(employeeDTO);
            await _repo.EmployeesRepository.SaveAsync(employee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            Employee? employee = await _repo.EmployeesRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(EmployeeToDTO(employee));
            }
        }
        // Delete only Employee with no orders    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            Employee? emp = await _repo.EmployeesRepository.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                await _repo.EmployeesRepository.DeleteAsync(emp);
                return Ok();
            }

        }


        private static EmployeeDTO EmployeeToDTO(Employee emp) =>
          new EmployeeDTO
          {
              EmployeeId = emp.EmployeeId,
              LastName = emp.LastName,
              FirstName = emp.FirstName,
              BirthDate = emp.BirthDate,
              HireDate = emp.HireDate,
              Title = emp.Title,
              TitleOfCourtesy = emp.TitleOfCourtesy

          };

        private static Employee DTOToEmployee(EmployeeDTO emp) =>
            new Employee
            {
                EmployeeId = emp.EmployeeId,
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                BirthDate = emp.BirthDate,
                HireDate = emp.HireDate,
                Title = emp.Title,
                TitleOfCourtesy = emp.TitleOfCourtesy
            };


    }
}

