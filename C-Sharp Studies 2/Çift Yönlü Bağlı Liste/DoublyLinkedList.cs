using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Çift_Yönlü_Bağlı_Liste
{
    public class DoublyLinkedList<T> :IEnumerable
    {
        public DoublyLinkedList()
        {

        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        //Lisgtemize baş düğüm(head) ve son düğüm tail olmak üzere 2 düğüm tanımladık.

        public dllNode<T> Head { get; set; }
        public dllNode<T> Tail { get; set; }

        // yeni bir düğüm tanımlayarak işe başladık.
        // baş düğüm eğer ki son düğüm değilse 1 eleman geri gelecek.
        //sonra oluşturduğumuz düğümün sağını baş düğüm solunu boş yapacak
        //en sonda düğümümüzü baş düğüm yapmış olacak.

        public void AddFirst(T value)
        {

            var newNode = new dllNode<T>(value);
            if (Head != null)
            {
                Head.Prev = newNode;

            }
            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;

            if (Tail != null)
            {
                Tail = Head;
            }
        }

        //Yeni düğüm tanımladık.
        //eğer dizi boşsa başa ekleyen istisna durumu göze aldık.
        //en son düğümün sonuna yeni düğümü koyduk
        //yeni düğümün arkasının null olacağını söyledik.
        //son düğümü(tail)i yeni düğüm olarak güncelledik
        //return ile dönüş yaptık.

        public void AddLast(T value)
        {
            if (Tail == null)
            {
                AddFirst(value);
                return;
            }

            var newNode = new dllNode<T>(value);
            Tail.Next = newNode;
            newNode.Next = null;
            Tail = newNode;
            return;
        }

        //Bu metod bir referans düğüm ve bir yeni düğüme bağlı olarak çalışıyor.
        //referans düğüm boş olamaz olursa hata fırlatacak

        //referans düğüm hem baş düğüm hem kuyruk düğümse yani tek bir eleman varsa çalışacak blok 
        //referans düğümün ilerisini yeni düğüm gerisini null yaptı
        //yeni düğümün gerisini referans düğüm yeni düğümün ilerisini null yaptı
        //baş düğüm ve kuyruk düğümü güncelledik
        //aslında head düğümün arkasına eleman eklemiş olduk.

        //ara yerlerdeki elemanlar için 2. if bloğu çalışacak
        //yeni düğümün öncesindeki düğümü referans olarak aldı
        //yeni düğümün ilerisindeki düğümü referans düğümün ilerisindeki düğüm olarak tanımladık.
        //referans düğümün ilerisine gidip geri dönmek referans düğüm demek 
        //referans düğümün ilerisini yeni düğüm olarak güncelledik.

        public void AddAfter(dllNode<T> refnode, dllNode<T> newNode)
        {
            if (refnode == null)
                throw new Exception("The Reference Node cannot empty");

            if (refnode == Head && refnode == Tail)
            {
                refnode.Next = newNode;
                refnode.Prev = null;

                newNode.Prev = refnode;
                newNode.Next = null;

                Head = refnode;
                Tail = newNode;
                return;
            }
            if (refnode != Tail)
            {    //ara düğümse
                newNode.Prev = refnode;
                newNode.Next = refnode.Next;


                refnode.Next.Prev = newNode;
                refnode.Next = newNode;

            }
            else
            {
                //son düğümse
                newNode.Prev = refnode;
                newNode.Next = null;
                refnode.Next = newNode;
                Tail = newNode;
            }
        }

        public void AddBefore(dllNode<T> refnode, dllNode<T> newNode)
        {
            if (refnode == null)
                throw new Exception("The Reference Node cannot empty");

            //tek eleman olma durumu
            if (refnode==Head && Tail==refnode)
            {
                AddFirst(Head.Value);
            }
            if (refnode!=Tail)
            {//ara eleman olma durumu
                newNode.Next = refnode;
                newNode.Prev = refnode.Prev;

                refnode.Prev.Next = newNode;
                refnode.Prev = newNode;

            }

            else
            {
                //en başa ekleme durumu
                newNode.Next = refnode;
                newNode.Prev = null;
                refnode.Prev = newNode;
                Head = newNode;
            }

        }

        //numaralandırma özelliği için metot
        //düğümleri içeren bir liste tanımı yaptık.
        //geçici değişken tanımlayıp baş düğüm yaptık.
        //döngü düğüm sayısı kadar dönüp listelenebilir olacak.
        // en son listeye döneceğiz
        //implemente ettiğimiz şeyi de bu metoda döndüreceğiz.

        private List<dllNode<T>> GetAllNodes()
        {
            var list = new List<dllNode<T>>();
            var now = Head;
            while (now != null)
            {
                list.Add(now);
                now = now.Next;
            }
            return list;
        }
       // dizide eleman yoksa hata fırlattık
       //temp geçici değişkenini baş düğüm olarak atadık
       //eğer dizide sadece bir eleman var ise hem baş hem de son düğümü null yaptık direk sildik
       //eğer birden çok eleman varsa da else yapısı çalışacak
       //baş düğümü ileriki düğüme atayacak.
       //baş düğümün solunu da boşaltacak
       //tempe dönünce temp ilk eleman olarak silinecek

        public T RemoveFirst()
        {
            if (Head==null)
            {
                throw new Exception("there is nothing to be removed from the list");
            }
            var temp=Head.Value;
            if (Head==Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            return temp;
        }

        //üstteki hikayeyi tersten işletmek yeterli olacaktır.
        // dizide eleman yoksa hata fırlattık
        //temp geçici değişkenini son düğüm olarak atadık
        //eğer dizide sadece bir eleman var ise hem baş hem de son düğümü null yaptık direk sildik
        //eğer birden çok eleman varsa da else yapısı çalışacak
        //son düğümü gerideki düğüme atayacak.
        //son düğümün sağını da boşaltacak
        //tempe dönünce temp son eleman olarak silinecek

        //prev.next ifadesinin hikayesi şu şekilde : önceki prevle önceki düğümü işaret edip next ile işaret etmiş olduğumuz düğümün sağını işaret eden düğümü gösterecek
        //yani artık kuyruğu işaret eden hiçbir işaretçi yok

        public T RemoveLast()
        {
            if (Tail==null)
            {
                throw new Exception("there is nothing to be removed from the list");
            }

            var temp = Tail.Value;

            if (Tail==Head)
            {
                Head = null;
                Tail = null;
            }

            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }
            return temp;
            
        }

        // dizide eleman yoksa hata fırlattık
        // tek eleman varsa elemanı başa ekleyecek
        // sonraki durumda baş düğüm olan geçici değişken tanımladık.
        //ilk elemansa baş düğümü ileri taşıyıp işaretçisini yok ettik.
        //son eleman için de son düğümü bir öne taşıyıp işaretçisini yok ettik
        //arada bir yerde ise ileri ve geri işaretçileri bir önceki ve bir sonraki elemana taşıyarak silinebilir hale getirdik.

        public void Remove(T value)
        {

            if (Head == null)
            {
                throw new Exception("there is nothing to be removed from the list");
            }
            //tek eleman varsa
            if (Head == Tail)
            {

                if (Head.Equals(value))
                {
                    RemoveFirst();
                }
                return;

            }

            var now = Head;

            while (now!=null)
            {
                if (now.Prev == null)
                {
                    //ilk eleman
                    now.Next.Prev = null;
                    Head = now.Next;

                }
                     //son eleman
                else if (now.Next == null)
                {
                    now.Prev.Next = null;
                    Tail = now.Prev;

                }
                //arada herhangi bir yerde
                else
                {
                    now.Prev.Next = now.Next;
                    now.Next.Prev= now.Prev;

                }
                break;
            }
            now = now.Next;

        }

        public IEnumerator GetEnumerator()
        {
           return GetAllNodes().GetEnumerator();
        }
    }

    }

