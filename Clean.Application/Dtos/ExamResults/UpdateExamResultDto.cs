namespace Clean.Application.Dtos.ExamResults;

public class UpdateExamResultDto
{
    public string ResultId { get; set; } = null!;
    public double Score { get; set; }
    public string Grade { get; set; } = null!;
}