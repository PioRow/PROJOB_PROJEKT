using PROJOB_PROJEKT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROJOB_PROJEKT
{
    public class BoardGame : IBoardGame
    {
        private string name;
        public string GetName() => name;
        public void SetName(string name) { this.name=name; }
        private List<IAuthor> authors;
        public List<IAuthor> GetAuthorList() => authors;
        private int minPlayers;
        public int GetMinPlayers() => minPlayers;
        public void SetMinPlayers(int mp) { minPlayers = mp; }
        private int maxPlayers;
        public int GetMaxPlayers() => maxPlayers;
        public void SetMaxPlayers(int mp) { maxPlayers = mp; }
        private int difficulty;

        private Dictionary<string, IComparable> StrToVal;
        public Dictionary<string, IComparable> Properties => StrToVal;

        public int GetDifficulty() => difficulty;
        public void SetDifficulty(int d) { difficulty = d; }
        public BoardGame(string name, int minPlayers, int maxPlayers, int difficulty, List<IAuthor> authors)
        {
            this.name = name;
            this.minPlayers = minPlayers;
            this.maxPlayers = maxPlayers;
            this.difficulty = difficulty;
            this.authors = new List<IAuthor>();
            foreach (var a in authors)
            {
                this.authors.Add(a);
            }
            StrToVal = new Dictionary<string, IComparable>();
            StrToVal.Add("name", GetName());
            StrToVal.Add("minplayers", GetMinPlayers());
            StrToVal.Add("maxplayers", GetMaxPlayers());
            StrToVal.Add("difficulty", GetDifficulty());
        }
        public override string ToString()
        {
            string s = $" {name} {difficulty} {minPlayers}-{maxPlayers}";
            foreach (var a in authors) { s += "\n" + a.ToString(); }
            return s;
        }
    }
}






