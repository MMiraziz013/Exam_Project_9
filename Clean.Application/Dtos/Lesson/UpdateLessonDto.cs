namespace Clean.Application.Dtos.Lesson;

public class UpdateLessonDto
{
    public string LessonId { get; set; } = null!;
    public string TimetableId { get; set; } = null!;
    public DateTime LessonDate { get; set; }
}