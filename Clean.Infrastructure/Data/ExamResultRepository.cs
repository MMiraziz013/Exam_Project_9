using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class ExamResultRepository : IExamResultRepository
{
    private readonly DataContext _context;

    public ExamResultRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(ExamResult result)
    {
        try
        {
            await _context.ExamResults.AddAsync(result);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<ExamResult>> GetAllAsync() =>
        await _context.ExamResults.ToListAsync();

    public async Task<ExamResult> GetByIdAsync(string id)
    {
        var result = await _context.ExamResults.FindAsync(id);
        if (result != null) return result;
        throw new ArgumentException($"No exam result with id {id}");
    }

    public async Task<bool> UpdateAsync(ExamResult result)
    {
        var existing = await _context.ExamResults.FindAsync(result.ResultId);
        if (existing == null) throw new ArgumentException($"No exam result with id {result.ResultId}");

        existing.Score = result.Score;
        existing.Grade = result.Grade;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var existing = await GetByIdAsync(id);
        _context.ExamResults.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}
