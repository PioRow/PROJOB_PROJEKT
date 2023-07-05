using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BoardGameAdapter2 : IBoardGame
    {
        public BoardGameAdaptee2 boardgame;

        private Dictionary<string, IComparable> StrToVal;
        public Dictionary<string, IComparable> Properties => StrToVal;
        public BoardGameAdapter2(BoardGameAdaptee2 boardgame)
        {
            this.boardgame = boardgame;
            StrToVal = new Dictionary<string, IComparable>();
            StrToVal.Add("name", GetName());
            StrToVal.Add("minplayers", GetMinPlayers());
            StrToVal.Add("maxplayers", GetMaxPlayers());
            StrToVal.Add("difficulty", GetDifficulty());
        }

        public List<IAuthor> GetAuthorList()
        {
            List<IAuthor> s = new List<IAuthor>();
            foreach (var e in boardgame.boardgame)
            {
                if (e.Item1 == "authors")
                    s = (List<IAuthor>)e.Item2;
            }
            return s;
        }

        public int GetDifficulty()
        {
            int s = 0;
            foreach (var e in boardgame.boardgame)
            {
                if (e.Item1 == "difficulty")
                    s = (int)e.Item2;
            }
            return s;
        }

        public int GetMaxPlayers()
        {
            int s = 0;
            foreach (var e in boardgame.boardgame)
            {
                if (e.Item1 == "max players")
                    s = (int)e.Item2;
            }
            return s;
        }

        public int GetMinPlayers()
        {
            int s = 0;
            foreach (var e in boardgame.boardgame)
            {
                if (e.Item1 == "min players")
                    s = (int)e.Item2;
            }
            return s;
        }

        public string GetName()
        {
            string s = "";
            foreach (var e in boardgame.boardgame)
            {
                if (e.Item1 == "name")
                    s = (string)e.Item2;
            }
            return s;
        }
        public override string ToString()
        {
            string s = $"{GetName()} {GetMinPlayers()}-{GetMaxPlayers()} {GetDifficulty()}";
            foreach (var a in GetAuthorList()) { s += "\n" + a.ToString(); }
            return s;
        }

        public void SetName(string name)
        {
            throw new NotImplementedException();
        }

        public void SetMinPlayers(int minPlayers)
        {
            throw new NotImplementedException();
        }

        public void SetMaxPlayers(int maxPlayers)
        {
            throw new NotImplementedException();
        }

        public void SetDifficulty(int difficulty)
        {
            throw new NotImplementedException();
        }
    }
}
