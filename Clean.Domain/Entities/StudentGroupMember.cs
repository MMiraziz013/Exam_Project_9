namespace Clean.Domain.Entities;

public class StudentGroupMember
{
    public string MembershipId { get; set; } = Guid.NewGuid().ToString();
    public string GroupId { get; set; } = null!;
    public string StudentId { get; set; } = null!;
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;

    public StudentGroup Group { get; set; } = null!;
    public Student Student { get; set; } = null!;
}