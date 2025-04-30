using LambdaExpressions;

// => - fat arrow

// (x, y) => x + y -> anonim fonksiyon
// eğer doğrudan return yapıyorsak => sonrasına herhangi ekstra bir ifade eklememize gerek yok
// parametre almıyorsa () kullanmalıyız
// tek parametre alıyorsa sadece parametreyi yazabiliriz x => x * x;
// eğer çok sayıda işlem yapacaksak ve return daha sonra olacaksa o zaman {} kullanabiliriz
// () => { var bisey = digerBisey * baskaBisey; return bisey; }
// () => digerBisey * baskaBisey

var ogrenciler = new List<Ogrenci>
{
    new Ogrenci{ Ad = "Orhan", Soyad = "Ekici", Cinsiyet = "Erkek"},
    new Ogrenci{ Ad = "Sevim", Soyad = "Ekici", Cinsiyet = "Kadın"},
    new Ogrenci{ Ad = "Kıvanç", Soyad = "Ekici", Cinsiyet = "Erkek"},
    new Ogrenci{ Ad = "Fıstık", Soyad = "Ekici", Cinsiyet = "Kedi"},
    new Ogrenci{ Ad = "Lucky", Soyad = "Ekici", Cinsiyet = "Kedi"},
    new Ogrenci{ Ad = "Marcel", Soyad = "Ekici", Cinsiyet = "Kedi"},
};

// ogrenciler.ForEach(x => Console.WriteLine($"{x.Ad} {x.Soyad}"));

var kediler = ogrenciler.Where(x => x.Cinsiyet == "Kedi").ToList();

// foreach tüm elemanlarda döner
// x iterasyondaki elemanı ifade eder
// => sağ tarafı da anonim fonksiyon eğer tek satırda dönüyorsa ekstra return demeye gerek yok
// eğer çoklu satırda işlem yapacaksak o zaman mutlaka => sonrasında süslü parantez açmalıyız {}
// eğer void değilse de return kelimesi ile standart method/fonk'lardaki gibi dönmeliyiz
kediler.ForEach(x => Console.WriteLine($"{x.Ad} {x.Soyad}"));

