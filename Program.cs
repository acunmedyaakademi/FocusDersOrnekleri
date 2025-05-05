using Relations;
using Relations.Models;

var users = new List<User>
{
    new User { Name = "Alice" },
    new User { Name = "Bob" },
    new User { Name = "Charlie" },
    new User { Name = "Diana" },
    new User { Name = "Eve" }
};

string[] contents = 
[
    "Sabah kahvesi gibisi yok!",
    "Yeni başlayanlar için C# çok eğlenceli olabilir.",
    "Bugün spora başladım, bakalım ne kadar sürecek :)",
    "Yapay zeka geleceğimizi şekillendirecek.",
    "Kedim klavyemde uyuyor, nasıl çalışacağım?",
    "Kitap okumak ruhuma iyi geliyor.",
    "Güneşli havaları çok özlemişim.",
    "Bu hafta sonu kamp yapmayı planlıyorum.",
    "Yeni tarif denedim, sonuç harika!",
    "Film önerisi olan var mı? Dram türü olsun.",
    "Bugün biraz üretkenlik düşük ama idare ediyoruz.",
    "Yaz tatili için önerisi olan?",
    "Kütüphanede kaybolmak istiyorum.",
    "İlk defa kendi başıma proje geliştiriyorum.",
    "Bu sabah trafik kabus gibiydi.",
    "Kahvaltı mı akşam yemeği mi daha önemli?",
    "Evde ekmek yapmak terapi gibi.",
    "Şarkı listemi güncelledim, harika oldu.",
    "Eski fotoğraflara bakmak nostaljik hissettirdi.",
    "Kütüphane sessizliği huzur veriyor.",
    "Arkadaşlarla buluşmak iyi geldi.",
    "Yeni telefon aldım, kamerası harika!",
    "Bugün moralim biraz düşük ama geçecek.",
    "Kafamda bin tane fikir var, hangisinden başlasam?",
    "Uykusuz geçen bir gecenin ardından kahve candır.",
    "Ders çalışmak için motivasyon arıyorum.",
    "Rüyamda sınava girdim, ne garipti!",
    "Yabancı dil öğrenmek çok zaman alıyor.",
    "İlk defa bisikletle uzak bir yere gittim.",
    "Kendime minik bir tatil hediye ettim."
];

var tweets = new List<Tweet>();

var random = new Random();

foreach (var content in contents)
{
    tweets.Add(new Tweet
    {
        Content = content,
        User = users[random.Next(users.Count)],
        CreatedAt = DateTime.Now.AddMinutes(-random.Next(0, 10000))
    });
}

var bobsTweets = tweets.Where(x => x.User.Name == "Bob").ToList();
    
bobsTweets.ForEach(x => Helper.WriteLine($"{x.User.Name} diyor ki: {x.Content} ({x.CreatedAt})"));

Console.Clear();

var teachers = new List<Teacher>
{
    new Teacher { FirstName = "Orhan", LastName = "Ekici" },
    new Teacher { FirstName = "Nihat", LastName = "Duysak" },
    new Teacher { FirstName = "Ayşe", LastName = "Güler" },
};

var classrooms = new List<Classroom>
{
    new Classroom { Name = "BE Focus" },
    new Classroom { Name = "BE Flex" },
    new Classroom { Name = "FE Focus/Flex" },
};

var students = new List<Student>
{
    new Student{ FirstName = "Batuhan", LastName = "Yılmaz" },
    new Student{ FirstName = "Burak", LastName = "Bayrak" },
    new Student{ FirstName = "Celil", LastName = "İskender" },
};

// aşağıdaki işlem classrooms içindeki ilk sınıfa ilk öğrenciyi ekler ardından
// ilk öğrenciye ilk sınıfı ekleriz
classrooms[0].Students.Add(students[0]);
students[0].Classrooms.Add(classrooms[0]);
// fakat veritabanı ile çalışmaya başladığımızda bu işlemi elle yapmak zorunda kalmayacağız

// consistency - tutarlılık - veri tutarlılığı


