using System.Runtime.InteropServices;
using Siniflar;

// new kelimesini obje oluşturmak için kullanıyoruz
// aşağıdaki örnekte obje oluşturken Kisi sınıfından bir örnek (instance) alıyoruz
// işlemi tamamlamak için mutlaka parantez açıp kapatıyoruz
var orhan = new Kisi();
orhan.Ad = "Orhan"; // yeni oluşturduğumuz objenin yanına . (nokta) ekleyerek property'lerine
// erişebiliriz
orhan.Soyad = "Ekici";

// Console.WriteLine($"{orhan.Ad} {orhan.Soyad}");

var ozan = new Kisi
{
    Ad = "Ozan",
    Soyad = "Alıcı",
    Yas = 37,
    Cinsiyet = "Erkek"
};

var ogrenciler = new List<Kisi>
{
    ozan, orhan
};
// ogrenciler.Add(ozan);
// ogrenciler.Add(orhan);

// foreach (var ogrenci in ogrenciler)
// {
//     Console.WriteLine(ogrenci.Ad);
// }

var urunler = new List<Urun>();

urunler.Add(new Urun
{
    Ad = "Çikolata",
    Fiyat = 35,
    Stok = 75,
});

urunler.Add(new Urun
{
    Ad = "Kola",
    Fiyat = 45,
    Stok = 50,
});

urunler.Add(new Urun
{
    Ad = "Çekirdek",
    Fiyat = 25,
    Stok = 150,
});

int toplam = 0;
double kdvliToplam = 0;
int stokToplamFiyat = 0;

foreach (var urun in urunler)
{
    double kdvDahilFiyat = urun.Fiyat * 1.2;
    Console.WriteLine($"{urun.Ad} fiyat: {urun.Fiyat} kdvli fiyat: {kdvDahilFiyat} TL stok: {urun.Stok}");
    toplam += urun.Fiyat;
    kdvliToplam += kdvDahilFiyat;
    stokToplamFiyat += urun.Fiyat * urun.Stok;
}

Console.WriteLine($"Toplam: {toplam}");
Console.WriteLine($"Kdvli Toplam: {kdvliToplam}");
Console.WriteLine($"Stok Toplam Fiyat: {stokToplamFiyat}");

while (true)
{
    Console.Clear();

    Console.WriteLine("Hoşgeldiniz. Aşağıdan yapmak istediğiniz işlemi seçin.");
    Console.WriteLine("1. Ürünleri listele");
    Console.WriteLine("2. Yeni ürün ekle");
    Console.Write("Seçiminiz: ");
    var inputSecim = Console.ReadLine();

    if (inputSecim == "1")
    {
        Console.Clear();

        if (urunler.Count == 0)
        {
            Console.WriteLine("Listeleyecek ürün bulamadım.");
        }

        Console.WriteLine("ÜRÜN ADI FİYAT/STOK");
        foreach (var urun in urunler)
        {
            Console.WriteLine($"{urun.Ad} {urun.Fiyat}/{urun.Stok}");
        }

        Console.WriteLine("\nDevam etmek için entera bas...");
        Console.ReadLine();

    } else if (inputSecim == "2")
    {
        Console.Clear();
        Console.Write("Ürün adı: ");
        var inputAd = Console.ReadLine();
    
        Console.Write("Ürün fiyatı: ");
        var inputFiyat = int.Parse(Console.ReadLine());
    
        Console.Write("Ürün stok sayısı: ");
        var inputStok = int.Parse(Console.ReadLine());
    
        urunler.Add(new Urun
        {
            Ad = inputAd,
            Fiyat = inputFiyat,
            Stok = inputStok,
        });

        Console.WriteLine("\nÜrün eklendi");
        Console.WriteLine("\nDevam etmek için entera bas...");
        Console.ReadLine();
    }
}

