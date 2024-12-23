using SchoolApp.Models;

namespace SchoolApp.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {

        IList<Student> GetStudentBySectionOrderByYearResult();
    }
}