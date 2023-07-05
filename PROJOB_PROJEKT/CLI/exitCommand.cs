using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace PROJOB_PROJEKT
{
    public class exitCommand : ICommand
    {
        public void Undo()
        {

        }
        public string Name => "exit";
        public exitCommand() { }
        public void Execute() { System.Environment.Exit(0); }
        public void Init(string[] args, IBookstore bookstore,string? Meta) { }
    }

    
}
