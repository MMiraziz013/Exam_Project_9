namespace Clean.Domain.Entities;

public class Attendance
{
    public string AttendanceId { get; set; } = Guid.NewGuid().ToString();
    public string StudentId { get; set; } = null!;
    public string ClassroomId { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Status { get; set; } = null!;
    public Student Student { get; set; } = null!;
    public Classroom Classroom { get; set; } = null!;
}