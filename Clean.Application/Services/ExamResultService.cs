using Clean.Application.Abstractions;
using Clean.Application.Dtos.ExamResults;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class ExamResultService : IExamResultService
{
    private readonly IExamResultRepository _repository;

    public ExamResultService(IExamResultRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> AddAsync(AddExamResultDto dto)
    {
        var result = new ExamResult
        {
            ExamId = dto.ExamId,
            StudentId = dto.StudentId,
            Score = (float)dto.Score,
            Grade = dto.Grade
        };
        var added = await _repository.AddAsync(result);
        return new Response<bool>(added);
    }

    public async Task<Response<IEnumerable<GetExamResultDto>>> GetAllAsync()
    {
        var results = await _repository.GetAllAsync();
        var dtoList = results.Select(r => new GetExamResultDto
        {
            ResultId = r.ResultId,
            ExamId = r.ExamId,
            StudentId = r.StudentId,
            Score = r.Score,
            Grade = r.Grade
        }).ToList();

        return new Response<IEnumerable<GetExamResultDto>>(dtoList);
    }

    public async Task<Response<GetExamResultDto>> GetByIdAsync(string id)
    {
        var result = await _repository.GetByIdAsync(id);
        var dto = new GetExamResultDto
        {
            ResultId = result.ResultId,
            ExamId = result.ExamId,
            StudentId = result.StudentId,
            Score = result.Score,
            Grade = result.Grade
        };
        return new Response<GetExamResultDto>(dto);
    }

    public async Task<Response<bool>> UpdateAsync(UpdateExamResultDto dto)
    {
        var result = new ExamResult
        {
            ResultId = dto.ResultId,
            Score = (float)dto.Score,
            Grade = dto.Grade
        };
        var updated = await _repository.UpdateAsync(result);
        return new Response<bool>(updated);
    }

    public async Task<Response<bool>> DeleteAsync(string id)
    {
        var deleted = await _repository.DeleteAsync(id);
        return new Response<bool>(deleted);
    }
}
