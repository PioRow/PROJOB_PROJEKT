using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class NewsPaper : INewsPaper
    {
        private string title;
        public string GetTitle() => title;
        public void SetTitle(string title) { this.title = title; }
        private int year;
        public int GetYear() => year;
        public void SetYear(int y) { year = y; }
        private int pageCount;
        public int GetPageCount() => pageCount;
        public void SetPageCount(int pc) { pageCount=pc; }

        private Dictionary<string, IComparable> StrToVal;
        public Dictionary<string, IComparable> Properties => StrToVal;
        public NewsPaper(string title, int year, int pageCount)
        {
            this.title = title;
            this.year = year;
            this.pageCount = pageCount;
            StrToVal = new Dictionary<string, IComparable>();
            StrToVal.Add("title", GetTitle());
            StrToVal.Add("year", GetYear());
            StrToVal.Add("pageCount", GetPageCount());
        }
        public override string ToString()
        {
            return $"{title} {year} {pageCount}";
        }
    }
}

