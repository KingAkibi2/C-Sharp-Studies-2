namespace İkili_Ağaç_Yapısı;

public class Program
{
    static void Main(string[] args)
    {

        var bst = new BinarySearchTree<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });

        var list = new BinaryTree<int>().InOrder(bst.Root);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.ReadKey();
        Console.WriteLine();

        var liste = new BinaryTree<int>().PreOrder(bst.Root);

        foreach (var item in liste)
        {
            Console.WriteLine(item);
        }

        Console.ReadKey();
        Console.WriteLine();

        var listeM = new BinaryTree<int>().PostOrder(bst.Root);

        foreach (var item in listeM)
        {
            Console.WriteLine(item);
        }

    }
}