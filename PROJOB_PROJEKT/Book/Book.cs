using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class Book : IBook
    {
        private string title;
        public string GetTitle() => title;
        private List<IAuthor> authors;
        public List<IAuthor> GetAuthorList() => authors;
        private int year;
        public int GetYear() => year;
        private int pageCount;
        private Dictionary<string, IComparable> StrToVal;
        public Dictionary<string, IComparable> Properties => StrToVal;

        public int GetPageCount() => pageCount;
        
        public Book(string title, int year, int pagecount, string genre, List<IAuthor> authors)
        {
            
            this.title = title;
            this.year = year;
            this.pageCount = pagecount;
            this.authors = authors;
            StrToVal = new Dictionary<string, IComparable>();
            StrToVal.Add("title", GetTitle());
            StrToVal.Add("year", GetYear());
            StrToVal.Add("pageCount", GetPageCount());
           
        }
        public override string ToString()
        {
            string s = $"{title} {year} {pageCount}";
            foreach (var a in authors) { s +="\n"+ a.ToString();}
            return s;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetYear(int year)
        {
            this.year = year;
        }

        public void SetPageCount(int pageCount)
        {
            this.pageCount = pageCount; 
        }
    }
}
