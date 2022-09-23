using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tek_Yönlü_Bağlı_Liste
{
    public class Node<T>
    {
        //ilk önce düğümü(node) özellik olarak tanımladık.
        //T değerini diziyi oluştururken verdiğimiz int string char gibi tip güvenliğini sağlayan parametre gibi düşünebiliriz.
        

        public Node<T> Next { get; set; }
        public T Value { get; set; }
        public Node(T value)
        {
            Value = value;
        }

      //bu ifade sayesinde düğüm içindeki değer kullanıcıya döndürülmüş olacak.  
        public override string ToString()
        {
            return  $"{Value}";
        }
    }
}
