using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kuyruk_Yapısı
{
    //kendi kuyruğumuzu tanımladık
    //count özelliğini kuyruğumuzun büyüklüğü olarak ifade ettik
    //ctor ifadesini kullandık 
    // enum ifadesi ile oluşacak kuyryğun tipini seçmekte yardımcı olacak bir yapı kurduk
    //parametre girmediğimiz takdirde otomatik olarak array kuyruk olarak tanımlamış olacağız.
    //ekleme işlemi parametre alırken çıkarma işlemleri parametreye ihtiyaç duymazlar.
    //tanımladığımız interface ile yığınımızda aktif olarak kullanabileceğimiz özellikleri implemente edeceğimiz özellikleri belirledik.
    //ekleme işlemlerinde geriye değer dönmez(void) çıkarma işlemlerinde ise geriye dönme (return) ifadesine ihgtiyaç vardır.

    public class Queue<T>
    {
        private readonly IQueue<T> queue;
        public int Count => queue.Count;

        public Queue(QueueType type = QueueType.Array)
        {
            if (type==QueueType.Array)
            {
                queue = new ArrayQueue<T>();
            }
            else
            {
                queue = new LinkedListQueue<T>();
            }
        }

        public void Enqueue(T value)
        {
            queue.Enqueue(value);
        }

        public T DeQueue()
        {
            return queue.DeQueue();
        }

        public T Dequeue()
        {
            return queue.DeQueue();
        }

        public T Peek()
        {
            return queue.DeQueue();
        }
    }

    public interface IQueue<T>  
    {
    int Count { get; }
        void Enqueue(T value);
        T DeQueue();
        T Peek();
    }

    public enum QueueType
    {
     Array=0,
     LinkedList=1
    }

}
