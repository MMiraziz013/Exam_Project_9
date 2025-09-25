using Clean.Application.Abstractions;
using Clean.Application.Dtos.Lesson;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("[controller]")]
public class LessonController : ControllerBase
{
    private readonly ILessonService _service;

    public LessonController(ILessonService service)
    {
        _service = service;
    }

    [HttpPost("add-lesson")]
    public async Task<IActionResult> Add([FromBody] AddLessonDto dto)
    {
        var result = await _service.AddAsync(dto);
        return Ok(result);
    }

    [HttpGet("get-all-lessons")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("get-lesson/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPut("update-lesson")]
    public async Task<IActionResult> Update([FromBody] UpdateLessonDto dto)
    {
        var result = await _service.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("delete-lesson/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }
}