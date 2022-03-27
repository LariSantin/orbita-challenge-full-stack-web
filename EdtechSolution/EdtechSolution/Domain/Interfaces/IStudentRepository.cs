namespace EdtechSolution.Domain.Interfaces;

public interface IStudentRepository
{
    Task<Student> Add(Student student);
}