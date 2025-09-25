using Clean.Application.Dtos.Response;
using Clean.Application.Dtos.Student;
using Clean.Application.Services;
using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student>? GetStudentByIdAsync(string id);
    Task<bool> AddAsync(Student student);
    Task<bool> UpdateAsync(Student student);
    Task<bool> DeleteAsync(string id);
}