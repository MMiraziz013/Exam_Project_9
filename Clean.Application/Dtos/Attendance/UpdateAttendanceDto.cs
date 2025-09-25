namespace Clean.Application.Dtos.Attendance;

public class UpdateAttendanceDto
{
    public string AttendanceId { get; set; } = null!;
    public string Status { get; set; } = null!;
}