using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("teachers");

        builder.HasKey(t => t.TeacherId);
        builder.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(t => t.LastName).IsRequired().HasMaxLength(50);
        builder.Property(t => t.HireDate).HasDefaultValueSql("NOW()");

        builder.HasMany(t => t.Timetables)
            .WithOne(tt => tt.Teacher)
            .HasForeignKey(t => t.TimetableId);
    }
}