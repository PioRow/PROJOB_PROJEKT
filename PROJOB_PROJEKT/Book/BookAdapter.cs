using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BookAdapter : IBook
    {
        BookAdaptee adaptee;
        private Dictionary<string, IComparable> StrToVal;
        public Dictionary<string, IComparable> Properties => StrToVal;

        public BookAdapter(BookAdaptee adaptee)
        {
            this.adaptee = adaptee;
            StrToVal = new Dictionary<string, IComparable>();
            StrToVal.Add("title", GetTitle());
            StrToVal.Add("year", GetYear());
            StrToVal.Add("pageCount", GetPageCount());
        }
        public int GetPageCount()
        {
            string[] pom = adaptee.book.Split("(");
            string[] pom2 = pom[1].Split(")");
            return int.Parse(pom2[0]);
        }

        public string GetTitle()
        {
            string[] pom = adaptee.book.Split(';');
            return pom[0];
        }
        public int GetYear()
        {
            string[] pom = adaptee.book.Split(";");
            string[] pom2 = pom[1].Split("(");
            return int.Parse(pom2[0]);
        }
        public int[] GetAuthros()
        {
            List<int> authors = new List<int>();
            string[] s = this.adaptee.book.Split("(");
            for (int i = 2; i < s.Length; i++)
            {
                s[i] = s[i].Split(")")[0];
                authors.Add(int.Parse(s[i]));
            }
            return authors.ToArray();
        }
        public override string ToString()
        {
            string s = $"{this.GetTitle()} {this.GetYear()} {this.GetPageCount()}\n";
            foreach (var a in GetAuthorList())
                s += a.ToString() + "\n";
            return s;
        }

        public List<IAuthor> GetAuthorList()
        {
            List<IAuthor> authors = new List<IAuthor>();
            string[] s = this.adaptee.book.Split("(");
            for (int i = 2; i < s.Length; i++)
            {
                s[i] = s[i].Split(")")[0];
                authors.Add((IAuthor)AuthorsMap.Authors[int.Parse(s[i])]);
            }
            return authors;
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
