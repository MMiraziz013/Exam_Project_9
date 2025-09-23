namespace Clean.Application.Dtos.Student;

public class GetStudentDto
{
    public string StudentId { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public ICollection<string> Attendances { get; set; } = new List<string>();
    public ICollection<string> StudentIssues { get; set; } = new List<string>();
    public ICollection<int> ExamResults { get; set; } = new List<int>();
}