namespace Clean.Application.Dtos.StudentGroupMember;

public class CreateStudentGroupMemberDto
{
    public string GroupId { get; set; } = null!;
    public string StudentId { get; set; } = null!;
}