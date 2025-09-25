namespace Clean.Application.Dtos.Attendance;

public class GetAttendanceDto
{
    public string AttendanceId { get; set; } = null!;
    public string StudentId { get; set; } = null!;
    public string ClassroomId { get; set; } = null!;
    public string LessonId { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Status { get; set; } = null!;
}