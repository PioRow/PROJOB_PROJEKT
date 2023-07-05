using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PROJOB_PROJEKT
{

    public class deleteCommand : ICommand
    {
        public string Name => "delete";
        string[] Args;
        IBookstore bookstore;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, ICommandFactory> Deletes;
        ICommand toExec;
        public void Undo()
        {
            toExec.Undo();
        }
        public void Init(string[] args, IBookstore bookstore, string? Meta)
        {
            try
            {
                this.bookstore = bookstore;
                Deletes = new Dictionary<string, ICommandFactory>();
                Deletes.Add("books", new deletebookFactory());
                Deletes.Add("authors", new deleteauthorFactory());
                Deletes.Add("newspapers", new deleteNewspaperFactory());
                Deletes.Add("boardgames", new deleteBoardGameFactory());
                if(Args==null)
                    Args = args;
                toExec = Deletes[Args[1]].Make(Args, bookstore, null);
            }
            catch
            {
                Console.WriteLine("invalid edit arguments");
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (var a in Args)
                s += a + " ";
            return s;
        }
        public void Execute()
        {
            toExec.Execute();
        }
    }
    public class deleteAuthorsCommand : ICommand
    {
        public void Undo()
        {
            authors.Add(deleted);
        }
        public string Name => "find authors";
        string[] Args;
        IAuthor deleted;
        private ICollection<IAuthor> authors;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        private List<IAuthor> authorList;
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            authorList = new List<IAuthor>();
            Fields = new Dictionary<string, Action<string[]>>();
            authors = collection.Authors;
            Fields.Add("name", FindByName);
            Fields.Add("YearOfBirth", FindByYearOfBirth);
            Fields.Add("nickname", FindByNickname);
            Fields.Add("surname", FindBySurname);
            Predicates = new Dictionary<string, Func<IComparable, IComparable, bool>>();
            Predicates.Add("=", (x, y) => x.Equals(y));
            Predicates.Add("<", (x, y) => x.CompareTo(y) < 0);
            Predicates.Add(">", (x, y) => x.CompareTo(y) > 0);
            Args = args;
        }
        public void Execute()
        {
            Action<string[]> Act = Fields[Args[2]];
            Act(Args);
            deleted = authorList.First();
             authors.Delete(deleted); 
        }
        private void FindByName(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(authors.GetForwardIterator(), b =>
            {
                if (pred(b.GetName(), fieldname))
                {
                    authorList.Add(b);
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
                    authorList.Add(b);
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
                    authorList.Add(b);
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
                    authorList.Add(b);
                }
            });
        }
    }
    public class deleteBooksCommand : ICommand
    {
        public void Undo()
        {
            books.Add(deleted);
        }
        public string Name => "find books";
        string[] Args;
        private ICollection<IBook> books;
        private List<IBook> booklist;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        IBook deleted;
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            Args = args;
            booklist = new List<IBook>();
            Predicates = new Dictionary<string, Func<IComparable, IComparable, bool>>();
            Predicates.Add("=", (x, y) => x.Equals(y));
            Predicates.Add("<", (x, y) => x.CompareTo(y) < 0);
            Predicates.Add(">", (x, y) => x.CompareTo(y) > 0);
            books = collection.Books;
            Fields = new Dictionary<string, Action<string[]>>();
            Fields.Add("title", FindByTitle);
            Fields.Add("year", FindbyYear);
            Fields.Add("pageCount", FindByPageCount);
        }
        public void Execute()
        {
            Action<string[]> Act = Fields[Args[2]];
            Act(Args);
            deleted = booklist.First();
            books.Delete(deleted);
        }
        private void FindByTitle(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(books.GetForwardIterator(), b =>
            {
                if (pred(b.GetTitle(), fieldname))
                {
                    booklist.Add(b);
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
                    booklist.Add(b);
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
                    booklist.Add(b);
                }
            });
        }
    }
    public class deleteNewspapersCommand : ICommand
    {
        public void Undo()
        {
            newspapers.Add(delted);
        }
        public string Name => "find books";
        string[] Args;
        private ICollection<INewsPaper> newspapers;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        private List<INewsPaper> newspapaerlist;
        INewsPaper delted;
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            Args = args;
            newspapaerlist = new List<INewsPaper>();
            Predicates = new Dictionary<string, Func<IComparable, IComparable, bool>>();
            Predicates.Add("=", (x, y) => x.Equals(y));
            Predicates.Add("<", (x, y) => x.CompareTo(y) < 0);
            Predicates.Add(">", (x, y) => x.CompareTo(y) > 0);
            newspapers = collection.Newspapers;
            Fields = new Dictionary<string, Action<string[]>>();
            Fields.Add("title", FindByTitle);
            Fields.Add("year", FindbyYear);
            Fields.Add("pageCount", FindByPageCount);
        }
        public void Execute()
        {
            Action<string[]> Act = Fields[Args[2]];
            Act(Args);
            delted = newspapaerlist.First();
            newspapers.Delete(delted);
        }
        private void FindByTitle(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(newspapers.GetForwardIterator(), b =>
            {
                if (pred(b.GetTitle(), fieldname))
                {
                    newspapaerlist.Add(b);
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
                    newspapaerlist.Add(b);
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
                    newspapaerlist.Add(b);
                }
            });
        }
    }
    public class deleteBoardgamesCommand : ICommand
    {
        public void Undo()
        {
            boardgames.Add(deleted);
        }
        string[] Args;
        public string Name => "find boardgames";
        private List<IBoardGame> dgl = new List<IBoardGame>();
        private ICollection<IBoardGame> boardgames;
        IBoardGame deleted;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            dgl=new List<IBoardGame>();
            boardgames = collection.Boardgames;
            Predicates = new Dictionary<string, Func<IComparable, IComparable, bool>>();
            Predicates.Add("=", (x, y) => x.Equals(y));
            Predicates.Add("<", (x, y) => x.CompareTo(y) < 0);
            Predicates.Add(">", (x, y) => x.CompareTo(y) > 0);
            Fields = new Dictionary<string, Action<string[]>>();
            Fields.Add("MaxPlayers", FindByMaxPlayers);
            Fields.Add("MinPlayers", FindByMinPlayers);
            Fields.Add("difficulty", FindByDifficulty);
            Fields.Add("name", FindByName);
            Args = args;
        }
        public void Execute()
        {
            Action<string[]> action = Fields[Args[2]];
            action(Args);
            deleted = dgl.First();
            boardgames.Delete(deleted);
        }
        private void FindByMaxPlayers(string[] Args)
        {
            IComparable fieldname = int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(boardgames.GetForwardIterator(), b =>
            {
                if (pred(b.GetMaxPlayers(), fieldname))
                {
                    dgl.Add(b);
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
                    dgl.Add(b);
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
                    dgl.Add(b);
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
                    dgl.Add(b);
                }
            });
        }
    }
 }
