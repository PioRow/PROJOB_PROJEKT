using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT.Iterators
{
    public class LListBackwardIterator<T> : Iiterator<T>
    {
        LList<T>.Node current;
        public LListBackwardIterator(LList<T>.Node tail)
        {
            current =new LList<T>.Node(default(T));
            current.prev = tail;
        }
        public bool Compare(Iiterator<T> iterator)
        {
            return this.value().Equals(iterator.value());
        }

        public Iiterator<T> next()
        {
            current = current.prev;
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
