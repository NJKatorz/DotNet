using System;
using System.Collections.Generic;

namespace SchoolApp.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
