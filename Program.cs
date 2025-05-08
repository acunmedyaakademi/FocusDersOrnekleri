using ConsoleDb;

using var db = new AppDbContext();
var total = db.Todos.Count();
// biz linq method yapısı ile sorgumuzu kod tarafında otomatik oluşturuyoruz.
// eğer sonuna ToList(), ToArray() veya First(), Find() ya da Count() gibi sonucu üreten methodlar eklersek
// EF otomatik olarak oluşturduğu sorguyu veritabanına gönderir ve bize sonuç döndürür
Console.WriteLine($"veritabanımdaki toplam kayıt sayısı: {total}");

Console.Write("Eklemek istediğin iş: ");
var inputTask = Console.ReadLine();
var newTodo = new Todo
{
    Task = inputTask,
};

db.Todos.Add(newTodo); // context'e ekler ama kayıt etmez
db.SaveChanges(); // bu komut ile contextdeki yapılan değişiklikler veritabanına kaydedilir

var todos = db.Todos.ToList();
foreach (var todo in todos)
{
    Console.WriteLine($"{todo.Id} - {todo.Task} - {(todo.Completed ? "tamamlandı" : "tamamlanmadı")}");
}

Console.WriteLine("----------------");
Console.Write("Hangi kaydı düzenlemek istiyorsun(id): ");
var todoId = int.Parse(Console.ReadLine());

// Find() doğrudan id girdiğimizde ilgili kayıt varsa kaydı döner, yoksa null döner
// FirstOrDefault() girdiğimiz koşulla ilk bulduğu kaydı getirir
// SingleOrDefault() girdğimiz koşula uyan kayıtlar içinde sadece 1 tane getirir

var todoToUpdate = db.Todos.Find(todoId);
if (todoToUpdate == null)
{
    Console.WriteLine("bu todo yok");
    return;
    // işlem yapmayıp hata vermeliyiz veya akışımızı durdurabiliriz
}

Console.Write("Güncellenecek iş tanımı: ");
var inputTodoTask = Console.ReadLine();
if (!string.IsNullOrEmpty(inputTodoTask))
{// eğer kullanıcı boş enter yaparsa güncellemiyoruz
    todoToUpdate.Task = inputTodoTask;
}

Console.Write("Tamamlandı mı? (e/h): ");
var inputTodoCompleted = Console.ReadLine();
if (!string.IsNullOrEmpty(inputTodoCompleted))
{// eğer kullanıcı boş enter yaparsa güncellemiyoruz
    // todoToUpdate.Completed = (inputTodoCompleted == "e" ? true : false);
    todoToUpdate.Completed = (inputTodoCompleted == "e");
}

// bir bulma işlemi yaptığımızda bulduğumuz veri otomatik olarak context'e eklenir
// dolayısı ile değişiklik yaparsak sadece yaptıklarımızı veritabanına göndermemiz yeterli
// bunun için de context'i kaydetmemiz gerekiyor
db.SaveChanges();

foreach (var todo in todos)
{
    Console.WriteLine($"{todo.Id} - {todo.Task} - {(todo.Completed ? "tamamlandı" : "tamamlanmadı")}");
}

Console.WriteLine("----------");
Console.Write("Silmek istediğin: ");
var todoIdToDelete = int.Parse(Console.ReadLine());
var todoToDelete = db.Todos.Find(todoIdToDelete);
if (todoToDelete != null)
{
    db.Todos.Remove(todoToDelete);
    db.SaveChanges();
}

Console.WriteLine("----------");

foreach (var todo in db.Todos.ToList())
{
    Console.WriteLine($"{todo.Id} - {todo.Task} - {(todo.Completed ? "tamamlandı" : "tamamlanmadı")}");
}

/*
 * Create
 * Read
 * Update
 * Delete
*/