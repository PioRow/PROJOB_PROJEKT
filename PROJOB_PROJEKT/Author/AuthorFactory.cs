using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public interface IAuthorFactory
    {
        public IAuthor Build(string name, string surname, int yearOfBirth, string? nickname);
    }
    public class BaseAuthorFactory : IAuthorFactory
    {
        public BaseAuthorFactory() { }
        public IAuthor Build(string name, string surname, int yearOfBirth, string? nickname)
        {
            return new Author(name, surname, yearOfBirth, nickname);
        }
    }
    public class SecondaryAuthorFactory : IAuthorFactory
    {
        public SecondaryAuthorFactory() { }
        public IAuthor Build(string name, string surname, int yearOfBirth, string? nickname)
        {
            return new AuthorAdapter2(new AuthorAdaptee2(name, surname, yearOfBirth, nickname));
        }
    }

}
