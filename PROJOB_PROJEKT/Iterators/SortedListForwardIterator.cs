using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class SortedListForwardIterator<T> : Iiterator<T> 
    {
        public int idx;
        SortedArray<T> list;
        public SortedListForwardIterator( SortedArray<T> list)
        {
            idx = -1;
            this.list = list;
        }

        public bool Compare(Iiterator<T> iterator)
        {         
               return this.value().Equals(iterator.value());
        }

        public Iiterator<T> next()
        {
            idx++;
            if(idx==list.GetLength()) 
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
