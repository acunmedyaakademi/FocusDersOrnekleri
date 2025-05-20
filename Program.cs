using ConsoleStudentManagement;
using ConsoleStudentManagement.Data;
using ConsoleStudentManagement.Models;
using Microsoft.EntityFrameworkCore;

//
// DbHelper.AddFirstData(); // data yoksa çalışır
//
// // kullanıcım listeleme yapmak istiyor
// Console.Clear();
var db = new AppDbContext();



// one to many
// student -> todos
// öğrencilerin todoları var
// her bir todo, spesifik olarak bir öğrenciye ait

// kullanıcı arayüzden bir id girecekse aşağıdaki yapıyı kullanmak en mantıklısı
// fakat ilgili öğrencinin aynı zamanda ilişkili verilerini de okumak istiyorsak
// find yerine single veya first kullanmamız lazım. böylelikle include yapabiliriz.
// var inputStudentId = 7;
// var student = db.Students.Include(t => t.Todos).FirstOrDefault(s => s.Id == inputStudentId);
// if (student == null) // defansif kod
// {
//     // eğer öğrencimiz yoksa burada akışı kesmeliyiz.
//     return; // void olsa bile return işe yarar
//     // fakat eğer tip varsa, mutlaka bizim o tipe uygun bir dönüş yapmamız lazım.
// }

// Console.WriteLine(student.Todos.Count);

// var newTodo = new Todo { Task = "Bir başka todo" };
// student.Todos.Add(newTodo);
// Console.WriteLine(newTodo.StudentId);
// Console.WriteLine(newTodo.Id);
// db.SaveChanges();
// Console.WriteLine(newTodo.StudentId);
// Console.WriteLine(newTodo.Id);

// Console.WriteLine($"Todo Sayısı: {student.Todos.Where(t => t.Completed).Count()}/{student.Todos.Count}");
//
// foreach (var todo in  student.Todos)
// {
//     Console.WriteLine($"{todo.Task} - {(todo.Completed ? "Tamamlandı" : "Tamamlanmadı")}");
// }


var todos = db.Todos
    .Include(s => s.Student)
        .ThenInclude(c => c.Classrooms) // bu öğrencinin içindekini include ediyor. yani öğrencinin classroom bilgisi
    .ToList();

foreach (var todo in todos)
{
    string classroomsOfStudent;
    if (todo.Student.Classrooms.Count > 0)
    {
        classroomsOfStudent = string.Join(", ", todo.Student.Classrooms.Select(c => c.Name));
    }
    else
    {
        classroomsOfStudent = "Henüz sınıfa atanmadı.";
    }
    
    var studentFullName = $"{todo.Student.FirstName} {todo.Student.LastName} ({classroomsOfStudent})";
    
    Console.WriteLine($"{(todo.Completed ? "[X]" : "[ ]")} {todo.Task} - {studentFullName}");
}



