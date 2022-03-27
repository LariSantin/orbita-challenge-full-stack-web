using EdtechSolution.Application.DTOs;
using EdtechSolution.Application.ViewModels;
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
    public async Task<ActionResult<StudentViewModel>> Add(AddStudentDTO student)
    {
        return Ok(await _service.AddStudent(student));
    }
    [HttpGet]
    public ActionResult<List<StudentViewModel>> Get()
    {
        return Ok(_service.Get());
    }    
    
    [HttpGet("{id}")]
    public ActionResult<StudentViewModel> GetById(string id)
    {
        var result = _service.GetById(id);
        if (result == null)
            return BadRequest("Student not found.");
        
        return Ok(result);
    }   
    
    [HttpDelete("{id}")]
    public Task<bool> Delete(string id)
    {
        return _service.Remove(id);
    }   
    
    [HttpPut("{id}")]
    public async Task<ActionResult<StudentViewModel>> Update(string id, UpdateStudentDTO student)
    {
        return Ok(await _service.Update(id, student));
    }
}