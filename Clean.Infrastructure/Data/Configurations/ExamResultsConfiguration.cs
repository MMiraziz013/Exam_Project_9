using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations;

public class ExamResultsConfiguration : IEntityTypeConfiguration<ExamResult>
{
    public void Configure(EntityTypeBuilder<ExamResult> builder)
    {
        builder.ToTable("exam_results");
        builder.HasKey(e => e.ResultId);
        builder.Property(e => e.Score);
        builder.Property(e => e.Grade).HasMaxLength(20);
        
        builder.HasOne(e => e.Exam)
            .WithMany(e => e.ExamResults)
            .HasForeignKey(e => e.ExamId);
        builder.HasOne(e => e.Student)
            .WithMany(s=>s.ExamResults)
            .HasForeignKey(e=> e.StudentId);
    }
}