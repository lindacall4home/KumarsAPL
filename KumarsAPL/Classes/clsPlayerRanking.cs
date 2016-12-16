using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumarsAPL.Classes
{
    public class clsPlayerRanking
    {
        private int playerID;
        public int PlayerID
        {
            get { return playerID; }
            set { playerID = value; }
        }

        private string playerFullName;
        public string PlayerFullName
        {
            get { return playerFullName; }
            set { playerFullName = value; }
        }

        private int rank;
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public class clsCompareRankingsByRank : IComparer<clsPlayerRanking>
        {
            public int Compare(clsPlayerRanking x, clsPlayerRanking y)
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
                        return x.Rank.CompareTo(y.Rank);
                    }
                }
            }
        }
    }
}
