using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KumarsAPL.Classes;
using static KumarsAPL.Classes.clsChallengeGame;

namespace KumarsAPL.Forms
{
    public partial class frmChallengeGames : Form
    {

        private clsXMLDataStore dataStore = new clsXMLDataStore();
        private DateTimePicker oDateTimePicker;
        clsChallengeGameList outsideGames;
        List<clsChallengeGame> currentGames;
        clsChessClubMeeting currentMeeting;
        clsCompareGameByDateAndBoard gameComparer = new clsCompareGameByDateAndBoard();

        public frmChallengeGames():this(null)
        {
            
        }
        public frmChallengeGames(clsChessClubMeeting meeting)
        {
            currentMeeting = meeting;
            InitializeComponent();
            InitializeGameGrid();
        }

        private void InitializeGameGrid()
        {
            if (currentMeeting == null)
            {
                outsideGames = dataStore.LoadOutsideGamesFromDataStore();
                currentGames = outsideGames.ToList();
            }

            else
                currentGames = currentMeeting.listChallengeGames;

            currentGames.Sort(gameComparer);
            bindChallengeGames.DataSource = currentGames;
            
            SortableBindingList<clsPlayer> sortableWhitePlayerList = new SortableBindingList<clsPlayer>(dataStore.LoadPlayersFromDataStore());
            bindWhitePlayers.DataSource = sortableWhitePlayerList;
            bindWhitePlayers.Sort = "FullName";
            colWhitePlayer.DataSource = bindWhitePlayers;


            SortableBindingList<clsPlayer> sortableBlackPlayerList = new SortableBindingList<clsPlayer>(dataStore.LoadPlayersFromDataStore());
            bindBlackPlayers.DataSource = sortableBlackPlayerList;
            bindBlackPlayers.Sort = "FullName";
            colBlackPlayer.DataSource = bindBlackPlayers;


        }

        private void gridChallengeGames_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message + " Column: " + gridChallengeGames.Columns[e.ColumnIndex].Name + 
                ", Value: " + gridChallengeGames.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }

        private void gridChallengeGames_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (bindWhitePlayers.Count > 0)
                {
                    e.Row.Cells[colWhitePlayer.Name].Value = ((clsPlayer)bindWhitePlayers.Current).PlayerID;

                }

                if (bindBlackPlayers.Count > 0)
                {
                    e.Row.Cells[colBlackPlayer.Name].Value = ((clsPlayer)bindBlackPlayers.Current).PlayerID;

                }
                e.Row.Cells[colGameResult.Name].Value = "None";
                e.Row.Cells[colGameDate.Name].Value = DateTime.Today;
               



            }
            catch(Exception ex)
            {
                MessageBox.Show("Error getting default values: " + ex.Message);
            }
        }

         private void gridChallengeGames_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if ((e.ColumnIndex != -1) && (gridChallengeGames.Columns[e.ColumnIndex] == colGameDate) && (e.RowIndex != -1))
                {
                    gridChallengeGames.CurrentCell = gridChallengeGames.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //calendarCellRow = e.RowIndex;
                    //Initialized a new DateTimePicker Control  
                    oDateTimePicker = new DateTimePicker();

                    //Adding DateTimePicker control into DataGridView   
                    gridChallengeGames.Controls.Add(oDateTimePicker);

                    // Setting the format (i.e. 2014-10-10)  
                    oDateTimePicker.Format = DateTimePickerFormat.Short;

                    // It returns the retangular area that represents the Display area for a cell  
                    Rectangle oRectangle = gridChallengeGames.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    //Setting area for DateTimePicker Control  
                    oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                    // Setting Location  
                    oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                    // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                    oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                    // An event attached to dateTimePicker Control which is fired when any date is selected  
                    oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                    // Now make it visible  
                    oDateTimePicker.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting up date control: " + ex.Message);
            }
       
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            try
            {
                gridChallengeGames.CurrentCell.Value = oDateTimePicker.Text.ToString();
             }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting date: " + ex.Message);
            }
           
        }
        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            try
            {
                gridChallengeGames.EndEdit();
                // Hiding the control after use   
                //oDateTimePicker.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing calendar: " + ex.Message);
            }
       
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //dataStore.SaveChallengeGamesToDataStore((clsChallengeGameList)bindChallengeGames.DataSource);
            SaveChallengeGames();
            //Close();
        }


        private void gridChallengeGames_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == colGameDate.Index) && (oDateTimePicker != null))
                oDateTimePicker.Visible = false;
        }

        private void gridChallengeGames_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colGameDate.Index)
                {
                    if (e.Value == null)
                        e.Value = "";
                    else
                        e.Value = ((DateTime)e.Value).ToShortDateString();
                    e.FormattingApplied = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error formatting Date: " + ex.Message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmConfirm confirmForm = new frmConfirm();
            confirmForm.SetConfirmText("Save challenge games? ");
            DialogResult result = confirmForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
                SaveChallengeGames();
            }
            Close();
        }

        private void SaveChallengeGames()
        {
            try
            {
                bool successful = false;
                if (currentMeeting != null)
                {
                    successful = dataStore.SaveMeetingToDataStore(currentMeeting);
 
                }
                else
                    successful = dataStore.SaveChallengeGamesToDataStore(outsideGames);

                if (successful)
                { 
                    currentGames.Sort(gameComparer);
                    gridChallengeGames.Refresh();

                    frmMessage messageForm = new frmMessage();
                    messageForm.SetMessageText("Challenge games have been saved.");
                    messageForm.ShowDialog();
                }
 
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error saving challenge games: " + ex.Message);
                messageForm.ShowDialog();

            }


        }

        private void gridChallengeGames_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.)
        }

        private void gridChallengeGames_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //e.
        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfirm confirmForm = new frmConfirm();
                confirmForm.SetConfirmText("Are you sure you are ready to set the rankings? ");
                DialogResult result = confirmForm.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    currentMeeting.SetRankings();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error setting rankings. " + ex.Message);
            }
        }
    }
}
