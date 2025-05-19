namespace ConsoleStudentManagement.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Classroom> Classrooms { get; set; }
    public ICollection<Todo> Todos { get; set; }
    public DateOnly Birthday { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; // kaydımızın ne zaman yapıldığını görmek için
    //public DateTime UpdatedAt { get; set; } //haftaya ekleriz  // son güncellemenin ne zaman olduğunu görmek için
}