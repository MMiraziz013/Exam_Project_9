namespace Clean.Domain.Entities;

public class Exam
{
    public string ExamId { get; set; } = Guid.NewGuid().ToString();
    public string SubjectId { get; set; } = null!;
    public DateTime Date { get; set; }
    public string ExamType { get; set; } = null!;

    public Subject Subject { get; set; } = null!;
    public ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();
}