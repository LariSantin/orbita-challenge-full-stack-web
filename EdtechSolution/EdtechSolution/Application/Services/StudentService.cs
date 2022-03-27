using EdtechSolution.Application.DTOs;
using EdtechSolution.Domain.Interfaces;
using EdtechSolution.Repositories;

namespace EdtechSolution.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Student> AddStudent(StudentDTO studentDto)
    {
       return await _studentRepository.Add(
            new Student(
                Guid.NewGuid().ToString(),
                studentDto.Name,
                studentDto.Email,
                studentDto.AcademicRecord,
                studentDto.CPF)
            );
    }
}