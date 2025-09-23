using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("subjects");
        builder.HasKey(s => s.SubjectId);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Description).HasMaxLength(120);
        
        builder.HasMany(s => s.Timetables)
            .WithOne(t => t.Subject)
            .HasForeignKey(t => t.SubjectId);
        builder.HasMany(s => s.Exams)
            .WithOne(e => e.Subject)
            .HasForeignKey(e => e.SubjectId);
    }

}