using Clean.Application.Dtos.StudentGroupMember;

namespace Clean.Application.Dtos.StudentGroup;

public class GetStudentGroupDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<GetStudentGroupMemberDto> Members { get; set; } = new();
}