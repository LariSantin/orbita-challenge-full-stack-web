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
    
    public async Task<Student> Add(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }
}