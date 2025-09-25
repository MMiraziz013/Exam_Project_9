using Clean.Application.Abstractions;
using Clean.Application.Dtos.Timetable;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("[controller]")]
public class TimetableController : ControllerBase
{
    private readonly ITimetableService _service;

    public TimetableController(ITimetableService service)
    {
        _service = service;
    }

    [HttpPost("add-timetable")]
    public async Task<IActionResult> Add([FromBody] AddTimetableDto dto)
    {
        var result = await _service.AddAsync(dto);
        return Ok(result);
    }

    [HttpGet("get-all-timetables")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("get-timetable/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPut("update-timetable")]
    public async Task<IActionResult> Update([FromBody] UpdateTimetableDto dto)
    {
        var result = await _service.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("delete-timetable/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }
}
