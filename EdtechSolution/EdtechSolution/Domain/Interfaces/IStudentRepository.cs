namespace EdtechSolution.Domain.Interfaces;

public interface IStudentRepository
{
    Task<Student?> Add(Student? student);
    List<Student?> Get();

    Student? GetById(string id);
    Task<bool> Remove(Student student);
    Task<bool> Update(Student student);
}