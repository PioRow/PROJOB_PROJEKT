using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PROJOB_PROJEKT
{
    public class editCommand : ICommand
    {
        IBookstore bookstore;
        public void Undo()
        {
            toExec.Undo();
        }
        [XmlArray]
        public string[] Args;
        public string Name => "edit";
        [XmlElement]
        public ICommand toExec;
        private Dictionary<string, ICommandFactory> editors;
        public editCommand() { }
        public void Init(string[] args,IBookstore bookstore, string? Meta)
        {
            try
            {
                this.bookstore = bookstore;
                editors = new Dictionary<string, ICommandFactory>();
                editors.Add("books", new editbookFactory());
                editors.Add("authors", new editAuthorFactory());
                editors.Add("newspapers", new editNewspaperFactory());
                editors.Add("boardgames", new editBoardgameFactory());
                Args = args;
                toExec = editors[Args[1]].Make(Args, bookstore, Meta);
            }
            catch
            {
                Console.WriteLine("invalid edit arguments");
            }
        }

        public void Execute()
        {
            toExec.Execute();
        }
        public override string ToString()
        {
            string s = "";
            foreach (var a in Args)
                s += a + " ";
            s += "\n" + toExec.ToString();
            return s;

        }
    }
  
    public class editBooksCommand:  ICommand
    {
        public void Undo()
        {
            edited.SetTitle(oldT);
            edited.SetYear(oldY);
            edited.SetPageCount(oldPC);
        }
        private ICollection<IBook> books;
        [XmlArray]
        string[] Args;
        IBook edited;
        string oldT;
        int oldY;
        int oldPC;
        [XmlArray]
        public Dictionary<string, string?> ValReader;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        private List<IBook> matching;
        public void Init( string[] args, IBookstore collection, string? Meta)
        {
            matching = new List<IBook>();
            ValReader = new Dictionary<string, string?>();
            ValReader.Add("title", null);
            ValReader.Add("year", null);
            ValReader.Add("pageCount", null);
            Predicates = new Dictionary<string, Func<IComparable, IComparable, bool>>();
            Predicates.Add("=", (x, y) => x.Equals(y));
            Predicates.Add("<", (x, y) => x.CompareTo(y) < 0);
            Predicates.Add(">", (x, y) => x.CompareTo(y) > 0);
            books = collection.Books;
            Fields = new Dictionary<string, Action<string[]>>();
            Fields.Add("title", FindByTitle);
            Fields.Add("year", FindbyYear);
            Fields.Add("pageCount", FindByPageCount);
            Args = args;
            Action<string[]> Act = Fields[Args[2]];
            Act(Args);
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
                    if (attributes[i].Split("=")[0]=="title"|| attributes[i].Split("=")[0] == "pageCount" || attributes[i].Split("=")[0] == "year")
                        ValReader[attributes[i].Split("=")[0]] = attributes[i].Split('=')[1];
                }
            }
        }
        public string Name => "book";
        public override string ToString()
        {
            string s = "";
            if (ValReader.Count > 0)
            {
                if (ValReader["title"] != null)
                    s += $"title={ValReader["title"]}\n";
                if (ValReader["pageCount"] != null)
                    s += $"pageCount={ValReader["pageCount"]}\n";
                if (ValReader["year"] != null)
                    s += $"year={ValReader["year"]}";
               
            }
            return s;
        }
        public void Execute()
        {
            if (ValReader.Count > 0)
            {
                edited = matching.First();
                oldPC = edited.GetPageCount();
                oldY = edited.GetYear();
                oldT = edited.GetTitle();
                    try
                    {
                        if (ValReader["title"] != null)
                        edited.SetTitle(ValReader["title"]);
                        if (ValReader["pageCount"] != null)
                        edited.SetPageCount(int.Parse(ValReader["pageCount"]));
                        if (ValReader["year"] != null)
                        edited.SetYear(int.Parse(ValReader["year"]));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                
            }
        }
        private void FindByTitle(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(books.GetForwardIterator(), b =>
            {
                if (pred(b.GetTitle(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
        private void FindByPageCount(string[] Args)
        {
            IComparable fieldname = int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(books.GetForwardIterator(), b =>
            {
                if (pred(b.GetPageCount(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
        private void FindbyYear(string[] Args)
        {
            IComparable fieldname = int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(books.GetForwardIterator(), b =>
            {
                if (pred(b.GetYear(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
    }
    public class editAuthorCommand : ICommand
    {
        public void Undo()
        {
            edited.SetSurname(oldS);
            edited.SetNickname(oldNN);
            edited.SetName(oldN);
            edited.SetYearOfBirth(oldY);
        }
        IAuthor edited;
        string oldN, oldS;
        string? oldNN;
        int oldY;
        public string Name => "authors";
        private ICollection<IAuthor> authors;
        string[] Args;
        [XmlArray]
        Dictionary<string, string?> ValReader;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        private List<IAuthor> matching;
        public void Init(string[] args,IBookstore bookstore, string? Meta)
        {
            Fields = new Dictionary<string, Action<string[]>>();
            matching=new List<IAuthor>();
            authors = bookstore.Authors;
            Fields.Add("name", FindByName);
            Fields.Add("YearOfBirth", FindByYearOfBirth);
            Fields.Add("nickname", FindByNickname);
            Fields.Add("surname", FindBySurname);
            Predicates = new Dictionary<string, Func<IComparable, IComparable, bool>>();
            Predicates.Add("=", (x, y) => x.Equals(y));
            Predicates.Add("<", (x, y) => x.CompareTo(y) < 0);
            Predicates.Add(">", (x, y) => x.CompareTo(y) > 0);
            Args = args;
            Action<string[]> Act = Fields[Args[2]];
            Act(Args);
            ValReader = new Dictionary<string, string?>();
            ValReader.Add("name", null);
            ValReader.Add("yearOfBirth", null);
            ValReader.Add("surname", null);
            ValReader.Add("nickname", null);
            if (Meta == null)
            {
                Console.WriteLine("available fields:\"name\", \"surname\", \"yearOfBirth\", \"nickname\"");
              
                while (true)
                {
                    string[] input = Console.ReadLine().Split("=");


                    if (input[0].ToUpper() == "EXIT")
                    {
                        Console.WriteLine("author edition Aborted");
                        ValReader.Clear();
                        break;
                    }
                    else if (input[0].ToUpper() == "DONE")
                    {
                        Console.WriteLine("author edition finialized");
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
                    if (attributes[i].Split("=")[0]=="name"|| attributes[i].Split("=")[0] == "surname" || attributes[i].Split("=")[0] == "yearOfBirth" ||
                        attributes[i].Split("=")[0] == "nickname")
                        ValReader[attributes[i].Split("=")[0]] = attributes[i].Split('=')[1];
                }
            }

        }
        public override string ToString()
        {
            string s = "";
            if (ValReader.Count > 0)
            {
                if (ValReader["name"] != null)
                    s += $"name={ValReader["name"]}\n";
                if (ValReader["yearOfBirth"] != null)
                    s += $"yearOfBirth={ValReader["yearOfBirth"]}\n";
                if (ValReader["surname"] != null)
                    s += $"surname={ValReader["surname"]}\n";
                if (ValReader["nickname"] != null)
                    s += $"nickname={ValReader["nickname"]}";

            }
            return s;
        }
        private void FindByName(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(authors.GetForwardIterator(), b =>
            {
                if (pred(b.GetName(), fieldname))
                {
                   matching.Add(b);
                }
            });
        }
        private void FindBySurname(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(authors.GetForwardIterator(), b =>
            {
                if (pred(b.GetSurname(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
        private void FindByNickname(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(authors.GetForwardIterator(), b =>
            {
                if (b.GetNickname() != null && pred(b.GetNickname(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
        private void FindByYearOfBirth(string[] Args)
        {
            IComparable fieldname = int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(authors.GetForwardIterator(), b =>
            {
                if (pred(b.GetYearOfBirth(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
        public void Execute()
        {
            if (ValReader.Count != 0)
            {
                edited = matching.First();
                oldN = edited.GetName();
                oldS = edited.GetSurname();
                oldNN = edited.GetNickname();
                oldY = edited.GetYearOfBirth();
                    if (ValReader["name"] != null)
                    edited.SetName(ValReader["name"]);
                    if (ValReader["surname"] != null)
                    edited.SetSurname(ValReader["surname"]);
                    if (ValReader["nickname"]!=null)
                    edited.SetNickname(ValReader["surname"]);
                    if (ValReader["yearOfBirth"] != null)
                    edited.SetYearOfBirth(int.Parse(ValReader["yearOfBirth"]));
                
               
            }
        }
    }
    public class editNewspaperCommand:ICommand
    {

        public void Undo()
        {
            edited.SetTitle(oldT);
            edited.SetPageCount(oldPC);
            edited.SetYear(oldY);
        }
        private ICollection<INewsPaper> newspapers;
        [XmlArray]
        INewsPaper edited;
        int oldY;
        int oldPC;
        string oldT;
        Dictionary<string, string?> ValReader;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        string[] Args;
        List<INewsPaper> matching;
        public void Init(string[] args,IBookstore collection, string? Meta)
        {
            ValReader = new Dictionary<string, string?>();
            Args = args;
            Predicates = new Dictionary<string, Func<IComparable, IComparable, bool>>();
            Predicates.Add("=", (x, y) => x.Equals(y));
            Predicates.Add("<", (x, y) => x.CompareTo(y) < 0);
            Predicates.Add(">", (x, y) => x.CompareTo(y) > 0);
            newspapers = collection.Newspapers;
            matching = new List<INewsPaper>();
            Fields = new Dictionary<string, Action<string[]>>();
            Fields.Add("title", FindByTitle);
            Fields.Add("year", FindbyYear);
            Fields.Add("pageCount", FindByPageCount);
            Action<string[]> Act = Fields[Args[2]];
            Act(Args);
            ValReader.Add("title", null);
            ValReader.Add("year", null);
            ValReader.Add("pageCount", null);
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
                    if (attributes[i].Split("=")[0] == "title" || attributes[i].Split("=")[0] == "year" || attributes[i].Split("=")[0] == "pageCount")
                        ValReader[attributes[i].Split("=")[0]] = attributes[i].Split('=')[1];
                }
            }

        }
        public override string ToString()
        {
            string s = "";
            if (ValReader.Count > 0)
            {
                if (ValReader["title"] != null)
                    s += $"title={ValReader["title"]}\n";
                if (ValReader["year"] != null)
                    s += $"year={ValReader["year"]}\n";
                if (ValReader["pageCount"] != null)
                    s += $"pageCount={ValReader["pageCount"]}";
            }
            return s;
        }
        public string Name => "newspapers";
        public void Execute()
        {
            if(ValReader.Count!=0)
            {
                edited = matching.First();
                oldPC = edited.GetPageCount();
                oldT = edited.GetTitle();
                oldY = edited.GetYear();
                    if (ValReader["title"] != null)
                    edited.SetTitle(ValReader["title"]);
                    if (ValReader["pageCount"] != null)
                    edited.SetPageCount(int.Parse(ValReader["pageCount"]));
                    if (ValReader["year"] != null)
                    edited.SetYear(int.Parse(ValReader["year"]));
                
            }
        }
        private void FindByTitle(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(newspapers.GetForwardIterator(), b =>
            {
                if (pred(b.GetTitle(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
        private void FindByPageCount(string[] Args)
        {
            IComparable fieldname = int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(newspapers.GetForwardIterator(), b =>
            {
                if (pred(b.GetPageCount(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
        private void FindbyYear(string[] Args)
        {
            IComparable fieldname = int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(newspapers.GetForwardIterator(), b =>
            {
                if (pred(b.GetYear(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
    }
    public class editBoardgameCommand : ICommand
    {
        public void Undo()
        {
            edited.SetMinPlayers(oldMi);
            edited.SetMaxPlayers(oldMa);
            edited.SetDifficulty(oldD);
            edited.SetName(oldN);
        }
        int oldMa, oldMi, oldD;
        string oldN;
        private ICollection<IBoardGame> boardgames;
        string[] Args;
        [XmlArray]
        Dictionary<string, string?> ValReader;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        private List<IBoardGame> matching;
        public string Name => "boardgames";
        IBoardGame edited;
        public void Init(string[] Args,IBookstore collection, string? Meta)
        {
            matching = new List<IBoardGame>();
            boardgames = collection.Boardgames;
            Predicates = new Dictionary<string, Func<IComparable, IComparable, bool>>();
            this.Args = Args;
            ValReader = new Dictionary<string, string?>();
            Predicates.Add("=", (x, y) => x.Equals(y));
            Predicates.Add("<", (x, y) => x.CompareTo(y) < 0);
            Predicates.Add(">", (x, y) => x.CompareTo(y) > 0);
            Fields = new Dictionary<string, Action<string[]>>();
            Fields.Add("MaxPlayers", FindByMaxPlayers);
            Fields.Add("MinPlayers", FindByMinPlayers);
            Fields.Add("difficulty", FindByDifficulty);
            Fields.Add("name", FindByName);
            
            Action<string[]> action = Fields[Args[2]];
            action(Args);
            ValReader.Add("name", null);
            ValReader.Add("minPlayers", null);
            ValReader.Add("maxPlayers", null);
            ValReader.Add("difficulty", null);
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
                    if (attributes[i].Split("=")[0] == "name" || attributes[i].Split("=")[0] == "minPlayers" || attributes[i].Split("=")[0] == "maxPlayers"
                         || attributes[i].Split("=")[0] == "difficulty")
                        ValReader[attributes[i].Split("=")[0]] = attributes[i].Split('=')[1];
                }
            }

        }
        public override string ToString()
        {
            string s = "";
            if (ValReader.Count > 0)
            {
                if (ValReader["name"] != null)
                    s += $"name={ValReader["name"]}\n";
                if (ValReader["minPlayers"] != null)
                    s += $"minPlayers={ValReader["minPlayers"]}\n";
                if (ValReader["maxPlayers"] != null)
                    s += $"maxPlayers={ValReader["maxPlayers"]}\n";
                if (ValReader["difficulty"] != null)
                    s += $"difficulty={ValReader["difficulty"]}";
            }
            return s;
        }
        private void FindByMaxPlayers(string[] Args)
        {
            IComparable fieldname = int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(boardgames.GetForwardIterator(), b =>
            {
                if (pred(b.GetMaxPlayers(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
        private void FindByMinPlayers(string[] Args)
        {
            IComparable fieldname = int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(boardgames.GetForwardIterator(), b =>
            {
                if (pred(b.GetMinPlayers(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
        private void FindByDifficulty(string[] Args)
        {
            IComparable fieldname = int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(boardgames.GetForwardIterator(), b =>
            {
                if (pred(b.GetDifficulty(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }
        private void FindByName(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(boardgames.GetForwardIterator(), b =>
            {
                if (pred(b.GetName(), fieldname))
                {
                    matching.Add(b);
                }
            });
        }

        public void Execute()
        {
            if(ValReader.Count != 0)
            {
                edited = matching.First();
                oldMi = edited.GetMinPlayers();
                oldMa = edited.GetMaxPlayers();
                oldD = edited.GetDifficulty();
                oldN = edited.GetName();
                if (ValReader["name"]!=null)
                    edited.SetName(ValReader["name"]);
                    if (ValReader["minPlayers"] != null)
                    edited.SetMinPlayers(int.Parse(ValReader["minPlayers"]));
                    if (ValReader["maxPlayers"] != null)
                    edited.SetMaxPlayers(int.Parse(ValReader["maxPlayers"]));
                    if (ValReader["difficulty"] != null)
                    edited.SetDifficulty(int.Parse(ValReader["difficulty"]));
                
            }
        }
    }


}
