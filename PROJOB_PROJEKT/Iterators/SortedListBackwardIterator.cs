using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class SortedListBackwardIterator<T> : Iiterator<T>
    {
        public int idx;
        SortedArray<T> list;
        public SortedListBackwardIterator(SortedArray<T> list)
        {
            idx = list.GetLength();
            this.list = list;
        }

        public bool Compare(Iiterator<T> iterator)
        {
            return this.value().Equals(iterator.value());
        }

        public Iiterator<T> next()
        {
            idx--;
            if (idx < 0)
            {
                return null;
            }
            return this;
        }

        public T value()
        {
            return list.array[idx];
        }
    }
}
