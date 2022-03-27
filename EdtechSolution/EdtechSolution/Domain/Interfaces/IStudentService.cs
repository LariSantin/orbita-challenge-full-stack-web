using EdtechSolution.Application.DTOs;
using EdtechSolution.Application.ViewModels;

namespace EdtechSolution.Domain.Interfaces;

public interface IStudentService
{
    Task<StudentViewModel?> AddStudent(AddStudentDTO studentDto);
    List<StudentViewModel> Get();
    StudentViewModel? GetById(string id);
    Task<bool> Remove(string id);
    Task<StudentViewModel?> Update(string id, UpdateStudentDTO student);
}