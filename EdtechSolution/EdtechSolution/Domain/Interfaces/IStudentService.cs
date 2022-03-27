using EdtechSolution.Application.DTOs;

namespace EdtechSolution.Domain.Interfaces;

public interface IStudentService
{
    Task<Student> AddStudent(StudentDTO studentDto);
}