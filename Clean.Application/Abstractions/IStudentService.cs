using Clean.Application.Dtos.Student;
using Clean.Application.Services;

namespace Clean.Application.Abstractions;

public interface IStudentService
{
    public Task<Response<GetStudentDto>> GetStudentByIdAsync(string id);

    public Task<Response<bool>> AssignClasses(string id, List<string> courses);
}