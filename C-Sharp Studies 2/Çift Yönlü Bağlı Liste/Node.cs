using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Çift_Yönlü_Bağlı_Liste
{ 
    //İlerlemeyi temsil eden next ve bir önceki elemana gitmeyi temsil eden next olacak şekilde 2 adet düğüm oluşturduk.
    
    public class dllNode<T>
    {
        public dllNode<T> Prev { get; set; }
        public dllNode<T> Next { get; set; }
        public T Value { get; set; }

        public dllNode(T value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
        

    }
}
