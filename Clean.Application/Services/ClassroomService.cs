using Clean.Application.Abstractions;
using Clean.Application.Dtos.Classroom;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class ClassroomService : IClassroomService
{
    private readonly IClassroomRepository _repository;

    public ClassroomService(IClassroomRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> AddAsync(AddClassroomDto dto)
    {
        var classroom = new Classroom
        {
            RoomNumber = dto.RoomNumber,
            Capacity = dto.Capacity
        };

        var result = await _repository.AddAsync(classroom);
        return new Response<bool>(result);
    }

    public async Task<Response<IEnumerable<GetClassroomDto>>> GetAllAsync()
    {
        var classrooms = await _repository.GetAllAsync();
        var dtoList = classrooms.Select(c => new GetClassroomDto
        {
            ClassroomId = c.ClassroomId,
            RoomNumber = c.RoomNumber,
            Capacity = c.Capacity
        }).ToList();

        return new Response<IEnumerable<GetClassroomDto>>(dtoList);
    }

    public async Task<Response<GetClassroomDto>> GetByIdAsync(string id)
    {
        var classroom = await _repository.GetByIdAsync(id);
        var dto = new GetClassroomDto
        {
            ClassroomId = classroom.ClassroomId,
            RoomNumber = classroom.RoomNumber,
            Capacity = classroom.Capacity
        };

        return new Response<GetClassroomDto>(dto);
    }

    public async Task<Response<bool>> UpdateAsync(UpdateClassroomDto dto)
    {
        var classroom = new Classroom
        {
            ClassroomId = dto.ClassroomId,
            RoomNumber = dto.RoomNumber,
            Capacity = dto.Capacity
        };

        var result = await _repository.UpdateAsync(classroom);
        return new Response<bool>(result);
    }

    public async Task<Response<bool>> DeleteAsync(string id)
    {
        var result = await _repository.DeleteAsync(id);
        return new Response<bool>(result);
    }
}
