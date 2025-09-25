using Clean.Application.Abstractions;
using Clean.Application.Dtos.Student;
using Clean.Domain.Entities;

namespace Clean.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Response<bool>> AddAsync(AddStudentDto student)
    {
        
        var isAdded = await _repository.AddAsync(new Student
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth,
            EnrollmentDate = DateTime.UtcNow
        });

        return new Response<bool>(isAdded);
    }

    public async Task<Response<IEnumerable<GetStudentDto>>> GetAllAsync()
    {
        var students = await _repository.GetAllAsync();
        var studentDtos = new List<GetStudentDto>();
        foreach (var student in students)
        {
            studentDtos.Add(new GetStudentDto
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                EnrollmentDate = student.EnrollmentDate
            });
        }

        return new Response<IEnumerable<GetStudentDto>>(studentDtos);
    }
        
    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("Id is empty");
        }
        
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
    
    public async Task<Response<bool>> UpdateAsync(UpdateStudentDto student)
    {
        var data = new Student()
        {
            StudentId = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth
        };

        var isUpdated = await _repository.UpdateAsync(data);
        return new Response<bool>(isUpdated);
    }

    public async Task<Response<bool>> DeleteAsync(string id)
    {
        var isDeleted = await _repository.DeleteAsync(id);
        return new Response<bool>(isDeleted);
    }

    public Task<Response<bool>> AssignClasses(string id, List<string> courses)
    {
        throw new NotImplementedException();
    }
}