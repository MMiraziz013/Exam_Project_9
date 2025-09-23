using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable("exams");

        builder.HasKey(ex => ex.ExamId);
        builder.Property(ex => ex.ExamType)
            .HasMaxLength(50);
        builder.Property(ex => ex.Date)
            .IsRequired();
        
        builder.HasOne(ex => ex.Subject)
            .WithMany(s => s.Exams)
            .HasForeignKey(ex => ex.SubjectId);
        builder.HasMany(ex => ex.ExamResults)
            .WithOne(er => er.Exam)
            .HasForeignKey(er => er.ExamId);
    }
}