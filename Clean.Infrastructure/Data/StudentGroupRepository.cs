using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class StudentGroupRepository : IStudentGroupRepository
{
    private readonly DataContext _context;

    public StudentGroupRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StudentGroup>> GetAllAsync()
    {
        return await _context.StudentGroups
            .Include(g => g.Members)
            .ThenInclude(m=> m.Student)
            .ToListAsync();
    }

    public async Task<StudentGroup?> GetByIdAsync(string id)
    {
        return await _context.StudentGroups
            .Include(g => g.Members)
            .ThenInclude(m=> m.Student)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<bool> AddAsync(StudentGroup group)
    {
        await _context.StudentGroups.AddAsync(group);
        var changes = await _context.SaveChangesAsync();
        if (changes > 0)
        {
            return true;
        }
        throw new ArgumentException($"No group with id: {group.Id}");
    }

    public async Task<bool> UpdateAsync(StudentGroup group)
    {
        _context.StudentGroups.Update(group);
        var changes = await _context.SaveChangesAsync();
        if (changes > 0)
        {
            return true;
        }
        
        throw new ArgumentException($"No group with id: {group.Id}");
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var group = await _context.StudentGroups.FindAsync(id);
        if (group != null)
        {
            _context.StudentGroups.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }

        throw new ArgumentException($"No group with id: {id}");
    }
}
