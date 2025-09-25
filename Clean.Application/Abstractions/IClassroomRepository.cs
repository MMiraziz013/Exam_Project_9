using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IClassroomRepository
{
    Task<bool> AddAsync(Classroom classroom);
    Task<IEnumerable<Classroom>> GetAllAsync();
    Task<Classroom> GetByIdAsync(string id);
    Task<bool> UpdateAsync(Classroom classroom);
    Task<bool> DeleteAsync(string id);
}