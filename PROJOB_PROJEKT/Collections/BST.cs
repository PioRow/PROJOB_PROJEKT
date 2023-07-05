using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BST<T>:ICollection<T>
    {
        public Node? root;
        public int Count;
        public class Node
        {
            public T val;
            public Node? left, right;
            public Node(T v,Node r=null,Node l=null)
            {
                val = v;
                left = l;
                right = r;
            }
        }
        public BST()
        {
            Count = 0;
            root = null;    
        }
        public void Add(T obj)
        {
           if(root == null)
            {
                root = new Node(obj);
                Count++;
                return;
            }
            Node node = new Node(obj);           
            Node p = root;
            Node pp=null;
            
            while (p != null && p.val.GetHashCode() != node.val.GetHashCode()) 
            {
                if (node.val.GetHashCode() < p.val.GetHashCode())
                { pp =p;
                    p = p.left;  }
                else
                {
                    pp = p;
                    p = p.right; }
            }
            if(p==null)
            {
                if (pp.val.GetHashCode() > node.val.GetHashCode())
                    pp.left = node;
                else
                    pp.right = node;
                Count++;
            }
            return;
        }
        
        public bool Delete(T obj)
        {
            root = DeleteNode(root, obj);
            if(root==null)
                return false;
            Count--;
            return true;
        }
        private Node DeleteNode(Node node, T val)
        {
            if (node == null)
            {
                return null;
            }
            if (val.GetHashCode() < node.val.GetHashCode())
            {
                node.left = DeleteNode(node.left, val);
            }
            else if (val.GetHashCode() > node.val.GetHashCode())
            {
                node.right = DeleteNode(node.right, val);
            }
            else
            {
                if (node.left == null && node.right == null)
                {
                    node = null;
                }
                else if (node.left == null)
                {
                    node = node.right;
                }
                else if (node.right == null)
                {
                    node = node.left;
                }
                else
                {
                    Node temp = FindMin(node.right);
                    node.val = temp.val;
                    node.right = DeleteNode(node.right, temp.val);
                }
            }
            return node;
        }
        public Node FindMin(Node current)
        {
            while (current.left != null)
            {
                current = current.left;
            }
            return current;
        }

        public Iiterator<T> GetBackwardIterator()
        {
            return new BSTReverseInOrderIterator<T>(root);

        }

        public Iiterator<T> GetForwardIterator()
        {
            return new BSTInOrderIterator<T>(root);
        }

        public int GetLength()
        {
            return Count;
        }

       

    }
}
