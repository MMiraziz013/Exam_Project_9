namespace Clean.Application.Dtos.Attendance;

public class AddAttendanceDto
{
    public string StudentId { get; set; } = null!;
    public string ClassroomId { get; set; } = null!;
    public DateTime Date { get; set; }
    public string LessonId { get; set; }
    public string Status { get; set; } = "Present";
}