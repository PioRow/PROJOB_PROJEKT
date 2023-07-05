using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace PROJOB_PROJEKT
{
    public class findCommand : ICommand
    {
        public void Undo()
        {

        }
        public string Name => "find";
        string[] Args;
        IBookstore bookstore;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, ICommandFactory> Finds;
        public void Init(string[] args,IBookstore collection, string? Meta)
        {
            Finds = new Dictionary<string, ICommandFactory>();
            bookstore = collection;
            Predicates = new Dictionary<string, Func<IComparable, IComparable, bool>>();
            Predicates.Add("=", (x, y) => x.Equals(y));
            Predicates.Add("<", (x, y) => x.CompareTo(y) < 0);
            Predicates.Add(">", (x, y) => x.CompareTo(y) > 0);
            Finds.Add("authors", new findauthorFactory());
            Finds.Add("books", new findbookFactory());
            Finds.Add("boardgames", new findBoardgameFactory());
            Finds.Add("newspapers", new findNewspaperFactory());
            if(Args==null)
                Args = args;
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
            if (Args.Length <3)
            {
                Console.WriteLine("find :invalid args nr");
            }
            else
            {
                try
                {
                    ICommandFactory Com = Finds[Args[1]];
                    Com.Make(Args,bookstore,null).Execute() ;
                    
                }
                catch 
                {
                    Console.WriteLine("invalid input(collection doesnt exist or predicate isnt supported)");
                }
            }
        }
        //private void findbooks(ICollection col, Func<IComparable, IComparable, bool> predicate, IComparable ComVal, string FieldName)
        //{
        //    try
        //    {
        //        ComVal = int.Parse((string)ComVal);
        //    }
        //    catch { }

        //    foreach (IBook book in col)
        //    {
        //        if (predicate(book.Properties[FieldName], ComVal))
        //        {
        //            Console.WriteLine(book.GetTitle() + " " + book.GetYear() + " " + book.GetYear());
        //        }
        //    }
        //}
        //private void findnewspapers(ICollection col, Func<IComparable, IComparable, bool> predicate, IComparable ComVal, string FieldName)
        //{
        //    try
        //    {
        //        ComVal = int.Parse((string)ComVal);
        //    }
        //    catch { }

        //    foreach (INewsPaper b in col)
        //    {
        //        if (predicate(b.Properties[FieldName], ComVal))
        //        {
        //            Console.WriteLine(b.GetTitle() + " " + b.GetYear() + " " + b.GetYear()); 
        //        }
        //    }
        //}
        //private void findboardgames(ICollection col, Func<IComparable, IComparable, bool> predicate, IComparable ComVal, string FieldName)
        //{
        //    try
        //    {
        //        ComVal = int.Parse((string)ComVal);
        //    }
        //    catch { }

        //    foreach (IBoardGame b in col)
        //    {
        //        if (predicate(b.Properties[FieldName], ComVal))
        //        {
        //            Console.WriteLine(b.GetName() + " " + b.GetDifficulty() + " " + b.GetMaxPlayers() + "-" + b.GetMaxPlayers());
        //        }
        //    }
        //}
    }
    public class findAuthorsCommand:ICommand
    {
        public void Undo()
        {

        }
        public string Name => "find authors";
        string[] Args;
        private ICollection<IAuthor> authors;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
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
        }
        private void FindByName(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable,IComparable,bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(authors.GetForwardIterator(), b =>
            {
                if (pred(b.GetName(), fieldname))
                {
                    string? pom = b.GetNickname() != null ? "\""+b.GetNickname()+"\"" : " ";
                    Console.WriteLine(b.GetName() + " " + b.GetSurname() + " " + b.GetYearOfBirth() + " " + pom);
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
                    string? pom = b.GetNickname() != null ? "\"" + b.GetNickname() + "\"" : " ";
                    Console.WriteLine(b.GetName() + " " + b.GetSurname() + " " + b.GetYearOfBirth() + " " + pom);
                }
            });
        }
        private void FindByNickname(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(authors.GetForwardIterator(), b =>
            {
                if (b.GetNickname()!=null&&pred(b.GetNickname(), fieldname))
                {
                    string? pom = b.GetNickname() != null ? "\"" + b.GetNickname() + "\"" : " ";
                    Console.WriteLine(b.GetName() + " " + b.GetSurname() + " " + b.GetYearOfBirth() + " " + pom);
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
                    string? pom = b.GetNickname() != null ? "\"" + b.GetNickname() + "\"" : " ";
                    Console.WriteLine(b.GetName() + " " + b.GetSurname() + " " + b.GetYearOfBirth() + " " + pom);
                }
            });
        }
    }
    public class findBooksCommand:ICommand
    {
        public void Undo()
        {

        }
        public string Name => "find books";
        string[] Args;
        private ICollection<IBook> books;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            Args = args;
            Predicates = new Dictionary<string, Func<IComparable, IComparable, bool>>();
            Predicates.Add("=", (x, y) => x.Equals(y));
            Predicates.Add("<", (x, y) => x.CompareTo(y) < 0);
            Predicates.Add(">", (x, y) => x.CompareTo(y) > 0);
            books =collection.Books;
            Fields = new Dictionary<string, Action<string[]>>();
            Fields.Add("title", FindByTitle);
            Fields.Add("year", FindbyYear);
            Fields.Add("pageCount", FindByPageCount);
        }
        public void Execute()
        {
            Action<string[]> Act = Fields[Args[2]];
            Act(Args);
        }
        private void FindByTitle(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(books.GetForwardIterator(), b =>
            {
                if (pred(b.GetTitle(), fieldname))
                {
                    Console.WriteLine(b.GetTitle() + " " + b.GetPageCount() + " " + b.GetYear());
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
                    Console.WriteLine(b.GetTitle() + " " + b.GetPageCount() + " " + b.GetYear());
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
                    Console.WriteLine(b.GetTitle() + " " + b.GetPageCount() + " " + b.GetYear());
                }
            });
        }
    }
    public class findBoardgamesCommand : ICommand
    {
        public void Undo()
        {

        }
        string[] Args;
        public string Name => "find boardgames";
        private ICollection<IBoardGame> boardgames;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
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
        }
        private void FindByMaxPlayers(string[] Args)
        {
            IComparable fieldname = int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(boardgames.GetForwardIterator(), b =>
            {
                if (pred(b.GetMaxPlayers(), fieldname))
                {
                    Console.WriteLine(b.GetName() + " " + b.GetDifficulty() + " " + b.GetMaxPlayers() + "-" + b.GetMaxPlayers());
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
                    Console.WriteLine(b.GetName() + " " + b.GetDifficulty() + " " + b.GetMaxPlayers() + "-" + b.GetMaxPlayers());
                }
            });
        }
        private void FindByDifficulty(string[] Args)
        {
            IComparable fieldname =int.Parse(Args[4]);
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(boardgames.GetForwardIterator(), b =>
            {
                if (pred(b.GetDifficulty(), fieldname))
                {
                    Console.WriteLine(b.GetName() + " " + b.GetDifficulty() + " " + b.GetMaxPlayers() + "-" + b.GetMaxPlayers());
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
                    Console.WriteLine(b.GetName() + " " + b.GetDifficulty() + " " + b.GetMaxPlayers() + "-" + b.GetMaxPlayers());
                }
            });
        }

    }
    public class findNewspapersCommand : ICommand
    {
        public void Undo()
        {

        }
        public string Name => "find books";
        string[] Args;
        private ICollection<INewsPaper> newspapers;
        private Dictionary<string, Func<IComparable, IComparable, bool>> Predicates;
        private Dictionary<string, Action<string[]>> Fields;
        public void Init(string[] args, IBookstore collection, string? Meta)
        {
            Args = args;
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
        }
        private void FindByTitle(string[] Args)
        {
            IComparable fieldname = Args[4];
            Func<IComparable, IComparable, bool> pred = Predicates[Args[3]];
            Algorithms.ForEach(newspapers.GetForwardIterator(), b =>
            {
                if (pred(b.GetTitle(), fieldname))
                {
                    Console.WriteLine(b.GetTitle() + " " + b.GetPageCount() + " " + b.GetYear());
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
                    Console.WriteLine(b.GetTitle() + " " + b.GetPageCount() + " " + b.GetYear());
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
                    Console.WriteLine(b.GetTitle() + " " + b.GetPageCount() + " " + b.GetYear());
                }
            });
        }
    }
}
