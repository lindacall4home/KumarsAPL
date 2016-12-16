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

namespace KumarsAPL.Forms
{
    public partial class frmMain : Form
    {
        clsXMLDataStore dataStore = new clsXMLDataStore();
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            frmPlayers PlayersForm = new frmPlayers();
            PlayersForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMeetings_Click(object sender, EventArgs e)
        {
            Classes.clsSettings settings = dataStore.LoadSettingsFromDataStore();

            bool newMeeting = false;
            if ((settings.meetingDates.Count == 0) || (settings.meetingDates.Last() < DateTime.Today))
            {
                frmConfirm confirmNewMeeting = new frmConfirm();
                confirmNewMeeting.SetConfirmText("Would you like to start a new meeting?");
                DialogResult result = confirmNewMeeting.ShowDialog();

               if (result == DialogResult.Yes)
                    newMeeting = true;
            }

            frmCheckIn CheckInForm = new frmCheckIn(newMeeting);
            CheckInForm.ShowDialog();
        }

        private void btnGames_Click(object sender, EventArgs e)
        {
            frmChallengeGames GamesForm = new frmChallengeGames();
            GamesForm.ShowDialog();
        }
    }
}
