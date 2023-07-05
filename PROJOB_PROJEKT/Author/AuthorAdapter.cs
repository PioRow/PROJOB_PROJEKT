using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROJOB_PROJEKT
{
    public class AuthorAdapter : IAuthor
    {
        public AuthorAdaptee author;
        public Dictionary<string, IComparable> ValbyName;
        public AuthorAdapter(AuthorAdaptee author)
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
            return author.Author.Split("+")[0];
        }

        public string? GetNickname()
        {
            if (author.Author[author.Author.Length - 1] == '$')
            {
                return author.Author.Split("$")[1];
            }
            return null;
        }

        public string GetSurname()
        {
            return author.Author.Split("+")[1];
        }

        public int GetYearOfBirth()
        {
            if (author.Author[author.Author.Length - 1] == '$')
            {
                return int.Parse(author.Author.Split("+")[2].Split("$")[0]);
            }
            return int.Parse(author.Author.Split("+")[2]);
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
            string s = $"{this.GetName()} {this.GetSurname()} {this.GetYearOfBirth()}";
            if (this.GetNickname() != null)
                s += $" \"{GetNickname()}\"";
            return s;
        }
    }
}
