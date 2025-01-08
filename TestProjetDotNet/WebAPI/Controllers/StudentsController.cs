using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;
using WebAPI.Entities;
using WebAPI.UnitOfWorks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWorkSchool _unitOfWorkSchool;
        private readonly SchoolContext _dbContext;

        public StudentsController()
        {
            _dbContext = new SchoolContext();
            _unitOfWorkSchool = new UnitOfWorkSchoolSQL(_dbContext);
        }

        // GET /api/Students

        [HttpGet]
        public async Task<IList<StudentDTO>> GetAllStudents()
        {
            IList<Student> list = await _unitOfWorkSchool.StudentsRepository.GetAllAsync();
          
            return list.Select(st => StudentToDTO(st)).ToList();
        }

        //POST /api/Students 

        [HttpPost]
        public async Task InsertStudentAsync(StudentDTO studentDTO)
        {
            // assure that id is not set to avoid error with autoincrement in database
            studentDTO.StudentId = 0;
            Student st = DTOToStudent(studentDTO);


            await _unitOfWorkSchool.StudentsRepository.InsertAsync(st);
        }

        // PUT /api/Students/id

        [HttpPut]

        public async Task UpdateStudentAsync(StudentDTO studentDTO)
        {
            Student st = DTOToStudent(studentDTO);
            await _unitOfWorkSchool.StudentsRepository.SaveAsync(st);
        }

        // GET /api/Students/id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentAsync(int id)
        {
            Student? st = await _unitOfWorkSchool.StudentsRepository.GetByIdAsync(id);
            if (st == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(StudentToDTO(st));
            }

        }

        // DELETE /api/Students/id

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            Student? st = await _unitOfWorkSchool.StudentsRepository.GetByIdAsync(id);
            if (st == null)
            {
                return NotFound();
            }
            else
            {
                await _unitOfWorkSchool.StudentsRepository.DeleteAsync(st);
                return Ok();
            }

        }

        private static StudentDTO StudentToDTO(Student st) =>
          new StudentDTO
          {
              StudentId = st.StudentId,
              Name = st.Name,
              Firstname = st.Firstname,
              YearResult = st.YearResult,
              // SectionId = st.SectionId,
             /** Section = new Section
              {
                  SectionId = st.Section.SectionId,
                  Name = st.Section.Name,
              },*/
          };

        private static Student DTOToStudent(StudentDTO st) =>
            new Student
            {
                StudentId = st.StudentId,
                Name = st.Name,
                Firstname = st.Firstname,
                YearResult = st.YearResult,
                // SectionId = st.SectionId,
                /** Section = new Section
               {
                   SectionId = st.Section.SectionId,
                   Name = st.Section.Name,
               },*/
            };

        private static SectionDTO SectionToDTO(Section se) =>
          new SectionDTO
          {
              SectionId = se.SectionId,
              Name = se.Name,
          };

        private static Section DTOToSection(SectionDTO se) =>
           new Section
           {
               SectionId = se.SectionId,
               Name = se.Name,
           };


    }
}
