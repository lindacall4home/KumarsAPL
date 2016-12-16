using KumarsAPL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KumarsAPL.Classes.clsChallengeGame;
using static KumarsAPL.Classes.clsMeetingAttendee;
using static KumarsAPL.Classes.clsPlayerRanking;

namespace KumarsAPL.Classes
{
    public class clsChessClubMeeting
    {
        private DateTime meetingDate;
        public DateTime MeetingDate
        {
            get { return meetingDate; }
            set { meetingDate = value; }
        }

        private clsXMLDataStore dataStore = new clsXMLDataStore();
        private clsCompareGameByDateAndBoard gameComparer = new clsCompareGameByDateAndBoard();

        public SortableBindingList<clsMeetingAttendee> listMeetingAttendees = new SortableBindingList<clsMeetingAttendee>();
        public List<clsMeetingAttendee> listChallengeGameAttendees = new List<clsMeetingAttendee>();
        public List<clsChallengeGame> listChallengeGames = new List<clsChallengeGame>();
        public List<clsPlayerRanking> initialRankings = new List<clsPlayerRanking>();
        public List<clsPlayerRanking> finalRankings = new List<clsPlayerRanking>();
        public clsChallengeGameList allGames;
       // private clsChessClubMeeting previousMeeting;

        private int gameBoard = 0;

        private clsCompareRankingsByRank rankComparer = new clsCompareRankingsByRank();

        public clsChessClubMeeting ()
        {
            //if (initialRankings.Count == 0)
            //{
            //    previousMeeting = dataStore.GetPreviousMeetingFromDataStore(meetingDate);
            //    if (previousMeeting == null)
            //    {
            //        List<clsPlayer> playerList = dataStore.LoadPlayersFromDataStore();
            //        foreach (clsPlayer player in playerList)
            //        {
            //            clsPlayerRanking playerRanking = new clsPlayerRanking();
            //            playerRanking.PlayerID = player.PlayerID;
            //            playerRanking.Rank = player.Rank;
            //            playerRanking.PlayerFullName = player.FullName;
            //            initialRankings.Add(playerRanking);
            //        }
            //        initialRankings.Sort(rankComparer);
            //    }
            //    else
            //    {
            //        initialRankings = previousMeeting.finalRankings;

            //    }
            //}
        }

        public void PairAttendees()
        {
            allGames = dataStore.LoadAllGamesFromDataStore();
            allGames.Sort(gameComparer);
            List<clsMeetingAttendee> listRemainingAttendees = new List<clsMeetingAttendee>();
            foreach(clsMeetingAttendee attendee in listChallengeGameAttendees)
            {
                if(attendee.ChallengeGameAssigned == false)
                {
                    attendee.LastGame = allGames.GetPreviousGameForPlayer(attendee.Player);
                    listRemainingAttendees.Add(attendee);
                }
            }
            clsCompareAttendeesByRank rankComparer = new clsCompareAttendeesByRank();

            listRemainingAttendees.Sort(rankComparer);
            gameBoard = listRemainingAttendees.Count / 2;
   
            while (listRemainingAttendees.Count > 1)
            {
                clsChallengeGame nextGame = GetNextMatch(listRemainingAttendees);
                listChallengeGames.Add(nextGame);
                gameBoard--;
            }
            
        }
        
        private clsChallengeGame GetNextMatch(List<clsMeetingAttendee> listRemainingAttendees)
        {
            clsChallengeGame nextGame = new clsChallengeGame();
            nextGame.GameBoard = gameBoard;
            nextGame.GameDate = DateTime.Today;
            nextGame.GameResult = "None";

            clsMeetingAttendee whitePlayer = GetWhitePlayer(listRemainingAttendees);
            nextGame.WhitePlayerID = whitePlayer.Player.PlayerID;
            whitePlayer.ChallengeGameAssigned = true;
            listRemainingAttendees.Remove(whitePlayer);
            clsMeetingAttendee blackPlayer = GetBlackPlayer(whitePlayer, listRemainingAttendees);
            nextGame.BlackPlayerID = blackPlayer.Player.PlayerID;
            blackPlayer.ChallengeGameAssigned = true;
            listRemainingAttendees.Remove(blackPlayer);
            return nextGame;
        }
        private clsMeetingAttendee GetWhitePlayer(List<clsMeetingAttendee> listRemainingAttendees)
        {
            clsMeetingAttendee whitePlayer = listRemainingAttendees.Last();
            return whitePlayer;

        }
        private clsMeetingAttendee GetBlackPlayer(clsMeetingAttendee whitePlayer, List<clsMeetingAttendee> listRemainingAttendees)
        {
            clsMeetingAttendee blackPlayer;

            int n = listRemainingAttendees.Count;
            if (n >= 5)
                n = listRemainingAttendees.Count - 5;
            else
                n = 0;
            for (int x = n; x <= listRemainingAttendees.Count - 1; x++)
            {
                blackPlayer = listRemainingAttendees.ElementAt(x);
                if ((blackPlayer.LastGame != null) && (blackPlayer.LastGame.WhitePlayerID == blackPlayer.Player.PlayerID) && 
                    (blackPlayer.LastGame.BlackPlayerID != whitePlayer.Player.PlayerID))
                    return blackPlayer;
            }
            for (int x = n; x <= listRemainingAttendees.Count - 1; x++)
            {
                blackPlayer = listRemainingAttendees.ElementAt(x);
                if ((blackPlayer.LastGame != null) && ((blackPlayer.LastGame.WhitePlayerID == 
                    blackPlayer.Player.PlayerID) || (blackPlayer.LastGame.BlackPlayerID != whitePlayer.Player.PlayerID)))
                    return blackPlayer;
            }

            
            blackPlayer = listRemainingAttendees.ElementAt(n);
            return blackPlayer;

        }

        public void SetRankings()
        {
               List<clsPlayer> playerList = dataStore.LoadPlayersFromDataStore();
                initialRankings.Clear();
                finalRankings.Clear();
                foreach (clsPlayer player in playerList)
                {
                    clsPlayerRanking newRank = new clsPlayerRanking();
                    newRank.PlayerID = player.PlayerID;
                    newRank.Rank = player.Rank;
                    newRank.PlayerFullName = player.FullName;
                    initialRankings.Add(newRank);
                    finalRankings.Add(newRank);
                }
                initialRankings.Sort(rankComparer);
                finalRankings.Sort(rankComparer);


                foreach (clsChallengeGame game in listChallengeGames)
                {
                    if (game.GameResult != "None")
                    {
                        int blackPlayerRank = GetPlayerInitialRank(game.BlackPlayerID);
                        int whitePlayerRank = GetPlayerInitialRank(game.WhitePlayerID);

                        if (game.GameResult == "Draw")
                        {
                            if ((blackPlayerRank < whitePlayerRank) && (blackPlayerRank < whitePlayerRank - 1))
                                SetPlayerRank(game.WhitePlayerID, blackPlayerRank + 1);
                            else if ((whitePlayerRank < blackPlayerRank) && (whitePlayerRank < blackPlayerRank - 1))
                                SetPlayerRank(game.BlackPlayerID, whitePlayerRank + 1);
                        }
                        else if (game.GameResult == "White")
                        {
                            if (blackPlayerRank < whitePlayerRank)
                                SetPlayerRank(game.WhitePlayerID, blackPlayerRank);

                        }
                        else if (game.GameResult == "Black")
                        {
                            if (whitePlayerRank < blackPlayerRank)
                                SetPlayerRank(game.BlackPlayerID, whitePlayerRank);

                        }
                    }

                }

                foreach (clsPlayerRanking ranking in finalRankings)
                {
                    clsPlayer player = playerList.Find(x => x.PlayerID == ranking.PlayerID);
                    player.Rank = ranking.Rank;

                }
                dataStore.SavePlayersToDataStore(playerList);
          
        }

        public void SetPlayerRank(int playerID, int newRank)
        {
            int oldRank = 0;
            foreach (clsPlayerRanking rank in finalRankings)
            {
                if (rank.PlayerID == playerID)
                {
                    oldRank = rank.Rank;
                    rank.Rank = newRank;
                    break;
                }
           }

           finalRankings.Sort(rankComparer);
            foreach (clsPlayerRanking rank in finalRankings)
            {
                if ((rank.Rank >= newRank) && (rank.Rank < oldRank))
                {
                    if (rank.PlayerID != playerID)
                        rank.Rank++;

                }
            }
        }

 
        private int GetPlayerInitialRank(int playerID)
        {
            foreach(clsPlayerRanking rank in initialRankings)
            {
                if (rank.PlayerID == playerID)
                    return rank.Rank;
            }
            clsPlayerRanking newRank = new clsPlayerRanking();
            newRank.PlayerID = playerID;
            newRank.Rank = initialRankings.Count;

            foreach (clsMeetingAttendee attendee in listMeetingAttendees)
            {
                if (attendee.Player.PlayerID == playerID)
                {
                    newRank.PlayerFullName = attendee.Player.FullName;
                    break;
                }
            }
            initialRankings.Add(newRank);
            return newRank.Rank;

        }
    }
}
