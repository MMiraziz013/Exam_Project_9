using Clean.Application.Dtos.ExamResults;
using Clean.Application.Services;

namespace Clean.Application.Abstractions;

public interface IExamResultService
{
    Task<Response<bool>> AddAsync(AddExamResultDto dto);
    Task<Response<IEnumerable<GetExamResultDto>>> GetAllAsync();
    Task<Response<GetExamResultDto>> GetByIdAsync(string id);
    Task<Response<bool>> UpdateAsync(UpdateExamResultDto dto);
    Task<Response<bool>> DeleteAsync(string id);
}
