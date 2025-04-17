// dizi, array
// liste, list
// set, tuple

// önemli kural: eğer değişken tanımlıyorsak ve içinde bir veri kümesi olacaksa ismi mutlaka çoğul olmalıdır.
// küme içindeki elemanların türleri aynı olmak zorundadır.

// isimlendirme kuralları - naming conventions
// dizi - array
// c# da dizilere daha sonradan eleman eklenemez, dizilerin uzunlukları sabittir.
// dizilerdeki elemanlara ulaşmak için bir numaralandırma mantığı vardır.
// bu numaralandırmaya index ismi verilir
// indexler 0'dan başlar
string[] meyveler = ["kavun", "şeftali", "karpuz", "elma"];
// dizideki elemana erişmek için dizinin isminin yanına [] açarız içine de index numarasını yazarız
Console.WriteLine(meyveler[0]);

meyveler[0] = "KAVUN";
Console.WriteLine(meyveler[0]);

int[] sayilar = [10, 20, 25, 12, 28];
sayilar[0] += 50;
Console.WriteLine(sayilar[0]);

Console.WriteLine(sayilar.Length);

// dizilerin eleman sayıları artamaz veya azalamaz.
// ilk oluşturulduğunda kaç eleman olacağını belirtiriz veya elemanları gireriz.
int[] digerSayilar = new int[3];
digerSayilar[0] = 20;
digerSayilar[1] = 10;
digerSayilar[2] = 5;
// digerSayilar[3] = 2;

Console.WriteLine(digerSayilar.Length);

// listeler dizilerden farklı olarak, eleman ekleyebilir, silebilir veya sıralayabilir.
// Bunun gibi pek çok farklı özelliği de vardır.

// liste oluştururken sonunda mutlaka () olması gerekiyor. lütfen dikkatli olalım.

// listelerin eleman sayısını öğrenmek için Length yerine Count kullanıyoruz.
// Console.WriteLine(ogrenciler.Count);

// string isim = "Orhan";
// Console.WriteLine(isim[0]);
Console.Clear();
// Console.WriteLine(ogrenciler[0]);
// ogrenciler.Clear();  listenin içindeki tüm elemanları siler
// ogrenciler.Remove("Batuhan"); TODO: bunun örneğini döngülerden sonra tekrar yapacağız

// ogrenciler.Reverse(); listeyi tersine çevirir

// içindeki elemanın olup olmadığını kontrol etmek için aşağıdaki yapıyı kullanabiliriz
// if (ogrenciler.Contains("Batuhan") == true)
// {
//     Console.WriteLine("Batuhan varmış");
// }
//
// Console.WriteLine(ogrenciler.IndexOf("Orhan"));
// ogrenciler.RemoveAt(0); // bu listeden 0 indexli elemanı kaldırıyorum
//

// sıralı döngü - for döngüsü
// çalışma koşulu, scope
// döngüler her çalışmalarında bir işlem yapar
// döngülerin dönme işlemine iterasyon (iteration) denir
// parantez içinde (sayac tanımı; çalışma koşulu; ilerleme kodu)
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

Console.Clear();

List<string> ogrenciler = new List<string>();
ogrenciler.Add("Batuhan");
ogrenciler.Add("Burak");
ogrenciler.Add("Celil");
ogrenciler.Add("Cihat");
ogrenciler.Add("Samet");

for (int i = 0; i < ogrenciler.Count; i++)
{
    Console.WriteLine(ogrenciler[i]);
}

