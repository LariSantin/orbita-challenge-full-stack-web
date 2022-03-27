namespace EdtechSolution;

public class Student 
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string AcademicRecord { get; set; }
    public string CPF { get; set; }

    public Student()
    {
    }

    public Student(string id, string name, string email, string academicRecord, string cpf)
    {
        Id = id;
        Name = name;
        Email = email;
        AcademicRecord = academicRecord;
        CPF = cpf;
    }
}