using System.Collections;

namespace Kuyruk_Yapısı
{
    public class Program
    {
        static void Main(string[] args)
        {
            // iki tane kuyruk yapısı tanımladık
            // birinde parametre belirtmedik ve default olarak array kuyruğu olarak geldi
            // ikincisi ise linked list kuyruğu seçtiğimiz için öyle geldi
            // yeni bir tane de dizi tanımladık
            //dizinin elemanlarını foreach ile dönerek kuyruklarımıza ekledik
            //ardından ekleme kaldırma işlemlerini yaptık

            var numbers = new int[] { 1, 3, 5, 7, 9, };

            var q1 = new Queue<int>();
            var q2 = new Queue<int>(QueueType.LinkedList);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
                q1.Enqueue(item);
                q2.Enqueue(item);
            }

            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine($"q1 count : {q1.Count}");
            Console.WriteLine($"q2 count : {q2.Count}");

            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine($"{q1.DeQueue()} has been removed from the q1");
            Console.WriteLine($"{q2.DeQueue()} has been removed from the q2");

            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine($"q1 count : {q1.Count}");
            Console.WriteLine($"q2 count : {q2.Count}");

            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine($"q1 Peek : {q1.Peek()}");
            Console.WriteLine($"q2 Peek : {q2.Peek()}");

            Console.WriteLine();
            Console.ReadKey();

            
        }
    }
}