using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public class BoardGameAdaptee2
    {
        public List<(string, object)> boardgame;
        public BoardGameAdaptee2(string name, int minPlayers, int maxPlayers, int difficulty, List<IAuthor> authors)
        {
            boardgame = new List<(string, object)>();
            boardgame.Add(("name", name));
            boardgame.Add(("min players", minPlayers));
            boardgame.Add(("max players", maxPlayers));
            boardgame.Add(("difficulty", difficulty));
            boardgame.Add(("authors", authors));

        }
    }
}
