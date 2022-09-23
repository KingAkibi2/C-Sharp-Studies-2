using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İkili_Ağaç_Yapısı
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public List<Node<T>> list { get;private set; }

        public BinaryTree()
        {
            list = new List<Node<T>>();
        }


    //ınorder dolaşma sol alt köşeden her dalı satt yönünde dolaşır (sol dal-kök-sağ dal)

        public List<Node<T>> InOrder(Node<T> root)
        {
            if (!(root==null))
            {
                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);

            }
            return list;

        }
       
        public List<Node<T>> PreOrder(Node<T> root)
        {
            if (!(root==null))
            {
                list.Add(root);
                PreOrder(root.Left); 
                PreOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> PostOrder(Node<T> root)
        {
            if (!(root == null))
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root); 
            }
            return list;
        }

       public Node<T> FindMin(Node<T> root)
        {
            var current =root;
            while (!(current.Left==null))
            {
                current = current.Left;
            }
            return current;
        }

        public Node<T> FindMax(Node<T> root)
        {
            var current = root;
            while (!(current.Right == null))
            {
                current = current.Right;
            }
            return current;
        }

        public Node<T> Find(Node<T> root,T key)
        {
            var current = root;
            while (key.CompareTo(current.Value)!=0)
            {
                if (key.CompareTo(current.Value)<0)
                {

                }
                else
                {
                    current=current.Right;
                }
                if (current==null)
                {
                    throw new Exception("error");
                }
              
            }
            return current;
        }

        public Node<T> Remove(Node<T> root, T key)
        {
            if (root==null)
            {
                return root;
            }

            if (key.CompareTo(root.Value)<0)
            {
                root.Left = Remove(root.Left, key);
            }

            else if (key.CompareTo(root.Value)>0)
            {

            }

            else
            {
                if (root.Left==null)
                {
                    return root.Right;
                }

                else if (root.Right==null)
                {
                    return root.Left;
                }

                root.Value = FindMax(root.Right).Value;
                root.Right=Remove(root.Right, root.Value);

            }
            return root;
        }



    }

}
