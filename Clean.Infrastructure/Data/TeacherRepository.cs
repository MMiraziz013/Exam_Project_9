using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class TeacherRepository : ITeacherRepository
{
    private readonly DataContext _context;

    public TeacherRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Teacher teacher)
    {
        try
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<Teacher>> GetAllAsync() =>
        await _context.Teachers.ToListAsync();

    public async Task<Teacher> GetByIdAsync(string id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher is not null) return teacher;
        throw new ArgumentException($"No teacher with id {id}");
    }

    public async Task<bool> UpdateAsync(Teacher teacher)
    {
        var existing = await _context.Teachers.FindAsync(teacher.TeacherId);
        if (existing is null) throw new ArgumentException($"No teacher with id {teacher.TeacherId}");

        existing.FirstName = teacher.FirstName;
        existing.LastName = teacher.LastName;
        existing.HireDate = teacher.HireDate;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var teacher = await GetByIdAsync(id);
        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();
        return true;
    }
}
