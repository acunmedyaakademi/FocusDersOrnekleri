using Siniflar;
//
// var orhan = new Kisi();
// orhan.Ad = "Orhan";
// orhan.Soyad = "Ekici";
// orhan.DogumYili = 2000;
// var mesaj = orhan.KendiniTanit();
// Console.WriteLine(mesaj);
// Console.WriteLine(orhan.YasHesapla());
//
// var nihat = new Kisi
// {
//     Ad = "Nihat",
//     Soyad = "Duysak"
// };
//
// Console.WriteLine(nihat.KendiniTanit());

// rezerve edilmiş kelimeler
// reserved keywords
// programlama dillerinde bazı kelimeler dil,
// sistem veya framework tarafından daha önce kullanılmış
// veya rezerve edilmiş olur
// bu kelimeleri kod yazarken isim tanımlamak vb işler için
// kullanamayız. kelimelerin kendi fonksiyonları için kullanırız.

int toplam = Yardimci.Topla(10, 20);
Console.WriteLine(toplam);
Console.WriteLine(Yardimci.Topla(30, 70));
Console.WriteLine(Yardimci.Topla(29, 11));
Console.WriteLine(Yardimci.Topla(29, 11));

Console.WriteLine(Yardimci.Yil);
// Yardimci.Yil = 2025;
Console.WriteLine(Yardimci.YasHesapla(1989));

bool resitMi = Yardimci.ResitlikKontroluYap(17);
if (resitMi == true)
{
    Console.WriteLine("reşitmişin");
}
else
{
    Console.WriteLine("boşver büyümee");
}

var hepsininToplami = Yardimci.TumunuTopla([5, 7, 28, 13]);
Console.Write("Hepsinin toplamı: ");
Console.WriteLine(hepsininToplami);

var inputAd = Yardimci.SoruSor("Adın?");
Console.WriteLine($"merhaba {inputAd}");

