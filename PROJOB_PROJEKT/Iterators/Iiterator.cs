using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public interface Iiterator<T>
    {
        T value();
        Iiterator<T> next();
        bool Compare(Iiterator<T> iterator);
       
    }
    
}
