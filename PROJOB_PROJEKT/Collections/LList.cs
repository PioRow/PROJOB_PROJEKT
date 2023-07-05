using PROJOB_PROJEKT.Iterators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public  class LList<T>:ICollection<T>
    {
        public class Node
        {
            public Node? next;
            public Node? prev;
            public T value;
            public Node(T val)
            {
                next = prev = null;
                value = val;
            }
        }
        public Node? head;
        public Node? tail;
        public int Count;
        public LList()
        {
            head = tail = null;
            Count = 0;
        }
        public void Add(T obj)
        {
            if(head== null)
            {
               tail= head = new Node(obj);
                Count++;
                return;
            }
            tail.next=new Node(obj);
            tail.next.prev = tail;
            tail=tail.next;
            Count++;
            return;
        }

        public bool Delete(T obj)
        {
            Node? p = head;
            while (p != null && p.value.Equals(obj))
            {
                p = p.next;
            }
            if(p==null)
                return false;
            p.next.prev = p.prev;
            p.prev.next = p.next;
            Count--;
            return true;
        }

        public Iiterator<T> GetBackwardIterator()
        {
            return new LListBackwardIterator<T>(tail);
        }

        public Iiterator<T> GetForwardIterator()
        {
            return new LListForwardIterator<T>(head);
        }

        public int GetLength()
        {
            return Count;
        }

       
    }
}
