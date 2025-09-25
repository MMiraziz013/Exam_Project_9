using Clean.Application.Dtos.StudentIssue;
using Clean.Application.Dtos.StudentIssue.Clean.Application.Dtos.StudentIssue;
using Clean.Application.Services;

namespace Clean.Application.Abstractions;

public interface IStudentIssueService
{
    Task<Response<bool>> AddAsync(AddStudentIssueDto dto);
    Task<Response<IEnumerable<GetStudentIssueDto>>> GetAllAsync();
    Task<Response<GetStudentIssueDto>> GetByIdAsync(string id);
    Task<Response<bool>> UpdateAsync(UpdateStudentIssueDto dto);
    Task<Response<bool>> DeleteAsync(string id);
}
