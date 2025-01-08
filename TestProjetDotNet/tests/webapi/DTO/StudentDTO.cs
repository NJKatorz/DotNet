using question2.Entities;

namespace question2.DTO
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

        public string Name { get; set; } = null!;

        public string Firstname { get; set; } = null!;

        public long YearResult { get; set; }

        public int? SectionId { get; set; }

        public virtual Section? Section { get; set; }
    }
}
