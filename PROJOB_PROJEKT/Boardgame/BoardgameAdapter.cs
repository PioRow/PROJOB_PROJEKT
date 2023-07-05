using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BoardGameAdapter : IBoardGame
    {
        public BoardGameAdaptee boardgame;

        private Dictionary<string, IComparable> StrToVal;
        public Dictionary<string, IComparable> Properties => StrToVal;
        public BoardGameAdapter(BoardGameAdaptee boardgame)
        {
            this.boardgame = boardgame;
            StrToVal = new Dictionary<string, IComparable>();
            StrToVal.Add("name", GetName());
            StrToVal.Add("minplayers", GetMinPlayers());
            StrToVal.Add("maxplayers", GetMaxPlayers());
            StrToVal.Add("difficulty", GetDifficulty());
        }

        public int GetDifficulty()
        {
            return int.Parse(boardgame.board.Split("%")[1].Split(";")[0]);
        }

        public int GetMaxPlayers()
        {
            return int.Parse(boardgame.board.Split("-")[1].Split("%")[0]);
        }

        public int GetMinPlayers()
        {
            return int.Parse(boardgame.board.Split("/")[1].Split("-")[0]);
        }

        public string GetName()
        {
            return boardgame.board.Split("/")[0];
        }
        public int[] GetAuthors()
        {
            List<int> authors = new List<int>();
            string[] s = this.boardgame.board.Split("(");
            for (int i = 1; i < s.Length; i++)
            {

                string p = s[i].Split(")")[0];

                authors.Add(int.Parse(p));
            }
            return authors.ToArray();
        }
        public override string ToString()
        {
            string s = $"{this.GetName()}  {this.GetDifficulty()} {this.GetMinPlayers()}-{this.GetMaxPlayers()}";
            foreach (var a in GetAuthorList())
            {
                s += $"\n{a}";
            }
            s.Substring(0, s.Length - 2);
            return s;

        }

        public List<IAuthor> GetAuthorList()
        {
            List<IAuthor> authors = new List<IAuthor>();
            string[] s = this.boardgame.board.Split("(");
            for (int i = 1; i < s.Length; i++)
            {

                string p = s[i].Split(")")[0];

                authors.Add((IAuthor)AuthorsMap.Authors[int.Parse(p)]);
            }
            return authors;
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
