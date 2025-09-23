namespace Clean.Domain.Entities;

public class Timetable
{
    public string TimetableId { get; set; } = Guid.NewGuid().ToString();
    public string ClassroomId { get; set; } = null!;
    public string TeacherId { get; set; } = null!;
    public string SubjectId { get; set; } = null!;
    public string TimeSlot { get; set; } = null!;

    public Classroom Classroom { get; set; } = null!;
    public Teacher Teacher { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
}