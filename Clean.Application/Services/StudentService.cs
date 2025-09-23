using Clean.Application.Abstractions;
using Clean.Application.Dtos.Student;

namespace Clean.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }
    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(string id)
    {
        var student = await _repository.GetStudentByIdAsync(id);
        var studentDto = new GetStudentDto
        {
            StudentId = student.StudentId,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth,
            EnrollmentDate = student.EnrollmentDate
        };
        return new Response<GetStudentDto>(studentDto);
    }

    public Task<Response<bool>> AssignClasses(string id, List<string> courses)
    {
        throw new NotImplementedException();
    }
}