namespace Relations.Models;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Classroom> Classrooms { get; set; } = new List<Classroom>();
}