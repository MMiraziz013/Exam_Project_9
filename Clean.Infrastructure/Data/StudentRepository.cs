using Clean.Application.Abstractions;
using Clean.Domain.Entities;

namespace Clean.Infrastructure.Data;

public class StudentRepository : IStudentRepository
{
    private readonly IDataContext _context;

    public StudentRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<Student> GetStudentByIdAsync(string id)
    {
        var st = await _context.Students.FindAsync(id);
        if (st is not null)
        {
            return st;
        }

        throw new ArgumentException($"No student with id {id}");
    }

    public Task<Student> AssignClasses(string id, List<string> courseids)
    {
        throw new NotImplementedException();
    }
}