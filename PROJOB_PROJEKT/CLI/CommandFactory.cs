using PROJOB_PROJEKT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public  interface ICommandFactory
    {   string Name { get; }
        public ICommand Make(string[] Args, IBookstore Collection,string? Meta);
    }
    public class AddCommandFactory : ICommandFactory
    {
        public string Name => "add";

        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
            ICommand ret = new addCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class addAuthorFactory : ICommandFactory
    {
        public string Name => "add author";

    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
            ICommand ret = new addAuthorCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class addNewspaperFactory :ICommandFactory
    {
        public string Name => "add newspaper";

        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
            ICommand ret = new addNewspaperCommand();
            ret.Init(Args, Collection, Meta);
            return ret;

        }
    }
    public class addBookFactory : ICommandFactory
    {
        public string Name => "add book";

        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
            ICommand ret = new addBookCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class addBoardGameFactory : ICommandFactory
    {
        public string Name => "add boardgame";

        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
            ICommand ret = new addBoardgameCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }

    public class ListCommandFactory : ICommandFactory
    {
        public string Name => "list";

        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
          
            ICommand ret = new listCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class listAuthorsFactory :ICommandFactory
    {
        public string Name => "authors";
        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
         
            ICommand ret = new listAuthorsCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class listBooksFactory : ICommandFactory
    {
        public string Name => "authors";
        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
           
            ICommand ret = new listBooksCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class listBoardGamesFactory : ICommandFactory
    {
        public string Name => "authors";
        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
         
            ICommand ret = new listBoardGamesCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class listNewspapersFactory : ICommandFactory
    {
        public string Name => "authors";
        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
        
            ICommand ret = new listNewsPapersCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class findCommandFactory:ICommandFactory
    {
        public string Name => "find";
        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
           
            ICommand ret = new findCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class findbookFactory : ICommandFactory
    {
        public string Name => "books";
        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
          
            ICommand ret = new findBooksCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class findauthorFactory : ICommandFactory
    {
        public string Name => "authors";
        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {     


            ICommand ret = new findAuthorsCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class findBoardgameFactory : ICommandFactory
    {
        public string Name => "boardgames";
    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
        
            ICommand ret = new findBoardgamesCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class findNewspaperFactory : ICommandFactory
    {
        public string Name => "newspapers";
    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
          
            ICommand ret = new findNewspapersCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class editCommamdFactory : ICommandFactory
    {
        public string Name => "edit";

    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
         
            ICommand ret = new editCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class editbookFactory : ICommandFactory
    {
        public string Name => "book";

    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
          
            ICommand ret = new editBooksCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class editAuthorFactory : ICommandFactory
    {
        public string Name => "author";

     public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {
        
            ICommand ret = new editAuthorCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class editNewspaperFactory:ICommandFactory
    {
        public string Name => "newspaper";

        public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
        {


            ICommand ret = new editNewspaperCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }
    public class editBoardgameFactory : ICommandFactory
    {
        public string Name => "boardgame";

    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
           
            ICommand ret = new editBoardgameCommand();
            ret.Init(Args, Collection, Meta);
            return ret;
        }
    }


    public class exitCommandFactory : ICommandFactory
    {
        public string Name => "exit";
    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
            return new exitCommand();
        }
    }
    public class queueCommandFactory:ICommandFactory
    {
        private Queue<ICommand> _commands;
        private Queue<ICommand> _done;
        public queueCommandFactory(Queue<ICommand> commands, Queue<ICommand>done)
        {
            _commands = commands;
            _done = done;
        }
        public string Name => "queue";
    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
            queueCommand q = new queueCommand();
                q.Init(Args, Collection, Meta);
            q.Commands=_commands;
            q.done= _done;
            return q;
        }   
    }
    public class deleteCommandFactory : ICommandFactory
    {
        public string Name => "delete";
    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
            ICommand com =new deleteCommand();
            com.Init(Args, Collection, Meta);
            return com;
        }
    }
    public class deletebookFactory : ICommandFactory
    {
        public string Name => "book";
    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
            ICommand com = new deleteBooksCommand();
            com.Init(Args, Collection, Meta);
            return com;
        }   
    }
    public class deleteauthorFactory : ICommandFactory
    {
        public string Name => "author";
    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
            ICommand com = new deleteAuthorsCommand();
            com.Init(Args, Collection,Meta);
            return com;
        }
    }
    public class deleteNewspaperFactory : ICommandFactory
    {
        public string Name => "newspaper";
    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
            ICommand com = new deleteNewspapersCommand();
            com.Init(Args, Collection,Meta);
            return com;
        }
    }
    public class deleteBoardGameFactory : ICommandFactory
    {
        public string Name => "boardgame";
    public ICommand Make(string[] Args, IBookstore Collection, string? Meta)
    {
            ICommand com = new deleteBoardgamesCommand();
            com.Init(Args, Collection, Meta);
            return com;
        }
    }
}

