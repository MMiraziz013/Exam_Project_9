using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IStudentGroupMemberRepository
{
    Task<StudentGroupMember?> GetByIdAsync(string membershipId);
    Task<IEnumerable<StudentGroupMember>> GetAllAsync();
    Task<bool> AddAsync(StudentGroupMember member);
    Task<bool> UpdateAsync(StudentGroupMember member);
    Task<bool> DeleteAsync(string membershipId);
}
