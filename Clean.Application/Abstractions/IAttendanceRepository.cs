using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;


public interface IAttendanceRepository
{
    Task<bool> AddAsync(Attendance attendance);
    Task<IEnumerable<Attendance>> GetAllAsync();
    Task<Attendance> GetByIdAsync(string id);
    Task<IEnumerable<Attendance>> GetByStudentIdAsync(string studentId);
    Task<IEnumerable<Attendance>> GetByLessonIdAsync(string lessonId);
    Task<bool> UpdateAsync(Attendance attendance);
    Task<bool> DeleteAsync(string id);
}