namespace Clean.Domain.Entities;

public class StudentIssue
{
    public string IssueId { get; set; } = Guid.NewGuid().ToString();
    public string StudentId { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateReported { get; set; }

    public Student Student { get; set; } = null!;
}