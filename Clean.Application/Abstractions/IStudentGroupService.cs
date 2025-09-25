using Clean.Application.Dtos.StudentGroup;
using Clean.Application.Services;
using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IStudentGroupService
{
    Task<Response<IEnumerable<GetStudentGroupDto>>> GetAllGroupsAsync();
    Task<Response<GetStudentGroupDto?>> GetGroupByIdAsync(string id);
    Task<Response<bool>> AddGroupAsync(AddStudentGroupDto  group);
    Task<Response<bool>> UpdateGroupAsync(UpdateStudentGroupDto group);
    Task<Response<bool>> DeleteGroupAsync(string id);
}