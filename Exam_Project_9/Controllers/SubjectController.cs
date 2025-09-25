using Clean.Application.Abstractions;
using Clean.Application.Dtos.Subject;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("[controller]")]
public class SubjectsController : Controller
{
    private readonly ISubjectService _service;

    public SubjectsController(ISubjectService service)
    {
        _service = service;
    }

    [HttpPost("add-subject")]
    public async Task<IActionResult> Add(AddSubjectDto dto)
    {
        var response = await _service.AddAsync(dto);
        return Ok(response);
    }

    [HttpGet("get-all-subjects")]
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

    [HttpPut("update-subject")]
    public async Task<IActionResult> Update(UpdateSubjectDto dto)
    {
        var response = await _service.UpdateAsync(dto);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _service.DeleteAsync(id);
        return Ok(response);
    }
}