using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using PROJOB_PROJEKT;
using System.Xml.Serialization;

namespace PROJOB_PROJEKT
{


    public class listCommand : ICommand
    {
        public void Undo()
        {

        }
        IBookstore bookstore;
        private Dictionary<string, ICommandFactory> Listings;
        [XmlArray]  
        public  string[] Args;

        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            if(Args==null)
                Args = args;
            bookstore=collection;
            Listings=new Dictionary<string,ICommandFactory>();
            Listings.Add("authors",new listAuthorsFactory());
            Listings.Add("books", new listBooksFactory());
            Listings.Add("boardgames",new listBoardGamesFactory());
            Listings.Add("newspapers",new listNewspapersFactory());
        }
        public string Name => "list";
        public override string ToString()
        {
            string s = "";
            foreach(var a in Args)
                s += a+" ";
            return s;
        }
        public void Execute()
        {
            {
                try
                {
                    ICommandFactory com = Listings[Args[1].ToLower()];
                    com.Make(Args, bookstore,null).Execute();
                    
                }
                catch
                {
                    Console.WriteLine($"cant find collection {Args[1]}");
                }
            }
        }
     }
    public class listAuthorsCommand : ICommand
    {
        public void Undo()
        {

        }
        private ICollection<IAuthor> authors;
        private string[] Args;
        public string Name => "list authors";
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            Args = args;
            authors = collection.Authors;
        }
        public  void Execute()
        {
            Algorithms.ForEach(authors.GetForwardIterator(), b =>
            {
                string? pom = b.GetNickname() != null ? "\"" + b.GetNickname() + "\"" : " ";
                Console.WriteLine(b.GetName() + " " + b.GetSurname() + " " + b.GetYearOfBirth() + " " + pom);
            });
        }
    }
    public class listBooksCommand : ICommand
    {
        public void Undo()
        {

        }
        public string[] Args;
        private ICollection<IBook> books;
        public string Name => "list books";
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            Args = args;
            books = collection.Books;
        }
        public void Execute()
        {
            Algorithms.ForEach(books.GetForwardIterator(), b =>
            {
                Console.WriteLine(b.GetTitle() + " " + b.GetPageCount() + " " + b.GetYear());
            });
        }
    }
    public class listNewsPapersCommand : ICommand
    {

        public void Undo()
        {

        }
        public string[] Args;
        private ICollection<INewsPaper> newspapers;
        public string Name => "list newspapers";
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            Args = args;
            newspapers = collection.Newspapers;
        }
        public void Execute()
        {
            Algorithms.ForEach(newspapers.GetForwardIterator(), b =>
            {
                Console.WriteLine(b.GetTitle() + " " + b.GetYear() + " " + b.GetPageCount());
            });
        }
    }
    public class listBoardGamesCommand : ICommand
    {
        public void Undo()
        {

        }
        private string[] Args;
        private ICollection<IBoardGame> boardgames;
        public string Name => "list newspapers";
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            Args = args;
            boardgames = collection.Boardgames;
        }
        public void Execute()
        {
            Algorithms.ForEach(boardgames.GetForwardIterator(), b =>
            {
                Console.WriteLine(b.GetName() + " " + b.GetDifficulty() + " " + b.GetMaxPlayers() + "-" + b.GetMaxPlayers());
            });
        }
    }

}
