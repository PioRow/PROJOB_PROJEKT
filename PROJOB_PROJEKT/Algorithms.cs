using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public static class Algorithms
    {
            public static T Find<T>(Iiterator<T> iterator,Func<T,bool> Pred) 
            {
                while (iterator.next() != null) 
                {
                    if (Pred(iterator.value()))
                        return iterator.value();
                }
            return default(T);
            }
        public static void ForEach<T>(Iiterator<T> iterator, Action<T> func) 
        {
            while(iterator.next() != null)
            {
                func(iterator.value());
            }
        }
        public static int CountIf<T>(Iiterator<T> iterator, Func<T, bool> Pred) 
        {
            int count = 0;
            while (iterator.next() != null)
            {
                if (Pred(iterator.value()))
                    count++;
            }
            return count;
        }
    }
}
