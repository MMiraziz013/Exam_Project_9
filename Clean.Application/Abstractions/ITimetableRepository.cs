using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface ITimetableRepository
{
    Task<bool> AddAsync(Timetable timetable);
    Task<IEnumerable<Timetable>> GetAllAsync();
    Task<Timetable> GetByIdAsync(string id);
    Task<bool> UpdateAsync(Timetable timetable);
    Task<bool> DeleteAsync(string id);
}
