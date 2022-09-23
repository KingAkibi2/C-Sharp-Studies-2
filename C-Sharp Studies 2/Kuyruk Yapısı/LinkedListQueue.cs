using Çift_Yönlü_Bağlı_Liste;

namespace Kuyruk_Yapısı
{   //linkedlist kuyruğu tanımladığımız interface(arayüz)i kabul ediyor ve implemente edilebilir durumda oluyor
    // ctrl. kullanıp implement interface yapınca önceden tanımlamış olduğumuz interfacenin özelliklerini program hazırlar.
    public class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public int Count { get; private set; }

        //çıkarma işlemleri listenin başından olur kuyruk yapısında ilk gelen ilk çıkar
        //o yüzden listenin ilk elemanını çıkardık her çıkardığımızda kuyruk bir eleman küçülecek 
        //ve başa geri dönecek.

        public T DeQueue()
        {
            var temp = list.RemoveFirst();
            Count--;
            return temp;
        }

        //ekleme işlemi kuyruklarda sonundan  olur son gelen son gider.
        // bu yüzden kuyruğun sonuna eleman eklemsi yapacak
        //her ekledğinde eleman sayımız birer birer artacak.

        public void Enqueue(T value)
        {
            list.AddLast(value);
            Count++;
        }

        //peek ifadesinin mantığı şudur. tepedeki baştaki kimse onu verir
        // bu yüzden listenin baş düğümüne dönmemiz yeterlidir

        public T Peek()
        {
            return list.Head.Value;
        }
    }
}