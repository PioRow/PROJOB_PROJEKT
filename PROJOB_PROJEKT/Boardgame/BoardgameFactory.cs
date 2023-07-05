using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    
        public interface IBoardGameFactory
        {
            public IBoardGame Build(string name, int minPlayers, int maxPlayers, int difficulty, List<IAuthor> authors);
        }
        public class baseBoardGameFactory : IBoardGameFactory
        {
             public baseBoardGameFactory() { }
            public IBoardGame Build(string name, int minPlayers, int maxPlayers, int difficulty, List<IAuthor> authors)
            {
                return new BoardGame(name, minPlayers,maxPlayers,difficulty,authors);
            }
        }
        public class SecondaryBoardGameFactory : IBoardGameFactory
        {
        public SecondaryBoardGameFactory() { }
        public IBoardGame Build(string name, int minPlayers, int maxPlayers, int difficulty, List<IAuthor> authors)
        {
                return new BoardGameAdapter2(new BoardGameAdaptee2(name, minPlayers, maxPlayers, difficulty, authors));
            }
        }
    
}
