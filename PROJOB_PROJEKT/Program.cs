//using PROJOB_PROJEKT;
using System.Runtime.InteropServices;

namespace PROJOB_PROJEKT
{
    public class Program
    {
        public static void Main()
        {
            {
                //Console.WriteLine("--------------------------PART 1------------------------------");
                //Bookstore bookstore = new Bookstore();
                //Bookstore bookstore1 = new Bookstore();
                //Bookstore bookstore2 = new Bookstore();
                //bookstore.fill0();
                //bookstore1.fill1();
                //bookstore2.fill2();
                //bookstore.printif();
                //Console.WriteLine("--------------------------------------------------------------");
                //bookstore1.printif();
                //Console.WriteLine("--------------------------------------------------------------");
                //bookstore2.printif();
                //Console.WriteLine("-----------------------PART 2---------------------------------");
                ////Vector Section
                //{
                //    Console.WriteLine("----------------------PRINTIF VECTOR FORWARD------------------");

                //    Vector<IBoardGame> boardgames = new Vector<IBoardGame>();
                //    Vector<IBook> books = new Vector<IBook>();
                //    bookstore2.BookFillCollection(books);
                //    bookstore2.BoardGameFillCollection(boardgames);
                //    Bookstore.PrintIfCollection(books, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, true);
                //    Bookstore.PrintIfCollection(boardgames, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, true);
                //    Console.WriteLine("-------------------PRINTIF VECTOR BACKRWARD------------------");
                //    Bookstore.PrintIfCollection(boardgames, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, false);
                //    Bookstore.PrintIfCollection(books, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, false);
                //    Console.WriteLine("-------------------FINDIF VECTOR FORWARD-----------------------");

                //    var found = Bookstore.FindIfCollection(books, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, true);
                //    Console.WriteLine(found);
                //    var found2 = Bookstore.FindIfCollection(boardgames, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, true);
                //    Console.WriteLine(found2);
                //    Console.WriteLine("---------------------FINDIF VECTOR BACKWARD----------------------");
                //    found = Bookstore.FindIfCollection(books, b =>
                //   {
                //       foreach (var a in b.GetAuthorList())
                //           if (a.GetYearOfBirth() > 1970)
                //               return true;
                //       return false;
                //   }, false);
                //    Console.WriteLine(found);
                //    found2 = Bookstore.FindIfCollection(boardgames, b =>
                //   {
                //       foreach (var a in b.GetAuthorList())
                //           if (a.GetYearOfBirth() > 1970)
                //               return true;
                //       return false;
                //   }, false);
                //    Console.WriteLine(found2);
                //}
                ////LList Section
                //{
                //    Console.WriteLine("----------------------PRINTIF LLIST FORWARD------------------");
                //    LList<IBook> Lbooks = new LList<IBook>();
                //    LList<IBoardGame> Lboardgames = new LList<IBoardGame>();
                //    bookstore1.BookFillCollection(Lbooks);
                //    bookstore1.BoardGameFillCollection(Lboardgames);
                //    LList<IBook>.Node p = Lbooks.head;

                //    Console.WriteLine("-----------------------");
                //    Bookstore.PrintIfCollection(Lbooks, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, true);
                //    Bookstore.PrintIfCollection(Lboardgames, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, true);
                //    Console.WriteLine("-------------------PRINTIF LLIST BACKRWARD------------------");
                //    Bookstore.PrintIfCollection(Lboardgames, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, false);
                //    Bookstore.PrintIfCollection(Lbooks, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, false);
                //    Console.WriteLine("-------------------FINDIF LLIST FORWARD-----------------------");

                //    var found = Bookstore.FindIfCollection(Lbooks, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, true);
                //    Console.WriteLine(found);
                //    var found2 = Bookstore.FindIfCollection(Lboardgames, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, true);
                //    Console.WriteLine(found2);
                //    Console.WriteLine("---------------------FINDIF LLIST BACKWARD----------------------");
                //    found = Bookstore.FindIfCollection(Lbooks, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, false);
                //    Console.WriteLine(found);
                //    found2 = Bookstore.FindIfCollection(Lboardgames, b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    }, false);
                //    Console.WriteLine(found2);
                //}
                //Console.WriteLine("-----------------------PART 3---------------------------------");
                ////sorted list
                //{
                //    SortedArray<IBook> Sa = new SortedArray<IBook>((x, y) =>
                //    {
                //        if (x.GetHashCode() < y.GetHashCode()) return 1;
                //        if (x.GetHashCode() > y.GetHashCode()) return -1;
                //        return 0;
                //    });
                //    foreach (var b in bookstore2.books)
                //    {
                //        Sa.Add(b);
                //    }
                //    int i = Algorithms.CountIf(Sa.GetForwardIterator(), b =>
                //    {
                //        foreach (var a in b.GetAuthorList())
                //            if (a.GetYearOfBirth() > 1970)
                //                return true;
                //        return false;
                //    });
                //    Console.WriteLine(i);
                //    Algorithms.ForEach(Sa.GetForwardIterator(), b => Console.WriteLine(b + "\n"));
                //}
                ////BST
                //{
                //    Console.WriteLine("-----------------------BST------------------------------------");
                //    BST<IBook> bookT = new BST<IBook>();
                //    foreach (var b in bookstore1.books)
                //        bookT.Add(b);
                //    Console.WriteLine("-----------------------BST IN ORDER-----------------------------");
                //    Algorithms.ForEach(bookT.GetForwardIterator(), b => Console.WriteLine(b + "\n"));
                //    Console.WriteLine("-----------------------BST RIN ORDER----------------------------");
                //    Algorithms.ForEach(bookT.GetBackwardIterator(), b => Console.WriteLine(b + "\n"));
                //}
                //Console.WriteLine("-----------------------PART 4---------------------------------");
                ////filling collections
                ///
            }
            Bookstore bookstore = new Bookstore();
            bookstore.fill0();
            SortedArraysBookstore bs = new SortedArraysBookstore();
            bs.fill(bookstore);
            CLI.Run(bs);
        }
        
    }
}