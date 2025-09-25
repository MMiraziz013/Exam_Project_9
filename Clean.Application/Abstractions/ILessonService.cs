using Clean.Application.Dtos.Lesson;
using Clean.Application.Services;

namespace Clean.Application.Abstractions;

public interface ILessonService
{
    Task<Response<bool>> AddAsync(AddLessonDto dto);
    Task<Response<IEnumerable<GetLessonDto>>> GetAllAsync();
    Task<Response<GetLessonDto>> GetByIdAsync(string id);
    Task<Response<bool>> UpdateAsync(UpdateLessonDto dto);
    Task<Response<bool>> DeleteAsync(string id);
}