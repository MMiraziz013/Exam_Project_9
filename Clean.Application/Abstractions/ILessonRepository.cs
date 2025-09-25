using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface ILessonRepository
{
    Task<bool> AddAsync(Lesson lesson);
    Task<IEnumerable<Lesson>> GetAllAsync();
    Task<Lesson> GetByIdAsync(string id);
    Task<bool> UpdateAsync(Lesson lesson);
    Task<bool> DeleteAsync(string id);
}