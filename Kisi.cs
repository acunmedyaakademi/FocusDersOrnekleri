namespace Siniflar;

public class Kisi
{
    // data - veri
    // tckn, ad, soyad, doğum tarihi, cinsiyet
    // field(alan) ve property(özellik)
    //public string ad; // fieldlar camelCase yazılır
    // null = boş
    public string Ad { get; set; } // property'ler PascalCase yazılır
    public string Soyad { get; set; }
    public int DogumYili { get; set; }
    public string Cinsiyet { get; set; }
    public bool ogrenciMi { get; set; }
    // property(özellik) veya class(sınıf) tanımlarının başında bulunan public, private gibi ifadeler
    // access modifier(erişim ayarlayıcısı) anlamına geliyor. bu ifadeler ile ilgili örnekler yapacağız.
    
    // method - işlev
    // tekrar eden işleri aynı kodları tekrar tekrar yazmadan yapmamıza olanak sağlıyor
    // selamla, kendini tanıtabilir
    // method isimleri mutlaka fiil olmalıdır ve PascalCase yazılmalıdır.
    // her method bir iş yapmalıdır
    
    // documentation comments
    public string KendiniTanit()
    {
        // methodların scope kullanım kuralları önceden kullandığımız yapılarla aynıdır
        // örn: koşullar ve döngüler
        
        // return kelimesi sayesinde returnden sonra yazılan değeri methoddan döndürmüş oluruz
        // return aynı zamanda method içindeki akışın sonlandığını ifade eder
        // yani koşul veya döngü içinde return ifadesi kullanırsak methodun çalışma akışı tamamlanır
        
        // property ismi yazarak method içinden ilgili property'ye erişebiliyoruz
        return $"Merhaba ben {Ad} {Soyad}";
    }

    public int YasHesapla()
    {
        return 2025 - DogumYili;
    }
}

// 1. kişi -> ad
// 2. kişi -> ad
