namespace Relations.Models;

public class Classroom
{
    public string Name { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
}