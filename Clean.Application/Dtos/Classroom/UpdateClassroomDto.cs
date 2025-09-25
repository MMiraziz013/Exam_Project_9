namespace Clean.Application.Dtos.Classroom;

public class UpdateClassroomDto
{
    public string ClassroomId { get; set; } = null!;
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
}