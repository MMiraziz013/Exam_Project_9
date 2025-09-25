using Clean.Application.Abstractions;
using Clean.Application.Dtos.Student;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentController : Controller
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }

    [HttpPost("add-user")]
    public async Task<IActionResult> AddStudent([FromBody]AddStudentDto dto)
    {
        var response = await _service.AddAsync(dto);
        return Ok(response);
    }

    [HttpGet("get-all-students")]
    public async Task<IActionResult> GetStudents()
    {
        var response = await _service.GetAllAsync();
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(string id)
    {
        var response = await _service.GetStudentByIdAsync(id);
        return Ok(response);
    }

    [HttpPut("update-student")]
    public async Task<IActionResult> UpdateStudent([FromBody]UpdateStudentDto dto)
    {
        var response = await _service.UpdateAsync(dto);
        return Ok(response);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteStudent(string id)
    {
        var response = await _service.DeleteAsync(id);
        return Ok(response);
    }

}