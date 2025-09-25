namespace Clean.Application.Dtos.StudentGroupMember;

public class GetStudentGroupMemberDto
{
    public string MembershipId { get; set; } = null!;
    public string GroupId { get; set; } = null!;
    public string GroupName { get; set; } = null!;
    public string StudentId { get; set; } = null!;
    public string StudentName { get; set; } = null!;
    public DateTime DateJoined { get; set; }
}