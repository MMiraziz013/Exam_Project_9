using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("attendance");
        builder.HasKey(a => a.AttendanceId);
        builder.Property(a => a.Status).IsRequired().HasDefaultValue("Absent");
        builder.Property(a => a.Date).IsRequired();
        builder.HasOne(c => c.Classroom);
        
        builder.HasOne(s => s.Student)
            .WithMany(s=> s.Attendances)
            .HasForeignKey(s=>s.StudentId);
        builder.HasOne(a => a.Classroom)
            .WithMany(c => c.Attendances)
            .HasForeignKey(a => a.ClassroomId);
    }
}