using Clean.Application.Abstractions;
using Clean.Application.Dtos.StudentGroup;
using Clean.Application.Dtos.StudentGroupMember;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class StudentGroupService : IStudentGroupService
{
    private readonly IStudentGroupRepository _groupRepository;

    public StudentGroupService(IStudentGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<Response<IEnumerable<GetStudentGroupDto>>> GetAllGroupsAsync()
    {
        var list = await _groupRepository.GetAllAsync();
        
        List<GetStudentGroupDto> dtos = list.Select(g => new GetStudentGroupDto
            {
                Id = g.Id,
                Name = g.Name,
                Members = g.Members.Select(m => new GetStudentGroupMemberDto
                {
                    MembershipId = m.MembershipId,
                    GroupId = m.GroupId,
                    GroupName = g.Name,
                    StudentId = m.StudentId,
                    StudentName = m.Student.FirstName + " " + m.Student.LastName,
                    DateJoined = m.DateJoined
                }).ToList()
            })
            .ToList();
        return new Response<IEnumerable<GetStudentGroupDto>>(dtos);
    }

    public async Task<Response<GetStudentGroupDto?>> GetGroupByIdAsync(string id)
    {
        var g = await _groupRepository.GetByIdAsync(id);
        if (g is null)
        {
            throw new ArgumentException("Group with this id is not found");
        }
        return new Response<GetStudentGroupDto?>(new GetStudentGroupDto
        {
            Id = g.Id,
            Name = g.Name,
            Members = g.Members.Select(m => new GetStudentGroupMemberDto
            {
                MembershipId = m.MembershipId,
                StudentId = m.StudentId,
                StudentName = m.Student.FirstName + " " + m.Student.LastName,
                DateJoined = m.DateJoined
            }).ToList()
        });
    }

    public async Task<Response<bool>> AddGroupAsync(AddStudentGroupDto group)
    {
        var gr = new StudentGroup
        {
            Name = group.Name
        };
        var isAdded =  await _groupRepository.AddAsync(gr);

        return new Response<bool>(isAdded);
    }

    public async Task<Response<bool>> UpdateGroupAsync(UpdateStudentGroupDto group)
    {
        var gr = new StudentGroup
        {
            Id = group.Id,
            Name = group.Name
        };
        var isUpdated = await _groupRepository.UpdateAsync(gr);
        return new Response<bool>(isUpdated);
    }

    public async Task<Response<bool>> DeleteGroupAsync(string id)
    {
        var isDeleted = await _groupRepository.DeleteAsync(id);
        return new Response<bool>(isDeleted);
    }
}
