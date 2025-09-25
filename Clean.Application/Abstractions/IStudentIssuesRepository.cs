using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IStudentIssueRepository
{
    Task<bool> AddAsync(StudentIssue issue);
    Task<IEnumerable<StudentIssue>> GetAllAsync();
    Task<StudentIssue> GetByIdAsync(string id);
    Task<bool> UpdateAsync(StudentIssue issue);
    Task<bool> DeleteAsync(string id);
}
