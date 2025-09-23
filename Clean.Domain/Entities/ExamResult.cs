namespace Clean.Domain.Entities;

public class ExamResult
{
    public string ResultId { get; set; } = Guid.NewGuid().ToString();
    public string ExamId { get; set; } = null!;
    public string StudentId { get; set; } = null!;
    public float Score { get; set; }
    public string Grade { get; set; } = null!;

    public Exam Exam { get; set; } = null!;
    public Student Student { get; set; } = null!;
}