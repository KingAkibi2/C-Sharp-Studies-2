using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tek_Yönlü_Bağlı_Dizi;
using Tek_Yönlü_Bağlı_Liste;

namespace LINQ_İfadeleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var rnd = new Random();
            var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
            var linkedlist = new SinglyLinkedList<int>(initial);

            var q = from item in linkedlist where item%2==1 select item;

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }

        }
    }
}