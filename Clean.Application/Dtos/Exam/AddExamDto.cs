namespace Clean.Application.Dtos.Exam;

public class AddExamDto
{
    public string SubjectId { get; set; } = null!;
    public DateTime Date { get; set; }
    public string ExamType { get; set; } = null!;
}