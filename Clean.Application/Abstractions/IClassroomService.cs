using Clean.Application.Dtos.Classroom;
using Clean.Application.Services;

namespace Clean.Application.Abstractions;


public interface IClassroomService
{
    Task<Response<bool>> AddAsync(AddClassroomDto dto);
    Task<Response<IEnumerable<GetClassroomDto>>> GetAllAsync();
    Task<Response<GetClassroomDto>> GetByIdAsync(string id);
    Task<Response<bool>> UpdateAsync(UpdateClassroomDto dto);
    Task<Response<bool>> DeleteAsync(string id);
}