using Clean.Application.Dtos.Attendance;
using Clean.Application.Services;

namespace Clean.Application.Abstractions;

public interface IAttendanceService
{
    Task<Response<bool>> AddAsync(AddAttendanceDto dto);
    Task<Response<IEnumerable<GetAttendanceDto>>> GetAllAsync();
    Task<Response<GetAttendanceDto>> GetByIdAsync(string id);
    Task<Response<bool>> UpdateAsync(UpdateAttendanceDto dto);
    Task<Response<bool>> DeleteAsync(string id);
    Task<Response<IEnumerable<GetAttendanceDto>>> GetByStudentIdAsync(string studentId);

    Task<Response<IEnumerable<GetAttendanceDto>>> GetByLessonIdAsync(string lessonId);

    Task<Response<bool>> AssignStudentToLesson(string studentId, string lessonId, string status = "Enrolled");
}