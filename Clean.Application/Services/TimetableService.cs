using Clean.Application.Abstractions;
using Clean.Application.Dtos.Timetable;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class TimetableService : ITimetableService
{
    private readonly ITimetableRepository _repository;

    public TimetableService(ITimetableRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> AddAsync(AddTimetableDto dto)
    {
        var timetable = new Timetable
        {
            ClassroomId = dto.ClassroomId,
            TeacherId = dto.TeacherId,
            SubjectId = dto.SubjectId,
            StudentGroupId = dto.StudentGroupId,
            TimeSlot = dto.TimeSlot
        };
        var added = await _repository.AddAsync(timetable);
        return new Response<bool>(added);
    }

    public async Task<Response<IEnumerable<GetTimetableDto>>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        var dtoList = list.Select(t => new GetTimetableDto
        {
            TimetableId = t.TimetableId,
            ClassroomId = t.ClassroomId,
            TeacherId = t.TeacherId,
            SubjectId = t.SubjectId,
            StudentGroupId = t.StudentGroupId,
            TimeSlot = t.TimeSlot
        }).ToList();

        return new Response<IEnumerable<GetTimetableDto>>(dtoList);
    }

    public async Task<Response<GetTimetableDto>> GetByIdAsync(string id)
    {
        var t = await _repository.GetByIdAsync(id);
        var dto = new GetTimetableDto
        {
            TimetableId = t.TimetableId,
            ClassroomId = t.ClassroomId,
            TeacherId = t.TeacherId,
            SubjectId = t.SubjectId,
            StudentGroupId = t.StudentGroupId,
            TimeSlot = t.TimeSlot
        };
        return new Response<GetTimetableDto>(dto);
    }

    public async Task<Response<bool>> UpdateAsync(UpdateTimetableDto dto)
    {
        var timetable = new Timetable
        {
            TimetableId = dto.TimetableId,
            ClassroomId = dto.ClassroomId,
            TeacherId = dto.TeacherId,
            SubjectId = dto.SubjectId,
            StudentGroupId = dto.StudentGroupId,
            TimeSlot = dto.TimeSlot
        };
        var updated = await _repository.UpdateAsync(timetable);
        return new Response<bool>(updated);
    }

    public async Task<Response<bool>> DeleteAsync(string id)
    {
        var deleted = await _repository.DeleteAsync(id);
        return new Response<bool>(deleted);
    }
}
