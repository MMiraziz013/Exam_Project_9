using Clean.Application.Dtos.Exam;
using Clean.Application.Services;
using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IExamService
{
    Task<Response<bool>> AddAsync(AddExamDto dto);

    Task<Response<IEnumerable<GetExamDto>>> GetAllAsync();

    Task<Response<GetExamDto>> GetByIdAsync(string id);

    Task<Response<bool>> UpdateAsync(UpdateExamDto dto);

    Task<Response<bool>> DeleteAsync(string id);
}