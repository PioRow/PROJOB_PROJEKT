using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJOB_PROJEKT
{
    public interface IBoardGame
    {
        public string GetName();
        public void SetName(string name);
        public int GetMinPlayers();
        public void SetMinPlayers(int minPlayers);
        public int GetMaxPlayers();
        public void SetMaxPlayers(int maxPlayers);
        public int GetDifficulty();
        public void SetDifficulty(int difficulty);
        public List<IAuthor> GetAuthorList();
        public Dictionary<string, IComparable> Properties { get; }
    }
}
