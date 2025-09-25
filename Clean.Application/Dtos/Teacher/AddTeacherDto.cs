namespace Clean.Application.Dtos.Teacher;

public class AddTeacherDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime HireDate { get; set; }
}