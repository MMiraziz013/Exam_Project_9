namespace Clean.Domain.Entities;

public class Classroom
{
    public string ClassroomId { get; set; } = Guid.NewGuid().ToString();
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();

    public ICollection<Lesson> Lessons { get; set; }
}