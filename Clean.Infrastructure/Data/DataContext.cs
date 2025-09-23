using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Clean.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public override Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return base.SaveChangesAsync(ct);
    }

    // Db Sets
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentIssue> StudentIssues { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Timetable> Timetables { get; set; }

    public async Task MigrateAsync()
    {
        await Database.MigrateAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AttendanceConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClassroomConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamResultsConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentIssueConfiguraiton).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubjectConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeacherConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TimetableConfiguration).Assembly);
    }
}