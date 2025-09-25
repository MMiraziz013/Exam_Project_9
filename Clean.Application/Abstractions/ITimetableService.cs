using Clean.Application.Dtos.Timetable;
using Clean.Application.Services;

namespace Clean.Application.Abstractions;

public interface ITimetableService
{
    Task<Response<bool>> AddAsync(AddTimetableDto dto);
    Task<Response<IEnumerable<GetTimetableDto>>> GetAllAsync();
    Task<Response<GetTimetableDto>> GetByIdAsync(string id);
    Task<Response<bool>> UpdateAsync(UpdateTimetableDto dto);
    Task<Response<bool>> DeleteAsync(string id);
}