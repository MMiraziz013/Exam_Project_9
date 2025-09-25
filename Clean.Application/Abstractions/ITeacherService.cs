using Clean.Application.Dtos.Teacher;
using Clean.Application.Services;

namespace Clean.Application.Abstractions;

public interface ITeacherService
{
    Task<Response<bool>> AddAsync(AddTeacherDto dto);
    Task<Response<IEnumerable<GetTeacherDto>>> GetAllAsync();
    Task<Response<GetTeacherDto>> GetByIdAsync(string id);
    Task<Response<bool>> UpdateAsync(UpdateTeacherDto dto);
    Task<Response<bool>> DeleteAsync(string id);
}