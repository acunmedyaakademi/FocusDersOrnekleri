namespace ConsoleStudentManagement.Models;

public class Todo
{
    public int Id { get; set; }
    public string Task { get; set; }
    public bool Completed { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}