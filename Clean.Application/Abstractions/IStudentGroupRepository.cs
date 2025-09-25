using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IStudentGroupRepository
{
    Task<IEnumerable<StudentGroup>> GetAllAsync();
    Task<StudentGroup?> GetByIdAsync(string id);
    Task<bool> AddAsync(StudentGroup group);
    Task<bool> UpdateAsync(StudentGroup group);
    Task<bool> DeleteAsync(string id);
}