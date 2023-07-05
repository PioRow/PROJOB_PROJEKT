using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT.Newspaper
{
    public interface INewspaperFactory
    {
        public INewsPaper Build(string title, int year, int pageCount);
    }
    public class baseNewspaperFactory : INewspaperFactory
    {
        public baseNewspaperFactory() { }
        public INewsPaper Build(string title, int year, int pageCount)
        {
            return new NewsPaper(title, year, pageCount);
        }
    }
    public class SecondaryNewspaperFactory : INewspaperFactory
    {
        public SecondaryNewspaperFactory() { }

        public INewsPaper Build(string title, int year, int pageCount)
        {
            return new NewsPaperAdapter2(new NewsPaperAdaptee2(title, year, pageCount));
        }
    }

}
