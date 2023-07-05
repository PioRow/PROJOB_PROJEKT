using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class LListForwardIterator<T>:Iiterator<T>
    {
        LList<T>.Node current;
        public LListForwardIterator(LList<T>.Node head)
        {
            current = new LList<T>.Node(default(T));
            current.next = head;
        }
        public bool Compare(Iiterator<T> iterator)
        {
            return this.value().Equals(iterator.value());
        }

        public Iiterator<T> next()
        {
            current = current.next;
            if (current == null)
                return null;
            return this;
        }

        public T value()
        {
            return current.value;
        }
    }
}
