using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BoardGameAdaptee
    {
        public string board;
        public BoardGameAdaptee(string name, int minPlayers, int maxPlayers, int difficulty, List<IAuthor> authors)
        {
            board = $"{name}/{minPlayers}-{maxPlayers}%{difficulty};";
            foreach (var i in authors)
                board += $"({i.GetHashCode()})";
        }
    }
}
