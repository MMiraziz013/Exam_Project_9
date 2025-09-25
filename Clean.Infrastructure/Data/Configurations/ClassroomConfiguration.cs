using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations;

public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
{
    public void Configure(EntityTypeBuilder<Classroom> builder)
    {
        builder.ToTable("classrooms");
        builder.HasKey(c => c.ClassroomId);

        builder.Property(c => c.Capacity).IsRequired();
        builder.Property(c => c.RoomNumber).IsRequired();

        builder.HasMany(c => c.Timetables)
            .WithOne(t => t.Classroom)
            .HasForeignKey(t => t.ClassroomId);
    }
}