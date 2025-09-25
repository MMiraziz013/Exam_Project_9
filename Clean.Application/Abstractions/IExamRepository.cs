using Clean.Domain.Entities;

namespace Clean.Application.Abstractions;

public interface IExamRepository
{
    Task<bool> AddAsync(Exam exam);

    Task<IEnumerable<Exam>> GetAllAsync();

    Task<Exam> GetByIdAsync(string id);
    Task<bool> UpdateAsync(Exam exam);

    Task<bool> DeleteAsync(string id);
}