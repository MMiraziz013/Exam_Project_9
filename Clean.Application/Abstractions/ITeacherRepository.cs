using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface ITeacherRepository
{
    Task<bool> AddAsync(Teacher teacher);
    Task<IEnumerable<Teacher>> GetAllAsync();
    Task<Teacher> GetByIdAsync(string id);
    Task<bool> UpdateAsync(Teacher teacher);
    Task<bool> DeleteAsync(string id);
}
