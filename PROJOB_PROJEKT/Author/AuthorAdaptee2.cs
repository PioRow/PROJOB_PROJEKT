using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class AuthorAdaptee2
    {
        public List<(string, object)> author;
        public AuthorAdaptee2(string name, string surname, int yearOfBirth, string? nickname)
        {
            author = new List<(string, object)>();
            author.Add(("name", name));
            author.Add(("surname", surname));
            author.Add(("year of birth", yearOfBirth));
            if (nickname != null)
                author.Add(("nickname", nickname));
        }
    }
}
