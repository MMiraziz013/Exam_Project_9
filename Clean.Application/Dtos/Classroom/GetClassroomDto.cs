namespace Clean.Application.Dtos.Classroom;

public class GetClassroomDto
{
    public string ClassroomId { get; set; } = null!;
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
}