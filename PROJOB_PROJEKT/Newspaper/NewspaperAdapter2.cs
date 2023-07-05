using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class NewsPaperAdapter2 : INewsPaper
    {
        public NewsPaperAdaptee2 newspaper;
        private Dictionary<string, IComparable> StrToVal;
        public Dictionary<string, IComparable> Properties => StrToVal;
        public NewsPaperAdapter2(NewsPaperAdaptee2 newspaper)
        {
            this.newspaper = newspaper;
            StrToVal = new Dictionary<string, IComparable>();
            StrToVal.Add("title", GetTitle());
            StrToVal.Add("year", GetYear());
            StrToVal.Add("pageCount", GetPageCount());
        }

        public int GetPageCount()
        {
            int s = 0;
            foreach (var e in newspaper.newspaper)
            {
                if (e.Item1 == "page count")
                    s = (int)e.Item2;
            }
            return s;
        }

        public string GetTitle()
        {
            string s = "";
            foreach (var e in newspaper.newspaper)
            {
                if (e.Item1 == "title")
                    s = (string)e.Item2;
            }
            return s;
        }

        public int GetYear()
        {
            int s = 0;
            foreach (var e in newspaper.newspaper)
            {
                if (e.Item1 == "year")
                    s = (int)e.Item2;
            }
            return s;
        }
        public override string ToString()
        {
            return $"{GetTitle()} {GetYear()} {GetPageCount()}";
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
