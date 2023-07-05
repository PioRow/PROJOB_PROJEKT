using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public interface INewsPaper
    {
        public string GetTitle();
        public void SetTitle(string title);
        public int GetYear();
        public void SetYear(int year);
        public int GetPageCount();
        public void SetPageCount(int pageCount);
        public Dictionary<string, IComparable> Properties { get; }
    }
}
