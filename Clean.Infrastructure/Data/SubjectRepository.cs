using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class SubjectRepository : ISubjectRepository
{
    private readonly DataContext _context;

    public SubjectRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Subject subject)
    {
        await _context.Subjects.AddAsync(subject);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Subject>> GetAllAsync()
    {
        return await _context.Subjects.AsNoTracking().ToListAsync();
    }

    public async Task<Subject?> GetByIdAsync(string id)
    {
        return await _context.Subjects.AsNoTracking()
            .FirstOrDefaultAsync(s => s.SubjectId == id);
    }

    public async Task<bool> UpdateAsync(Subject subject)
    {
        _context.Subjects.Update(subject);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var entity = await _context.Subjects.FindAsync(id);
        if (entity == null) return false;

        _context.Subjects.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}
