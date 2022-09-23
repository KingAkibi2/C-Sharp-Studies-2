using Tek_Yönlü_Bağlı_Dizi;

namespace Yığın_Yapısı
{
    public class LinkedListStack<T> : Istack<T>
    {
        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
        public int Count { get; private set; }

        //peek ifadesi listenin başına dönecek çünkü en son listenin en üstü 
        public T Peek()
        {
            return list.Head.Value;
        }
        //pop ifadesi listenin en başından eleman silen metot
        //remove first metodunu kullanarak baştan eleman silecek
        //count ifadesi de her eleman silindiğinde 1 azalacak

        public T Pop()
        {
            var temp = list.RemoveFirst();
            Count--;
            return temp;
        }

        //push ifadesş listenin sonuna eleman ekleyen bir metot 
        //count ifadesi her eleman ekledğiğmizde 1 artacak

        public void Push(T value)
        {
            list.AddFirst(value);
            Count++;

        }
    }
}