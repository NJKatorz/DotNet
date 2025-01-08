using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace question1.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School").UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasIndex(e => e.ProfessorId, "IX_FK_ProfessorCourse");

            entity.Property(e => e.CourseId).HasColumnName("Course_Id");
            entity.Property(e => e.ProfessorId).HasColumnName("Professor_Id");

            entity.HasOne(d => d.Professor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfessorCourse");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasIndex(e => e.SectionId, "IX_FK_SectionProfessor");

            entity.Property(e => e.ProfessorId).HasColumnName("Professor_Id");
            entity.Property(e => e.SectionId).HasColumnName("Section_Id");

            entity.HasOne(d => d.Section).WithMany(p => p.Professors)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SectionProfessor");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.Property(e => e.SectionId).HasColumnName("Section_Id");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasIndex(e => e.SectionId, "IX_FK_StudentSection");

            entity.Property(e => e.StudentId).HasColumnName("Student_Id");
            entity.Property(e => e.SectionId).HasColumnName("Section_Id");

            entity.HasOne(d => d.Section).WithMany(p => p.Students)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_StudentSection");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
