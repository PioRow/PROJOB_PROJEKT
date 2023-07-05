using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BSTCustomOrderIterator<T>:Iiterator<T>
    {
        Queue<BST<T>.Node> nodes;
        public BSTCustomOrderIterator(BST<T>.Node root)
        {
            nodes = new Queue<BST<T>.Node>();
            nodes.Enqueue(null);
            nodes.Enqueue(root);
           

        }
        public bool Compare(Iiterator<T> iterator)
        {
            return this.value().Equals(iterator.value());
        }

        public Iiterator<T> next()
        {

            BST<T>.Node node = nodes.Dequeue();
            if(node!=null)
            {
                if(node.left!=null)
                {
                    nodes.Enqueue(node.left);
                }
                if(node.right!=null) 
                {
                    nodes.Enqueue(node.right
                        );
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
