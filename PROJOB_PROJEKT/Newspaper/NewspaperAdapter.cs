using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class NewsPaperAdapter : INewsPaper
    {
        public NewsPaperAdaptee newspaper;
        private Dictionary<string, IComparable> StrToVal;
        public Dictionary<string, IComparable> Properties => StrToVal;
        public NewsPaperAdapter(NewsPaperAdaptee newspaper)
        {
            this.newspaper = newspaper;
            StrToVal = new Dictionary<string, IComparable>();
            StrToVal.Add("title", GetTitle());
            StrToVal.Add("year", GetYear());
            StrToVal.Add("pageCount", GetPageCount());
        }

        public int GetPageCount()
        {
            string[] s = newspaper.Newspaper.Split("+");

            return int.Parse(s[1]);
        }

        public string GetTitle()
        {
            string[] s = newspaper.Newspaper.Split("(");
            return s[0];
        }

        public int GetYear()
        {
            string[] s = newspaper.Newspaper.Split("(");
            s = s[1].Split(")");
            return int.Parse(s[0]);
        }
        public override string ToString()
        {
            return $"{this.GetTitle()} {GetYear()} {this.GetPageCount()} ";
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
