namespace Clean.Application.Dtos.Student;

public class GetStudentDto
{
    public string StudentId { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public DateTime EnrollmentDate { get; set; }
}