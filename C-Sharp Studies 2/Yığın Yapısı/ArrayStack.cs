using Tek_Yönlü_Bağlı_Dizi;

namespace Yığın_Yapısı
{
    public class ArrayStack<T> : Istack<T>
    {
        //Yığın_Yapısı büyüklüğünü gösteren count özelliği tanımladık
        //sadece okunabilen liste tanımı yaptık.

        public int Count { get; private set;}

        private readonly List<T> list = new List<T>();

        //peek ifadesi listenin sonuna dönecek çünkü en son listenin en üstü 

        public T Peek()
        {
           return list[list.Count - 1];
        }

        //listenin sonundan eleman silen metot
        //geçici değikeni listenin son elemanı yaptık.
        //count her eleman eksildğiğnde 1 azalacak

        public T Pop()
        {
            var temp = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Count--;
            return temp;
        }

        // Push ifadesinin özelliği olarak eleman ekleyen metot 
        //listenin sonuna ekliyor her eleman eklediğinde dizi büyüklüğü bir eleman ekliyor

        public void Push(T value)
        {
           list.Add(value);
            Count++;
        }
    }
}