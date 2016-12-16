using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumarsAPL.Classes
{
    public class clsSettings
    {
        
        private bool rankingSet = false;
        public bool RankingSet
        {
            get { return rankingSet; }
            set { rankingSet = value; }
        }

        public List<DateTime> meetingDates = new List<DateTime>();
    }
}
