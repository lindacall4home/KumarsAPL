namespace KumarsAPL.Forms
{
    partial class frmPlayers
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
            this.lblPlayers = new System.Windows.Forms.Label();
            this.gridPlayers = new System.Windows.Forms.DataGridView();
            this.colRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTShirtSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TurnedInForm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindPlayers = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblFind = new System.Windows.Forms.Label();
            this.txtFindPlayer = new System.Windows.Forms.TextBox();
            this.btnStartRanking = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayers
            // 
            this.lblPlayers.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayers.ForeColor = System.Drawing.Color.Black;
            this.lblPlayers.Location = new System.Drawing.Point(12, 19);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(776, 66);
            this.lblPlayers.TabIndex = 0;
            this.lblPlayers.Text = "Players";
            this.lblPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridPlayers
            // 
            this.gridPlayers.AutoGenerateColumns = false;
            this.gridPlayers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRank,
            this.colPlayerID,
            this.colFirstName,
            this.colLastName,
            this.colFullName,
            this.colGrade,
            this.colBirthday,
            this.colAge,
            this.colGender,
            this.colTShirtSize,
            this.TurnedInForm,
            this.Paid});
            this.gridPlayers.DataSource = this.bindPlayers;
            this.gridPlayers.GridColor = System.Drawing.Color.DimGray;
            this.gridPlayers.Location = new System.Drawing.Point(12, 132);
            this.gridPlayers.MultiSelect = false;
            this.gridPlayers.Name = "gridPlayers";
            this.gridPlayers.Size = new System.Drawing.Size(852, 392);
            this.gridPlayers.TabIndex = 1;
            this.gridPlayers.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPlayers_CellValidated);
            this.gridPlayers.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridPlayers_DefaultValuesNeeded);
            this.gridPlayers.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPlayers_RowValidated);
            this.gridPlayers.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridPlayers_UserDeletedRow);
            // 
            // colRank
            // 
            this.colRank.DataPropertyName = "Rank";
            this.colRank.HeaderText = "Rank";
            this.colRank.Name = "colRank";
            this.colRank.ReadOnly = true;
            this.colRank.Width = 50;
            // 
            // colPlayerID
            // 
            this.colPlayerID.DataPropertyName = "PlayerID";
            this.colPlayerID.HeaderText = "Player ID";
            this.colPlayerID.Name = "colPlayerID";
            this.colPlayerID.Visible = false;
            // 
            // colFirstName
            // 
            this.colFirstName.DataPropertyName = "FirstName";
            this.colFirstName.HeaderText = "First Name";
            this.colFirstName.MaxInputLength = 50;
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Width = 200;
            // 
            // colLastName
            // 
            this.colLastName.DataPropertyName = "LastName";
            this.colLastName.HeaderText = "Last Name";
            this.colLastName.MaxInputLength = 50;
            this.colLastName.Name = "colLastName";
            this.colLastName.Width = 200;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.HeaderText = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Visible = false;
            // 
            // colGrade
            // 
            this.colGrade.DataPropertyName = "Grade";
            this.colGrade.HeaderText = "Grade";
            this.colGrade.Name = "colGrade";
            this.colGrade.Width = 40;
            // 
            // colBirthday
            // 
            this.colBirthday.DataPropertyName = "Birthday";
            this.colBirthday.HeaderText = "Birthday";
            this.colBirthday.Name = "colBirthday";
            this.colBirthday.Width = 85;
            // 
            // colAge
            // 
            this.colAge.DataPropertyName = "Age";
            this.colAge.HeaderText = "Age";
            this.colAge.Name = "colAge";
            this.colAge.ReadOnly = true;
            this.colAge.Visible = false;
            this.colAge.Width = 40;
            // 
            // colGender
            // 
            this.colGender.DataPropertyName = "Gender";
            this.colGender.HeaderText = "Gender";
            this.colGender.Items.AddRange(new object[] {
            "F",
            "M"});
            this.colGender.Name = "colGender";
            this.colGender.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGender.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colGender.Width = 60;
            // 
            // colTShirtSize
            // 
            this.colTShirtSize.DataPropertyName = "TShirtSize";
            this.colTShirtSize.HeaderText = "T-Shirt Size";
            this.colTShirtSize.MaxInputLength = 4;
            this.colTShirtSize.Name = "colTShirtSize";
            this.colTShirtSize.Width = 50;
            // 
            // TurnedInForm
            // 
            this.TurnedInForm.DataPropertyName = "TurnedInForm";
            this.TurnedInForm.HeaderText = "Form";
            this.TurnedInForm.Name = "TurnedInForm";
            this.TurnedInForm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TurnedInForm.Width = 50;
            // 
            // Paid
            // 
            this.Paid.DataPropertyName = "Paid";
            this.Paid.HeaderText = "Paid";
            this.Paid.Name = "Paid";
            this.Paid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Paid.Width = 50;
            // 
            // bindPlayers
            // 
            this.bindPlayers.DataSource = typeof(KumarsAPL.Classes.clsPlayer);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Gold;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(12, 541);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 64);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gold;
            this.btnExit.CausesValidation = false;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(210, 541);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 64);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFind.ForeColor = System.Drawing.Color.White;
            this.lblFind.Location = new System.Drawing.Point(17, 98);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(63, 26);
            this.lblFind.TabIndex = 7;
            this.lblFind.Text = "Find:";
            // 
            // txtFindPlayer
            // 
            this.txtFindPlayer.Location = new System.Drawing.Point(86, 103);
            this.txtFindPlayer.Name = "txtFindPlayer";
            this.txtFindPlayer.Size = new System.Drawing.Size(214, 20);
            this.txtFindPlayer.TabIndex = 8;
            this.txtFindPlayer.TextChanged += new System.EventHandler(this.txtFindPlayer_TextChanged);
            // 
            // btnStartRanking
            // 
            this.btnStartRanking.BackColor = System.Drawing.Color.Gold;
            this.btnStartRanking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartRanking.Location = new System.Drawing.Point(788, 77);
            this.btnStartRanking.Name = "btnStartRanking";
            this.btnStartRanking.Size = new System.Drawing.Size(76, 49);
            this.btnStartRanking.TabIndex = 9;
            this.btnStartRanking.Text = "Start Season";
            this.btnStartRanking.UseVisualStyleBackColor = false;
            this.btnStartRanking.Click += new System.EventHandler(this.btnStartRanking_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(325, 98);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(45, 28);
            this.btnUp.TabIndex = 11;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(376, 98);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(45, 28);
            this.btnDown.TabIndex = 12;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Gold;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(111, 541);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 64);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmPlayers
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(884, 617);
            this.ControlBox = false;
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnStartRanking);
            this.Controls.Add(this.txtFindPlayer);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridPlayers);
            this.Controls.Add(this.lblPlayers);
            this.Name = "frmPlayers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.gridPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.DataGridView gridPlayers;
        private System.Windows.Forms.BindingSource bindPlayers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.TextBox txtFindPlayer;
        private System.Windows.Forms.Button btnStartRanking;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewComboBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTShirtSize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TurnedInForm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Paid;
        private System.Windows.Forms.Button btnExport;
    }
}