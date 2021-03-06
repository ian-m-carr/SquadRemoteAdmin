﻿namespace Squad.Admin.Console.Forms
{
    partial class frmMainConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainConsole));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpPlayerList = new System.Windows.Forms.GroupBox();
            this.grdPlayers = new System.Windows.Forms.DataGridView();
            this.cSlot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPlayer = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cSteam64Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDisconnect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.lblFindPlayer = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpConsole = new System.Windows.Forms.GroupBox();
            this.btnClearConsole = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.MTQueryPort = new System.Windows.Forms.MaskedTextBox();
            this.txtServerPort = new System.Windows.Forms.MaskedTextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRconPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblConnectedTo = new System.Windows.Forms.Label();
            this.lblMapLabel = new System.Windows.Forms.Label();
            this.lblMapName = new System.Windows.Forms.Label();
            this.lblPlayerCountLabel = new System.Windows.Forms.Label();
            this.lblPlayerCount = new System.Windows.Forms.Label();
            this.grpMapManagement = new System.Windows.Forms.GroupBox();
            this.RBPostScriptum = new System.Windows.Forms.RadioButton();
            this.RBSquad = new System.Windows.Forms.RadioButton();
            this.RestartMatchButton = new System.Windows.Forms.Button();
            this.EndMatchButton = new System.Windows.Forms.Button();
            this.SetNextMapButton = new System.Windows.Forms.Button();
            this.ChangeMapButton = new System.Windows.Forms.Button();
            this.MapNamesCombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpPlayerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlayers)).BeginInit();
            this.grpConsole.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpMapManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // grpPlayerList
            // 
            this.grpPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpPlayerList.Controls.Add(this.grdPlayers);
            this.grpPlayerList.Controls.Add(this.txtPlayerName);
            this.grpPlayerList.Controls.Add(this.lblFindPlayer);
            this.grpPlayerList.Controls.Add(this.btnRefresh);
            this.grpPlayerList.Enabled = false;
            this.grpPlayerList.Location = new System.Drawing.Point(12, 133);
            this.grpPlayerList.Name = "grpPlayerList";
            this.grpPlayerList.Size = new System.Drawing.Size(639, 711);
            this.grpPlayerList.TabIndex = 0;
            this.grpPlayerList.TabStop = false;
            this.grpPlayerList.Text = "Player List";
            // 
            // grdPlayers
            // 
            this.grdPlayers.AllowUserToAddRows = false;
            this.grdPlayers.AllowUserToDeleteRows = false;
            this.grdPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSlot,
            this.cPlayer,
            this.cSteam64Id,
            this.cStatus,
            this.cDisconnect});
            this.grdPlayers.Location = new System.Drawing.Point(9, 46);
            this.grdPlayers.Name = "grdPlayers";
            this.grdPlayers.ReadOnly = true;
            this.grdPlayers.Size = new System.Drawing.Size(624, 617);
            this.grdPlayers.TabIndex = 11;
            // 
            // cSlot
            // 
            this.cSlot.HeaderText = "Slot";
            this.cSlot.Name = "cSlot";
            this.cSlot.ReadOnly = true;
            this.cSlot.Width = 40;
            // 
            // cPlayer
            // 
            this.cPlayer.HeaderText = "Player";
            this.cPlayer.Name = "cPlayer";
            this.cPlayer.ReadOnly = true;
            this.cPlayer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cPlayer.Width = 160;
            // 
            // cSteam64Id
            // 
            this.cSteam64Id.HeaderText = "Steam64Id";
            this.cSteam64Id.Name = "cSteam64Id";
            this.cSteam64Id.ReadOnly = true;
            this.cSteam64Id.Width = 165;
            // 
            // cStatus
            // 
            this.cStatus.HeaderText = "Status";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            // 
            // cDisconnect
            // 
            this.cDisconnect.HeaderText = "Disconnected";
            this.cDisconnect.Name = "cDisconnect";
            this.cDisconnect.ReadOnly = true;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(71, 20);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(239, 20);
            this.txtPlayerName.TabIndex = 2;
            this.txtPlayerName.Visible = false;
            // 
            // lblFindPlayer
            // 
            this.lblFindPlayer.AutoSize = true;
            this.lblFindPlayer.Location = new System.Drawing.Point(6, 23);
            this.lblFindPlayer.Name = "lblFindPlayer";
            this.lblFindPlayer.Size = new System.Drawing.Size(59, 13);
            this.lblFindPlayer.TabIndex = 1;
            this.lblFindPlayer.Text = "Find Player";
            this.lblFindPlayer.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(482, 669);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(151, 36);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh Player List";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpConsole
            // 
            this.grpConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConsole.Controls.Add(this.btnClearConsole);
            this.grpConsole.Controls.Add(this.label2);
            this.grpConsole.Controls.Add(this.lstHistory);
            this.grpConsole.Controls.Add(this.label1);
            this.grpConsole.Controls.Add(this.btnClear);
            this.grpConsole.Controls.Add(this.btnSend);
            this.grpConsole.Controls.Add(this.txtResponse);
            this.grpConsole.Controls.Add(this.txtCommand);
            this.grpConsole.Enabled = false;
            this.grpConsole.Location = new System.Drawing.Point(657, 195);
            this.grpConsole.Name = "grpConsole";
            this.grpConsole.Size = new System.Drawing.Size(482, 649);
            this.grpConsole.TabIndex = 0;
            this.grpConsole.TabStop = false;
            this.grpConsole.Text = "Console Command";
            // 
            // btnClearConsole
            // 
            this.btnClearConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearConsole.Location = new System.Drawing.Point(367, 607);
            this.btnClearConsole.Name = "btnClearConsole";
            this.btnClearConsole.Size = new System.Drawing.Size(109, 36);
            this.btnClearConsole.TabIndex = 8;
            this.btnClearConsole.Text = "Clear Console";
            this.btnClearConsole.UseVisualStyleBackColor = true;
            this.btnClearConsole.Click += new System.EventHandler(this.btnClearConsole_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Command History:";
            // 
            // lstHistory
            // 
            this.lstHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.Location = new System.Drawing.Point(6, 108);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(470, 56);
            this.lstHistory.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server Console Output:";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(367, 170);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(109, 36);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear History";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(367, 46);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(109, 36);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send Command";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtResponse
            // 
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.BackColor = System.Drawing.Color.Black;
            this.txtResponse.ForeColor = System.Drawing.Color.Lime;
            this.txtResponse.Location = new System.Drawing.Point(6, 221);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(470, 380);
            this.txtResponse.TabIndex = 7;
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCommand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCommand.Location = new System.Drawing.Point(6, 20);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(470, 20);
            this.txtCommand.TabIndex = 1;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(1099, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(40, 40);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtServerIP);
            this.panel1.Controls.Add(this.MTQueryPort);
            this.panel1.Controls.Add(this.txtServerPort);
            this.panel1.Controls.Add(this.chkShowPassword);
            this.panel1.Controls.Add(this.btnDisconnect);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.txtDisplayName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblDisplayName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtRconPassword);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 115);
            this.panel1.TabIndex = 0;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(278, 10);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(102, 20);
            this.txtServerIP.TabIndex = 2;
            this.txtServerIP.TextChanged += new System.EventHandler(this.txtServerIP_TextChanged);
            // 
            // MTQueryPort
            // 
            this.MTQueryPort.Location = new System.Drawing.Point(278, 85);
            this.MTQueryPort.Mask = "#####";
            this.MTQueryPort.Name = "MTQueryPort";
            this.MTQueryPort.Size = new System.Drawing.Size(49, 20);
            this.MTQueryPort.TabIndex = 10;
            this.MTQueryPort.TextChanged += new System.EventHandler(this.MTQueryPort_TextChanged);
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(424, 10);
            this.txtServerPort.Mask = "#####";
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(49, 20);
            this.txtServerPort.TabIndex = 4;
            this.txtServerPort.TextChanged += new System.EventHandler(this.txtServerPort_TextChanged);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(394, 36);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(102, 17);
            this.chkShowPassword.TabIndex = 9;
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(515, 48);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(109, 36);
            this.btnDisconnect.TabIndex = 10;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(515, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(109, 36);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(278, 60);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(162, 20);
            this.txtDisplayName.TabIndex = 8;
            this.txtDisplayName.TextChanged += new System.EventHandler(this.txtDisplayName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Query Port";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(188, 63);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(70, 13);
            this.lblDisplayName.TabIndex = 7;
            this.lblDisplayName.Text = "Admin Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Password:";
            // 
            // txtRconPassword
            // 
            this.txtRconPassword.Location = new System.Drawing.Point(278, 34);
            this.txtRconPassword.Name = "txtRconPassword";
            this.txtRconPassword.Size = new System.Drawing.Size(102, 20);
            this.txtRconPassword.TabIndex = 6;
            this.txtRconPassword.UseSystemPasswordChar = true;
            this.txtRconPassword.TextChanged += new System.EventHandler(this.txtRconPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Server IP:";
            // 
            // lblConnectedTo
            // 
            this.lblConnectedTo.AutoSize = true;
            this.lblConnectedTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectedTo.Location = new System.Drawing.Point(663, 12);
            this.lblConnectedTo.Name = "lblConnectedTo";
            this.lblConnectedTo.Size = new System.Drawing.Size(0, 17);
            this.lblConnectedTo.TabIndex = 12;
            // 
            // lblMapLabel
            // 
            this.lblMapLabel.AutoSize = true;
            this.lblMapLabel.Location = new System.Drawing.Point(663, 41);
            this.lblMapLabel.Name = "lblMapLabel";
            this.lblMapLabel.Size = new System.Drawing.Size(68, 13);
            this.lblMapLabel.TabIndex = 13;
            this.lblMapLabel.Text = "Current Map:";
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Location = new System.Drawing.Point(737, 41);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(0, 13);
            this.lblMapName.TabIndex = 14;
            // 
            // lblPlayerCountLabel
            // 
            this.lblPlayerCountLabel.AutoSize = true;
            this.lblPlayerCountLabel.Location = new System.Drawing.Point(663, 61);
            this.lblPlayerCountLabel.Name = "lblPlayerCountLabel";
            this.lblPlayerCountLabel.Size = new System.Drawing.Size(70, 13);
            this.lblPlayerCountLabel.TabIndex = 15;
            this.lblPlayerCountLabel.Text = "Player Count:";
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.AutoSize = true;
            this.lblPlayerCount.Location = new System.Drawing.Point(739, 61);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(0, 13);
            this.lblPlayerCount.TabIndex = 16;
            // 
            // grpMapManagement
            // 
            this.grpMapManagement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMapManagement.Controls.Add(this.RBPostScriptum);
            this.grpMapManagement.Controls.Add(this.RBSquad);
            this.grpMapManagement.Controls.Add(this.RestartMatchButton);
            this.grpMapManagement.Controls.Add(this.EndMatchButton);
            this.grpMapManagement.Controls.Add(this.SetNextMapButton);
            this.grpMapManagement.Controls.Add(this.ChangeMapButton);
            this.grpMapManagement.Controls.Add(this.MapNamesCombo);
            this.grpMapManagement.Enabled = false;
            this.grpMapManagement.Location = new System.Drawing.Point(657, 89);
            this.grpMapManagement.Name = "grpMapManagement";
            this.grpMapManagement.Size = new System.Drawing.Size(482, 100);
            this.grpMapManagement.TabIndex = 18;
            this.grpMapManagement.TabStop = false;
            this.grpMapManagement.Text = "Map Management";
            // 
            // RBPostScriptum
            // 
            this.RBPostScriptum.AutoSize = true;
            this.RBPostScriptum.Location = new System.Drawing.Point(76, 21);
            this.RBPostScriptum.Name = "RBPostScriptum";
            this.RBPostScriptum.Size = new System.Drawing.Size(87, 17);
            this.RBPostScriptum.TabIndex = 6;
            this.RBPostScriptum.Text = "PostScriptum";
            this.RBPostScriptum.UseVisualStyleBackColor = true;
            this.RBPostScriptum.CheckedChanged += new System.EventHandler(this.RBPostScriptum_CheckedChanged);
            // 
            // RBSquad
            // 
            this.RBSquad.AutoSize = true;
            this.RBSquad.Checked = true;
            this.RBSquad.Location = new System.Drawing.Point(14, 21);
            this.RBSquad.Name = "RBSquad";
            this.RBSquad.Size = new System.Drawing.Size(56, 17);
            this.RBSquad.TabIndex = 5;
            this.RBSquad.TabStop = true;
            this.RBSquad.Text = "Squad";
            this.RBSquad.UseVisualStyleBackColor = true;
            this.RBSquad.CheckedChanged += new System.EventHandler(this.RBSquad_CheckedChanged);
            // 
            // RestartMatchButton
            // 
            this.RestartMatchButton.Location = new System.Drawing.Point(95, 71);
            this.RestartMatchButton.Name = "RestartMatchButton";
            this.RestartMatchButton.Size = new System.Drawing.Size(89, 23);
            this.RestartMatchButton.TabIndex = 4;
            this.RestartMatchButton.Text = "Restart Current";
            this.RestartMatchButton.UseVisualStyleBackColor = true;
            this.RestartMatchButton.Click += new System.EventHandler(this.RestartMatchButton_Click);
            // 
            // EndMatchButton
            // 
            this.EndMatchButton.Location = new System.Drawing.Point(14, 71);
            this.EndMatchButton.Name = "EndMatchButton";
            this.EndMatchButton.Size = new System.Drawing.Size(75, 23);
            this.EndMatchButton.TabIndex = 3;
            this.EndMatchButton.Text = "End Current Match";
            this.EndMatchButton.UseVisualStyleBackColor = true;
            this.EndMatchButton.Click += new System.EventHandler(this.EndMatchButton_Click);
            // 
            // SetNextMapButton
            // 
            this.SetNextMapButton.Location = new System.Drawing.Point(336, 71);
            this.SetNextMapButton.Name = "SetNextMapButton";
            this.SetNextMapButton.Size = new System.Drawing.Size(137, 23);
            this.SetNextMapButton.TabIndex = 2;
            this.SetNextMapButton.Text = "SetNextMap (delayed)";
            this.SetNextMapButton.UseVisualStyleBackColor = true;
            this.SetNextMapButton.Click += new System.EventHandler(this.SetNextMapButton_Click);
            // 
            // ChangeMapButton
            // 
            this.ChangeMapButton.Location = new System.Drawing.Point(190, 71);
            this.ChangeMapButton.Name = "ChangeMapButton";
            this.ChangeMapButton.Size = new System.Drawing.Size(140, 23);
            this.ChangeMapButton.TabIndex = 1;
            this.ChangeMapButton.Text = "ChangeMap (immediate)";
            this.ChangeMapButton.UseVisualStyleBackColor = true;
            this.ChangeMapButton.Click += new System.EventHandler(this.ChangeMapButton_Click);
            // 
            // MapNamesCombo
            // 
            this.MapNamesCombo.AllowDrop = true;
            this.MapNamesCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapNamesCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.MapNamesCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.MapNamesCombo.FormattingEnabled = true;
            this.MapNamesCombo.Location = new System.Drawing.Point(14, 44);
            this.MapNamesCombo.Name = "MapNamesCombo";
            this.MapNamesCombo.Size = new System.Drawing.Size(460, 21);
            this.MapNamesCombo.TabIndex = 0;
            // 
            // frmMainConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1151, 856);
            this.Controls.Add(this.grpMapManagement);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.lblPlayerCountLabel);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.lblMapLabel);
            this.Controls.Add(this.lblConnectedTo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.grpConsole);
            this.Controls.Add(this.grpPlayerList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Squad RCON - Remote Server Console";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainConsole_FormClosing);
            this.Load += new System.EventHandler(this.frmMainConsole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpPlayerList.ResumeLayout(false);
            this.grpPlayerList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlayers)).EndInit();
            this.grpConsole.ResumeLayout(false);
            this.grpConsole.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpMapManagement.ResumeLayout(false);
            this.grpMapManagement.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grpPlayerList;
        private System.Windows.Forms.GroupBox grpConsole;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label lblFindPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdPlayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRconPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.MaskedTextBox txtServerPort;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSlot;
        private System.Windows.Forms.DataGridViewLinkColumn cPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSteam64Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDisconnect;
        private System.Windows.Forms.Button btnClearConsole;
        private System.Windows.Forms.Label lblConnectedTo;
        private System.Windows.Forms.Label lblMapLabel;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.Label lblPlayerCountLabel;
        private System.Windows.Forms.Label lblPlayerCount;
        private System.Windows.Forms.GroupBox grpMapManagement;
        private System.Windows.Forms.Button SetNextMapButton;
        private System.Windows.Forms.Button ChangeMapButton;
        private System.Windows.Forms.ComboBox MapNamesCombo;
        private System.Windows.Forms.Button EndMatchButton;
        private System.Windows.Forms.Button RestartMatchButton;
        private System.Windows.Forms.RadioButton RBPostScriptum;
        private System.Windows.Forms.RadioButton RBSquad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox MTQueryPort;
    }
}