namespace Clean.Application.Dtos.Lesson;

public class AddLessonDto
{
    public string TimetableId { get; set; } = null!;
    public DateTime LessonDate { get; set; } = DateTime.UtcNow;
}