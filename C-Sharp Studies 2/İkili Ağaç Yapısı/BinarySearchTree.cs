using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İkili_Ağaç_Yapısı
{


    //ıenumerable özelliği ile sayılabilme özelliğini ekledik.
    //ı comperable ifadesi karşılaştırma yapılabilme özelliği sağlar.
    //root ile ana dğüğm ana kök düğümü tanımladık.

    public class BinarySearchTree<T> : IEnumerable<T>
       where T : IComparable
    {
        private int[] ints;

        public BinarySearchTree()
        {

        }
        //Bu ifade ile otomatik eleman ekleme özelliği kazandırdık.
        public BinarySearchTree(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public Node<T> Root { get; set; }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //eleman ekleme işlevinde gelecek eleman sol tarafa mı sağ tarafa mı gideceğine değerler karar verecek 
        //eğer ki kökten büyükse sağa küçükse sol tarafa gidecek
    
        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("there is nothing here");
            }

            //yeni düğüm tanımladık
            //kök düğüm boşsa ekleyeceğimiz elemanı kök düğüm yaptık.
            //eğer ki doluysa gelecek elemanın değeri kök düğümle karşılaştıracağız
            //kök düğümden küçükse sola yönlendirecek büyükse sağa yönlendirecek
            //beak ile döngüyü kırabiliriz

            var newNode = new Node<T>(value);

            if (Root==null)
            {
                Root = newNode;
            }
            else
            {
                var temp = Root;
                Node<T> parent;
                 
                while (true)
                {
                    parent = temp;

                    if (value.CompareTo(temp.Value)<0)
                    {
                        temp = temp.Left;
                        if (temp==null)
                        {
                            parent.Left = newNode;
                            break;

                        }
                    }

                    else
                    {
                        parent.Right = newNode;
                        break;

                    }

                }
            }

        }


    }
}
