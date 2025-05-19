using ConsoleStudentManagement;
using ConsoleStudentManagement.Data;
using Microsoft.EntityFrameworkCore;

//
// DbHelper.AddFirstData(); // data yoksa çalışır
//
// // kullanıcım listeleme yapmak istiyor
// Console.Clear();
var db = new AppDbContext();

// var classroomList = db
//         .Classrooms
//         .Include(s => s.Students)
//     .ToList();
//
// foreach (var classroom in classroomList)
// {
//     Console.WriteLine($"{classroom.Id} {classroom.Name}");
//     foreach (var student in classroom.Students)
//     {
//         Console.WriteLine($"\t{student.Id} {student.FirstName} {student.LastName}");
//     }
//     Console.WriteLine();
// }

var studentList = db.Students
    .Include(c => c.Classrooms)
    .Include(t => t.Todos)
    .ToList();

var todos = db.Todos.Where(t => t.StudentId == 7).ToList();

foreach (var student in studentList)
{
    Console.WriteLine($"Ad: {student.FirstName} {student.LastName}");
    var studentClassrooms = student.Classrooms.Select(x => x.Name);
    // şekilli kod yazma
    // kısa yazayım
    
    // bizim her zaman önceliğimiz kolay okunabilir kod yazmak
    if (studentClassrooms.Count() > 0)
    {
        Console.WriteLine($"Sınıfları: {string.Join(", " ,studentClassrooms)}");
    }
    else
    {
        Console.WriteLine("Henüz sınıf ataması yapılmamış.");        
    }
    Console.WriteLine();
}

return;

Console.WriteLine("Tüm Öğrenciler\n".ToUpper());
// DbHelper.ListAllStudents();
var students = db.Students.ToList();
foreach (var student in students)
{
    Console.WriteLine($"{student.Id} {student.FirstName} {student.LastName}");
}

Console.WriteLine();

Console.WriteLine("Tüm Sınıflar\n".ToUpper());
var classrooms = db.Classrooms.ToList();
foreach (var classroom in classrooms)
{
    Console.WriteLine($"{classroom.Id} {classroom.Name} ");
}

Console.Write("İşlem yapmak istediğin öğrenci: ");
var studentId = int.Parse(Console.ReadLine());

Console.Write("Öğrenciyi eklemek istediğin sınıf: ");
var classroomId = int.Parse(Console.ReadLine());

// eğer ilişki olan kayıtlarla iş yapmayacaksak o zaman find çok hızlı çalışır ve find ile ilerleyebiliriz
// ama ilişkiler üzerinde işlem yapılacaksa o zaman include kullanabileceğimiz bir yapıya ihtiyacımız var.
var foundStudent = db.Students
                .Include(c => c.Classrooms) // öğrencilerle ilişkili classroom verilerini de veritabanından çek
                .FirstOrDefault(s => s.Id == studentId);
var foundClassroom = db.Classrooms.Find(classroomId);

foundStudent.Classrooms.Add(foundClassroom);

// yaptığımız işlemleri her zaman en sonda veritabanına kaydetmeliyiz
db.SaveChanges();

// ilişki kurduğumuz verilerle işlem yapmadan önce mutlaka include yapmamız gerekiyor
// Console.WriteLine(foundStudent.Classrooms.Count);


