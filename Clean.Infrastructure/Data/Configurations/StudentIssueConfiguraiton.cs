using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations;

public class StudentIssueConfiguraiton : IEntityTypeConfiguration<StudentIssue>
{
    public void Configure(EntityTypeBuilder<StudentIssue> builder)
    {
        builder.ToTable("student_issues");
        builder.HasKey(si => si.IssueId);
        builder.Property(si => si.Description).HasMaxLength(300);
        builder.Property(si => si.DateReported).HasDefaultValueSql("NOW()");
        builder.HasOne(si => si.Student)
            .WithMany(s => s.StudentIssues)
            .HasForeignKey(si => si.StudentId);
    }
}