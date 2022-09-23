using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İkili_Ağaç_Yapısı
{
    public class BTNode<T>
    {
        public T Value { get; set; }
        public BTNode<T> Left { get; set; }
        public BTNode<T> Right { get; set; }
        public BTNode()
        {

        }

        public BTNode(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }


    }
}
