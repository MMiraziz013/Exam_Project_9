using Clean.Application.Abstractions;
using Clean.Application.Dtos.StudentIssue;
using Clean.Application.Dtos.StudentIssue.Clean.Application.Dtos.StudentIssue;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentIssueController : ControllerBase
{
    private readonly IStudentIssueService _service;

    public StudentIssueController(IStudentIssueService service)
    {
        _service = service;
    }

    [HttpPost("add-issue")]
    public async Task<IActionResult> Add([FromBody] AddStudentIssueDto dto)
    {
        var result = await _service.AddAsync(dto);
        return Ok(result);
    }

    [HttpGet("get-all-issues")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("get-issue/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPut("update-issue")]
    public async Task<IActionResult> Update([FromBody] UpdateStudentIssueDto dto)
    {
        var result = await _service.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("delete-issue/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }
}