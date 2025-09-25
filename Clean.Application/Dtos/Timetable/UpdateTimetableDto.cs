namespace Clean.Application.Dtos.Timetable;

public class UpdateTimetableDto
{
    public string TimetableId { get; set; } = null!;
    public string ClassroomId { get; set; } = null!;
    public string TeacherId { get; set; } = null!;
    public string SubjectId { get; set; } = null!;
    public string StudentGroupId { get; set; } = null!;
    public string TimeSlot { get; set; } = null!;
}