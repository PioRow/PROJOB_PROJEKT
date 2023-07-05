using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public interface ICollection<T>
    {
        public void Add(T obj);
        public bool Delete(T obj);
       public int GetLength();
        public Iiterator<T> GetForwardIterator();
        public Iiterator<T> GetBackwardIterator();
        
    }

}
