using Tek_Yönlü_Bağlı_Dizi;

namespace Tek_Yönlü_Bağlı_Liste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        var linkedlist = new SinglyLinkedList<int>();
        
        linkedlist.AddFirst(1);
        linkedlist.AddFirst(2);
        linkedlist.AddFirst(3);

        linkedlist.AddLast(4);
        linkedlist.AddLast(5);
        linkedlist.AddLast(6);
            
        linkedlist.AddAfter(linkedlist.Head.Next,32);
        linkedlist.AddAfter(linkedlist.Head.Next.Next, 33);

            foreach (var o in linkedlist)
            {
                Console.Write($"{o,-3}");
            }

            Console.ReadKey();
            Console.WriteLine();

            linkedlist.RemoveFirst();
            linkedlist.RemoveFirst();

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Eleman Silinmiş Liste");

            foreach (var o in linkedlist)
            {
                Console.Write($"{o,-3}");
            }

            Console.ReadKey();
            Console.WriteLine();

            Console.ReadKey();
            Console.WriteLine();

            linkedlist.RemoveLast();

            foreach (var o in linkedlist)
            {
                Console.Write($"{o,-3}");
            }

            Console.ReadKey();
            Console.WriteLine();

            // LINQ ifadeleri.

            var rnd = new Random();
            var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
            var linkedliste = new SinglyLinkedList<int>(initial);

            var q = from item in linkedliste where item % 2 == 1 select item;

            Console.WriteLine("Tek Sayılar");

            foreach (var item in q)
            {
                Console.Write($"{item,-5}");
            }

            Console.ReadKey();
            Console.WriteLine();

            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("5ten büyük olanlar");
            linkedlist.Where(x => x > 5).ToList().ForEach(x => Console.Write($"{x,-4}"));

            

        }
    }
}