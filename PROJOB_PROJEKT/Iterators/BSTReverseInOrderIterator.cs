using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BSTReverseInOrderIterator<T>:Iiterator<T>
    {
        Stack<BST<T>.Node> nodes;
        public BSTReverseInOrderIterator(BST<T>.Node root)
        {
            nodes = new Stack<BST<T>.Node>();
            while (root.right != null)
            {
                nodes.Push(root);
                root = root.right;
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
                if (node.left != null)
                {
                    node = node.left;
                    while (node != null)
                    {
                        nodes.Push(node);
                        node = node.right;
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
