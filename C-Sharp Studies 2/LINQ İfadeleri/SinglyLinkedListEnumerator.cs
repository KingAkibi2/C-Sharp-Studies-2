using System.Collections;
using Tek_Yönlü_Bağlı_Liste;

namespace Tek_Yönlü_Bağlı_Dizi
{
    public class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {

        //Head ve geçici değişkeni tanımalayarak işe başladık.
        //Sonra head ifadesini yapılandırıcı metoda dönüştürdük.
        //geçici değişkeni(now1) boş atadık 

        private Node<T> Head;
        private Node<T> now1;
        public SinglyLinkedListEnumerator(Node<T> head)
        {
            Head = head;
            now1 = null;
        }

        //current zaten now1 demek olduğu için direk onun değerini girdik.

        public T Current => now1.Value;

        object IEnumerator.Current => now1;

        //dispose yoketme tarzı bir işe yarıyor.
        //baş düğümün boş olma durumunu yok edecek.

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if (now1==null)
            {
                now1 = Head;
                return true;
            }
            else
            {
                now1 = now1.Next;
                return now1 != null ? true : false;
            }

        }

        // düğüm boş olunca resetlenmiş oluyor.

        public void Reset()
        {
            now1 = null;
        }
    }
}