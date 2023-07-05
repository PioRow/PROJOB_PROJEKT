using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public interface IAuthor
    {
        public string GetName();
        public void SetName(string name);
        public string GetSurname();
        public void SetSurname(string surname);
        public int GetYearOfBirth();
        public void SetYearOfBirth(int yearOfBirth);
        public string? GetNickname();
        public void SetNickname(string nickname);
        public Dictionary<string, IComparable> Properties { get; }

    }
}
