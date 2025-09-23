using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations;

public class TimetableConfiguration : IEntityTypeConfiguration<Timetable>
{
    public void Configure(EntityTypeBuilder<Timetable> builder)
    {
        builder.ToTable("timetables");
        builder.HasKey(t => t.TimetableId);
        builder.Property(t => t.TimeSlot).IsRequired().HasMaxLength(20);

        builder.HasOne(t => t.Classroom)
            .WithMany(c => c.Timetables)
            .HasForeignKey(t => t.ClassroomId);

        builder.HasOne(t => t.Teacher)
            .WithMany(tr => tr.Timetables)
            .HasForeignKey(t => t.TeacherId);

        builder.HasOne(t => t.Subject)
            .WithMany(s => s.Timetables)
            .HasForeignKey(t => t.SubjectId);
    }
}