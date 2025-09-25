using Clean.Application.Abstractions;
using Clean.Application.Dtos.Classroom;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassroomController : ControllerBase
{
    private readonly IClassroomService _service;

    public ClassroomController(IClassroomService service)
    {
        _service = service;
    }

    [HttpPost("add-classroom")]
    public async Task<IActionResult> AddClassroom([FromBody] AddClassroomDto dto)
    {
        var response = await _service.AddAsync(dto);
        return Ok(response);
    }

    [HttpGet("get-all-classrooms")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _service.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var response = await _service.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPut("update-classroom")]
    public async Task<IActionResult> Update([FromBody] UpdateClassroomDto dto)
    {
        var response = await _service.UpdateAsync(dto);
        return Ok(response);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _service.DeleteAsync(id);
        return Ok(response);
    }
}