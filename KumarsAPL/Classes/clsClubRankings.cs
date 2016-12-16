using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumarsAPL.Classes
{
    class clsClubRankings
    {
        private DateTime rankingDate;
        public DateTime RankingDate
        {
            get { return rankingDate; }
            set { rankingDate = value; }
        }

        private List<clsPlayerRanking> playerRankings = new List<clsPlayerRanking>();
    }
}
