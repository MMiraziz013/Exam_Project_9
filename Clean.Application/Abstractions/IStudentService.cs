using Clean.Application.Dtos.Student;
using Clean.Application.Services;

namespace Clean.Application.Abstractions;

public interface IStudentService
{
    public Task<Response<GetStudentDto>> GetStudentByIdAsync(string id);

    public Task<Response<bool>> AssignClasses(string id, List<string> courses);

    Task<Response<IEnumerable<GetStudentDto>>> GetAllAsync();
    Task<Response<bool>> AddAsync(AddStudentDto student);
    Task<Response<bool>> UpdateAsync(UpdateStudentDto student);
    Task<Response<bool>> DeleteAsync(string id);

}