using Clean.Application.Dtos.Subject;
using Clean.Application.Services;

namespace Clean.Application.Abstractions;

public interface ISubjectService
{
    Task<Response<bool>> AddAsync(AddSubjectDto dto);
    Task<Response<IEnumerable<GetSubjectDto>>> GetAllAsync();
    Task<Response<GetSubjectDto>> GetByIdAsync(string id);
    Task<Response<bool>> UpdateAsync(UpdateSubjectDto dto);
    Task<Response<bool>> DeleteAsync(string id);

}