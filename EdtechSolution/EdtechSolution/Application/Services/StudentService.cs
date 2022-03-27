using EdtechSolution.Application.DTOs;
using EdtechSolution.Application.ViewModels;
using EdtechSolution.Domain.Interfaces;

namespace EdtechSolution.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<StudentViewModel?> AddStudent(AddStudentDTO studentDto)
    {
        if (!Validations(studentDto)) return null;
        
        var student = await _studentRepository.Add(
            new Student(
                Guid.NewGuid().ToString(),
                studentDto.Name,
                studentDto.Email,
                studentDto.AcademicRecord,
                studentDto.CPF)
            );

       return new StudentViewModel(student.Id, student.Name, student.Email, 
           student.AcademicRecord, student.CPF);
    }

    private bool Validations(AddStudentDTO studentDto)
    {
        if (_studentRepository.Get().Exists(c => c.AcademicRecord == studentDto.AcademicRecord))
        {
            throw new Exception("Academic Record already exists");
        }

        return true;
    }

    public List<StudentViewModel> Get()
    {
        var listStudents = _studentRepository.Get();

       return listStudents.Select(c =>
            new StudentViewModel(c.Id, c.Name, c.Email, c.AcademicRecord, c.CPF)
       ).ToList();
    }

    public StudentViewModel? GetById(string id)
    {
        var student = _studentRepository.GetById(id);
        if (student == null)
            return null;
        
        return new StudentViewModel(student.Id, student.Name, student.Email, 
            student.AcademicRecord, student.CPF);
    }

    public async Task<bool> Remove(string id)
    {
        var student = _studentRepository.GetById(id);
        if (student == null)
            return false;
            
        return await _studentRepository.Remove(student);
    }

    public async Task<StudentViewModel?> Update(string id, UpdateStudentDTO studentDto)
    {
        var student = _studentRepository.GetById(id);
        if (student == null)
        {
            return null;
        }

        student.Name = studentDto.Name;
        student.Email = studentDto.Email;

        var result = await _studentRepository.Update(student);

        if (result) 
            return new StudentViewModel(student.Id, student.Name, student.Email, 
                student.AcademicRecord, student.CPF);

        return null;
    }
    
    
}