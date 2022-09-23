namespace Kuyruk_Yapısı
{
    //array kuyruğu tanımladığımız interface(arayüz)i kabul ediyor ve implemente edilebilir durumda oluyor
    // ctrl. kullanıp implement interface yapınca önceden tanımlamış olduğumuz interfacenin özelliklerini program hazırlar.
    
    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly List<T> list = new List<T>();
        public int Count {get;private set;}
        
        //çıkarma işlemleri listenin başından olur kuyruk yapısında ilk gelen ilk çıkar
        //o yüzden listenin ilk elemanını çıkardık her çıkardığımızda kuyruk bir eleman küçülecek 
        //ve başa geri dönecek.

        public T DeQueue()
        {
            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }

        //ekleme işlemi kuyruklarda sonundan  olur son gelen son gider.
        // bu yüzden kuyruğun sonuna eleman eklemsi yapacak
        //her ekledğinde eleman sayımız birer birer artacak.

        public void Enqueue(T value)
        {
            list.Add(value);
            Count++;
        }
        //peek ifadesinin mantığı şudur. tepedeki baştaki kimse onu verir
        // bu yüzden listenin ilk elemanına dönmemiz yeterlidir
        
        public T Peek()
        {
            return list[0];
        }
    }
}