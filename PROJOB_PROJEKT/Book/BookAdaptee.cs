using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BookAdaptee
    {
        public string book;
        public BookAdaptee(string title, int year, int pagecount, string genre, List<IAuthor> authors)
        {
            book = $"{title};{year}({pagecount});";
            foreach (var i in authors)
            {
                book += $"({i.GetHashCode()}); ";
            }

        }

    }
}
