namespace KumarsAPL.Forms
{
    partial class frmCheckIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dateCheckIn = new System.Windows.Forms.DateTimePicker();
            this.listPlayers = new System.Windows.Forms.ListBox();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.listPlayersCheckedIn = new System.Windows.Forms.ListBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.txtFindPlayer = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.bindPlayers = new System.Windows.Forms.BindingSource(this.components);
            this.bindCheckedIn = new System.Windows.Forms.BindingSource(this.components);
            this.lblGo = new System.Windows.Forms.Label();
            this.lblChallengeGamePlayers = new System.Windows.Forms.Label();
            this.btnStartGames = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCheckedIn)).BeginInit();
            this.SuspendLayout();
            // 
            // dateCheckIn
            // 
            this.dateCheckIn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateCheckIn.Location = new System.Drawing.Point(542, 67);
            this.dateCheckIn.Name = "dateCheckIn";
            this.dateCheckIn.Size = new System.Drawing.Size(134, 29);
            this.dateCheckIn.TabIndex = 0;
            this.dateCheckIn.Value = new System.DateTime(2016, 9, 12, 19, 42, 31, 0);
            // 
            // listPlayers
            // 
            this.listPlayers.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayers.FormattingEnabled = true;
            this.listPlayers.ItemHeight = 22;
            this.listPlayers.Location = new System.Drawing.Point(14, 182);
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(281, 312);
            this.listPlayers.Sorted = true;
            this.listPlayers.TabIndex = 1;
            this.listPlayers.SelectedValueChanged += new System.EventHandler(this.listPlayers_SelectedValueChanged);
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckIn.ForeColor = System.Drawing.Color.Black;
            this.lblCheckIn.Location = new System.Drawing.Point(1, 30);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(784, 66);
            this.lblCheckIn.TabIndex = 2;
            this.lblCheckIn.Text = "Check-In";
            this.lblCheckIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gold;
            this.btnExit.CausesValidation = false;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(113, 527);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 64);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gold;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(14, 527);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 64);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // listPlayersCheckedIn
            // 
            this.listPlayersCheckedIn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayersCheckedIn.FormattingEnabled = true;
            this.listPlayersCheckedIn.ItemHeight = 22;
            this.listPlayersCheckedIn.Location = new System.Drawing.Point(476, 182);
            this.listPlayersCheckedIn.Name = "listPlayersCheckedIn";
            this.listPlayersCheckedIn.Size = new System.Drawing.Size(281, 312);
            this.listPlayersCheckedIn.TabIndex = 8;
            this.listPlayersCheckedIn.SelectedIndexChanged += new System.EventHandler(this.listPlayersCheckedIn_SelectedIndexChanged);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.Gold;
            this.btnCheckIn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.Location = new System.Drawing.Point(337, 304);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(96, 53);
            this.btnCheckIn.TabIndex = 9;
            this.btnCheckIn.Text = "Check In -->";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // txtFindPlayer
            // 
            this.txtFindPlayer.Location = new System.Drawing.Point(81, 149);
            this.txtFindPlayer.Name = "txtFindPlayer";
            this.txtFindPlayer.Size = new System.Drawing.Size(214, 20);
            this.txtFindPlayer.TabIndex = 11;
            this.txtFindPlayer.TextChanged += new System.EventHandler(this.txtFindPlayer_TextChanged);
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFind.ForeColor = System.Drawing.Color.White;
            this.lblFind.Location = new System.Drawing.Point(12, 144);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(63, 26);
            this.lblFind.TabIndex = 10;
            this.lblFind.Text = "Find:";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(730, 153);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(26, 23);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "<--";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Gold;
            this.btnStart.Location = new System.Drawing.Point(682, 67);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(31, 29);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Go";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // bindPlayers
            // 
            this.bindPlayers.AllowNew = false;
            // 
            // lblGo
            // 
            this.lblGo.AutoSize = true;
            this.lblGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGo.ForeColor = System.Drawing.Color.White;
            this.lblGo.Location = new System.Drawing.Point(538, 44);
            this.lblGo.Name = "lblGo";
            this.lblGo.Size = new System.Drawing.Size(184, 20);
            this.lblGo.TabIndex = 14;
            this.lblGo.Text = "Enter date and press Go";
            // 
            // lblChallengeGamePlayers
            // 
            this.lblChallengeGamePlayers.AutoSize = true;
            this.lblChallengeGamePlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChallengeGamePlayers.ForeColor = System.Drawing.Color.White;
            this.lblChallengeGamePlayers.Location = new System.Drawing.Point(472, 156);
            this.lblChallengeGamePlayers.Name = "lblChallengeGamePlayers";
            this.lblChallengeGamePlayers.Size = new System.Drawing.Size(184, 20);
            this.lblChallengeGamePlayers.TabIndex = 15;
            this.lblChallengeGamePlayers.Text = "*Challenge game players";
            // 
            // btnStartGames
            // 
            this.btnStartGames.BackColor = System.Drawing.Color.Gold;
            this.btnStartGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGames.Location = new System.Drawing.Point(682, 527);
            this.btnStartGames.Name = "btnStartGames";
            this.btnStartGames.Size = new System.Drawing.Size(79, 64);
            this.btnStartGames.TabIndex = 16;
            this.btnStartGames.Text = "Pair Players";
            this.btnStartGames.UseVisualStyleBackColor = false;
            this.btnStartGames.Click += new System.EventHandler(this.btnStartGames_Click);
            // 
            // btnGames
            // 
            this.btnGames.BackColor = System.Drawing.Color.Gold;
            this.btnGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGames.Location = new System.Drawing.Point(577, 527);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(79, 64);
            this.btnGames.TabIndex = 17;
            this.btnGames.Text = "Games";
            this.btnGames.UseVisualStyleBackColor = false;
            this.btnGames.Click += new System.EventHandler(this.btnGames_Click);
            // 
            // frmCheckIn
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(789, 603);
            this.ControlBox = false;
            this.Controls.Add(this.btnGames);
            this.Controls.Add(this.btnStartGames);
            this.Controls.Add(this.lblChallengeGamePlayers);
            this.Controls.Add(this.lblGo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txtFindPlayer);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.listPlayersCheckedIn);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listPlayers);
            this.Controls.Add(this.dateCheckIn);
            this.Controls.Add(this.lblCheckIn);
            this.Name = "frmCheckIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCheckIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCheckedIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateCheckIn;
        private System.Windows.Forms.ListBox listPlayers;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox listPlayersCheckedIn;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.TextBox txtFindPlayer;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.BindingSource bindPlayers;
        private System.Windows.Forms.BindingSource bindCheckedIn;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblGo;
        private System.Windows.Forms.Label lblChallengeGamePlayers;
        private System.Windows.Forms.Button btnStartGames;
        private System.Windows.Forms.Button btnGames;
    }
}