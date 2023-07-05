using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Data.SqlTypes;

namespace PROJOB_PROJEKT
{
    public class Bookstore
    {
        public List<IBook> books;
        public List<INewsPaper> newspapers;
        public List<IBoardGame> boardgames;
        public List<IAuthor> authors;
        public Bookstore()
        {
            books = new List<IBook>();
            newspapers = new List<INewsPaper>();
            boardgames = new List<IBoardGame>();
            authors = new List<IAuthor>();
        }
        public void fill0()
        {

            {
                authors.Add(new Author("Douglas", "Adamns", 1952, null));//0
                authors.Add(new Author("Tom", "Wolfe", 1930, null));//1
                authors.Add(new Author("Elmar", "Eisemann", 1978, null));//2
                authors.Add(new Author("Michael", "Schwarz", 1970, null));//3
                authors.Add(new Author("Ulf", "Assarsson", 1975, null));//4
                authors.Add(new Author("Michael", "Wimmer", 1980, null));//5
                authors.Add(new Author("Frank", "Herbert", 1920, null));//6
                authors.Add(new Author("Terry", "Pratchett", 1948, null));//7
                authors.Add(new Author("Neil", "Gaiman", 1952, null));//8
                authors.Add(new Author("Jamey", "Stegmaier", 1975, null));//9
                authors.Add(new Author("Jakub", "Różalski", 1981, "Mr Werewolf"));//10
                authors.Add(new Author("Klaus", "Teuber", 1952, null));//11
                authors.Add(new Author("Alfred", "Butts", 1899, null));//12
                authors.Add(new Author("James", "Brunot", 1902, null));//13
                authors.Add(new Author("Christian T.", "Petersen", 1970, null));//14
            }

            this.books.Add(new Book("The Hitchhiker's Guide to the Galaxy", 1987, 320, "science fiction", new List<IAuthor>() { authors[0] }));
            this.books.Add(new Book("Real-Time Shadows", 1993, 512, "journalism", new List<IAuthor>() { authors[1] }));
            this.books.Add(new Book("The Right Stuff", 2011, 383, "scientific", new List<IAuthor>() { authors[2], authors[3], authors[4], authors[5] }));
            this.books.Add(new Book("Mesjasz Diuny", 1972, 272, "scientific", new List<IAuthor>() { authors[6], authors[7] }));
            this.books.Add(new Book("Dobry Omen", 1990, 416, "fantasy", new List<IAuthor>() { authors[8], authors[9] }));
            this.newspapers.Add(new NewsPaper("International Journal of Human - Computer Studies", 2023, 300));
            this.newspapers.Add(new NewsPaper("Nature", 1869, 200));
            this.newspapers.Add(new NewsPaper("National Geographic", 2001, 106));
            this.newspapers.Add(new NewsPaper("Pixel.", 2015, 115));
            this.boardgames.Add(new BoardGame("Scythe", 1, 5, 7, new List<IAuthor>() { authors[10], authors[11] }));
            this.boardgames.Add(new BoardGame("Catan", 3, 4, 6, new List<IAuthor>() { authors[12], authors[13] }));
            this.boardgames.Add(new BoardGame("Twilight Imperium", 3, 8, 9, new List<IAuthor> { authors[14] }));
        }
        public void fill2()
        {

            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Douglas", "Adamns", 1952, null)));//0
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Tom", "Wolfe", 1930, null)));//1
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Elmar", "Eisemann", 1978, null)));//2
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Michael", "Schwarz", 1970, null)));//3
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Ulf", "Assarsson", 1975, null)));//4
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Michael", "Wimmer", 1980, null)));//5
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Frank", "Herbert", 1920, null)));//6
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Terry", "Pratchett", 1948, null)));//7
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Neil", "Gaiman", 1952, null)));//8
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Jamey", "Stegmaier", 1975, null)));//9
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Jakub", "Różalski", 1981, "Mr Werewolf")));//10
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Klaus", "Teuber", 1952, null)));//11
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Alfred", "Butts", 1899, null)));//12
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("James", "Brunot", 1902, null)));//13
            authors.Add(new AuthorAdapter2(new AuthorAdaptee2("Christian T.", "Petersen", 1970, null)));//14           


            this.books.Add(new BookAdapter2(new BookAdaptee2("The Hitchhiker's Guide to the Galaxy", 1987, 320, "science fiction", new List<IAuthor>() { authors[0] })));
            this.books.Add(new BookAdapter2(new BookAdaptee2("Real-Time Shadows", 1993, 512, "journalism", new List<IAuthor>() { authors[1] })));
            this.books.Add(new BookAdapter2(new BookAdaptee2("The Right Stuff", 2011, 383, "scientific", new List<IAuthor>() { authors[2], authors[3], authors[4], authors[5] })));
            this.books.Add(new BookAdapter2(new BookAdaptee2("The Right Stuff", 2011, 383, "scientific", new List<IAuthor>() { authors[6], authors[7] })));
            this.books.Add(new BookAdapter2(new BookAdaptee2("Dobry Omen", 1990, 416, "fantasy", new List<IAuthor>() { authors[8], authors[9] })));
            this.newspapers.Add(new NewsPaperAdapter2(new NewsPaperAdaptee2("International Journal of Human - Computer Studies", 2023, 300)));
            this.newspapers.Add(new NewsPaperAdapter2(new NewsPaperAdaptee2("Nature", 1869, 200)));
            this.newspapers.Add(new NewsPaperAdapter2(new NewsPaperAdaptee2("National Geographic", 2001, 106)));
            this.newspapers.Add(new NewsPaperAdapter2(new NewsPaperAdaptee2("Pixel.", 2015, 115)));
            this.boardgames.Add(new BoardGameAdapter2(new BoardGameAdaptee2("Scythe", 1, 5, 7, new List<IAuthor>() { authors[10], authors[11] })));
            this.boardgames.Add(new BoardGameAdapter2(new BoardGameAdaptee2("Catan", 3, 4, 6, new List<IAuthor>() { authors[12], authors[13] })));
            this.boardgames.Add((new BoardGameAdapter2(new BoardGameAdaptee2("Twilight Imperium", 3, 8, 9, new List<IAuthor> { authors[14] }))));
        }
        public void printAll1()
        {
            foreach (var book in books) { Console.WriteLine(book); Console.WriteLine(); }
            foreach (var magazine in newspapers) { Console.WriteLine(magazine); Console.WriteLine(); }
            foreach (var board in boardgames) { Console.WriteLine(board); Console.WriteLine(); }
        }
        public void printif()
        {
            foreach (var book in books)
            {
                bool cond = false;
                foreach (var a in book.GetAuthorList())
                {
                    if (a.GetYearOfBirth() > 1970)
                        cond = true;
                }
                if (cond)
                {
                    Console.WriteLine(book);
                    Console.WriteLine();
                }
            }
            foreach (var board in boardgames)
            {
                bool cond = false;
                foreach (var a in board.GetAuthorList())
                {
                    if (a.GetYearOfBirth() > 1970)
                        cond = true;
                }
                if (cond)
                {
                    Console.WriteLine(board);
                    Console.WriteLine();
                }
            }
        }
        public void fill1()
        {
            this.books.Add(new BookAdapter(new BookAdaptee("The Hitchhiker's Guide to the Galaxy", 1987, 320, "science fiction", new List<IAuthor>()
            { AuthorsMap.Authors[AuthorsMap.hashes[0]] })));
            this.books.Add(new BookAdapter(new BookAdaptee("Real-Time Shadows", 1993, 512, "journalism", new List<IAuthor>()
            { AuthorsMap.Authors[AuthorsMap.hashes[1]] })));
            this.books.Add(new BookAdapter(new BookAdaptee("The Right Stuff", 2011, 383, "scientific", new List<IAuthor>()
            { AuthorsMap.Authors[AuthorsMap.hashes[2]], AuthorsMap.Authors[AuthorsMap.hashes[3]], AuthorsMap.Authors[AuthorsMap.hashes[4]], AuthorsMap.Authors[AuthorsMap.hashes[5]] })));
            this.books.Add(new BookAdapter(new BookAdaptee("The Right Stuff", 2011, 383, "scientific", new List<IAuthor>()
            { AuthorsMap.Authors[AuthorsMap.hashes[6]],AuthorsMap.Authors[AuthorsMap.hashes[7]] })));
            this.books.Add(new BookAdapter(new BookAdaptee("Dobry Omen", 1990, 416, "fantasy", new List<IAuthor>()
            { AuthorsMap.Authors[AuthorsMap.hashes[8]],AuthorsMap.Authors[AuthorsMap.hashes[9]] })));
            this.newspapers.Add(new NewsPaperAdapter(new NewsPaperAdaptee("International Journal of Human - Computer Studies", 2023, 300)));
            this.newspapers.Add(new NewsPaperAdapter(new NewsPaperAdaptee("Nature", 1869, 200)));
            this.newspapers.Add(new NewsPaperAdapter(new NewsPaperAdaptee("National Geographic", 2001, 106)));
            this.newspapers.Add(new NewsPaperAdapter(new NewsPaperAdaptee("Pixel.", 2015, 115)));
            this.boardgames.Add(new BoardGameAdapter(new BoardGameAdaptee("Scythe", 1, 5, 7, new List<IAuthor>()
            { AuthorsMap.Authors[AuthorsMap.hashes[10]],AuthorsMap.Authors[AuthorsMap.hashes[11]] })));
            this.boardgames.Add(new BoardGameAdapter(new BoardGameAdaptee("Catan", 3, 4, 6, new List<IAuthor>()
            { AuthorsMap.Authors[AuthorsMap.hashes[12]],AuthorsMap.Authors[AuthorsMap.hashes[13]] })));
            this.boardgames.Add(new BoardGameAdapter(new BoardGameAdaptee("Twilight Imperium", 3, 8, 9, new List<IAuthor>()
            { AuthorsMap.Authors[AuthorsMap.hashes[14]] })));
        }
        public void AuthorFillCollection(ICollection<IAuthor> coll)
        {
            foreach (var b in authors)
                coll.Add(b);
        }
        public void BookFillCollection(ICollection<IBook> coll)
        {
            foreach (var b in books)
                coll.Add(b);
        }
        public void BoardGameFillCollection(ICollection<IBoardGame> coll)
        {
            foreach (var b in boardgames)
                coll.Add(b);
        }
        public void NewspaperFillCollection(ICollection<INewsPaper> coll)
        {
            foreach (var b in newspapers)
                coll.Add(b);
        }
        public static void PrintIfCollection<T>(ICollection<T> col, Func<T, bool> F, bool fromStart)
        {
            Iiterator<T> it;
            if (fromStart)
                it = col.GetForwardIterator();
            else
                it = col.GetBackwardIterator();
            while (it.next() != null)
            {
                if (F(it.value()))
                {
                    Console.WriteLine(it.value());
                    Console.WriteLine();
                }
            }
        }
        public static T? FindIfCollection<T>(ICollection<T> col, Func<T, bool> F, bool fromStart)
        {
            Iiterator<T> it;
            if (fromStart)
                it = col.GetForwardIterator();
            else
                it = col.GetBackwardIterator();
            while (it.next() != null)
            {
                if (F(it.value()))
                {
                    return it.value();
                }
            }
            return default(T);
        }
    }
    public interface IBookstore
    {
        public ICollection<IAuthor> Authors { get; }
        public ICollection<IBook> Books { get; }
        public ICollection<IBoardGame> Boardgames { get; }
        public ICollection<INewsPaper> Newspapers { get; }
    }
    public class SortedArraysBookstore:IBookstore
    {
        private SortedArray<IBook> books;
        private SortedArray<IAuthor> authors;
        private SortedArray<INewsPaper> newspapers;
        private SortedArray<IBoardGame> boardgames;
        public SortedArraysBookstore()
        {
            books = new SortedArray<IBook>((x, y) =>
             {
                 if (x.GetHashCode() < y.GetHashCode()) return 1;
                 if (x.GetHashCode() > y.GetHashCode()) return -1;
                 return 0;
             });
            authors = new SortedArray<IAuthor>((x, y) =>
             {
                 if (x.GetHashCode() < y.GetHashCode()) return 1;
                 if (x.GetHashCode() > y.GetHashCode()) return -1;
                 return 0;
             });
            newspapers = new SortedArray<INewsPaper>((x, y) =>
             {
                 if (x.GetHashCode() < y.GetHashCode()) return 1;
                 if (x.GetHashCode() > y.GetHashCode()) return -1;
                 return 0;
             });
            boardgames = new SortedArray<IBoardGame>((x, y) =>
            {
                if (x.GetHashCode() < y.GetHashCode()) return 1;
                if (x.GetHashCode() > y.GetHashCode()) return -1;
                return 0;
            });
        }

        public ICollection<IAuthor> Authors => authors;

        public ICollection<IBook> Books => books;

        public ICollection<IBoardGame> Boardgames => boardgames;

        public ICollection<INewsPaper> Newspapers => newspapers;

        public void fill(Bookstore bookstore)
        {
            foreach (var b in bookstore.books)
            {
                books.Add(b);
            }
            foreach (var b in bookstore.authors)
            {
                authors.Add(b);
            }
            foreach (var b in bookstore.newspapers)
            {
                newspapers.Add(b);
            }
            foreach (var b in bookstore.boardgames)
            {
                boardgames.Add(b);
            }
        }
    }
        public static class AuthorsMap
        {
            public static Dictionary<int, IAuthor> Authors;
            public static List<int> hashes;
            static AuthorsMap()
            {
                hashes = new List<int>();
                Authors = new Dictionary<int, IAuthor>();
                {
                    var e = new AuthorAdapter(new AuthorAdaptee("Douglas", "Adamns", 1952, null));
                    Authors.Add(e.GetHashCode(), e); //0
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Tom", "Wolfe", 1930, null));
                    Authors.Add(e.GetHashCode(), e);//1
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Elmar", "Eisemann", 1978, null));
                    Authors.Add(e.GetHashCode(), e);//2
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Michael", "Schwarz", 1970, null));
                    Authors.Add(e.GetHashCode(), e);//3
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Ulf", "Assarsson", 1975, null));
                    Authors.Add(e.GetHashCode(), e);//4
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Michael", "Wimmer", 1980, null));
                    Authors.Add(e.GetHashCode(), e);//5
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Frank", "Herbert", 1920, null));
                    Authors.Add(e.GetHashCode(), e);//6
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Terry", "Pratchett", 1948, null));
                    Authors.Add(e.GetHashCode(), e);//7
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Neil", "Gaiman", 1952, null));
                    Authors.Add(e.GetHashCode(), e);//8
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Jamey", "Stegmaier", 1975, null));
                    Authors.Add(e.GetHashCode(), e);//9
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Jakub", "Różalski", 1981, "Mr Werewolf"));
                    Authors.Add(e.GetHashCode(), e);//10
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Klaus", "Teuber", 1952, null));
                    Authors.Add(e.GetHashCode(), e);//11
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Alfred", "Butts", 1899, null));
                    Authors.Add(e.GetHashCode(), e);//12
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("James", "Brunot", 1902, null));
                    Authors.Add(e.GetHashCode(), e);//13
                    hashes.Add(e.GetHashCode());
                    e = new AuthorAdapter(new AuthorAdaptee("Christian T.", "Petersen", 1970, null));
                    Authors.Add(e.GetHashCode(), e);//14
                    hashes.Add(e.GetHashCode());
                }
            }
        }
    
}
