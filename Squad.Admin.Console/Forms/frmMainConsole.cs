﻿#region License

/* 
 * Copyright (C) 2013 Myrcon Pty. Ltd. / Geoff "Phogue" Green
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to
 * deal in the Software without restriction, including without limitation the
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
 * sell copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 * IN THE SOFTWARE.
*/

#endregion

using System;
using System.ComponentModel;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using QueryMaster.GameServer;
using Squad.Admin.Console.Properties;
using Squad.Admin.Console.RCON;
using Squad.Admin.Console.Utilities;

namespace Squad.Admin.Console.Forms
{
    internal delegate void ClearGrid(DataGridView gridControl);

    internal delegate void ClearListBox(ListBox listboxControl);

    internal delegate void SetControlEnabled(Control control, bool isEnabled);

    internal delegate void AddGridRow(string slot, string name, string steamId, string status, string disconnectTime);

    internal delegate void AddListboxItem(string command);

    internal delegate void AddTextToTextbox(TextBox textbox, string response);

    public partial class frmMainConsole : Form
    {
        private readonly ServerProxy rconServerProxy;

        private readonly ServerConnectionInfo serverConnectionInfo = new ServerConnectionInfo();
        private XDocument menuReasons;

        public frmMainConsole()
        {
            InitializeComponent();

            // Bind control event handlers
            txtServerIP.Validating += TxtServerIP_Validating;
            txtServerPort.Validating += TxtServerPort_Validating;
            MTQueryPort.Validating += TxtQueryPort_Validating;
            txtRconPassword.Validating += TxtRconPassword_Validating;
            grdPlayers.CellContentClick += GrdPlayers_CellContentClick;
            grdPlayers.MouseClick += GrdPlayers_MouseClick;
            grdPlayers.RowPrePaint += GrdPlayers_RowPrePaint;
            lstHistory.MouseDoubleClick += LstHistory_MouseDoubleClick;

            rconServerProxy = new ServerProxy();
            LoadAutocompleteCommands();

            // start with the squad set
            LoadMapNames("SQMaps.dat");

            LoadSettings();
        }

        private void LoadSettings()
        {
            string serverip = Settings.Default.ServerIp;
            IPAddress ip;
            if (IPAddress.TryParse(serverip.Trim(), out ip))
            {
                serverConnectionInfo.ServerIP = ip;
                txtServerIP.Text = serverip;
            }

            int port = Settings.Default.PortNumber;
            if (port > 0)
            {
                txtServerPort.Text = port.ToString();
                serverConnectionInfo.ServerPort = port;
            } else
            {
                txtServerPort.Text = "21114";
                serverConnectionInfo.ServerPort = 21114;
            }

            int queryport = Settings.Default.QueryPort;
            if (port > 0) {
                MTQueryPort.Text = queryport.ToString();
                serverConnectionInfo.QueryPort = queryport;
            } else
            {
                MTQueryPort.Text = "27165";
                serverConnectionInfo.QueryPort = 27165;
            }

            txtDisplayName.Text = Settings.Default.AdminName;

            btnConnect.Enabled = serverConnectionInfo.IsValid();
        }

        private void ChangeMapButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MapNamesCombo.Text))
                MessageBox.Show("Please select or type a map name above", "Missing map name", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else RunCommand("AdminChangeMap " + MapNamesCombo.Text);
        }

        private void SetNextMapButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MapNamesCombo.Text))
                MessageBox.Show("Please select or type a map name above", "Missing map name", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else RunCommand("AdminSetNextMap " + MapNamesCombo.Text);
        }

        private void EndMatchButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm termination of current match", "confirm", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation) == DialogResult.OK) RunCommand("AdminEndMatch");
        }

        private void RestartMatchButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm restart of current match", "confirm", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation) == DialogResult.OK) RunCommand("AdminRestartMatch");
        }

        private void txtServerIP_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ServerIp = txtServerIP.Text;
            Settings.Default.Save();
        }

        private void txtServerPort_TextChanged(object sender, EventArgs e)
        {
            try{
                Settings.Default.PortNumber = int.Parse(txtServerPort.Text ?? "0");
                Settings.Default.Save();
            } catch (FormatException)
            {

            }
        }

        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.AdminName = txtDisplayName.Text;
            Settings.Default.Save();
        }

        private void txtRconPassword_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox) sender;
            serverConnectionInfo.Password = tb.Text.Trim();
            btnConnect.Enabled = serverConnectionInfo.IsValid();
        }

        private void frmMainConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Settings.Default.Location = RestoreBounds.Location;
                Settings.Default.Size = RestoreBounds.Size;
                Settings.Default.Maximised = true;
                Settings.Default.Minimised = false;
            } else if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.Location = Location;
                Settings.Default.Size = Size;
                Settings.Default.Maximised = false;
                Settings.Default.Minimised = false;
            } else
            {
                Settings.Default.Location = RestoreBounds.Location;
                Settings.Default.Size = RestoreBounds.Size;
                Settings.Default.Maximised = false;
                Settings.Default.Minimised = true;
            }

            Settings.Default.Save();
        }

        private void frmMainConsole_Load(object sender, EventArgs e)
        {
            Point dloc = Location = Settings.Default.Location;
            Size dsize = Settings.Default.Size;

            if (Settings.Default.Maximised)
                WindowState = FormWindowState.Maximized;
            else if (Settings.Default.Minimised) WindowState = FormWindowState.Minimized;
            if (dloc != Point.Empty) Location = Settings.Default.Location;
            if (dsize != Size.Empty) Size = Settings.Default.Size;
        }

        private void RBPostScriptum_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb != null && rb.Checked) LoadMapNames("PSMaps.dat");
        }

        private void RBSquad_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb != null && rb.Checked) LoadMapNames("SQMaps.dat");
        }

        #region control validation events

        private void TxtRconPassword_Validating(object sender, CancelEventArgs e)
        {
            var tb = (TextBox) sender;
            serverConnectionInfo.Password = tb.Text.Trim();
            btnConnect.Enabled = serverConnectionInfo.IsValid();
        }

        private void TxtServerPort_Validating(object sender, CancelEventArgs e)
        {
            var tb = (MaskedTextBox) sender;
            try
            {
                serverConnectionInfo.ServerPort = Convert.ToInt32(tb.Text.Trim());
                btnConnect.Enabled = serverConnectionInfo.IsValid();
            } catch (Exception)
            {
                // do nothing, port is not a valid one
            }
        }

        private void TxtQueryPort_Validating(object sender, CancelEventArgs e) {
            var tb = (MaskedTextBox)sender;
            try {
                serverConnectionInfo.QueryPort = Convert.ToInt32(tb.Text.Trim());
                btnConnect.Enabled = serverConnectionInfo.IsValid();
            } catch (Exception) {
                // do nothing, port is not a valid one
            }
        }

        private void TxtServerIP_Validating(object sender, CancelEventArgs e)
        {
            IPAddress ip;
            var tb = (TextBox) sender;
            if (IPAddress.TryParse(tb.Text.Trim(), out ip)) serverConnectionInfo.ServerIP = ip;
            btnConnect.Enabled = serverConnectionInfo.IsValid();
        }

        #endregion

        #region control event handlers

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Connect to the game server
                if (rconServerProxy.Connect(serverConnectionInfo))
                {
                    EnableLoginControls(true);
                    GetServerInformation();
                    ListPlayers();
                }

                LoadContextMenuItems();
            } catch (Exception ex)
            {
                MessageBox.Show("Unexpected error occurred trying to connect! Exception: " + ex.Message +
                                "\r\nPlease report this error to the adminstrator.");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            ClearGridRows(grdPlayers);
            EnableLoginControls(false);
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // turn on or off the password mask by checking the checkbox
            txtRconPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetServerInformation();
            ListPlayers();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            RunCommand(txtCommand.Text);
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCommandHistory(lstHistory);
            SetControlEnabledState(btnClear, false);
        }

        private void btnClearConsole_Click(object sender, EventArgs e)
        {
            // Clear the text from the server console response
            SetTextboxText(txtResponse, string.Empty);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var fSettings = new frmSettings();
            fSettings.ShowDialog(this);
            LoadContextMenuItems();
        }

        // Launch the browser with the Steam profile of the selected player
        private void GrdPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Only act if the cell content clicked was the player name and an actual row, not a column header
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                string sUrl = "http://steamcommunity.com/profiles/" + grdPlayers.Rows[e.RowIndex].Cells[2].Value;
                var sInfo = new ProcessStartInfo(sUrl);
                Process.Start(sInfo);
            }
        }

        /// <summary>
        ///     Menu is dynamically built each time a row is clicked on. The "Tag" property of each menu item is used to store
        ///     the actual RCON command to be executed if a menu item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdPlayers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = grdPlayers.HitTest(e.X, e.Y).RowIndex;

                // pull the current player name from the clicked row
                string playerName = grdPlayers.Rows[currentMouseOverRow].Cells[1].Value.ToString();
                string playerSteamId = grdPlayers.Rows[currentMouseOverRow].Cells[2].Value.ToString();
                string adminName = txtDisplayName.Text.Trim().Length != 0 ? txtDisplayName.Text.Trim() : "RCON Admin";
                string slot = grdPlayers.Rows[currentMouseOverRow].Cells[0].Value.ToString();

                if (currentMouseOverRow >= 0)
                {
                    var m = new ContextMenu();

                    var ct = new MenuItem("ChangeTeam");
                    ct.Tag = "AdminForceTeamChange " + playerSteamId;
                    ct.Click += menu_Click;
                    m.MenuItems.Add(ct);

                    // Warnings
                    var wi = new MenuItem("Warn");

                    foreach (XElement w in menuReasons.Root.Element("WarnReasons").Elements())
                    {
                        var warn = new MenuItem(w.Value.Replace("PLAYERNAME", playerName)
                            .Replace("ADMINNAME", adminName));
                        warn.Tag = "AdminBroadcast " + warn.Text;
                        warn.Click += menu_Click;
                        wi.MenuItems.Add(warn);
                    }

                    m.MenuItems.Add(wi);

                    // Kicks
                    var ki = new MenuItem("Kick");

                    foreach (XElement k in menuReasons.Root.Element("KickReasons").Elements())
                    {
                        var kick = new MenuItem(k.Value.Replace("PLAYERNAME", playerName)
                            .Replace("ADMINNAME", adminName));
                        kick.Tag = "AdminKick " + playerSteamId + " " + kick.Text;
                        kick.Click += menu_Click;
                        ki.MenuItems.Add(kick);
                    }

                    m.MenuItems.Add(ki);

                    // BansS
                    var bi = new MenuItem("Ban");

                    foreach (XElement b in menuReasons.Root.Element("BanReasons").Elements())
                    {
                        var ban = new MenuItem(
                            b.Value.Replace("PLAYERNAME", playerName).Replace("ADMINNAME", adminName));
                        ban.Tag = "AdminBan " + playerSteamId + " " + ban.Text;
                        ban.Click += menu_Click;
                        bi.MenuItems.Add(ban);
                    }

                    m.MenuItems.Add(bi);

                    m.Show(grdPlayers, new Point(e.X, e.Y));
                }
            }
        }

        private void GrdPlayers_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (Convert.ToString(grdPlayers.Rows[e.RowIndex].Cells[4].Value).Trim() != string.Empty)
                grdPlayers.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Silver;
        }

        private void menu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Confirm the player action {0}", ((MenuItem) sender).Tag),
                    "Confirm the player action", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                DialogResult.OK)
            {
                string response = rconServerProxy.SendCommand(((MenuItem) sender).Tag.ToString());
                AddCommandToHistoryList(((MenuItem) sender).Tag.ToString());
                AddServerResponseText(txtResponse, response);
            }
        }


        private void LstHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = lstHistory.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches) SetTextboxText(txtCommand, lstHistory.Items[index].ToString());
            }
        }

        #endregion

        #region Helpers

        private void EnableLoginControls(bool enable)
        {
            SetControlEnabledState(btnDisconnect, enable);
            SetControlEnabledState(btnConnect, !enable);
            SetControlEnabledState(txtServerIP, !enable);
            SetControlEnabledState(txtServerPort, !enable);
            SetControlEnabledState(MTQueryPort, !enable);
            SetControlEnabledState(txtRconPassword, !enable);
            SetControlEnabledState(txtDisplayName, !enable);
            SetControlEnabledState(chkShowPassword, !enable);
            SetControlEnabledState(grpPlayerList, enable);
            SetControlEnabledState(grpConsole, enable);
            SetControlEnabledState(grpMapManagement, enable);
        }

        /// <summary>
        ///     Fill the Command textbox autocomplete list with all valid commands from the Commands.dat text file
        /// </summary>
        private void LoadAutocompleteCommands()
        {
            var commandList = new AutoCompleteStringCollection();

            string commandsFile;
            if (ApplicationDeployment.IsNetworkDeployed)
                commandsFile = ApplicationDeployment.CurrentDeployment.DataDirectory + @"\Assets\Commands.dat";
            else
                commandsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Assets\Commands.dat");

            if (!File.Exists(commandsFile))
            {
                MessageBox.Show(string.Format("Failed to load commands autocomplete file {0}", commandsFile),
                    "Missing resource", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                string[] commands = File.ReadAllLines(commandsFile);

                for (var i = 0; i < commands.Length; i++)
                {
                    commandList.Add(commands[i].Trim());
                }

                txtCommand.AutoCompleteCustomSource = commandList;
            }
        }

        /// <summary>
        ///     Fill the Command textbox autocomplete list with all valid commands from the Commands.dat text file
        /// </summary>
        private void LoadMapNames(string filename)
        {
            var mapList = new AutoCompleteStringCollection();

            string commandsFile;
            if (ApplicationDeployment.IsNetworkDeployed)
                commandsFile = ApplicationDeployment.CurrentDeployment.DataDirectory + @"\Assets\" + filename;
            else
                commandsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Assets\" + filename);

            if (!File.Exists(commandsFile))
            {
                MessageBox.Show(string.Format("Failed to load map list file {0}", commandsFile),
                    "Missing resource", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                string[] commands = File.ReadAllLines(commandsFile);

                MapNamesCombo.Items.Clear();

                for (var i = 0; i < commands.Length; i++)
                {
                    string map = commands[i].Trim();
                    if (!string.IsNullOrWhiteSpace(map) && !map.StartsWith(";"))
                    {
                        mapList.Add(commands[i].Trim());
                        MapNamesCombo.Items.Add(map);
                    }
                }

                MapNamesCombo.AutoCompleteCustomSource = mapList;
            }
        }

        /// <summary>
        ///     Load context menu options from the menu xml file into
        /// </summary>
        private void LoadContextMenuItems()
        {
            string commandsFile;
            if (ApplicationDeployment.IsNetworkDeployed)
                commandsFile = ApplicationDeployment.CurrentDeployment.DataDirectory + @"\Assets\MenuReasons.xml";
            else
                commandsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Assets\MenuReasons.xml");

            // Load the xml file with the menu reasons
            try
            {
                menuReasons = XDocument.Load(commandsFile);
            } catch (Exception ex)
            {
                MessageBox.Show("Error occurred trying to open the menu options!\r\nError: " + ex.Message, "Exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        #endregion

        #region Command and response handlers

        /// <summary>
        ///     Retrieve server information and display it
        /// </summary>
        private void GetServerInformation()
        {
            ServerInfo info = rconServerProxy.GetServerData(serverConnectionInfo.QueryPort);

            if (info != null)
            {
                lblConnectedTo.Text = info.Name;
                lblMapName.Text = info.Map;
                lblPlayerCount.Text = info.Players + "/" + info.MaxPlayers;
            }
        }


        public void ListPlayers()
        {
            string currentLine = string.Empty;
            var activePlayers = false;
            var disconnectedPlayers = false;
            var isPlayer = false;

            try
            {
                string playerList = rconServerProxy.GetPlayerList();

                // Remove all rows from the grid
                ClearGridRows(grdPlayers);

                // Take the response and break it into a string array breaking each line off
                string[] playerArray = playerList.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None);

                for (var i = 0; i < playerArray.Length; i++)
                {
                    // Get the current line
                    currentLine = playerArray[i].Trim();

                    // No blank lines
                    if (currentLine.Length > 0)
                    {
                        switch (currentLine.Trim())
                        {
                            case "----- Active Players -----":
                                activePlayers = true;
                                disconnectedPlayers = false;
                                isPlayer = false;
                                break;
                            case "----- Recently Disconnected Players [Max of 15] -----":
                                activePlayers = false;
                                disconnectedPlayers = true;
                                isPlayer = false;
                                break;
                            default:
                                isPlayer = true;
                                break;
                        }


                        // Process connected player list
                        if (activePlayers)
                            if (isPlayer)
                            {
                                string[] playerInfo = currentLine.Split(':');

                                string[] slot = playerInfo[1].Split('|');
                                string[] steamId = playerInfo[2].Split('|');
                                string playerName = playerInfo[3];

                                AddPlayerToGrid(slot[0], playerName, steamId[0], "Connected", "");
                            }

                        // Process disconnected player list
                        if (disconnectedPlayers)
                            if (isPlayer)
                            {
                                string[] playerInfo = currentLine.Split(':');

                                string[] slot = playerInfo[1].Split('|');
                                string[] steamId = playerInfo[2].Split('|');
                                string[] time = playerInfo[3].Split('|');
                                string playerName = playerInfo[4];

                                AddPlayerToGrid(slot[0], playerName, steamId[0], "Disconnected", time[0]);
                            }
                    }
                }
            } catch (Exception ex)
            { }
        }

        #endregion

        #region Invoke Callbacks

        private void AddPlayerToGrid(string serverSlot, string playerName, string steamId, string connectStatus,
            string disconnectTime)
        {
            if (grdPlayers.InvokeRequired)
            {
                AddGridRow i = AddPlayerToGrid;
                Invoke(i, serverSlot, playerName, steamId, connectStatus, disconnectTime);
            } else
            {
                grdPlayers.Rows.Add(serverSlot, playerName, steamId, connectStatus, disconnectTime);
            }
        }

        private void AddCommandToHistoryList(string commandText)
        {
            if (lstHistory.InvokeRequired)
            {
                AddListboxItem c = AddCommandToHistoryList;
                Invoke(c, commandText);
            } else
            {
                // prevent duplication of the same command from being added to the list
                var isDup = false;
                for (var i = 0; i < lstHistory.Items.Count; i++)
                {
                    isDup = lstHistory.Items[i].ToString() == commandText;
                    if (isDup) break;
                }

                if (!isDup) lstHistory.Items.Insert(0, commandText);
            }
        }

        private void AddServerResponseText(TextBox control, string response)
        {
            if (txtResponse.InvokeRequired)
            {
                AddTextToTextbox c = AddServerResponseText;
                Invoke(c, control, response);
            } else
            {
                // substitute \r\n for \n
                if (!string.IsNullOrWhiteSpace(response)) response = response.Replace("\n", Environment.NewLine);
                if (control.Text.Length > 0) control.Text += Environment.NewLine + Environment.NewLine;
                control.Text += response;
            }
        }

        private void SetTextboxText(TextBox control, string text)
        {
            if (control.InvokeRequired)
            {
                AddTextToTextbox c = SetTextboxText;
                Invoke(c, control, text);
            } else
            {
                control.Text = text;
            }
        }

        private void ClearCommandText(TextBox control, string response)
        {
            if (txtResponse.InvokeRequired)
            {
                AddTextToTextbox c = ClearCommandText;
                Invoke(c, control, response);
            } else
            {
                control.Text = string.Empty;
            }
        }

        private void ClearGridRows(DataGridView gridControl)
        {
            if (gridControl.InvokeRequired)
            {
                ClearGrid c = ClearGridRows;
                Invoke(c, gridControl);
            } else
            {
                gridControl.Rows.Clear();
            }
        }

        private void ClearCommandHistory(ListBox listboxControl)
        {
            if (listboxControl.InvokeRequired)
            {
                ClearListBox c = ClearCommandHistory;
                Invoke(c, listboxControl);
            } else
            {
                listboxControl.Items.Clear();
            }
        }


        private void SetControlEnabledState(Control control, bool isEnabled)
        {
            if (control.InvokeRequired)
            {
                SetControlEnabled c = SetControlEnabledState;
                Invoke(c, control, isEnabled);
            } else
            {
                control.Enabled = isEnabled;
            }
        }

        private void RunCommand(string command)
        {
            string response = rconServerProxy.SendCommand(command);
            AddCommandToHistoryList(command);
            AddServerResponseText(txtResponse, response);
            ClearCommandText(txtCommand, string.Empty);
            SetControlEnabledState(btnClear, true);
        }

        #endregion

        private void label3_Click(object sender, EventArgs e) {

        }

        private void MTQueryPort_TextChanged(object sender, EventArgs e) {
            try
            {
              Settings.Default.QueryPort = int.Parse(MTQueryPort.Text ?? "0");
                Settings.Default.Save();
            } catch (FormatException) { }
        }

    }
}