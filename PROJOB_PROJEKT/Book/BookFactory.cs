using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public interface IBookFactory
    {
        public IBook Build(string title, int year, int pagecount, string genre, List<IAuthor> authors);
    }

    public class BaseBookFactory : IBookFactory
    {

        public BaseBookFactory() { }
        public IBook Build(string title, int year, int pagecount, string genre, List<IAuthor> authors)
        {
            return new Book(title, year, pagecount, genre, authors);
        }
    }
    public class SecondaryBookFactory : IBookFactory
    {
        public SecondaryBookFactory()
        { }
        public IBook Build(string title, int year, int pagecount, string genre, List<IAuthor> authors)
        {
            return new BookAdapter2(new BookAdaptee2(title, year, pagecount, genre, authors));
        }
    }

}
