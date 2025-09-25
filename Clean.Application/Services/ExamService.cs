using Clean.Application.Abstractions;
using Clean.Application.Dtos.Exam;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class ExamService : IExamService
{
    private readonly IExamRepository _repository;

    public ExamService(IExamRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<bool>> AddAsync(AddExamDto dto)
    {
        var exam = new Exam
        {
            SubjectId = dto.SubjectId,
            Date = dto.Date,
            ExamType = dto.ExamType
        };
        var result = await _repository.AddAsync(exam);
        return new Response<bool>(result);
    }

    public async Task<Response<IEnumerable<GetExamDto>>> GetAllAsync()
    {
        var exams = await _repository.GetAllAsync();
        var dtoList = exams.Select(e => new GetExamDto
        {
            ExamId = e.ExamId,
            SubjectId = e.SubjectId,
            Date = e.Date,
            ExamType = e.ExamType
        }).ToList();

        return new Response<IEnumerable<GetExamDto>>(dtoList);
    }

    public async Task<Response<GetExamDto>> GetByIdAsync(string id)
    {
        var exam = await _repository.GetByIdAsync(id);
        var dto = new GetExamDto
        {
            ExamId = exam.ExamId,
            SubjectId = exam.SubjectId,
            Date = exam.Date,
            ExamType = exam.ExamType
        };

        return new Response<GetExamDto>(dto);
    }

    public async Task<Response<bool>> UpdateAsync(UpdateExamDto dto)
    {
        var exam = new Exam
        {
            ExamId = dto.ExamId,
            SubjectId = dto.SubjectId,
            Date = dto.Date,
            ExamType = dto.ExamType
        };
        var result = await _repository.UpdateAsync(exam);
        return new Response<bool>(result);
    }

    public async Task<Response<bool>> DeleteAsync(string id)
    {
        var result = await _repository.DeleteAsync(id);
        return new Response<bool>(result);
    }
}
