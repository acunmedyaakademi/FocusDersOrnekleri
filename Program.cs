// Döngüler

// C#'da bulunan döngüler
/*
 * For - sıralı döngüdür, bir sayaç ile çalışır, tersten çalıştırmak mümkündür
 * Foreach - Koleksiyonlar üzerinde baştan sona çalışan döngü
 * While - Koşula bağlı çalışan döngü
 * Do While - Koşula bağlı olarak çalışır fakat koşul gerçekleşmezse dahi 1 kez çalışır.
*/

// Döngülerle ilgili dikkat edilmesi gereken en önemli konu döngülerin sonsuz döngüye girmemesini sağlamaktır.
// Sonsuz döngü - infinite loop

// int sira = 1;
// while (sira <= 10)
// {
//     Console.WriteLine($"sonsuz döngü {sira}");
//     sira++;
// }

// List<string> ogrenciler = ["Orhan", "Ozan", "Nihat", "Furkan", "Ayşe"];
// // ogrenciler.Reverse();
// foreach (string ogrenci in ogrenciler)
// {
//     Console.WriteLine(ogrenci);
// }

// var sayilar = new List<int>{ 5, 20, 15, 35, 40 };
// List<int> sayilar = [5, 20, 15, 35, 40];
// var toplam = 0;
// foreach (var sayi in sayilar)
// {
//     toplam += sayi;
// }
//
// Console.WriteLine($"Toplam: {toplam}");

// var - variable - değişken
// var kelimesini kullanarak değişken tanımı yaparsak
// kodlarımız derlenirken otomatik olarak tip bilgisi eklenir.
// Yani program çalışırken dinamik şekilde tip oluşturulmaz.

// ŞEKİLLİ ÇARPIM TABLOSU (Efe onaylı)
// for (int i = 1; i <= 10; i++)
// {
//     for (int j = 1; j <= 10; j++)
//     {
//         Console.Write($"{j}x{i}={i*j}\t");
//     }
//     Console.WriteLine("");
// }

string[] kullanicilar = [
    "orhanekici",
    "nihatdy",
    "ozancagatayalici",
];

string[] sifreler = [
    "zorbişey",
    "123",
    "orhanıçokseviyorum"
];

string[] isimler = [
    "Orhan Ekici",
    "Nihat Duysak",
    "Ozan Çağatay Alıcı"
];

Console.WriteLine("Hoş geldin. Devam etmek için kullanıcı girişi yapmalısın!");

while (true)
{
    Console.Write("Kullanıcı adı: ");
    var inputKullaniciAdi = Console.ReadLine();

    Console.Write("Şifre: ");
    var inputSifre = Console.ReadLine();

    var arananKullaniciIsmi = "";
    var kullaniciBulunduMu = false;

    for (int i = 0; i < kullanicilar.Length; i++)
    {
        var kullanici = kullanicilar[i];
        var sifre = sifreler[i];
        var isim = isimler[i];

        if (inputKullaniciAdi == kullanici && inputSifre == sifre)
        {
            kullaniciBulunduMu = true;
            arananKullaniciIsmi = isim;
            // Console.WriteLine($"Hoş geldin {isim}");
            break; // döngünün çalışmasını durdurur
        }
    }

    if (kullaniciBulunduMu == true)
    {
        Console.WriteLine($"Hoş geldin {arananKullaniciIsmi}");
        break; // while döngüsünü kırıyor
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Bu kullanıcıyı bulamadım!\n");
        Console.Write("Tekrar dene(e/h): ");
        var inputTekrarCevap = Console.ReadLine();
        if (inputTekrarCevap != "e")
        {
            Console.Clear();
            Console.WriteLine("Hoşçakal...");
            Thread.Sleep(1000);
            break;
        }
    }
}

// araştırın: CLI
// araştırın c# console renklendirme
// wordle oyunu
