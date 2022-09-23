using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yığın_Yapısı
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var charset = new char[] { 'a', 'b', 'c', 'd','e'};

            var stack1 = new Stack<char>();
            var stack2 = new Stack<char>(StackType.LinkedList);

            foreach (var c in charset)
            {
                Console.WriteLine(c);
                stack1.Push(c);
                stack2.Push(c);
            }

            Console.ReadKey();

            Console.WriteLine("\nPeek");
            Console.WriteLine($"Stack1 : {stack1.Peek()}");
            Console.WriteLine($"Stack1 : {stack2.Peek()}");

            Console.ReadKey();

            Console.WriteLine("\nCount");
            Console.WriteLine($"Stack2 : {stack1.Count}");
            Console.WriteLine($"Stack2 : {stack2.Count}");

            Console.ReadKey();

            Console.WriteLine("\nPop");
            Console.WriteLine($"Stack1 : {stack1.Pop()} has been removed");
            Console.WriteLine($"Stack1 : {stack2.Pop()} has been removed");

            Console.ReadKey();

        }
    }
}