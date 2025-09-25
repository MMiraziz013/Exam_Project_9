using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly DataContext _context;

    public AttendanceRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Attendance attendance)
    {
        await _context.Attendances.AddAsync(attendance);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Attendance>> GetAllAsync() =>
        await _context.Attendances.ToListAsync();

    public async Task<Attendance> GetByIdAsync(string id)
    {
        var att = await _context.Attendances.FindAsync(id);
        if (att is not null) return att;

        throw new ArgumentException($"No attendance record with id {id}");
    }

    public async Task<IEnumerable<Attendance>> GetByStudentIdAsync(string studentId) =>
        await _context.Attendances.Where(a => a.StudentId == studentId).ToListAsync();

    public async Task<IEnumerable<Attendance>> GetByLessonIdAsync(string lessonId) =>
        await _context.Attendances.Where(a => a.LessonId == lessonId).ToListAsync();

    public async Task<bool> UpdateAsync(Attendance attendance)
    {
        var existing = await _context.Attendances.FindAsync(attendance.AttendanceId);
        if (existing is null) throw new ArgumentException($"No attendance record with id {attendance.AttendanceId}");

        existing.Status = attendance.Status;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var att = await GetByIdAsync(id);
        _context.Attendances.Remove(att);
        await _context.SaveChangesAsync();
        return true;
    }
}
