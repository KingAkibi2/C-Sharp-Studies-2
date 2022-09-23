using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yığın_Yapısı
{
    public class Stack<T>
    {
        //sadece okunabilen Istack arayüzünü kullanan yığın tanımı yaptık.
        //yığının eleman sayısını gösterebilen count özelliği tanımladık.
        //enum yapısıyla stack türüne karar veren yapıyı oluşturduk.
        //Istack arayüzüne 3 özellik ekledik push ekleme pop çıkarma peek en üsttki elemanı gösterme
        //üstte belirttiğimiz gibi o arayüzü kullanarak yığın tanımladık.
        //array stack ve linkedlist stacklerini başka bir sınıfta implemente ettik
        //bu yapılar ıstack arayüzünü kabul ettiğini görmekteyiz.

        private readonly Istack<T> stack;
        public int Count => stack.Count;
        public Stack(StackType type = StackType.Array)
        {
            if (type==StackType.Array)
            {
                stack = new ArrayStack<T>();
            }
            else
            {
                stack = new LinkedListStack<T>();
            }
        }

        public T Pop()
        {
            return stack.Pop();
        }
        public T Peek()
        {
            return stack.Peek();

        }

        public void Push(T value)
        {
            stack.Push(value);
        }

    }

    public interface Istack<T>
    {
        int Count { get; }
        void Push(T value);
        T Peek();
        T Pop();

    }

    public enum StackType
    {
        Array = 0,
        LinkedList = 1

    }

}
