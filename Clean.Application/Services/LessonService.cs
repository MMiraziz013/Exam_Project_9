using Clean.Application.Abstractions;
using Clean.Application.Dtos.Lesson;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _repository;

    public LessonService(ILessonRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> AddAsync(AddLessonDto dto)
    {
        var lesson = new Lesson
        {
            TimetableId = dto.TimetableId,
            LessonDate = dto.LessonDate
        };

        var added = await _repository.AddAsync(lesson);
        return new Response<bool>(added);
    }

    public async Task<Response<IEnumerable<GetLessonDto>>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        var dtoList = list.Select(l => new GetLessonDto
        {
            LessonId = l.LessonId,
            TimetableId = l.TimetableId,
            LessonDate = l.LessonDate
        }).ToList();

        return new Response<IEnumerable<GetLessonDto>>(dtoList);
    }

    public async Task<Response<GetLessonDto>> GetByIdAsync(string id)
    {
        var lesson = await _repository.GetByIdAsync(id);
        var dto = new GetLessonDto
        {
            LessonId = lesson.LessonId,
            TimetableId = lesson.TimetableId,
            LessonDate = lesson.LessonDate
        };
        return new Response<GetLessonDto>(dto);
    }

    public async Task<Response<bool>> UpdateAsync(UpdateLessonDto dto)
    {
        var lesson = new Lesson
        {
            LessonId = dto.LessonId,
            TimetableId = dto.TimetableId,
            LessonDate = dto.LessonDate
        };

        var updated = await _repository.UpdateAsync(lesson);
        return new Response<bool>(updated);
    }

    public async Task<Response<bool>> DeleteAsync(string id)
    {
        var deleted = await _repository.DeleteAsync(id);
        return new Response<bool>(deleted);
    }
}
