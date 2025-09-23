namespace Clean.Domain.Entities;

public class Subject
{
    public string SubjectId { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
    public ICollection<Exam> Exams { get; set; } = new List<Exam>();
}