using Clean.Application.Abstractions;
using Clean.Application.Dtos.Subject;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _repository;

    public SubjectService(ISubjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> AddAsync(AddSubjectDto dto)
    {
        var subject = new Subject
        {
            SubjectId = Guid.NewGuid().ToString(),
            Name = dto.Name,
            Description = dto.Description
        };

        var result = await _repository.AddAsync(subject);
        return new Response<bool>(result);
    }

    public async Task<Response<IEnumerable<GetSubjectDto>>> GetAllAsync()
    {
        var subjects = await _repository.GetAllAsync();
        var dtoList = subjects.Select(s => new GetSubjectDto
        {
            SubjectId = s.SubjectId,
            Name = s.Name,
            Description = s.Description
        }).ToList();

        return new Response<IEnumerable<GetSubjectDto>>(dtoList);
    }

    public async Task<Response<GetSubjectDto>> GetByIdAsync(string id)
    {
        var subject = await _repository.GetByIdAsync(id);
        if (subject == null) throw new ArgumentException("Subject not found");

        var dto = new GetSubjectDto
        {
            SubjectId = subject.SubjectId,
            Name = subject.Name,
            Description = subject.Description
        };

        return new Response<GetSubjectDto>(dto);
    }

    public async Task<Response<bool>> UpdateAsync(UpdateSubjectDto dto)
    {
        var subject = new Subject
        {
            SubjectId = dto.SubjectId,
            Name = dto.Name,
            Description = dto.Description
        };

        var result = await _repository.UpdateAsync(subject);
        return new Response<bool>(result);
    }

    public async Task<Response<bool>> DeleteAsync(string id)
    {
        var result = await _repository.DeleteAsync(id);
        return new Response<bool>(result);
    }
}
