namespace Clean.Domain.Entities;

public class StudentGroup
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = null!;
    public ICollection<StudentGroupMember> Members { get; set; } = new List<StudentGroupMember>();
}