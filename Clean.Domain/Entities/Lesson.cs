namespace Clean.Domain.Entities;

public class Lesson
{
    public string LessonId { get; set; } = Guid.NewGuid().ToString();

    public string TimetableId { get; set; } = null!;
    public Timetable Timetable { get; set; } = null!;

    public DateTime LessonDate { get; set; }

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
