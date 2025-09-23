namespace Clean.Domain.Entities;

public class Teacher
{
    public string TeacherId { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime HireDate { get; set; }

    public ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}