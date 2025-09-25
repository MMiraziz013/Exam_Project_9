using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class LessonRepository : ILessonRepository
{
    private readonly DataContext _context;

    public LessonRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Lesson lesson)
    {
        try
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<Lesson>> GetAllAsync() =>
        await _context.Lessons.ToListAsync();

    public async Task<Lesson> GetByIdAsync(string id)
    {
        var lesson = await _context.Lessons.FindAsync(id);
        if (lesson != null) return lesson;
        throw new ArgumentException($"No lesson with id {id}");
    }

    public async Task<bool> UpdateAsync(Lesson lesson)
    {
        var existing = await _context.Lessons.FindAsync(lesson.LessonId);
        if (existing == null) throw new ArgumentException($"No lesson with id {lesson.LessonId}");

        existing.TimetableId = lesson.TimetableId;
        existing.LessonDate = lesson.LessonDate;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var existing = await GetByIdAsync(id);
        _context.Lessons.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}
