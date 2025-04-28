// değer tipi veri - value type
int sayi = 30;
int digerSayi = sayi; // -> doğrudan değeri yazar yani 30 yazar bırakır

Console.WriteLine(digerSayi);
digerSayi = 50;
Console.WriteLine(digerSayi); // ? 

Console.Clear();

int[] sayilar = [3, 7, 11]; // -> ref number 0x38478374
int dizidekiSayi = sayilar[0];
Console.WriteLine(dizidekiSayi);
// sayilar[0] = 5;
Console.WriteLine(dizidekiSayi);

Console.Clear();

int[] digerSayilar = sayilar; // 0x38478374
Console.WriteLine(digerSayilar[0]);
// sayilar[0] = 15;
Console.WriteLine(digerSayilar[0]);

Console.Clear();

string ad = "orhan";
ad = ad.ToUpper();
Console.WriteLine(ad);

var ogrenciler = new List<string>();

ogrenciler.Add("Orhan");
