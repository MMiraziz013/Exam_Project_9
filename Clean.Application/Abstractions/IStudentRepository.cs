using Clean.Application.Dtos.Response;
using Clean.Application.Dtos.Student;
using Clean.Application.Services;
using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IStudentRepository
{
    public Task<Student> GetStudentByIdAsync(string id);
    public Task<Student> AssignClasses(string id, List<string> courseids);
}