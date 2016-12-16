using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using KumarsAPL.Forms;

namespace KumarsAPL.Classes
{
    public class clsXMLDataStore
    {
        private const string DataDirectory = "C:\\KumarsAPL\\Data";
        private const string PlayerDirectory = "\\Players";
        private const string MeetingDirectory = "\\Meetings";
        private const string GameDirectory = "\\Games";
        private const string BackupDirectory = "\\Backup";
        // private const string PlayerBackupDirectory = "C:\\KumarsAPL\\Data\\2016-17\\Backup\\Players";
        //private const string MeetingBackupDirectory = "C:\\KumarsAPL\\Data\\2016-17\\Backup\\Meetings";
        // private const string GameBackupDirectory = "C:\\KumarsAPL\\Data\\2016-17\\Backup\\Games";
        //private const string GameFileName = "C:\\KumarsAPL\\Data\\2016-17\\Games\\Games_2016-17.xml";
        private const string SettingsDirectory = "\\Settings";
        private const string SettingsFile = "\\Settings.xml";
        private const string GamesFile = "\\games_";
        private const string MeetingsFile = "\\meeting_";
        private const string GlobalSettingsFile = "C:\\KumarsAPL\\Data\\GlobalSettings\\GlobalSettings.xml";

        private clsGlobalSettings globalSettings;

        public clsXMLDataStore()
        {
            try
            {

                System.IO.FileStream fs = new System.IO.FileStream(GlobalSettingsFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                XmlSerializer serializer = new XmlSerializer(typeof(clsGlobalSettings));
                globalSettings = (clsGlobalSettings)serializer.Deserialize(fs);
                fs.Close();


            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error loading global settings: " + ex.Message);
                messageForm.ShowDialog();
                
            }

        }

        private string GetCurrentYearDataDirectory()
        {
            return DataDirectory + "\\" + globalSettings.CurrentYear;
        }

        private string GetCurrentYearPlayerDirectory()
        {
            return GetCurrentYearDataDirectory() + PlayerDirectory;
        }

        private string GetCurrentYearMeetingDirectory()
        {
            return GetCurrentYearDataDirectory() + MeetingDirectory;
        }

        private string GetCurrentYearGameDirectory()
        {
            return GetCurrentYearDataDirectory() + GameDirectory;
        }

        private string GetCurrentYearGameFileName()
        {
            return GetCurrentYearGameDirectory() + GamesFile + globalSettings.CurrentYear + ".xml";
        }

        private string GetCurrentYearBackupDirectory()
        {
            return GetCurrentYearDataDirectory() + BackupDirectory;
        }

        private string GetCurrentYearPlayerBackupDirectory()
        {
            return GetCurrentYearBackupDirectory() + PlayerDirectory;
        }

        private string GetCurrentYearMeetingBackupDirectory()
        {
            return GetCurrentYearBackupDirectory() + MeetingDirectory;
        }

        private string GetCurrentYearGameBackupDirectory()
        {
            return GetCurrentYearBackupDirectory() + GameDirectory;
        }

        private string GetCurrentYearGameBackupFileName()
        {
            return GetCurrentYearGameBackupDirectory() + GamesFile + globalSettings.CurrentYear + ".xml";
        }

        private string GetCurrentYearSettingsDirectory()
        {
            return GetCurrentYearDataDirectory() + SettingsDirectory;
        }

        private string GetCurrentYearSettingsFile()
        {
            return GetCurrentYearSettingsDirectory() + SettingsFile;
        }


        public clsSettings LoadSettingsFromDataStore()
        {
            clsSettings appSettings = new clsSettings();

            try
            {

                System.IO.FileStream fs = new System.IO.FileStream(GetCurrentYearSettingsFile(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                XmlSerializer serializer = new XmlSerializer(typeof(clsSettings));
                appSettings = (clsSettings)serializer.Deserialize(fs);
                fs.Close();


            }
            catch (Exception ex)
            {

                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error loading settings: " + ex.Message);
                messageForm.ShowDialog();
                
            }

            return appSettings;
        }

        public bool SaveSettingsToDataStore(clsSettings appSettings)
        {
            try
            {
                if (System.IO.Directory.Exists(GetCurrentYearSettingsDirectory()) == false)
                {
                    System.IO.Directory.CreateDirectory(GetCurrentYearSettingsDirectory());
                }

                using (System.IO.FileStream fs = new System.IO.FileStream(GetCurrentYearSettingsFile(), System.IO.FileMode.Create))
                {
                    XmlSerializer s = new XmlSerializer(appSettings.GetType());
                    s.Serialize(fs, appSettings);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error saving settings: " + ex.Message);
                messageForm.ShowDialog();
                return false;
            }

            return true;
        }


        public List<clsPlayer> LoadPlayersFromDataStore()
        {
            //SortableBindingList<clsPlayer> playerList = new SortableBindingList<clsPlayer>();
            List<clsPlayer> playerList = new List<clsPlayer>();

            if (System.IO.Directory.Exists(GetCurrentYearPlayerDirectory()) == true)
            { 
                string[] fileList = System.IO.Directory.GetFiles(GetCurrentYearPlayerDirectory());
                foreach (string filePath in fileList)
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                    string ext = System.IO.Path.GetExtension(filePath);
                    if (fileName.Contains("player_") && ext.Equals(".xml"))
                    {
                        clsPlayer retrievedPlayer = LoadPlayer_XML(filePath);
                        if (retrievedPlayer != null)
                            playerList.Add(retrievedPlayer);
                    }
                }
            }
            return playerList;
        }

        private clsPlayer LoadPlayer_XML(string filePath)
        {
            try
             {

                System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                XmlSerializer serializer = new XmlSerializer(typeof(clsPlayer));
                clsPlayer retrievedPlayer = (clsPlayer)serializer.Deserialize(fs);
                fs.Close();
                return retrievedPlayer;

            }
            catch(Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error loading player: " + ex.Message);
                messageForm.ShowDialog();
            }

            return null;
        }



    public bool SavePlayersToDataStore(List<clsPlayer> playerList)
    {
            //DeletePlayerFromDataStore(playerToSave);
            bool returnValue = true;
            try
            {
                if (System.IO.Directory.Exists(GetCurrentYearPlayerBackupDirectory()) == true)
                {

                    Directory.Delete(GetCurrentYearPlayerBackupDirectory(), true);


                }
                if (System.IO.Directory.Exists(GetCurrentYearBackupDirectory()) == false)
                    System.IO.Directory.CreateDirectory(GetCurrentYearBackupDirectory());

                if (System.IO.Directory.Exists(GetCurrentYearPlayerDirectory()) == true)
                {
                    System.IO.Directory.Move(GetCurrentYearPlayerDirectory(), GetCurrentYearPlayerBackupDirectory());
                }
                System.IO.Directory.CreateDirectory(GetCurrentYearPlayerDirectory());
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error creating player directory: " + ex.Message);
                messageForm.ShowDialog();
                returnValue = false;
            }
            foreach(clsPlayer playerToSave in playerList)
            {
                string fileName = "player_" + playerToSave.FullName + ".xml";
                string filePath = GetCurrentYearPlayerDirectory() + "\\" + fileName;

                if (SavePlayer_XML(playerToSave, filePath) == false)
                    returnValue = false;
   
            }
            return returnValue;
        }
        private bool SavePlayer_XML(clsPlayer playerToSave, string filepath)
        {
            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.Create))
                {
                    XmlSerializer s = new XmlSerializer(playerToSave.GetType());
                    s.Serialize(fs, playerToSave);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error saving player: " + ex.Message);
                messageForm.ShowDialog();
                return false;
            }

            return true;
         }

        public clsChessClubMeeting GetMeetingByDate(DateTime meetingDate)
        { 
           
            if (System.IO.Directory.Exists(GetCurrentYearMeetingDirectory()) == true)
            {
                string[] fileList = System.IO.Directory.GetFiles(GetCurrentYearMeetingDirectory());
                foreach (string filePath in fileList)
                {
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                    string dateString = meetingDate.ToShortDateString();
                    dateString = dateString.Replace("/", "-");
                    string ext = System.IO.Path.GetExtension(filePath);
                    if (fileName.Contains(dateString) && ext.Equals(".xml"))
                    {
                        clsChessClubMeeting retrievedMeeting = LoadMeeting_XML(filePath);
                        return retrievedMeeting;
                    }
                }
            }
            return null;
        }

       

        private clsChessClubMeeting LoadMeeting_XML(string filePath)
        {
            try
            {

                System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                XmlSerializer serializer = new XmlSerializer(typeof(clsChessClubMeeting));
                clsChessClubMeeting retrievedMeeting = (clsChessClubMeeting)serializer.Deserialize(fs);
                fs.Close();
                return retrievedMeeting;

            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error loading club meetings: " + ex.Message);
                messageForm.ShowDialog();
            }

            return null;
        }
        public bool SaveMeetingToDataStore(clsChessClubMeeting meetingToSave)
        {
            bool returnValue = true;
            string fileName = GetCurrentYearMeetingDirectory() + MeetingsFile + meetingToSave.MeetingDate.ToShortDateString() + ".xml";
            fileName = fileName.Replace("/", "-");
            string backupFileName = GetCurrentYearMeetingBackupDirectory() + MeetingsFile + meetingToSave.MeetingDate.ToShortDateString() + ".xml";
            backupFileName = backupFileName.Replace("/", "-");
            try
            {
                if (System.IO.Directory.Exists(GetCurrentYearMeetingBackupDirectory()) == false)
                    Directory.CreateDirectory(GetCurrentYearMeetingBackupDirectory());
                else if(System.IO.File.Exists(fileName) == true)
                {
                    if (System.IO.File.Exists(backupFileName) == true)
                        System.IO.File.Delete(backupFileName);
                      System.IO.File.Move(fileName, backupFileName);
                }

                if (System.IO.Directory.Exists(GetCurrentYearMeetingDirectory()) == false)
                  System.IO.Directory.CreateDirectory(GetCurrentYearMeetingDirectory());
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error backing up club meeting: " + ex.Message);
                messageForm.ShowDialog();
                returnValue = false;
            }
           
           if (SaveMeeting_XML(meetingToSave, fileName) == false)
                returnValue = false;

            try
            {
                clsSettings settings = LoadSettingsFromDataStore();
                if(!settings.meetingDates.Contains(meetingToSave.MeetingDate))
                {
                    settings.meetingDates.Add(meetingToSave.MeetingDate);
                    SaveSettingsToDataStore(settings);
                }

            }
            catch (Exception ex)
            {

                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error updating meeting list in settings: " + ex.Message);
                messageForm.ShowDialog();
                returnValue = false;

            }
                return returnValue;
        }
        private bool SaveMeeting_XML(clsChessClubMeeting meetingToSave, string filepath)
        {
            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.Create))
                {
                    XmlSerializer s = new XmlSerializer(meetingToSave.GetType());
                    s.Serialize(fs, meetingToSave);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error saving club meeting info: " + ex.Message);
                messageForm.ShowDialog();
                return false;
            }

            return true;
        }

       public clsChessClubMeeting GetPreviousMeetingFromDataStore(DateTime meetingDate)
       {
            try
            {
                clsSettings settings = LoadSettingsFromDataStore();

                DateTime previousMeetingDate = new DateTime(1900, 1, 1);

                foreach(DateTime date in settings.meetingDates)
                {
                    if ((date > previousMeetingDate) && (date < meetingDate))
                        previousMeetingDate = date;
                }

                return GetMeetingByDate(previousMeetingDate);
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error getting previous meeting info: " + ex.Message);
                messageForm.ShowDialog();
                return null;
            }
            
        }
        public clsChallengeGameList LoadOutsideGamesFromDataStore()
        {

            try
            {
                string currentYearGameFile = GetCurrentYearGameFileName();

                if (System.IO.File.Exists(currentYearGameFile) == false)
                    return new clsChallengeGameList();

                System.IO.FileStream fs = new System.IO.FileStream(currentYearGameFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                XmlSerializer serializer = new XmlSerializer(typeof(clsChallengeGameList));
                clsChallengeGameList gameList = (clsChallengeGameList)serializer.Deserialize(fs);
                fs.Close();
                if (gameList == null)
                    return new clsChallengeGameList();
                else
                return gameList;

            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error loading challenge games: " + ex.Message);
                messageForm.ShowDialog();
                return new clsChallengeGameList();
            }

      
        }


        public clsChallengeGameList LoadAllGamesFromDataStore()
        {
            clsChallengeGameList allGames = new clsChallengeGameList();
            try
            {

                allGames.AddRange(LoadOutsideGamesFromDataStore());

                if (System.IO.Directory.Exists(GetCurrentYearMeetingDirectory()) == true)
                {
                    string[] fileList = System.IO.Directory.GetFiles(GetCurrentYearMeetingDirectory());
                    foreach (string filePath in fileList)
                    {
                        string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                        if (fileName.Contains(GamesFile) )
                        {
                            clsChessClubMeeting retrievedMeeting = LoadMeeting_XML(filePath);
                            allGames.AddRange(retrievedMeeting.listChallengeGames);
                        }
                    }
                }
                return allGames;
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error loading all challenge games: " + ex.Message);
                messageForm.ShowDialog();
                return new clsChallengeGameList();
            }


        }

        public bool SaveChallengeGamesToDataStore(clsChallengeGameList gameList)
        {
            string currentYearGameBackupDirectory = GetCurrentYearGameBackupDirectory();
            string currentYearGameDirectory = GetCurrentYearGameDirectory();
            string currentYearGameFile = GetCurrentYearGameFileName();
            string currentYearBackupGameFile = GetCurrentYearGameBackupFileName();

            try
            {
                if (System.IO.Directory.Exists(currentYearGameBackupDirectory) == true)
                {
                    if(System.IO.File.Exists(currentYearBackupGameFile))
                        System.IO.File.Delete(currentYearBackupGameFile);
                }
                else
                    System.IO.Directory.CreateDirectory(currentYearGameBackupDirectory);
                //                if (System.IO.Directory.Exists(GetCurrentYearBackupDirectory()) == false)
                if (System.IO.Directory.Exists(currentYearGameDirectory) == true)
                {
                    if (System.IO.File.Exists(currentYearGameFile) == true)
                    {
                        System.IO.Directory.Move(currentYearGameFile, currentYearBackupGameFile);
                    }
                }
                else
                   System.IO.Directory.CreateDirectory(currentYearGameDirectory);
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error creating challenge game directory: " + ex.Message);
                messageForm.ShowDialog();
                return false;
            }

            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(currentYearGameFile, System.IO.FileMode.Create))
                {
                    XmlSerializer s = new XmlSerializer(gameList.GetType());
                    s.Serialize(fs, gameList);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                frmMessage messageForm = new frmMessage();
                messageForm.SetMessageText("Error saving challenge games: " + ex.Message);
                messageForm.ShowDialog();
                return false;
            }

            return true;
 
        }

    
    }
}
