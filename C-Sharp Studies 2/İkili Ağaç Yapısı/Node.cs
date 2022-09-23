using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace İkili_Ağaç_Yapısı
{
    //her zamanki gibi ağacımıza düğüm özelliği tanımladık.
    //diğerlerinden farklı olarak left ve right şeklinde iki dal tanımladık.
    //yapılandırıcı metot ve ctor kullandık.
  
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node()
        {

        }

        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

    }
}
