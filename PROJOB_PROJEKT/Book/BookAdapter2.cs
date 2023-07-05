using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BookAdapter2 : IBook
    {
        public BookAdaptee2 book;
        private Dictionary<string, IComparable> StrToVal;
        public Dictionary<string, IComparable> Properties => StrToVal;

        public BookAdapter2(BookAdaptee2 book)
        {
            this.book = book;
            StrToVal = new Dictionary<string, IComparable>();
            StrToVal.Add("title", GetTitle());
            StrToVal.Add("year", GetYear());
            StrToVal.Add("pageCount", GetPageCount());
        }

        public int GetPageCount()
        {
            int s = 0;
            foreach (var e in book.book)
            {
                if (e.Item1 == "page count")
                    s = (int)e.Item2;
            }
            return s;
        }

        public string GetTitle()
        {
            string s = "";
            foreach (var e in book.book)
            {
                if (e.Item1 == "title")
                    s = (string)e.Item2;
            }
            return s;
        }
        public List<IAuthor> GetAuthorList()
        {
            List<IAuthor> s = new List<IAuthor>();
            foreach (var e in book.book)
            {
                if (e.Item1 == "authors")
                    s = (List<IAuthor>)e.Item2;
            }
            return s;
        }
        public int GetYear()
        {
            int s = 0;
            foreach (var e in book.book)
            {
                if (e.Item1 == "year")
                    s = (int)e.Item2;
            }
            return s;
        }
        public override string ToString()
        {
            string s = $"{GetTitle()} {GetYear()} {GetPageCount()}";
            foreach (var a in GetAuthorList()) { s += "\n" + a.ToString(); }
            return s;
        }

        public void SetTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void SetYear(int year)
        {
            throw new NotImplementedException();
        }

        public void SetPageCount(int pageCount)
        {
            throw new NotImplementedException();
        }
    }
}
