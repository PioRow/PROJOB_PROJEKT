using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class VectorBackwardIterator<T>:Iiterator<T>
    {
        private Vector<T> collection;
        int idx;
        public VectorBackwardIterator(Vector<T> vec)
        {
            idx = vec.array.Length;
            collection = vec;
        }

        public bool Compare(Iiterator<T> iterator)
        {
            return this.value().Equals(iterator.value());
        }
        public Iiterator<T> next()
        {
            idx--;
            if (idx <0) { return null; }
            return this;
        }
        public T value()
        {
            return collection.array[idx];
        }
    
    }   
}
