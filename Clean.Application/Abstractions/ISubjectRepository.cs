using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface ISubjectRepository
{
    Task<bool> AddAsync(Subject subject);
    Task<IEnumerable<Subject>> GetAllAsync();
    Task<Subject?> GetByIdAsync(string id);
    Task<bool> UpdateAsync(Subject subject);
    Task<bool> DeleteAsync(string id);
}