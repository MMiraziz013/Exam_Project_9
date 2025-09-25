namespace Clean.Application.Dtos.Student;

public class AddStudentDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; } 
}