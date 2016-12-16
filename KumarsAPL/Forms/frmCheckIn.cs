using KumarsAPL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KumarsAPL.Classes.clsPlayerRanking;

namespace KumarsAPL.Forms
{
    public partial class frmCheckIn : Form
    {
        private clsXMLDataStore dataStore = new clsXMLDataStore();

        private clsChessClubMeeting meeting;
        //private clsChessClubMeeting lastMeeting;

        private List<clsPlayer> playerList;
        private SortableBindingList<clsPlayer> filteredPlayerList = new SortableBindingList<clsPlayer>();
        bool meetingDataChanged = false;
        private clsCompareRankingsByRank rankComparer = new clsCompareRankingsByRank();



        //private clsChallengeGameList listGames; 

        private List<clsMeetingAttendee> playersCheckedIn = new List<clsMeetingAttendee>();

        public frmCheckIn() : this(false)
        {

        }
        public frmCheckIn(bool newMeeting)
        {
            InitializeComponent();

            if (newMeeting)
            {
                meeting = new clsChessClubMeeting();
                meeting.MeetingDate = DateTime.Today;
                InitializePlayerLists();
                EnableControls(true);

                lblCheckIn.Text = "Check-In " + DateTime.Today.ToShortDateString();
                btnStart.Visible = false;
                dateCheckIn.Visible = false;
                lblGo.Visible = false;
            }
          
        }

        private void frmCheckIn_Load(object sender, EventArgs e)
        {
            if (meeting == null)
            {
                dateCheckIn.Value = DateTime.Today;
                //listGames = dataStore.LoadChallengeGamesFromDataStore();
                EnableControls(false);
            }


        }

        private void EnableControls(bool enable)
        {
            btnSave.Enabled = enable;
            btnRemove.Enabled = enable;
            btnCheckIn.Enabled = enable;
        }
        private void InitializePlayerLists()
        {
            playerList = new List<clsPlayer>(dataStore.LoadPlayersFromDataStore());
            UpdateFilteredPlayerList();

            bindPlayers.DataSource = filteredPlayerList;
            bindPlayers.Sort = "FullName"; 
            listPlayers.DataSource = bindPlayers;
            listPlayers.DisplayMember = "FullName";

            bindCheckedIn.DataSource = meeting.listMeetingAttendees;
            bindCheckedIn.Sort = "PlayerFullNameAndChallengeGame";
            listPlayersCheckedIn.DataSource = bindCheckedIn;
            listPlayersCheckedIn.DisplayMember = "PlayerFullNameAndChallengeGame";

            foreach (clsMeetingAttendee checkedInPlayer in meeting.listMeetingAttendees)
            {
                foreach (clsPlayer player in playerList)
                {
                    if (player.PlayerID == checkedInPlayer.Player.PlayerID)
                    {
                        bindPlayers.Remove(player);
                        break;
                    }
                }
            }
        }

        private void UpdateFilteredPlayerList()
        {
            filteredPlayerList.Clear();
            foreach(clsPlayer player in playerList)
            {
                bool playerIsAttendee = false;
                foreach(clsMeetingAttendee attendee in meeting.listMeetingAttendees)
                {
                    if (attendee.Player.PlayerID == player.PlayerID)
                    {
                        playerIsAttendee = true;
                        break;
                    }

                }
                if((!playerIsAttendee) && ((txtFindPlayer.Text.Trim().Length == 0) ||
                    (player.FullName.ToLower().Contains(txtFindPlayer.Text.ToLower()))))
                {
                    filteredPlayerList.Add(player);
                }
            }
 
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            clsPlayer checkInPlayer = (clsPlayer)listPlayers.Items[listPlayers.SelectedIndex];

            frmConfirm confirmChallengeGame = new frmConfirm();
            confirmChallengeGame.SetConfirmText("Would you like to play a challenge game today?");
            DialogResult result = confirmChallengeGame.ShowDialog();

            clsMeetingAttendee newAttendee = new clsMeetingAttendee();
            newAttendee.Player = checkInPlayer;
            newAttendee.LastGame = new clsChallengeGame();
            newAttendee.PlayChallengeGame = (result == DialogResult.Yes);

            bindCheckedIn.Add(newAttendee);
            bindPlayers.Remove(checkInPlayer);
            bindCheckedIn.Sort = "PlayerFullNameAndChallengeGame";

            meetingDataChanged = true;

        }

        private void listPlayers_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listPlayers.SelectedIndex == -1)
                btnCheckIn.Enabled = false;
            else
                btnCheckIn.Enabled = true;
        }

        private void listPlayersCheckedIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPlayers.SelectedIndex == -1)
                btnRemove.Enabled = false;
            else
                btnRemove.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            clsMeetingAttendee attendee = (clsMeetingAttendee)listPlayersCheckedIn.Items[listPlayersCheckedIn.SelectedIndex];
            bindPlayers.Add(attendee.Player);
            bindCheckedIn.Remove(attendee);
            UpdateFilteredPlayerList();
            bindPlayers.Sort = "FullName";
            meetingDataChanged = true;


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            meeting = dataStore.GetMeetingByDate(dateCheckIn.Value);
            if (meeting == null)
            {
                frmMessage message = new frmMessage();
                message.SetMessageText("Meeting not found.");
                message.ShowDialog();
                return;
            //    meeting = new clsChessClubMeeting();
            //    meeting.MeetingDate = dateCheckIn.Value;
            }
            InitializePlayerLists();
            EnableControls(true);

            if (meeting.initialRankings.Count == 0)
                {
                     clsChessClubMeeting previousMeeting = dataStore.GetPreviousMeetingFromDataStore(meeting.MeetingDate);
                    if (previousMeeting == null)
                    {
                        List<clsPlayer> playerList = dataStore.LoadPlayersFromDataStore();
                        foreach (clsPlayer player in playerList)
                        {
                            clsPlayerRanking playerRanking = new clsPlayerRanking();
                            playerRanking.PlayerID = player.PlayerID;
                            playerRanking.Rank = player.Rank;
                            playerRanking.PlayerFullName = player.FullName;
                            meeting.initialRankings.Add(playerRanking);
                        }
                        meeting.initialRankings.Sort(rankComparer);
                    }
                    else
                    {
                        meeting.initialRankings = previousMeeting.finalRankings;

                    }
                }

            }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveMeeting(true);
        }

        private void SaveMeeting(bool displayMessage)
        {
            try
            {
                meeting.listChallengeGameAttendees.Clear();
                foreach(clsMeetingAttendee attendee in meeting.listMeetingAttendees)
                {
                    if (attendee.PlayChallengeGame)
                        meeting.listChallengeGameAttendees.Add(attendee);
                }
                dataStore.SaveMeetingToDataStore(meeting);

                if (displayMessage)
                {
                    frmMessage messageForm = new frmMessage();
                    messageForm.SetMessageText("Meeting attendees have been saved.");
                    messageForm.ShowDialog();
                    meetingDataChanged = false;
                }

            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error saving meeting attendees: " + ex.Message);
                messageForm.ShowDialog();

            }
           

        }

        private void txtFindPlayer_TextChanged(object sender, EventArgs e)
        {

            UpdateFilteredPlayerList();
        }

        private void btnStartGames_Click(object sender, EventArgs e)
        {
            frmConfirm ConfirmStartGames = new frmConfirm();
            ConfirmStartGames.SetConfirmText("Are you sure you are ready to set the challenge games?");
            DialogResult result = ConfirmStartGames.ShowDialog();
            if (result == DialogResult.Yes)
            {
                SaveMeeting(false);
                meeting.PairAttendees();
                ShowGames();
                
                //List<clsChallengeGame> challengeGames = dataStore.LoadChallengeGamesFromDataStore();
                //List<clsChallengeGame> newGames = meeting.PairAttendees();
                //foreach (clsChallengeGame game in newGames)
                //{
                //   //listGames.Add(game);
                //}
                ////dataStore.SaveChallengeGamesToDataStore(listGames);
                //dataStore.SaveMeetingToDataStore(meeting);
                //Close();
            }
        }

        private void ShowGames()
        {
            SaveMeeting(false);
            frmChallengeGames meetingGames = new frmChallengeGames(meeting);
            meetingGames.ShowDialog();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!meetingDataChanged)
                return;

            frmConfirm confirmForm = new frmConfirm();
            confirmForm.SetConfirmText("Save checked-in players? ");
            DialogResult result = confirmForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
                SaveMeeting(true);
            }
            Close();
        }

        private void btnGames_Click(object sender, EventArgs e)
        {
            ShowGames();
        }
    }
}
