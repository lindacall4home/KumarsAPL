namespace KumarsAPL.Forms
{
    partial class frmChallengeGames
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
            this.lblChallengeGames = new System.Windows.Forms.Label();
            this.gridChallengeGames = new System.Windows.Forms.DataGridView();
            this.colGameDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGameBoard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWhitePlayer = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindWhitePlayers = new System.Windows.Forms.BindingSource(this.components);
            this.colBlackPlayer = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindBlackPlayers = new System.Windows.Forms.BindingSource(this.components);
            this.colGameResult = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindChallengeGames = new System.Windows.Forms.BindingSource(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRank = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridChallengeGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindWhitePlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindBlackPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindChallengeGames)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChallengeGames
            // 
            this.lblChallengeGames.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChallengeGames.ForeColor = System.Drawing.Color.Black;
            this.lblChallengeGames.Location = new System.Drawing.Point(26, 9);
            this.lblChallengeGames.Name = "lblChallengeGames";
            this.lblChallengeGames.Size = new System.Drawing.Size(784, 66);
            this.lblChallengeGames.TabIndex = 3;
            this.lblChallengeGames.Text = "Challenge Games";
            this.lblChallengeGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridChallengeGames
            // 
            this.gridChallengeGames.AutoGenerateColumns = false;
            this.gridChallengeGames.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridChallengeGames.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridChallengeGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChallengeGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGameDate,
            this.colGameBoard,
            this.colWhitePlayer,
            this.colBlackPlayer,
            this.colGameResult});
            this.gridChallengeGames.DataSource = this.bindChallengeGames;
            this.gridChallengeGames.GridColor = System.Drawing.Color.DimGray;
            this.gridChallengeGames.Location = new System.Drawing.Point(34, 99);
            this.gridChallengeGames.MultiSelect = false;
            this.gridChallengeGames.Name = "gridChallengeGames";
            this.gridChallengeGames.Size = new System.Drawing.Size(776, 425);
            this.gridChallengeGames.TabIndex = 4;
            this.gridChallengeGames.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridChallengeGames_CellClick);
            this.gridChallengeGames.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridChallengeGames_CellFormatting);
            this.gridChallengeGames.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridChallengeGames_CellLeave);
            this.gridChallengeGames.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridChallengeGames_CellValidating);
            this.gridChallengeGames.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridChallengeGames_CellValueChanged);
            this.gridChallengeGames.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridChallengeGames_DataError);
            this.gridChallengeGames.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridChallengeGames_DefaultValuesNeeded);
            // 
            // colGameDate
            // 
            this.colGameDate.DataPropertyName = "GameDate";
            this.colGameDate.HeaderText = "Date";
            this.colGameDate.Name = "colGameDate";
            // 
            // colGameBoard
            // 
            this.colGameBoard.DataPropertyName = "GameBoard";
            this.colGameBoard.HeaderText = "Board";
            this.colGameBoard.Name = "colGameBoard";
            this.colGameBoard.Width = 60;
            // 
            // colWhitePlayer
            // 
            this.colWhitePlayer.DataPropertyName = "WhitePlayerID";
            this.colWhitePlayer.DataSource = this.bindWhitePlayers;
            this.colWhitePlayer.DisplayMember = "FullName";
            this.colWhitePlayer.HeaderText = "White";
            this.colWhitePlayer.Name = "colWhitePlayer";
            this.colWhitePlayer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWhitePlayer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colWhitePlayer.ValueMember = "PlayerID";
            this.colWhitePlayer.Width = 200;
            // 
            // bindWhitePlayers
            // 
            this.bindWhitePlayers.DataSource = typeof(KumarsAPL.Classes.clsPlayer);
            // 
            // colBlackPlayer
            // 
            this.colBlackPlayer.DataPropertyName = "BlackPlayerID";
            this.colBlackPlayer.DataSource = this.bindBlackPlayers;
            this.colBlackPlayer.DisplayMember = "FullName";
            this.colBlackPlayer.HeaderText = "Black";
            this.colBlackPlayer.Name = "colBlackPlayer";
            this.colBlackPlayer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBlackPlayer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBlackPlayer.ValueMember = "PlayerID";
            this.colBlackPlayer.Width = 200;
            // 
            // bindBlackPlayers
            // 
            this.bindBlackPlayers.DataSource = typeof(KumarsAPL.Classes.clsPlayer);
            // 
            // colGameResult
            // 
            this.colGameResult.DataPropertyName = "GameResult";
            this.colGameResult.HeaderText = "Result";
            this.colGameResult.Items.AddRange(new object[] {
            "None",
            "White",
            "Black",
            "Draw"});
            this.colGameResult.Name = "colGameResult";
            this.colGameResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGameResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bindChallengeGames
            // 
            this.bindChallengeGames.DataSource = typeof(KumarsAPL.Classes.clsChallengeGame);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gold;
            this.btnExit.CausesValidation = false;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(133, 541);
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
            this.btnSave.Location = new System.Drawing.Point(34, 541);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 64);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRank
            // 
            this.btnRank.BackColor = System.Drawing.Color.Gold;
            this.btnRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRank.Location = new System.Drawing.Point(731, 541);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(79, 64);
            this.btnRank.TabIndex = 8;
            this.btnRank.Text = "Rank";
            this.btnRank.UseVisualStyleBackColor = false;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // frmChallengeGames
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(846, 617);
            this.Controls.Add(this.btnRank);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridChallengeGames);
            this.Controls.Add(this.lblChallengeGames);
            this.Name = "frmChallengeGames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.gridChallengeGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindWhitePlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindBlackPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindChallengeGames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChallengeGames;
        private System.Windows.Forms.DataGridView gridChallengeGames;
        private System.Windows.Forms.BindingSource bindChallengeGames;
        private System.Windows.Forms.BindingSource bindWhitePlayers;
        private System.Windows.Forms.BindingSource bindBlackPlayers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGameDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGameBoard;
        private System.Windows.Forms.DataGridViewComboBoxColumn colWhitePlayer;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBlackPlayer;
        private System.Windows.Forms.DataGridViewComboBoxColumn colGameResult;
        private System.Windows.Forms.Button btnRank;
    }
}