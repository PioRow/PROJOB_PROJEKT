using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BookAdaptee2
    {
        public List<(string, object)> book;

        public BookAdaptee2(string title, int year, int pagecount, string genre, List<IAuthor> authors)
        {
            book = new List<(string, object)>();

            book.Add(("title", title));
            book.Add(("year", year));
            book.Add(("page count", pagecount));
            book.Add(("authors", authors));
        }
    }
}
