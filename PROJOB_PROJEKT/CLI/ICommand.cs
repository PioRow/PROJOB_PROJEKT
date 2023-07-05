using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    
    public interface ICommand
    {
        public string Name { get; }
       
        public void Execute();
        public void Undo();
        public void Init(string[] args,IBookstore bookstore,string? Meta);
    }
}
