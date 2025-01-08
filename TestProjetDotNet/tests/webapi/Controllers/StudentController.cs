using Microsoft.AspNetCore.Mvc;
using question2.DTO;
using question2.Entities;
using School_API.Repositories;

namespace School_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _dbcontext;
        private readonly IUnitOfWorkSchool _unitOfWorkSchool;


        // public StudentsController(IRepository<Student> StudentsRepository)
        // add service ? unitofwork
        public StudentsController()
        {
            _dbcontext = new SchoolContext();
            _unitOfWorkSchool = new IUnitOfWorkSchoolSQL(_dbcontext);
        }


        // GET /api/Students

        [HttpGet]
        public async Task<IList<StudentDTO>> GetStudentAsync()
        {
            IList<Student> lst = await _unitOfWorkSchool.StudentRepository.GetAllAsync();
            return lst.Select(e => StudentToDTO(e)).ToList();
        }

        //POST /api/Students 

        [HttpPost]
        public async Task InsertStudentAsync(StudentDTO studentDTO)
        {
            // assure that id is not set to avoid error with autoincrement in database
            studentDTO.StudentId = 0;
            Student e = DTOToStudent(studentDTO);
            await _unitOfWorkSchool.StudentRepository.InsertAsync(e);
        }


        private static StudentDTO StudentToDTO(Student stu) =>
            new StudentDTO
            {
                StudentId = stu.StudentId,
                Name = stu.Name,
                Firstname = stu.Firstname,
                YearResult = stu.YearResult,
                SectionId = stu.SectionId,
                Section = stu.Section,
            };

        private static Student DTOToStudent(StudentDTO stu) =>
            new Student
            {
                StudentId = stu.StudentId,
                Name = stu.Name,
                Firstname = stu.Firstname,
                YearResult = stu.YearResult,
                SectionId = stu.SectionId,
                Section = stu.Section,
            };
    }
}
