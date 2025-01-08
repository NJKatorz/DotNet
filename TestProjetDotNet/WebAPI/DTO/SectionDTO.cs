using WebAPI.Entities;

namespace WebAPI.DTO
{
    public class SectionDTO
    {
        public int SectionId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
