using EdtechSolution.Application.DTOs;
using EdtechSolution.Application.Services;
using EdtechSolution.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdtechSolution.Api;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentsController(IStudentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<List<Student>>> Add(StudentDTO student)
    {
        return Ok(await _service.AddStudent(student));
    }

}