using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class NewsPaperAdaptee
    {
        public string Newspaper;

        public NewsPaperAdaptee(string title, int year, int pageCount)
        {
            Newspaper = $"{title}({year})+{pageCount}";
        }
    }
}
