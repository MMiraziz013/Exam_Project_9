using Clean.Application.Abstractions;
using Clean.Application.Dtos.StudentGroupMember;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class StudentGroupMemberService : IStudentGroupMemberService
{
    private readonly IStudentGroupMemberRepository _repository;

    public StudentGroupMemberService(IStudentGroupMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<GetStudentGroupMemberDto?>> GetByIdAsync(string membershipId)
    {
        var member = await _repository.GetByIdAsync(membershipId);
        if (member is null)
        {
            throw new ArgumentException($"No group member with id: {membershipId}");
        }
        var memberDto =  new GetStudentGroupMemberDto
        {
            MembershipId = member.MembershipId,
            GroupId = member.GroupId,
            GroupName = member.Group.Name,
            StudentId = member.StudentId,
            StudentName = $"{member.Student.FirstName} {member.Student.LastName}",
            DateJoined = member.DateJoined
        };
        return new Response<GetStudentGroupMemberDto?>(memberDto);
    }
        

    public async Task<Response<IEnumerable<GetStudentGroupMemberDto>>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        var memberDtos = new List<GetStudentGroupMemberDto>();
        foreach (var studentGroupMember in list)
        {
            memberDtos.Add(new GetStudentGroupMemberDto
            {
                MembershipId = studentGroupMember.MembershipId,
                GroupId = studentGroupMember.GroupId,
                GroupName = studentGroupMember.Group.Name,
                StudentId = studentGroupMember.StudentId,
                StudentName = $"{studentGroupMember.Student.FirstName} {studentGroupMember.Student.LastName}",
                DateJoined = studentGroupMember.DateJoined
            });
        }
        return new Response<IEnumerable<GetStudentGroupMemberDto>>(memberDtos);
    }
        

    public async Task<Response<bool>> CreateAsync(string groupId, string studentId)
    {
        var member = new StudentGroupMember
        {
            MembershipId = Guid.NewGuid().ToString(),
            GroupId = groupId,
            StudentId = studentId,
            DateJoined = DateTime.UtcNow
        };
         
        var isAdded = await _repository.AddAsync(member);
        
        return new Response<bool>(isAdded);
    }
    
    public async Task<Response<bool>> DeleteAsync(string membershipId)
    {
        var isDeleted = await _repository.DeleteAsync(membershipId);
        return new Response<bool>(isDeleted);
    }
        
}
