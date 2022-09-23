using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tek_Yönlü_Bağlı_Liste;

namespace Tek_Yönlü_Bağlı_Dizi
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private List<int> list;

        public SinglyLinkedList(List<int> list)
        {
            this.list = list;
        }

        //Head ifadesi de bir düğüm olduğu için tipini node olarak aldık.
        //ve özellik olarak tanımladık.

        public Node<T> Head { get; set; }

        // başa eklem işlemi için öncelikli olarak yeni bir düğüm tanımladık.
        //sonrasında düğümün işaret ettiği değeri baş düğüm(head) olarak belirledik 
        // head ifadesini de yeni düğüm olarak güncelledik.
        // yani artık yeni düğüm baş düğüm olmuş oldu başa eleman eklemiş olduk.

        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        // ilk önce yeni bir düğüm tanımladık
        // listenin boş olması özel durumunu yazdık null ifadesi listenin sonundaki boşluğu sonu ifade ediyor
        // eğer liste boşşa eklenen düğümün baş düğüm yaptıracağız.
        //return ifadesini neden kullandık peki? çünkü eğer koymazsak alttaki kodları okumaya devam eder orada okumayı kesmek için geriye dön dedik
        //geçici bir değişken tanımlayıp baş düğüm yaptık 
        //düğüm boş olana kadar ilerleyen bir döngü kullandık yani düğüm boş olmadığı müddetçe her elemanı bir kez dönecek sona geldiğinde
        //geçiçi değişkeni oluşturduğumuz düğüme atayacak çünkü listenin sonuna eklemek istiyoruz.

        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);

            if (Head==null)
            {
                Head = newNode;
                return; 
            }
            var now = Head;
            while (now.Next!=null)
            {
                now = now.Next;
            }
            now.Next = newNode;
        }

        //öncelikle istisna iki durumu dikkate aldık 
        //düğümün boş olamaması durumu ve baş düğümün olmaması durumu

        //her zamanki gibi yeni düğüm tanımını yaptık ve baş düğüme atadık.
        //ardından kurduğumuz while döngüsü if bloğu sağlanmaya devam ettikçe çalışacak.
        // if bloğu now.equal(node) ifadesi çalıştıkça çalışacak 
        //now.Equals(node) ifadesi oluşturduğumuz düğümün üzerinde durduğumuz düğüme eşitliğini sorgulayacak
        //eğer ki değilse bir sonraki düğüme geçecek ve onu yeni düğüm yapacak ve istediğimiz düğüme geldiği zaman return ifadesiyle duracak
        //eşitlik sağlandığı vakit referans düğümü bulmuş olacağız

        public void AddAfter(Node<T> node,T value)
        {
            if (node==null)
            {
                throw new Exception("The list have to be at least one node");
            }

            if (Head==null)
            {
                AddFirst(value);
                return;
            }

            var newNode = new Node<T>(value);
            var now = Head;

            while (now!=null)
            {
                if (now.Equals(node))
                {
                    newNode.Next=now.Next;
                    now.Next = newNode;
                    return;
                }
                now = now.Next;
            }
            throw new Exception("the reference node is not in this list");


        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    }


