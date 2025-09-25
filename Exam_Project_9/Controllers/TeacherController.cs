using Clean.Application.Abstractions;
using Clean.Application.Dtos.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _service;

    public TeacherController(ITeacherService service)
    {
        _service = service;
    }

    [HttpPost("add-teacher")]
    public async Task<IActionResult> AddTeacher([FromBody] AddTeacherDto dto)
    {
        var response = await _service.AddAsync(dto);
        return Ok(response);
    }

    [HttpGet("get-all-teachers")]
    public async Task<IActionResult> GetTeachers()
    {
        var response = await _service.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeacherById(string id)
    {
        var response = await _service.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPut("update-teacher")]
    public async Task<IActionResult> UpdateTeacher([FromBody] UpdateTeacherDto dto)
    {
        var response = await _service.UpdateAsync(dto);
        return Ok(response);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteTeacher(string id)
    {
        var response = await _service.DeleteAsync(id);
        return Ok(response);
    }
}