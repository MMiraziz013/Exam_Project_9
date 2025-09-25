using Clean.Application.Abstractions;
using Clean.Application.Dtos.Attendance;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _repository;

    public AttendanceService(IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> AddAsync(AddAttendanceDto dto)
    {
        var attendance = new Attendance
        {
            AttendanceId = Guid.NewGuid().ToString(),
            StudentId = dto.StudentId,
            LessonId = dto.LessonId,
            Status = dto.Status
        };

        var result = await _repository.AddAsync(attendance);
        return new Response<bool>(result);
    }

    public async Task<Response<IEnumerable<GetAttendanceDto>>> GetAllAsync()
    {
        var attendances = await _repository.GetAllAsync();
        var dtoList = attendances.Select(MapToDto).ToList();
        return new Response<IEnumerable<GetAttendanceDto>>(dtoList);
    }

    public async Task<Response<GetAttendanceDto>> GetByIdAsync(string id)
    {
        var a = await _repository.GetByIdAsync(id);
        return new Response<GetAttendanceDto>(MapToDto(a));
    }

    public async Task<Response<IEnumerable<GetAttendanceDto>>> GetByStudentIdAsync(string studentId)
    {
        var attendances = await _repository.GetByStudentIdAsync(studentId);
        var dtoList = attendances.Select(MapToDto).ToList();
        return new Response<IEnumerable<GetAttendanceDto>>(dtoList);
    }

    public async Task<Response<IEnumerable<GetAttendanceDto>>> GetByLessonIdAsync(string lessonId)
    {
        var attendances = await _repository.GetByLessonIdAsync(lessonId);
        var dtoList = attendances.Select(MapToDto).ToList();
        return new Response<IEnumerable<GetAttendanceDto>>(dtoList);
    }

    public async Task<Response<bool>> UpdateAsync(UpdateAttendanceDto dto)
    {
        var attendance = new Attendance
        {
            AttendanceId = dto.AttendanceId,
            Status = dto.Status
        };

        var result = await _repository.UpdateAsync(attendance);
        return new Response<bool>(result);
    }

    public async Task<Response<bool>> DeleteAsync(string id)
    {
        var result = await _repository.DeleteAsync(id);
        return new Response<bool>(result);
    }

    public async Task<Response<bool>> AssignStudentToLesson(string studentId, string lessonId, string status = "Enrolled")
    {
        var attendance = new Attendance
        {
            AttendanceId = Guid.NewGuid().ToString(),
            StudentId = studentId,
            LessonId = lessonId,
            Status = status
        };

        var result = await _repository.AddAsync(attendance);
        return new Response<bool>(result);
    }

    private GetAttendanceDto MapToDto(Attendance a) =>
        new GetAttendanceDto
        {
            AttendanceId = a.AttendanceId,
            StudentId = a.StudentId,
            LessonId = a.LessonId,
            Status = a.Status
        };
}
