using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class AuthorAdaptee
    {
        public string Author;
        public AuthorAdaptee(string name, string surname, int yearOfBirth, string? nickname)
        {
            Author = $"{name}+{surname}+{yearOfBirth}";
            if (nickname != null) Author += $"${nickname}$";
        }
    }
}
