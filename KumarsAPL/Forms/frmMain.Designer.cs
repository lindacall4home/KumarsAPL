namespace KumarsAPL.Forms
{
    partial class frmMain
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
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMeetings = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(229, 60);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(410, 43);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.Text = "Eldorado Chess Club!!!";
            // 
            // btnPlayers
            // 
            this.btnPlayers.BackColor = System.Drawing.Color.Gold;
            this.btnPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayers.Location = new System.Drawing.Point(398, 232);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(96, 96);
            this.btnPlayers.TabIndex = 3;
            this.btnPlayers.Text = "Players";
            this.btnPlayers.UseVisualStyleBackColor = false;
            this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::KumarsAPL.Properties.Resources.pawn;
            this.pictureBox2.Location = new System.Drawing.Point(10, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(196, 275);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KumarsAPL.Properties.Resources.ELDORADO_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(661, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 118);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gold;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(500, 331);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 96);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMeetings
            // 
            this.btnMeetings.BackColor = System.Drawing.Color.Gold;
            this.btnMeetings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeetings.Location = new System.Drawing.Point(296, 139);
            this.btnMeetings.Name = "btnMeetings";
            this.btnMeetings.Size = new System.Drawing.Size(96, 96);
            this.btnMeetings.TabIndex = 5;
            this.btnMeetings.Text = "Meetings";
            this.btnMeetings.UseVisualStyleBackColor = false;
            this.btnMeetings.Click += new System.EventHandler(this.btnMeetings_Click);
            // 
            // btnGames
            // 
            this.btnGames.BackColor = System.Drawing.Color.Gold;
            this.btnGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGames.Location = new System.Drawing.Point(500, 139);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(96, 96);
            this.btnGames.TabIndex = 6;
            this.btnGames.Text = "Games";
            this.btnGames.UseVisualStyleBackColor = false;
            this.btnGames.Click += new System.EventHandler(this.btnGames_Click);
            // 
            // btnResults
            // 
            this.btnResults.BackColor = System.Drawing.Color.Gold;
            this.btnResults.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResults.Location = new System.Drawing.Point(296, 331);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(96, 96);
            this.btnResults.TabIndex = 7;
            this.btnResults.Text = "Results";
            this.btnResults.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(796, 462);
            this.ControlBox = false;
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnMeetings);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPlayers);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGames);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnPlayers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMeetings;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnResults;
    }
}