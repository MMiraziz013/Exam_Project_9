using Clean.Application.Abstractions;
using Clean.Application.Dtos.Teacher;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;

    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> AddAsync(AddTeacherDto dto)
    {
        var teacher = new Teacher
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            HireDate = dto.HireDate
        };
        var result = await _repository.AddAsync(teacher);
        return new Response<bool>(result);
    }

    public async Task<Response<IEnumerable<GetTeacherDto>>> GetAllAsync()
    {
        var teachers = await _repository.GetAllAsync();
        var teacherDtos = teachers.Select(t => new GetTeacherDto
        {
            TeacherId = t.TeacherId,
            FirstName = t.FirstName,
            LastName = t.LastName,
            HireDate = t.HireDate
        });
        return new Response<IEnumerable<GetTeacherDto>>(teacherDtos);
    }

    public async Task<Response<GetTeacherDto>> GetByIdAsync(string id)
    {
        var t = await _repository.GetByIdAsync(id);
        return new Response<GetTeacherDto>(new GetTeacherDto
        {
            TeacherId = t.TeacherId,
            FirstName = t.FirstName,
            LastName = t.LastName,
            HireDate = t.HireDate
        });
    }

    public async Task<Response<bool>> UpdateAsync(UpdateTeacherDto dto)
    {
        var teacher = new Teacher
        {
            TeacherId = dto.TeacherId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            HireDate = dto.HireDate
        };
        var result = await _repository.UpdateAsync(teacher);
        return new Response<bool>(result);
    }

    public async Task<Response<bool>> DeleteAsync(string id)
    {
        var result = await _repository.DeleteAsync(id);
        return new Response<bool>(result);
    }
}
