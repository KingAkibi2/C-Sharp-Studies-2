using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boyutu_Dinamik_Olarak_Ayarlanabilen_Dizi_Tasarımı
    {
        //Diziyi T parametresine bağlı olarak çalışan bir dizi haline getirdik.
        //Enumerable<T> ifadesi ile dizilere numaralandırma sayılabilme özelliği kazandırabliriz
        //ICloneable ile diziyi klonlanabilme yeteneği kazandırabiliriz.

        public class Dizi<T> : IEnumerable<T>, ICloneable
        {

        //initial adıyla boyutu dinamik olarak değişen bir dizi tanımlamış olduk
        //bu diziyi dolaşarak kendi dizimize ekledik
        //metodu aşırı yükleyerek diziye tanımlama sırasında eleman atayabilme özelliği kazandırmış olduk.

        public Dizi(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            foreach (var item in initial)
            {
                Add(item);
            }
        }

        //ienumerable interface altında collection adıyla yeni bir dizi tanımladık.
        //eleman sayısını her zamanki gibi 0 dan başlattık
        // biz diziye ekledikçe foreach döngüsü ile innerliste ekleyecek.

        public Dizi(IEnumerable<T> collection)
        {
            InnerList = new T[collection.ToArray().Length];
            Count = 0;
            foreach (var item in collection)
            {
                Add(item);
            }
        }

            // Diziye count ve capacity olacak şekilde 2 özellik tanımladık.
            //Sadece bu sınıf içinde okunabilecek bir dizi (InnerList) tanımladık.
            //Sadece okunabilir olan Kapasite özelliğini dizinin uzunluğu olarak tanımladık.

            private T[] InnerList;
            public int Count { get; private set; }
            public int Capacity => InnerList.Length;

            // ctor yazıp tab tuşuyla default constructor getiririz
            //2 elemanlı bir dizi tanımladık.
            public Dizi()
            {
                InnerList = new T[2];
                Count = 0;
            }

        //Diziye eleman ekleyen metot tasarladık.
        //Eğer dizideki eleman kapasiteye eşitlenirse kapasiteyi 2 katına çıkaran metot tasarladık.
        public void Add(T item)
        {
            if (InnerList.Length==Count)
            {
                DoubleArray();
            }

            InnerList[Count] = item;
            Count++;
        }

        //geçici bir değişken atayıp o geçici değişkeni dizinin uzunluğunun iki katı uzunlukta bir dizi olarak tanımladık
        // Array sınıfının copy metodunu kullandık.
        //Copy(InnerList, temp, InnerList.Length) 1.ifade kopyalanacak dizi verilir. 2.ifadede kopyalanacak hedef dizi verilir.3. ifade de ne kadar uzunlukta kopyalanacağını belirtir.
        //ardından listemizi geçici değişkene atadık ki dizimizin boyutu 2 katına çıksın.

        private void DoubleArray()
        {
            var temp = new T[InnerList.Length * 2];
            System.Array.Copy(InnerList, temp, InnerList.Length);
            InnerList = temp;
        }
        // Diziden eleman silmeye yarayan metot tasarladık
        //eleman yoksa hata verecek koşul ifadesi ekledik.
        //geçici değişkeni dizinin son elemanından silecek şekilde atadık
        // Dizinin uzunluğunun 4te 1 ini kullanıyor isek dizinin boyutunu yarıya indiren metot tasarladık.

        public T Remove()
        {
            if (Count==0)
            {
                throw new Exception("There is no more item to be removed from the array");
            }

            if (InnerList.Length/4==Count)
            {
                HalfArray();
            }

            var temp = InnerList[Count-1];
            Count--;
            return temp;
        }

        //dizinin uzunluğunun 2den fazla olmasını şartlandırdık
        //dizinin uzunluğunun 4te 1 inden az eleman varsa dizi boyutunu yarıya indirecek

        private void HalfArray()
        {
            if (InnerList.Length>2)
            {
                var temp = new T[InnerList.Length / 2];
                System.Array.Copy(InnerList, temp, InnerList.Length / 4);
                InnerList = temp;
            }
            
        }

        //diziden her bir x i seç ve numaralandır tarzı bir anlam ifade ediyor.
        //bu yöntemi kullandığımızda boş olan dizi boşlukları 0 olarak görünecek.
        //onun yerine take metodu ile sadece kullandığımız elemanları gösterebiliriz.

            public IEnumerator<T> GetEnumerator()
            {
                //return InnerList.Select(x => x).GetEnumerator();
                return InnerList.Take(Count).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

        public object Clone()
        {
            return this.MemberwiseClone();
            //Yöntem2
            var arc = new Dizi<T>();
            foreach (var item in this)
            {
                arc.Add(item);
            }
            return arc;
        }
    }
}
