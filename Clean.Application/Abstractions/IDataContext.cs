using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Abstractions;

public interface IDataContext
{
    // Db set with get
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentIssue> StudentIssues { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Timetable> Timetables { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
    Task MigrateAsync();
}