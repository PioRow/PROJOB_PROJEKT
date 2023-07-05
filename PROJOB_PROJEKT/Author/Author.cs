using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class Author : IAuthor
    {
        private string name;
        private string surname;
        private int yearOfBirth;
        private string? nickname;
        public string GetName() => name;
        public void SetName(string name) { this.name = name; }
        public string GetSurname() => surname;
        public void SetSurname(string surname) { this.surname = surname; }
        public int GetYearOfBirth() => yearOfBirth;
        public void SetYearOfBirth(int yob) { yearOfBirth=yob; }
        public string? GetNickname() => nickname;
        public void SetNickname(string nn) { nickname = nn; }
        public Dictionary<string, IComparable> ValbyName;

        public Dictionary<string, IComparable> Properties => ValbyName;

        public Author(string name, string surname, int yearOfBirth, string? nickname)
        {
            this.name = name;
            this.surname = surname;
            this.yearOfBirth = yearOfBirth;
            this.nickname = nickname;
            ValbyName = new Dictionary<string, IComparable>();
            ValbyName.Add("name", name);
            ValbyName.Add("surname", surname);
            ValbyName.Add("yearofbirth", yearOfBirth);
            ValbyName.Add("nickname", nickname);

        }
        public override string ToString()
        {
            string s = $" {name} {surname}  {yearOfBirth}";
            if (nickname != null)
                s += $" \"{nickname}\"";
            return s;
        }
    }   
}
