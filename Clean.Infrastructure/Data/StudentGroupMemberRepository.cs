using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class StudentGroupMemberRepository : IStudentGroupMemberRepository
{
    private readonly DataContext _context;

    public StudentGroupMemberRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(StudentGroupMember member)
    {
        try
        {
            await _context.StudentGroupMembers.AddAsync(member);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<StudentGroupMember>> GetAllAsync() =>
        await _context.StudentGroupMembers
            .Include(m => m.Student)
            .Include(m => m.Group)
            .ToListAsync();

    public async Task<StudentGroupMember?> GetByIdAsync(string id)
    {
        var member = await _context.StudentGroupMembers
            .Include(m => m.Student)
            .Include(m => m.Group)
            .FirstOrDefaultAsync(m => m.MembershipId == id);

        if (member is not null) return member;
        throw new ArgumentException($"No student group member with id {id}");
    }

    public async Task<bool> UpdateAsync(StudentGroupMember member)
    {
        var existing = await _context.StudentGroupMembers.FindAsync(member.MembershipId);
        if (existing is null) throw new ArgumentException($"No student group member with id {member.MembershipId}");

        existing.StudentId = member.StudentId;
        existing.GroupId = member.GroupId;
        existing.DateJoined = member.DateJoined;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentException("Id is empty!");
        var member = await GetByIdAsync(id);
        if (member is null)
        {
            throw new ArgumentException($"No group member with this id!");
        }
        _context.StudentGroupMembers.Remove(member);
        await _context.SaveChangesAsync();
        return true;
    }
}

