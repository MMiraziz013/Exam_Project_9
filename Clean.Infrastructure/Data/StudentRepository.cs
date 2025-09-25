using Clean.Application.Abstractions;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data;

public class StudentRepository : IStudentRepository
{
    private readonly IDataContext _context;

    public StudentRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<bool> AddAsync(Student student)
    {
        try
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }
    
    public async Task<IEnumerable<Student>> GetAllAsync() =>
        await _context.Students.ToListAsync();
    
    public async Task<Student>? GetStudentByIdAsync(string id)
    {
        var st = await _context.Students.FindAsync(id);
        if (st is not null)
        {
            return st;
        }

        throw new ArgumentException($"No student with id {id}");
    }
    
    public async Task<bool> UpdateAsync(Student student)
    {
        var st = await _context.Students.FindAsync(student.StudentId);
        if (st is null) throw new ArgumentException($"No student with id: {student.StudentId}");

        st.FirstName = student.FirstName;
        st.LastName = student.LastName;
        st.DateOfBirth = student.DateOfBirth;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentException("Id is empty!");
        var student = await GetStudentByIdAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
        throw new ArgumentException($"No student with id: {id}");
    }

}