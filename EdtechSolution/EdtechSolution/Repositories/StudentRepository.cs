using System.Data.Entity;
using EdtechSolution.Domain;
using EdtechSolution.Domain.Interfaces;

namespace EdtechSolution.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationContext _context;

    public StudentRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<Student?> Add(Student? student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }    
    
    public List<Student?> Get()
    {
        return _context.Students.ToList();
    }

    public Student? GetById(string id)
    {
        return _context.Students.FirstOrDefault(c => c.Id == id);
    }

    public async Task<bool> Remove(Student student)
    {
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return true;
    }
}