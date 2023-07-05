using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public  static class CLI
    {
       static Queue<ICommand> commands = new Queue<ICommand>();
        static Queue<ICommand> Done= new Queue<ICommand>();
      static  List<ICommandFactory> availableCommands = new List<ICommandFactory>(){ new AddCommandFactory(),new exitCommandFactory(),
                new ListCommandFactory(),new findCommandFactory(),new queueCommandFactory(commands,Done),new editCommamdFactory(),
            new deleteCommandFactory()};
        public static void Run( IBookstore bookstore)
        {
            //new findCommand(bookstore),new addCommand(bookstore)
           
            string Buffer=null;
            while (true)
            {
                if(Buffer!=null)
                {
                    Console.WriteLine(Buffer);
                }
                Console.Write(">");
               string input=Console.ReadLine();
                Executer(input,bookstore,null);
              
            }
        }
        public static void Executer(string line,IBookstore bookstore,string? MetaData)
        {
            string[] Args = line.Split(' ');
            ICommandFactory? com = availableCommands.FirstOrDefault(c => c.Name == Args[0]);
            if (com == null)
            {
                Console.WriteLine("invalid command");
            }
            else if (com.Name == "exit" || com.Name == "queue")
            {
                com.Make(Args, bookstore,MetaData).Execute();
                

            }
            else
            {
                ICommand c=com.Make(Args, bookstore, MetaData);
                commands.Enqueue(c);
                c.Execute();
                
                
            }
        }
    }
    
}
