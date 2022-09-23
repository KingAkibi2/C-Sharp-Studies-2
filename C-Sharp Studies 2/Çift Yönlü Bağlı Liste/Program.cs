namespace Çift_Yönlü_Bağlı_Liste
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var dll = new DoublyLinkedList<int>();

            dll.AddFirst(1);
            dll.AddFirst(2);
            dll.AddFirst(3);

            dll.AddLast(4);
            dll.AddLast(5);

            dll.AddAfter(dll.Head.Next.Next,new dllNode<int>(10));
            dll.AddAfter(dll.Head.Next.Next.Next, new dllNode<int>(30));

            foreach (var item in dll)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine()
                ;
            dll.AddBefore(dll.Head.Next.Next.Next, new dllNode<int>(31));

            foreach (var item in dll)
            {
                Console.WriteLine(item);
            }
        }
    }
}