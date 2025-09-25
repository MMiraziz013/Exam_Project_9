using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class ExamRepository : IExamRepository
{
    private readonly DataContext _context;

    public ExamRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Exam exam)
    {
        try
        {
            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Exam>> GetAllAsync() =>
        await _context.Exams.ToListAsync();

    public async Task<Exam> GetByIdAsync(string id)
    {
        var exam = await _context.Exams.FindAsync(id);
        if (exam != null) return exam;
        throw new ArgumentException($"No exam with id {id}");
    }

    public async Task<bool> UpdateAsync(Exam exam)
    {
        var existing = await _context.Exams.FindAsync(exam.ExamId);
        if (existing is null) throw new ArgumentException($"No exam with id {exam.ExamId}");

        existing.SubjectId = exam.SubjectId;
        existing.Date = exam.Date;
        existing.ExamType = exam.ExamType;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var exam = await GetByIdAsync(id);
        _context.Exams.Remove(exam);
        await _context.SaveChangesAsync();
        return true;
    }
}
