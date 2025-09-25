using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class StudentIssueRepository : IStudentIssueRepository
{
    private readonly DataContext _context;

    public StudentIssueRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(StudentIssue issue)
    {
        try
        {
            await _context.StudentIssues.AddAsync(issue);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<StudentIssue>> GetAllAsync() =>
        await _context.StudentIssues.ToListAsync();

    public async Task<StudentIssue> GetByIdAsync(string id)
    {
        var issue = await _context.StudentIssues.FindAsync(id);
        if (issue != null) return issue;
        throw new ArgumentException($"No student issue with id {id}");
    }

    public async Task<bool> UpdateAsync(StudentIssue issue)
    {
        var existing = await _context.StudentIssues.FindAsync(issue.IssueId);
        if (existing == null) throw new ArgumentException($"No student issue with id {issue.IssueId}");

        existing.StudentId = issue.StudentId;
        existing.Description = issue.Description;
        existing.DateReported = issue.DateReported;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var existing = await GetByIdAsync(id);
        _context.StudentIssues.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}
