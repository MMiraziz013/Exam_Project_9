using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class ClassroomRepository : IClassroomRepository
{
    private readonly DataContext _context;

    public ClassroomRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Classroom classroom)
    {
        try
        {
            await _context.Classrooms.AddAsync(classroom);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<Classroom>> GetAllAsync() =>
        await _context.Classrooms.ToListAsync();

    public async Task<Classroom> GetByIdAsync(string id)
    {
        var room = await _context.Classrooms.FindAsync(id);
        if (room is not null) return room;

        throw new ArgumentException($"No classroom with id {id}");
    }

    public async Task<bool> UpdateAsync(Classroom classroom)
    {
        var room = await _context.Classrooms.FindAsync(classroom.ClassroomId);
        if (room is null) throw new ArgumentException($"No classroom with id {classroom.ClassroomId}");

        room.RoomNumber = classroom.RoomNumber;
        room.Capacity = classroom.Capacity;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentException("Id is empty!");
        var room = await GetByIdAsync(id);
        _context.Classrooms.Remove(room);
        await _context.SaveChangesAsync();
        return true;
    }
}
