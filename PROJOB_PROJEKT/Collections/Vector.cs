using PROJOB_PROJEKT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class Vector<T> : ICollection<T> 
    {
       public   T[] array;
        public Vector()
        {
            array = new T[0];
        }
        public int GetLength() => array.Length;
        public void Add(T val)
        {
           Array.Resize(ref array, array.Length+1);
            array[array.Length-1] = val;
        }

        public bool Delete(T val)
        {
           
          for(int i=0; i<array.Length; i++)
          {
          if (array[i].Equals(val))
          {
              array[i]=array[array.Length - 1];
              Array.Resize(ref array,array.Length-1);
              return true;
          }
              
          }
            return false;
        }

        public Iiterator<T> GetBackwardIterator()
        {
            return new VectorBackwardIterator<T>(this);
        }

        public Iiterator<T>  GetForwardIterator()
        {
            return new VectorForwardIterator<T>(this);
        }
    }
}
