namespace Clean.Domain.Entities;

public class Attendance
{
    public string AttendanceId { get; set; } = Guid.NewGuid().ToString();

    public string StudentId { get; set; } = null!;
    public Student Student { get; set; } = null!;

    public string LessonId { get; set; } = null!;
    public Lesson Lesson { get; set; } = null!;

    public string Status { get; set; } = "Present";
}
