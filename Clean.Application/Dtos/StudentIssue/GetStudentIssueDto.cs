namespace Clean.Application.Dtos.StudentIssue;

public class GetStudentIssueDto
{
    public string IssueId { get; set; } = null!;
    public string StudentId { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateReported { get; set; }
}