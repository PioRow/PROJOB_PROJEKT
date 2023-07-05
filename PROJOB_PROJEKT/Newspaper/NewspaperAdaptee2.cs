using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class NewsPaperAdaptee2
    {
        public List<(string, object)> newspaper;
        public NewsPaperAdaptee2(string title, int year, int pageCount)
        {
            newspaper = new List<(string, object)>();
            newspaper.Add(("title", title));
            newspaper.Add(("year", year));
            newspaper.Add(("page count", pageCount));
        }
    }
}
