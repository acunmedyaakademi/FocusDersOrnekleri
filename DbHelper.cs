using ConsoleStudentManagement.Data;
using ConsoleStudentManagement.Models;

namespace ConsoleStudentManagement;

public static class DbHelper
{
    // seed = eğer veri yoksa veri oluştur
    
    private static AppDbContext _db = new AppDbContext();
    
    public static void AddFirstData()
    {
        // using var db = new AppDbContext();
        
        if (_db.Students.Any())
        {
            // void method'da return dersek akış kesilir
            return;
        }
        
        // projenizi ilk açtığınızda belirli başlı kayıtlar olsun istiyorsanız
        // bu yapıyı kullanabilirsiniz. diğer türlü veritabanı boş olacaktır
        // veritabanının boş olması bir problem değildir
        var firstClassroom = new Classroom { Name = "Focus BE" };
        _db.Classrooms.AddRange(
            firstClassroom,
            new Classroom{ Name = "Flex BE" },
            new Classroom{ Name = "Focus FE" },
            new Classroom{ Name = "Flex FE" }
        );

        var firstStudent = new Student { FirstName = "Orhan", LastName = "Ekici", Birthday = new DateOnly(1989, 3, 17) };
        _db.Students.AddRange(
            firstStudent,
            new Student
            {
                FirstName = "Kıvanç", LastName = "Ekici", Birthday = new DateOnly(2024, 9, 17)
            },
            new Student
            {
                FirstName = "Sevim", LastName = "Ekici", Birthday = new DateOnly(1991, 12, 14)
            }
        );
        
        // _db.SaveChanges();
        //
        // if (_db.Classrooms.FirstOrDefault() == null)
        // {
        //     Console.WriteLine("sınıflar boş");
        // }
        
        // _db.Classrooms.First().Students = new List<Student>();
        // _db.Classrooms.First().Students.Add(_db.Students.First());
        firstClassroom.Students = new List<Student>()
        {
            firstStudent
        };
        
        _db.SaveChanges();
    }

    public static List<Student> GetStudents()
    {
        return _db.Students.ToList();
    }

    // public static void ListAllStudents()
    // {
    //     var students = _db.Students.ToList();
    //     foreach (var student in students)
    //     {
    //         Console.WriteLine($"{student.FirstName} {student.LastName}");
    //     }
    // }
}