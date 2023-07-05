using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PROJOB_PROJEKT.Newspaper;

namespace PROJOB_PROJEKT
{
    public class addCommand : ICommand
    {
        public void Undo()
        {
            toExe.Undo();
        }
        public  string[] Args;
        public string Name => "add";
        public ICommand toExe;
        IBookstore bookstore;
        private Dictionary<string, ICommandFactory> Adds;
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
           
            Args = args;
            bookstore = collection;
            Adds=new Dictionary<string, ICommandFactory>();
            Adds.Add("book",new addBookFactory());
            Adds.Add("author",new addAuthorFactory());
            Adds.Add("newspaper",new addNewspaperFactory());
            Adds.Add("boardgame", new addBoardGameFactory());
            try
            {

                ICommandFactory com = Adds[Args[1]];

                toExe=com.Make(Args, bookstore,Meta);
            }
            catch
            {
                Console.WriteLine("ivalid add arguments");
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (var a in Args)
                s += a + " ";
            s +="\n"+ toExe.ToString();
            return s;
        }
        public void Execute()
        {
            toExe.Execute();
           
        }
    }
    public class addBookCommand:ICommand
    {

        private ICollection<IBook> books;
        [XmlArray]
        public Dictionary<string, string> ValReader;
        IBookFactory BB;
        string[] Args;
        public string Name => "book";
        public IBook added;
        private Dictionary<string, IBookFactory> bookFactory;
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            books = collection.Books;
            bookFactory = new Dictionary<string, IBookFactory>();
            bookFactory.Add("base", new BaseBookFactory());
            bookFactory.Add("secondary,", new SecondaryBookFactory());
            Args = args;
            ValReader = new Dictionary<string, string>();
            BB = bookFactory[Args[2]];
            ValReader.Add("title", "");
            ValReader.Add("year", "0");
            ValReader.Add("pageCount", "0");
            if (Meta == null)
            {
                Console.WriteLine("available fields:\"title\", \"year\", \"pageCount\"");
                
                while (true)
                {
                    string[] input = Console.ReadLine().Split("=");


                    if (input[0] == "EXIT")
                    {
                        Console.WriteLine("Book creation Aborted");

                        break;
                    }
                    else if (input[0] == "DONE")
                    {


                        break;
                    }
                    try
                    {
                        ValReader.Remove(input[0]);
                        ValReader.Add(input[0], input[1]);
                    }
                    catch
                    {
                        Console.WriteLine("invalid field name");
                    }

                }
            }
            else
            {
                string[] attributes = Meta.Split("\n");
                for (int i = 2; i < attributes.Length; i++)
                {
                    if (attributes[i].Split("=")[1].Length>0)
                        ValReader[attributes[i].Split("=")[0]] = attributes[i].Split('=')[1];
                }
            }
        }
        public override string ToString()
        {
            string s = "";
            if (ValReader.Count > 0)
            {
                s += $"title={ValReader["title"]}\n";
                s += $"pageCount={ValReader["pageCount"]}\n";
                s += $"year={ValReader["year"]}";
            }
            return s;
        }
        public void Execute()
        {
            if (ValReader.Count != 0)
            {
                added = BB.Build(ValReader["title"], int.Parse(ValReader["year"]), int.Parse(ValReader["pageCount"]), "", new List<IAuthor>());
                books.Add(added);
                Console.WriteLine(added);
                Console.WriteLine("Book created");
            }
        }

        public void Undo()
        {
            books.Delete(added);
        }
    }
    public class addAuthorCommand:ICommand
    {
        public string Name => "add author";
        string[] Args;
        IAuthor added;
        IAuthorFactory AB;
        ICollection<IAuthor> authors;
        private Dictionary<string, IAuthorFactory> authorFactory;
        Dictionary<string, string> ValReader;
        public void Undo()
        {
            authors.Delete(added);
        }
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            ValReader = new Dictionary<string, string>();
            authors = collection.Authors;
            authorFactory = new Dictionary<string, IAuthorFactory>();
            authorFactory.Add("base", new BaseAuthorFactory());
            authorFactory.Add("secondary", new SecondaryAuthorFactory());
            Args = args;
            AB = authorFactory[Args[2]];
           
            ValReader.Add("name", "");
            ValReader.Add("yearOfBirth", "0");
            ValReader.Add("surname", "");
            ValReader.Add("nickname", "");
            if (Meta == null)
            {
                Console.WriteLine("available fields:\"name\", \"surname\", \"yearOfBirth\", \"nickname\"");
                while (true)
                {
                    string[] input = Console.ReadLine().Split("=");


                    if (input[0].ToUpper() == "EXIT")
                    {
                        Console.WriteLine("Book creation Aborted");
                        ValReader.Clear();
                        break;
                    }
                    else if (input[0].ToUpper() == "DONE")
                    {
                        Console.WriteLine("author created");
                        break;
                    }
                    else
                    {
                        if (ValReader.ContainsKey(input[0]))
                        {
                            ValReader.Remove(input[0]);
                            ValReader.Add(input[0], input[1]);
                        }
                        else
                        {
                            Console.WriteLine("invalid field name");
                        }
                    }
                }
            }
            else
            {
                string[] attributes = Meta.Split("\n");
                for (int i = 2; i < attributes.Length; i++)
                {
                    if (attributes[i].Split("=")[1].Length > 0)
                        ValReader[attributes[i].Split("=")[0]] = attributes[i].Split('=')[1];
                }
            }
        }
        public override string ToString()
        {
            string s = "";
            if (ValReader.Count > 0)
            {
               
                    s += $"name={ValReader["name"]}\n";
               
                    s += $"yearOfBirth={ValReader["yearOfBirth"]}\n";
               
                    s += $"surname={ValReader["surname"]}\n";
               
                    s += $"nickname={ValReader["nickname"]}";

            }
            return s;
        }
        public void Execute()
        {
           
          if(ValReader.Count!=0)
            {
                added = AB.Build(ValReader["name"], (ValReader["surname"]), int.Parse(ValReader["yearOfBirth"]), ValReader["nickname"]);
                authors.Add(added);
            }
            
        }
    }
    public class addNewspaperCommand:ICommand
    {
        public string Name => "add newspaper";
        string[] Args;
        INewspaperFactory NB;
        INewsPaper added;
        ICollection<INewsPaper> newspapers;
        Dictionary<string, string> ValReader;
        private Dictionary<string, INewspaperFactory> newspaperFactorys;
        public void Undo()
        {
            newspapers.Delete(added);
        }
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            newspapers = collection.Newspapers;
            newspaperFactorys = new Dictionary<string, INewspaperFactory>();
            newspaperFactorys.Add("base", new baseNewspaperFactory());
            newspaperFactorys.Add("secondary", new SecondaryNewspaperFactory());
            Args = args;
            NB = newspaperFactorys[Args[2]];
            ValReader = new Dictionary<string, string>();
            ValReader.Add("title", "");
            ValReader.Add("year", "0");
            ValReader.Add("pageCount", "0");
            if (Meta == null)
            {
                Console.WriteLine("available fields:\"title\", \"year\", \"pageCount\"");

                while (true)
                {
                    string[] input = Console.ReadLine().Split("=");


                    if (input[0] == "EXIT")
                    {
                        Console.WriteLine("Book creation Aborted");
                        ValReader.Clear();
                        break;
                    }
                    else if (input[0] == "DONE")
                    {



                        Console.WriteLine("Newspaper created");
                        break;
                    }
                    try
                    {
                        ValReader.Remove(input[0]);
                        ValReader.Add(input[0], input[1]);
                    }
                    catch
                    {
                        Console.WriteLine("invalid field name");
                    }
                }
            }
            else
            {
                string[] attributes = Meta.Split("\n");
                for (int i = 2; i < attributes.Length; i++)
                {
                    if (attributes[i].Split("=")[1].Length > 0)
                        ValReader[attributes[i].Split("=")[0]] = attributes[i].Split('=')[1];
                }
            }

        }
        public override string ToString()
        {
            string s = "";
            if (ValReader.Count > 0)
            {
                    s += $"title={ValReader["title"]}\n";
                    s += $"year={ValReader["year"]}\n";
                    s += $"pageCount={ValReader["pageCount"]}";
            }
            return s;
        }
        public void Execute()
        {
            if (ValReader.Count != 0)
            {
                added = NB.Build(ValReader["title"], int.Parse(ValReader["year"]), int.Parse(ValReader["pageCount"]));
                newspapers.Add(added);
            }
        }
    }
    public class addBoardgameCommand : ICommand
    {
        public string Name => "add boardgame";
        string[] Args;
        ICollection<IBoardGame> boardgames;
        IBoardGameFactory BB;
        IBoardGame added;
        Dictionary<string, string> ValReader;
        private Dictionary<string, IBoardGameFactory> boardgamesFactory;
        public void Undo()
        {
            boardgames.Delete(added);
        }
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            Args = args;
            boardgames = collection.Boardgames;
            boardgamesFactory = new Dictionary<string, IBoardGameFactory>();
            boardgamesFactory.Add("base", new baseBoardGameFactory());
            boardgamesFactory.Add("secondary", new SecondaryBoardGameFactory());
            BB = boardgamesFactory[Args[2]];
            ValReader.Add("name", "");
            ValReader.Add("minPlayers", "0");
            ValReader.Add("maxPlayers", "0");
            ValReader.Add("difficulty", "0");
           
            ValReader = new Dictionary<string, string>();
            if (Meta == null)
            {
                Console.WriteLine("available fields:\"name\", \"minPlayers\", \"maxPlayers\", \"difficulty\"");
                while (true)
                {
                    string[] input = Console.ReadLine().Split("=");


                    if (input[0] == "EXIT")
                    {
                        Console.WriteLine("Book creation Aborted");
                        ValReader.Clear();
                        break;
                    }
                    else if (input[0] == "DONE")
                    {
                        Console.WriteLine("Boardgame created");
                        break;
                    }
                    try
                    {
                        ValReader.Remove(input[0]);
                        ValReader.Add(input[0], input[1]);
                    }
                    catch
                    {
                        Console.WriteLine("invalid field name");
                    }
                }
            }
                else
                {
                    string[] attributes = Meta.Split("\n");
                    for (int i = 2; i < attributes.Length; i++)
                    {
                        if (attributes[i].Split("=")[1].Length > 0)
                            ValReader[attributes[i].Split("=")[0]] = attributes[i].Split('=')[1];
                    }
                }

        }
        public void Execute()
        {
            if (ValReader.Count != 0)
            {
                added = BB.Build(ValReader["name"], int.Parse(ValReader["minPlayers"]), int.Parse(ValReader["maxPlayers"]), int.Parse(ValReader["difficulty"]), new List<IAuthor>());
                boardgames.Add(added);
            }
               
        }
        public override string ToString()
        {
            string s = "";
            if (ValReader.Count > 0)
            {
                s += $"name={ValReader["name"]}\n";

                s += $"minPlayers={ValReader["minPlayers"]}\n";

                s += $"maxPlayers={ValReader["maxPlayers"]}\n";

                s += $"difficulty={ValReader["difficulty"]}";
                
            }
            return s;
        }
    }
    
}
