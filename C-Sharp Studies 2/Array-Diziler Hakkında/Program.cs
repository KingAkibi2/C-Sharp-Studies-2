using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Array_Diziler_Hakkında
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2 Farklı dizi tanımı yaptık ve farklı yollarla oluşturduk.
            // ilk dizi sabit boyutlu olduğu için ekleme çıkarma işlemleri yapamıyoruz.

            //CreateInstance metodu ile dizi oluşturduk type of ile dizinin tipini verdik.(int)
            //Array systemin altında yer alan bir sınıftır

            var ArrChar = new char[] { 'b', 't', 'k' };
           var arrInt = Array.CreateInstance(typeof(int), 5);
            
            //SetValue metodu ile diziye değer atadık.

            arrInt.SetValue(10, 0);
            arrInt.SetValue(20, 1);
            arrInt.SetValue(30, 2);
            arrInt.SetValue(40, 3);
            arrInt.SetValue(50, 4);
            
            // Key Value Çiftinden 2 numaralı indisdeki değeri değişken olarak tutup konsola yazdırdık.

            var value = arrInt.GetValue(2);
            Console.WriteLine(value);

            Console.ReadKey();
            Console.WriteLine();

            //Objeleri Tutan Bir ArrayList Tanımladık.
            //Objeleri tuttuğu için tip güvenliğini kaybettik
            //Yani int,string,char farketmeksizin hepsi kutulanıp objeye dönüştürülür

            var arrobj = new ArrayList();
            
            arrobj.Add(60);
            arrobj.Add('a');    
            arrobj.Add("zeynep");

            //60 ile 10 u toplayıp 70 vereceğini düşünürken hata aldık.
            //Çünkü 60 artık bir tam sayı olarak algılanmıyor kutulandığı için obje olarak görülüyor.
            // Tam sayı ile obje mantıken toplanamayacağı için objeyi kutudan çıkarmalı cast işlemi yapabiliriz.

            //var c = arrobj[0] + 10; ifadenin başına int koyarak sorunu çözdük.

            var d = (int)arrobj[0] + 10;
            Console.WriteLine(d);

            Console.ReadKey();
            Console.WriteLine();

            // yeni bir liste tanımladık listelerde tip güvenliği sağlanır yani sadece girilen veri tipinde eleman ekleyebiliriz.
            //chardan inte dönüşüm mümkün olduğu için a ve b nin sayısal karşılıkları ekrana yazdırılmış oldu

            var ListInt = new List<int>();
            ListInt.Add(70);
            ListInt.Add((int)'a');
            ListInt.Add('b');
            ListInt.AddRange(new int[] { 80, 90, 100 });
            ListInt.RemoveAt(1);

            foreach (var item in ListInt)
            {
                Console.Write($"{item,-5}");
            }

            Console.ReadKey();
            Console.WriteLine();


        }
    }
}




