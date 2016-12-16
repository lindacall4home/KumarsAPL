using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumarsAPL.Classes
{
    public class clsMeetingAttendee
    {
        private clsPlayer player;
        public clsPlayer Player
        {
            get { return player; }
            set { player = value; }
        }

        public string PlayerFullName
        {
            get { return player.FullName; }
        }

        public string PlayerFullNameAndChallengeGame
        {
            get { if (playChallengeGame) return "*" + player.FullName; else return player.FullName; }
        }

        private bool playChallengeGame;
        public bool PlayChallengeGame
        {
            get { return playChallengeGame; }
            set { playChallengeGame = value; }
        }

        private bool challengeGameAssigned;
        public bool ChallengeGameAssigned
        {
            get { return challengeGameAssigned; }
            set { challengeGameAssigned = value; }
        }

        private clsChallengeGame lastGame;
        public clsChallengeGame LastGame
        {
            get { return lastGame; }
            set { lastGame = value; }
        }

        public class clsCompareAttendeesByRank : IComparer<clsMeetingAttendee>
        {
            public int Compare(clsMeetingAttendee x, clsMeetingAttendee y)
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
                        return x.Player.Rank.CompareTo(y.Player.Rank);
                    }
                }
            }
        }
    }
}
