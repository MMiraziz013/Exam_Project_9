using System.Runtime.InteropServices.JavaScript;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");
        
        builder.HasKey(s => s.StudentId);
        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(60);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(60);
        builder.Property(s => s.DateOfBirth).IsRequired();
        builder.Property(s => s.EnrollmentDate).HasDefaultValueSql("NOW()");
        
        
        builder.HasMany(s => s.Attendances)
            .WithOne(a => a.Student)
            .HasForeignKey(a => a.StudentId);
        builder.HasMany(s => s.StudentIssues)
            .WithOne(i => i.Student)
            .HasForeignKey(i => i.StudentId);
        builder.HasMany(s => s.ExamResults)
            .WithOne(r => r.Student)
            .HasForeignKey(r => r.StudentId);
    }

}