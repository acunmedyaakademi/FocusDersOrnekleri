namespace Siniflar;

// Helper
// static kelimesi ilgili sınıfı şablon gibi kullanılmaktan çıkarır
// sınıf doğrudan erişilen bir yapıya döner örn: Console
// ayrıca sınıfı static yapmasak fakat sınıf içindeki property veya methodlara
// static ifadesi eklersek o zaman bu tanımlar sınıfa ait olur. yani new kelimesi kullanıp
// yeni obje oluşturduğumuzda objeye geçmezler
public static class Yardimci
{
    public static string Selamla()
    {
        return "Naber??";
    }
    // static
    
    // parametre
    // methodların üzerinde işlem yapabileceği dışarıdan gelen verilere parametre denir
    public static int Topla(int sayi1, int sayi2)
    {
        return sayi1 + sayi2;
    }

    // property'ler ön tanımlı değer alabilir
    // ön tanım yapmak için, tanım sonrasında = deyip atama yaparız
    public static int Yil { get; set; } = 2025;

    public static int YasHesapla(int dogumYili)
    {
        return Yil -  dogumYili;
    }

    public static bool ResitlikKontroluYap(int yas)
    {
        if (yas >= 18)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int TumunuTopla(int[] sayilar)
    {
        int toplam = 0;
        foreach (int sayi in sayilar)
        {
            toplam += sayi;
        }
        return toplam;
    }

    public static string SoruSor(string soru)
    {
        Console.Write($"{soru}: ");
        return Console.ReadLine();
    }
}

