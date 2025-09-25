using Clean.Application.Abstractions;
using Clean.Application.Dtos.StudentIssue;
using Clean.Application.Dtos.StudentIssue.Clean.Application.Dtos.StudentIssue;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class StudentIssueService : IStudentIssueService
{
    private readonly IStudentIssueRepository _repository;

    public StudentIssueService(IStudentIssueRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> AddAsync(AddStudentIssueDto dto)
    {
        var issue = new StudentIssue
        {
            StudentId = dto.StudentId,
            Description = dto.Description,
            DateReported = dto.DateReported
        };

        var added = await _repository.AddAsync(issue);
        return new Response<bool>(added);
    }

    public async Task<Response<IEnumerable<GetStudentIssueDto>>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        var dtoList = list.Select(i => new GetStudentIssueDto
        {
            IssueId = i.IssueId,
            StudentId = i.StudentId,
            Description = i.Description,
            DateReported = i.DateReported
        }).ToList();

        return new Response<IEnumerable<GetStudentIssueDto>>(dtoList);
    }

    public async Task<Response<GetStudentIssueDto>> GetByIdAsync(string id)
    {
        var i = await _repository.GetByIdAsync(id);
        var dto = new GetStudentIssueDto
        {
            IssueId = i.IssueId,
            StudentId = i.StudentId,
            Description = i.Description,
            DateReported = i.DateReported
        };
        return new Response<GetStudentIssueDto>(dto);
    }

    public async Task<Response<bool>> UpdateAsync(UpdateStudentIssueDto dto)
    {
        var issue = new StudentIssue
        {
            IssueId = dto.IssueId,
            StudentId = dto.StudentId,
            Description = dto.Description,
            DateReported = dto.DateReported
        };
        var updated = await _repository.UpdateAsync(issue);
        return new Response<bool>(updated);
    }

    public async Task<Response<bool>> DeleteAsync(string id)
    {
        var deleted = await _repository.DeleteAsync(id);
        return new Response<bool>(deleted);
    }
}
