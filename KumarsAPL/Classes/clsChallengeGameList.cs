using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumarsAPL.Classes
{
    public class clsChallengeGameList : List<clsChallengeGame>
    {
        public clsChallengeGameList()
        {

        }

        public clsChallengeGameList(List<clsChallengeGameList> gameList) : base()
        {

        }

        public clsChallengeGame GetPreviousGameForPlayer(clsPlayer player)
        {
            clsChallengeGame previousGame = null;

            foreach(clsChallengeGame game in this)
            {
                if ((player.PlayerID == game.BlackPlayerID) ||
                    (player.PlayerID == game.WhitePlayerID))
                    return game;
            }

            return previousGame;
        }
    }

}
