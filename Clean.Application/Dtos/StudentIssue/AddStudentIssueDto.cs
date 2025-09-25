namespace Clean.Application.Dtos.StudentIssue;

public class AddStudentIssueDto
{
    public string StudentId { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateReported { get; set; } = DateTime.UtcNow;
}