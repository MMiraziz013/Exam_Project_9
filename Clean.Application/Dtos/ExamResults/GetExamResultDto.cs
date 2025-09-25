namespace Clean.Application.Dtos.ExamResults;

public class GetExamResultDto
{
    public string ResultId { get; set; } = null!;
    public string ExamId { get; set; } = null!;
    public string StudentId { get; set; } = null!;
    public double Score { get; set; }
    public string Grade { get; set; } = null!;
}