using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumarsAPL.Classes
{
   

    public class clsChallengeGame
    {
        private DateTime gameDate;
        public DateTime GameDate
        {
            get { return gameDate; }
            set { gameDate = value; }
        }
        private int gameBoard;
        public int GameBoard
        {
            get { return gameBoard; }
            set { gameBoard = value; }
        }

        private int whitePlayerID;
        public int WhitePlayerID
        {
            get { return whitePlayerID; }
            set { whitePlayerID = value; }
        }

        private int blackPlayerID;
        public int BlackPlayerID
        {
            get { return blackPlayerID; }
            set { blackPlayerID = value; }
        }

        private string gameResult;

        public string GameResult
        {
            get { return gameResult; }
            set { gameResult = value; }
        }

        public class clsCompareGameByDateAndBoard : IComparer<clsChallengeGame>
        {
            public int Compare(clsChallengeGame x, clsChallengeGame y)
            {
                if (x == null)
                {
                    if (y == null)
                    {
                        // If x is null and y is null, they're
                        // equal. 
                        return 0;
                    }
                    else
                    {
                        // If x is null and y is not null, y
                        // is greater. 
                        return -1;
                    }
                }
                else
                {
                    // If x is not null...
                    //
                    if (y == null)
                    // ...and y is null, x is greater.
                    {
                        return 1;
                    }
                    else
                    {
                        if (x.GameDate == y.GameDate)
                        {
                            if(x.GameBoard == y.GameBoard)
                                return 0;
                            else
                                return x.GameBoard.CompareTo(y.GameBoard);
                        }

                        return x.GameDate.CompareTo(y.GameDate); 
                    }
                }
            }
        }

  
    }
}
