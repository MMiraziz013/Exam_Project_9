using Clean.Application.Abstractions;
using Clean.Application.Dtos.ExamResults;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamResultController : ControllerBase
{
    private readonly IExamResultService _service;

    public ExamResultController(IExamResultService service)
    {
        _service = service;
    }

    [HttpPost("add-exam-result")]
    public async Task<IActionResult> Add([FromBody] AddExamResultDto dto)
    {
        var result = await _service.AddAsync(dto);
        return Ok(result);
    }

    [HttpGet("get-all-exam-results")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("get-exam-result/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPut("update-exam-result")]
    public async Task<IActionResult> Update([FromBody] UpdateExamResultDto dto)
    {
        var result = await _service.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("delete-exam-result/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }
}