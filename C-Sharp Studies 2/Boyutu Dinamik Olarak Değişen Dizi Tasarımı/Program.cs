using Boyutu_Dinamik_Olarak_Ayarlanabilen_Dizi_Tasarımı;
using System.Collections;

namespace Boyutu_Dinamik_Olarak_Değişen_Dizi_Tasarımı
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Dizi adıyla oluşturduğumuz sınıftan gelen diziyle kendi dizimizi tanımladık.

            var arr = new Dizi<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Add(4);
            arr.Add(5);
            arr.Add(6);
            arr.Remove();

            Console.WriteLine($"{arr.Count} / {arr.Capacity}");

            //böyle bir kullanımda getenumerator özelliği olmadığı için dizide dolaşamıyoruz.
            //getenumeratoru implemente edip ondan sonra dizide dolaşacağız.

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

            //Çift olan elemanları göstermek için kullanılan bir yöntem 

            Console.WriteLine("-----------------");
            Console.WriteLine("Çift Olan Elemanlar");
            arr.Where(x => x % 2 == 0).ToList().ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
            Console.WriteLine();

            var dizi = new Dizi<int> { 10, 20, 30, 40, 50 };

            foreach (int item in dizi)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.WriteLine();

            var p1 = new Dizi<int>() { 4, 8, 15, 23, 46 };
            var p2 = new int[] { 3, 7, 9, 10, 11 };
            var p3 = new List<int>() { 50, 19, 31, 21 };
            var p4 = new ArrayList() { 0, 1, 2, 3, 4, 5, 6, };

            //ilk 3 ifade ienumerable interface kabul ederken 4. etmiyor hatta dönüştürme dahi yapılmıyor.

            //var list = new Dizi<int>(p1);
            //var liste = new Dizi<int>(p2);
            //var listem = new Dizi<int>(p3);
            //var listecik = new Dizi<int>(p4);,

            var array = new Dizi<int>();

            for (int i = 0; i < 128; i++)
            {
                array.Add(i + 1);
                Console.WriteLine($"{i} has been added");
                Console.WriteLine($"{array.Count} / {array.Capacity}");

            }

            Console.ReadKey();
            Console.WriteLine();

            foreach (var item in array)
            {
                Console.Write($"{item,-5}");
            }

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = array.Count; i >= 1; i--)
            {
                Console.WriteLine($"{array.Remove()} has been removed");
                Console.WriteLine($"{array.Count} / {array.Capacity}");
            }

            Console.ReadKey();
            Console.WriteLine();

            //crr klonlanan dizi crc ise klon dizi olacak.
            //farkedildiği üzere crr dizisine eklenen eleman crc dizisine eklenmedi yani birbirinin aynısı iki dizi olmadı sadece eleman kopyalama işlemi yaptık

            var crr = new Dizi<int>() { 1, 3, 5, 7 };
            var crc = (Dizi<int>)crr.Clone();
            crr.Add(99);


            foreach (var item in crr)
            {
                Console.Write($"{item,-3}");
            }

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();

           // crc ifadesinde getenumerator özelliği olmadığı için foreach ile dönemedik.
           // yukarıda görüldüğü gibi cast işlemi yaptık.

            foreach (var item in crc)
            {
                Console.Write($"{item,-3}");
            }

            Console.ReadKey();
            Console.WriteLine();
        }
    }
}