using Clean.Application.Abstractions;
using Clean.Application.Dtos.Exam;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamController : ControllerBase
{
    private readonly IExamService _service;

    public ExamController(IExamService service)
    {
        _service = service;
    }

    [HttpPost("add-exam")]
    public async Task<IActionResult> Add([FromBody] AddExamDto dto)
    {
        var result = await _service.AddAsync(dto);
        return Ok(result);
    }

    [HttpGet("get-all-exams")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("get-exam/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPut("update-exam")]
    public async Task<IActionResult> Update([FromBody] UpdateExamDto dto)
    {
        var result = await _service.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("delete-exam/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }
}