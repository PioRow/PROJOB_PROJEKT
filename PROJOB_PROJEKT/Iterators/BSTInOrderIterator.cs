using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BSTInOrderIterator<T> : Iiterator<T>
    {
        Stack<BST<T>.Node> nodes;
        public BSTInOrderIterator(BST<T>.Node root)
        {
            nodes=new Stack<BST<T>.Node>();
            while(root.left!= null)
            {
                nodes.Push(root);
                root = root.left;
            }
            nodes.Push(root);
            nodes.Push(null);

        }
        public bool Compare(Iiterator<T> iterator)
        {
            return this.value().Equals(iterator.value());
        }

        public Iiterator<T> next()
        {
            
           BST<T>.Node node = nodes.Pop();
            if (node != null)
            {
                if(node.right!= null)
                {
                    node=node.right;
                    while(node!=null)
                    {
                        nodes.Push(node);
                        node = node.left;
                    }
                }    
            }
            if (nodes.Count == 0)
                return null;
            return this;
        }

        public T value()
        {
           
            return nodes.Peek().val;
        }
    }
}
