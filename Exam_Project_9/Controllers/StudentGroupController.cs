using Clean.Application.Abstractions;
using Clean.Application.Dtos.StudentGroup;
using Clean.Application.Services;
using Clean.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Project_9.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentGroupsController : ControllerBase
{
    private readonly IStudentGroupService _service;

    public StudentGroupsController(IStudentGroupService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllGroupsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
        => Ok(await _service.GetGroupByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Add(AddStudentGroupDto dto)
        => Ok(await _service.AddGroupAsync(dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateStudentGroupDto dto)
    {
        dto.Id = id;
        return Ok(await _service.UpdateGroupAsync(dto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
        => Ok(await _service.DeleteGroupAsync(id));
}
