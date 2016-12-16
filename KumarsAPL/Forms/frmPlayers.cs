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
using System.IO;

namespace KumarsAPL.Forms
{
    public partial class frmPlayers : Form
    {
        private clsXMLDataStore dataStore = new clsXMLDataStore();
        private clsSettings appSettings;
        List<clsPlayer> playerList;
        clsComparePlayersByBirthday birthdayComparer = new clsComparePlayersByBirthday();
        clsComparePlayersByRank rankComparer = new clsComparePlayersByRank();

        private int nextPlayerID = 1;
        public frmPlayers()
        {
            InitializeComponent();
            GetAppSettings();
            InitializePlayersGrid();
        }

        private void GetAppSettings()
        {
            appSettings = dataStore.LoadSettingsFromDataStore();
            EnableControls();

        }

        private void EnableControls()
        {
            if (appSettings.RankingSet == false)
            {
                btnStartRanking.Visible = true;
                btnUp.Visible = false;
                btnDown.Visible = false;
            }
            else
            {
                btnStartRanking.Visible = false;
                btnUp.Visible = true;
                btnDown.Visible = true;
            }
        }

        private void InitializePlayersGrid()
        {
            playerList = new List<clsPlayer>(dataStore.LoadPlayersFromDataStore());
            SortPlayers();
            SetNextPlayerID();
            bindPlayers.DataSource = playerList;


        }

        private void SortPlayers()
        {
            if (appSettings.RankingSet == false)
            {
                playerList.Sort(birthdayComparer);
            }

            else
            {
                playerList.Sort(rankComparer);
            }

        }

        private void SetNextPlayerID()
        {
            int lastID = 0;

            foreach (clsPlayer player in playerList)
            {
                if (player.PlayerID > lastID)
                    lastID = player.PlayerID;
            }
            nextPlayerID = lastID + 1;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            SavePlayers();

        }

        private void SavePlayers()
        {
            try
            {
                SortPlayers();
                SetRanksBasedOnRowPositions();
                bool successful = dataStore.SavePlayersToDataStore(playerList);
                if (successful)
                {
                    gridPlayers.Refresh();
                    frmMessage messageForm = new frmMessage();
                    messageForm.SetMessageText("All Players have been saved.");
                    messageForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error saving players: " + ex.Message);
                messageForm.ShowDialog();

            }

        }

        private void txtFindPlayer_TextChanged(object sender, EventArgs e)
        {
            gridPlayers.CurrentCell = null;

            foreach (DataGridViewRow row in gridPlayers.Rows)
            {
                if (row.Index != gridPlayers.NewRowIndex)
                {
                    if ((txtFindPlayer.Text.Length == 0) ||
                        (row.Cells[colFirstName.Name].Value.ToString().ToLower().Contains(txtFindPlayer.Text.ToLower())) ||
                        (row.Cells[colLastName.Name].Value.ToString().ToLower().Contains(txtFindPlayer.Text.ToLower())))

                    {
                        row.Visible = true;

                    }
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnStartRanking_Click(object sender, EventArgs e)
        {
            frmConfirm confirmForm = new frmConfirm();
            confirmForm.SetConfirmText("Are you sure you want to start the season and finalize the initial rankings? ");
            DialogResult result = confirmForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
                dataStore.SavePlayersToDataStore(playerList);
                appSettings.RankingSet = true;
                dataStore.SaveSettingsToDataStore(appSettings);
                SortPlayers();
                EnableControls();
            }
        }

        private void gridPlayers_CellValidated(object sender, DataGridViewCellEventArgs e)
        {


        }



        //private void CalculateRanks(int rowIndex)
        //{
        //    bool newRowPlaced = false;
        //    if (appSettings.RankingSet == false)
        //    {
        //        DateTime currentRowBirthday = (DateTime)gridPlayers.Rows[rowIndex].Cells[colBirthday.Name].Value;
        //        foreach (DataGridViewRow row in gridPlayers.Rows)
        //        {
        //            int replacedRowIndex = -1;
        //            if (newRowPlaced == false)
        //            {
        //                if ((rowIndex != row.Index) && (row.Index != gridPlayers.NewRowIndex) &&
        //                    ((DateTime)gridPlayers.Rows[row.Index].Cells[colBirthday.Name].Value > currentRowBirthday))
        //                {
        //                    gridPlayers.Rows[rowIndex].Cells[colRank.Name].Value = (int)gridPlayers.Rows[row.Index].Cells[colRank.Name].Value;
        //                    gridPlayers.Rows[row.Index].Cells[colRank.Name].Value = (int)gridPlayers.Rows[row.Index].Cells[colRank.Name].Value + 1;
        //                    replacedRowIndex = row.Index;
        //                    newRowPlaced = true;
        //                }
        //            }
        //            else if ((row.Index != rowIndex) && (row.Index != gridPlayers.NewRowIndex))

        //                gridPlayers.Rows[rowIndex].Cells[colRank.Name].Value = (int)gridPlayers.Rows[rowIndex].Cells[colRank.Name].Value + 1;

        //        }
        //        if (newRowPlaced == false)
        //            gridPlayers.Rows[rowIndex].Cells[colRank.Name].Value = 1;
        //    }
        //    else
        //    {
        //        int currentRowGrade = (int)gridPlayers.Rows[rowIndex].Cells[colGrade.Name].Value;

        //        for (int i = gridPlayers.Rows.Count; i >= 0; i++)
        //        {
        //            if (newRowPlaced == false)
        //            {
        //                if ((int)gridPlayers.Rows[i].Cells[colGrade.Name].Value == currentRowGrade)
        //                {
        //                    gridPlayers.Rows[rowIndex].Cells[colRank.Name].Value = (int)gridPlayers.Rows[i].Cells[colRank.Name].Value + 1;
        //                    newRowPlaced = true;
        //                    for(int n = i + 2; n < gridPlayers.Rows.Count; n++)
        //                    {
        //                        gridPlayers.Rows[n].Cells[colRank.Name].Value = (int)gridPlayers.Rows[n].Cells[colRank.Name].Value + 1;

        //                    }
        //                    break;
        //                }
        //            }
        //        }
        //        if (newRowPlaced == false)
        //            gridPlayers.Rows[rowIndex].Cells[colRank.Name].Value = gridPlayers.Rows.Count - 1;


        //    }

        //}

        private void gridPlayers_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

            //if (appSettings.RankingSet == false)
            //{
            //    bindPlayers.Sort = "Birthday";
            //    SetRanksBasedOnRowPositions();
            //}


        }

        private void SetRanksBasedOnRowPositions()
        {
            foreach (DataGridViewRow row in gridPlayers.Rows)
            {
                if (row.Index != gridPlayers.NewRowIndex)
                    row.Cells[colRank.Name].Value = row.Index + 1;
            }

        }

        private void gridPlayers_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (gridPlayers.Rows.Count > 1)
                gridPlayers.Rows[e.Row.Index].Cells[colRank.Name].Value = (int)gridPlayers.Rows[e.Row.Index - 1].Cells[colRank.Name].Value + 1;
            else
                gridPlayers.Rows[e.Row.Index].Cells[colRank.Name].Value = 1;

            gridPlayers.Rows[e.Row.Index].Cells[colPlayerID.Name].Value = nextPlayerID;
            nextPlayerID++;


        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (gridPlayers.SelectedRows.Count == 1)
            {
                MoveRowUp(gridPlayers.SelectedRows[0].Index);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (gridPlayers.SelectedRows.Count == 1)
            {
                MoveRowDown(gridPlayers.SelectedRows[0].Index);
            }
        }

        private void MoveRowUp(int rowIndex)
        {
            if (rowIndex == gridPlayers.NewRowIndex)
                return;
            if (rowIndex == 0)
                return;

            gridPlayers.Rows[rowIndex - 1].Cells[colRank.Name].Value = (int)gridPlayers.Rows[rowIndex - 1].Cells[colRank.Name].Value + 1;
            gridPlayers.Rows[rowIndex].Cells[colRank.Name].Value = (int)gridPlayers.Rows[rowIndex].Cells[colRank.Name].Value - 1;

            //bindPlayers.Sort = "Rank";
            SortPlayers();
            gridPlayers.Rows[rowIndex - 1].Selected = true;

        }
        private void MoveRowDown(int rowIndex)
        {
            if (rowIndex == gridPlayers.NewRowIndex)
                return;

            if (rowIndex >= gridPlayers.Rows.Count - 2)
                return;


            gridPlayers.Rows[rowIndex + 1].Cells[colRank.Name].Value = (int)gridPlayers.Rows[rowIndex + 1].Cells[colRank.Name].Value - 1;
            gridPlayers.Rows[rowIndex].Cells[colRank.Name].Value = (int)gridPlayers.Rows[rowIndex].Cells[colRank.Name].Value + 1;

            //bindPlayers.Sort = "Rank";
            SortPlayers();
            gridPlayers.Rows[rowIndex + 1].Selected = true;

        }

        private void gridPlayers_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            SetRanksBasedOnRowPositions();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmConfirm confirmForm = new frmConfirm();
            confirmForm.SetConfirmText("Save changes to players? ");
            DialogResult result = confirmForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
                SavePlayers();
            }
            Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (gridPlayers.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter("c:\\KumarsAPL\\Players.csv");

                //write header rows to csv
                for (int i = 0; i <= 3; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(gridPlayers.Columns[i].HeaderText);
                }

                swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= gridPlayers.Rows.Count - 2; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridPlayers.Rows[j];

                    for (int i = 0; i <= 3; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();
            }
        }
    }
}
