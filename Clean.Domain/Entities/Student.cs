namespace Clean.Domain.Entities;

public class Student
{
    public string StudentId { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<StudentIssue> StudentIssues { get; set; } = new List<StudentIssue>();
    public ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();
    
    public ICollection<StudentGroupMember> Groups { get; set; } = new List<StudentGroupMember>();
}