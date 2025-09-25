namespace Clean.Application.Dtos.Exam;

public class UpdateExamDto
{
    public string ExamId { get; set; } = null!;
    public string SubjectId { get; set; } = null!;
    public DateTime Date { get; set; }
    public string ExamType { get; set; } = null!;
}