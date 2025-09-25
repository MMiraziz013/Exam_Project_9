using Clean.Application.Dtos.StudentGroupMember;
using Clean.Application.Services;
using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IStudentGroupMemberService
{
    Task<Response<GetStudentGroupMemberDto?>> GetByIdAsync(string membershipId);
    Task<Response<IEnumerable<GetStudentGroupMemberDto>>> GetAllAsync();
    Task<Response<bool>> CreateAsync(string groupId, string studentId);
    Task<Response<bool>> DeleteAsync(string membershipId);
}
