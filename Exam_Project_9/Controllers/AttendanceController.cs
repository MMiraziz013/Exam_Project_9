using Clean.Application.Abstractions;
using Clean.Application.Dtos.Attendance;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddAttendanceDto dto)
    {
        var result = await _attendanceService.AddAsync(dto);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _attendanceService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _attendanceService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetByStudentId(string studentId)
    {
        var result = await _attendanceService.GetByStudentIdAsync(studentId);
        return Ok(result);
    }

    [HttpGet("lesson/{lessonId}")]
    public async Task<IActionResult> GetByLessonId(string lessonId)
    {
        var result = await _attendanceService.GetByLessonIdAsync(lessonId);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateAttendanceDto dto)
    {
        if (id != dto.AttendanceId)
        {
            return BadRequest("ID in route and DTO do not match.");
        }

        var result = await _attendanceService.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _attendanceService.DeleteAsync(id);
        return Ok(result);
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignStudentToLesson([FromQuery] string studentId, [FromQuery] string lessonId, [FromQuery] string status = "Enrolled")
    {
        var result = await _attendanceService.AssignStudentToLesson(studentId, lessonId, status);
        return Ok(result);
    }
}