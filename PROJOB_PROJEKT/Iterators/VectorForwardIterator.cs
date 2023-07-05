using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class VectorForwardIterator<T> : Iiterator<T>
    {
       private  Vector<T> collection;
        int idx;
        public VectorForwardIterator(Vector<T> vec)
        {
            idx = -1;
            collection = vec;
        }
            
        public bool Compare(Iiterator<T> iterator)
        {
            return this.value().Equals(iterator.value());
        }

       

        public Iiterator<T> next()
        {
            idx++;
            if(idx==collection.array.Length) { return null; }
            return this;
        }

        public T value()
        {
            return collection.array[idx];
        }
    }
}
