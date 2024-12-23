using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student_API_Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {

        private static List<Student> _students = new List<Student>()
        {
            new Student { Id = 1, FirstName = "Paul", LastName = "Ochon", Birthdate = new DateTime(1950, 12, 1) },
            new Student { Id = 2, FirstName = "Daisy", LastName = "Drathey", Birthdate = new DateTime(1970, 12, 1) },
            new Student { Id = 3, FirstName = "Elie", LastName = "Coptaire", Birthdate = new DateTime(1980, 12, 1) }
        };

        // GET: StudentController
        [HttpGet(Name = "GetAllStudents")]
        public ActionResult<List<Student>> GetAllStudents()
        {
            return Ok(_students);
        }

        // POST: StudentController/Create
        [HttpPost]
        public ActionResult<Student> Create([FromBody] Student student)
        {
            try
            {
                student.Id = _students.Max(s => s.Id) + 1;

                _students.Add(student);

                return CreatedAtAction(nameof(GetOneStudent), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur serveur: {ex.Message}");
            }
        }


            // GET: StudentController/Id/2
            [HttpGet("{id}", Name = "GetOneStudent")]
            public ActionResult<Student> GetOneStudent(int id)
            {
                Student foundStudent = _students.Find(s => s.Id == id);
                if (foundStudent == null)
                    return NotFound();
                return Ok(foundStudent);
            }
    }
}
