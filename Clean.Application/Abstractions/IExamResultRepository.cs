using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IExamResultRepository
{
    Task<bool> AddAsync(ExamResult result);
    Task<IEnumerable<ExamResult>> GetAllAsync();
    Task<ExamResult> GetByIdAsync(string id);
    Task<bool> UpdateAsync(ExamResult result);
    Task<bool> DeleteAsync(string id);
}
