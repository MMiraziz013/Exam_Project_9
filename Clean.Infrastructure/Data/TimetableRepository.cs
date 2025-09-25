using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class TimetableRepository : ITimetableRepository
{
    private readonly DataContext _context;

    public TimetableRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Timetable timetable)
    {
        try
        {
            await _context.Timetables.AddAsync(timetable);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<Timetable>> GetAllAsync() =>
        await _context.Timetables.ToListAsync();

    public async Task<Timetable> GetByIdAsync(string id)
    {
        var timetable = await _context.Timetables.FindAsync(id);
        if (timetable != null) return timetable;
        throw new ArgumentException($"No timetable with id {id}");
    }

    public async Task<bool> UpdateAsync(Timetable timetable)
    {
        var existing = await _context.Timetables.FindAsync(timetable.TimetableId);
        if (existing == null) throw new ArgumentException($"No timetable with id {timetable.TimetableId}");

        existing.ClassroomId = timetable.ClassroomId;
        existing.TeacherId = timetable.TeacherId;
        existing.SubjectId = timetable.SubjectId;
        existing.StudentGroupId = timetable.StudentGroupId;
        existing.TimeSlot = timetable.TimeSlot;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var existing = await GetByIdAsync(id);
        _context.Timetables.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}
