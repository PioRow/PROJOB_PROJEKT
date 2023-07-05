using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class AuthorAdapter2 : IAuthor
    {
        public AuthorAdaptee2 author;
        public Dictionary<string, IComparable> ValbyName;
        public AuthorAdapter2(AuthorAdaptee2 author)
        {
            this.author = author;
            ValbyName = new Dictionary<string, IComparable>();
            ValbyName.Add("name", GetName());
            ValbyName.Add("surname", GetSurname());
            ValbyName.Add("yearofbirth", GetYearOfBirth());
            ValbyName.Add("nickname", GetNickname());
        }

        public Dictionary<string, IComparable> Properties => ValbyName;

        public string GetName()
        {
            string s = "";
            foreach (var e in author.author)
            {
                if (e.Item1 == "name")
                    s = (string)e.Item2;
            }
            return s;
        }

        public string? GetNickname()
        {
            string s = "";
            foreach (var e in author.author)
            {
                if (e.Item1 == "nickname")
                    s = (string)e.Item2;
            }
            if (s == "")
                return null;
            return s;
        }

        public string GetSurname()
        {
            string s = "";
            foreach (var e in author.author)
            {
                if (e.Item1 == "surname")
                    s = (string)e.Item2;
            }
            return s;
        }

        public int GetYearOfBirth()
        {
            int s = 0;
            foreach (var e in author.author)
            {
                if (e.Item1 == "year of birth")
                    s = (int)e.Item2;
            }
            return s;
        }

        public void SetName(string name)
        {
            throw new NotImplementedException();
        }

        public void SetNickname(string nickname)
        {
            throw new NotImplementedException();
        }

        public void SetSurname(string surname)
        {
            throw new NotImplementedException();
        }

        public void SetYearOfBirth(int yearOfBirth)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string s = $"{GetName()} {GetSurname()} {GetYearOfBirth()}";
            if (GetNickname() != null)
                s += $" \"{GetNickname()}\"";
            return s;
        }
    }
}
