using Clean.Application.Abstractions;
using Clean.Application.Dtos.StudentGroupMember;
using Clean.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentGroupMemberController : ControllerBase
{
    private readonly IStudentGroupMemberService _service;

    public StudentGroupMemberController(IStudentGroupMemberService service)
    {
        _service = service;
    }

    [HttpGet("get-all-student-groups")]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var member = await _service.GetByIdAsync(id);
        return Ok(member);
    }

    [HttpPost("add-group-member")]
    public async Task<IActionResult> Create([FromBody] CreateStudentGroupMemberDto dto)
    {
        var member = await _service.CreateAsync(dto.GroupId, dto.StudentId);
        return Ok(member);
    }

    // I figured that Update is not needed, because there's nothing that can be updated in this entity.

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
