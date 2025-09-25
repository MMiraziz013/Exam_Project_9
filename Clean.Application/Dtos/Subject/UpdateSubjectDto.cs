namespace Clean.Application.Dtos.Subject;

public class UpdateSubjectDto
{
    public string SubjectId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}