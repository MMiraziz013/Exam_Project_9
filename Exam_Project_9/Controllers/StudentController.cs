using Clean.Application.Abstractions;
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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(string id)
    {
        var response = await _service.GetStudentByIdAsync(id);
        return Ok(response);
    }
}