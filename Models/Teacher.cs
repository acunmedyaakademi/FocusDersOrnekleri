namespace Relations.Models;

public class Teacher
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Classroom> Classrooms { get; set; } = new List<Classroom>();
}