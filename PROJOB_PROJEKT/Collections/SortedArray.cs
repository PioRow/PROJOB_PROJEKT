using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class SortedArray<T> : ICollection<T>
    {
        public T[] array;
        private int _count;
        Func<T,T,int> comparer;
        public SortedArray(Func<T,T,int> C)
            {
            _count = 0;
            array = new T[_count];
            comparer = C;
            }

        public void Add(T obj)
        {
            Array.Resize(ref array, _count+1);
            int idx = 0;
            while (idx < _count && comparer(obj, array[idx])>0)
            {
                idx++;
            }
            if (idx == _count)
            {
                array[idx] = obj;
                _count++;
                return;
             }
            for(int i=_count;i>idx;i--)
            {
                array[i] = array[i - 1];
            }
            array[idx] = obj;
            _count++;

        }

        public bool Delete(T obj)
        {
            int idx = 0;
            while (idx<_count&& comparer(obj, array[idx]) != 0)
            {
                idx++;
            }
            if(idx==_count)
                return false;
            for (int i=idx;i<_count-1;i++)
            {
                array[i] = array[i + 1];
            }
            _count--;
            Array.Resize(ref array, _count);
            return true;

        }

        public Iiterator<T> GetBackwardIterator()
        {
            return new SortedListBackwardIterator<T>(this);
        }

        public Iiterator<T> GetForwardIterator()
        {
            return new SortedListForwardIterator<T>(this);
        }
        public int Find(T obj)
        {
            int L = 0;
            int P = _count - 1;
            int mid = (P - L) / 2;
            while (comparer(obj, array[mid]) != 0)
            {
                if (L == P) { return -1; }
                if (comparer(obj, array[mid]) > 0)
                {
                    L = mid;
                    mid = (P - L) / 2;
                }
                else
                {
                    P = mid;
                    mid=(P- L) / 2;
                }

            }
            return mid;
        }
        
        public int GetLength()
        {
            return _count;
        }
    }
}
