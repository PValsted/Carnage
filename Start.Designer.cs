using System.Windows.Forms;

namespace Carnage
{
    partial class Start
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            btnStart = new Button();
            btnCustom = new Button();
            btnPreset = new Button();
            grbNumberOptions = new GroupBox();
            rdo48 = new RadioButton();
            rdo24 = new RadioButton();
            pnlOptions = new Panel();
            pnlStats = new Panel();
            txtHealth = new TextBox();
            cboHealth = new CheckBox();
            lblStats = new Label();
            btnBackGameSettings = new Button();
            pnlRealisticSettings = new Panel();
            cboHunger = new CheckBox();
            lblRealisticSettings = new Label();
            cboRealistic = new CheckBox();
            cboCombatLevel = new CheckBox();
            pnlGeneralSettings = new Panel();
            lblGeneralSettings = new Label();
            cboSponsor = new CheckBox();
            cboShortBattles = new CheckBox();
            txtGameSettings = new Label();
            btnBack = new Button();
            pnlMenu2 = new Panel();
            pnlSettings = new Panel();
            txtSettings = new Label();
            btnVisualSettings = new Button();
            btnGameSettings = new Button();
            label1 = new Label();
            cboArenas = new ComboBox();
            txtArena = new Label();
            pnlForest = new Panel();
            rtbForest = new RichTextBox();
            pictureForest = new PictureBox();
            txtSereneForest = new Label();
            pnlMainMenu = new Panel();
            btnTest = new Button();
            pictureSubLogo = new PictureBox();
            pictureMainLog = new PictureBox();
            btnChangelog = new Button();
            btnCharacterCreator = new Button();
            pnlChangelog = new Panel();
            rtbChangelog = new RichTextBox();
            txtVersion = new Label();
            txtChangelog = new Label();
            btnBackChange = new Button();
            toolTip1 = new ToolTip(components);
            label12 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            moralLab = new Label();
            strengthLabel = new Label();
            pronounLabel = new Label();
            charIDLabel = new Label();
            btnAll = new Button();
            txtSearch = new TextBox();
            pnlCharacterEntry = new Panel();
            btnBackCharacter = new Button();
            txtInfo = new Label();
            cboTag1 = new ComboBox();
            btnCharSearch = new Button();
            txtCharCreator = new Label();
            txtCharSearch = new TextBox();
            cboPronoun = new ComboBox();
            btnTagSearch = new Button();
            charIDText = new TextBox();
            rtbSearch = new RichTextBox();
            tag3Text = new TextBox();
            btnAddCharacter = new Button();
            tag2Text = new TextBox();
            strengthText = new TextBox();
            moralText = new TextBox();
            speedText = new TextBox();
            pnlVisualSettings = new Panel();
            cboDefaults = new CheckBox();
            btnApply = new Button();
            btnVisualSettingsBack = new Button();
            pnlMode = new Panel();
            rdoDarkMode = new RadioButton();
            rdoLightMode = new RadioButton();
            txtMode = new Label();
            txtVisualSettings = new Label();
            pnlTest = new Panel();
            btnTestBack = new Button();
            gboPlayers = new GroupBox();
            cboPlayer4Heal = new CheckBox();
            cboPlayer4Explosive = new CheckBox();
            cboPlayer3Heal = new CheckBox();
            cboPlayer3Explosive = new CheckBox();
            cboPlayer2Heal = new CheckBox();
            cboPlayer2Explosive = new CheckBox();
            cboPlayer1Heal = new CheckBox();
            cboPlayer1Explosive = new CheckBox();
            txtPlayer4Moral = new TextBox();
            txtPlayer4Speed = new TextBox();
            txtPlayer4Damage = new TextBox();
            txtPlayer3Moral = new TextBox();
            txtPlayer3Speed = new TextBox();
            txtPlayer3Damage = new TextBox();
            txtPlayer2Moral = new TextBox();
            txtPlayer2Speed = new TextBox();
            txtPlayer2Damage = new TextBox();
            txtPlayer1Moral = new TextBox();
            txtPlayer1Speed = new TextBox();
            txtPlayer1Damage = new TextBox();
            gboNumPlayers = new GroupBox();
            rdoFour = new RadioButton();
            rdoThree = new RadioButton();
            rdoTwo = new RadioButton();
            btnBattle = new Button();
            rtbTest = new RichTextBox();
            grbNumberOptions.SuspendLayout();
            pnlOptions.SuspendLayout();
            pnlStats.SuspendLayout();
            pnlRealisticSettings.SuspendLayout();
            pnlGeneralSettings.SuspendLayout();
            pnlMenu2.SuspendLayout();
            pnlSettings.SuspendLayout();
            pnlForest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureForest).BeginInit();
            pnlMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureSubLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureMainLog).BeginInit();
            pnlChangelog.SuspendLayout();
            pnlCharacterEntry.SuspendLayout();
            pnlVisualSettings.SuspendLayout();
            pnlMode.SuspendLayout();
            pnlTest.SuspendLayout();
            gboPlayers.SuspendLayout();
            gboNumPlayers.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackgroundImage = Properties.Resources.button_gradient;
            btnStart.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = SystemColors.Window;
            btnStart.Location = new Point(499, 620);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(152, 58);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnClassic_Click;
            // 
            // btnCustom
            // 
            btnCustom.BackgroundImage = Properties.Resources.button_gradient;
            btnCustom.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCustom.ForeColor = SystemColors.Window;
            btnCustom.Location = new Point(49, 692);
            btnCustom.Name = "btnCustom";
            btnCustom.Size = new Size(175, 61);
            btnCustom.TabIndex = 1;
            btnCustom.Text = "Use Custom Characters";
            toolTip1.SetToolTip(btnCustom, "Fill in your own characters (No support for Realistic Mode)");
            btnCustom.UseVisualStyleBackColor = true;
            btnCustom.Click += btnCustom_Click;
            // 
            // btnPreset
            // 
            btnPreset.BackgroundImage = Properties.Resources.button_gradient;
            btnPreset.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnPreset.ForeColor = SystemColors.Window;
            btnPreset.Location = new Point(241, 692);
            btnPreset.Name = "btnPreset";
            btnPreset.Size = new Size(175, 61);
            btnPreset.TabIndex = 2;
            btnPreset.Text = "Use Preset Characters";
            toolTip1.SetToolTip(btnPreset, "Use characters from a database (support for both gamemodes)");
            btnPreset.UseVisualStyleBackColor = true;
            btnPreset.Click += btnPreset_Click;
            // 
            // grbNumberOptions
            // 
            grbNumberOptions.BackColor = Color.Transparent;
            grbNumberOptions.Controls.Add(rdo48);
            grbNumberOptions.Controls.Add(rdo24);
            grbNumberOptions.Location = new Point(49, 527);
            grbNumberOptions.Name = "grbNumberOptions";
            grbNumberOptions.Size = new Size(245, 150);
            grbNumberOptions.TabIndex = 3;
            grbNumberOptions.TabStop = false;
            // 
            // rdo48
            // 
            rdo48.AutoSize = true;
            rdo48.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rdo48.Location = new Point(6, 70);
            rdo48.Name = "rdo48";
            rdo48.Size = new Size(162, 34);
            rdo48.TabIndex = 1;
            rdo48.TabStop = true;
            rdo48.Text = "48 Characters";
            rdo48.UseVisualStyleBackColor = true;
            // 
            // rdo24
            // 
            rdo24.AutoSize = true;
            rdo24.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            rdo24.Location = new Point(6, 22);
            rdo24.Name = "rdo24";
            rdo24.Size = new Size(162, 34);
            rdo24.TabIndex = 0;
            rdo24.TabStop = true;
            rdo24.Text = "24 Characters";
            rdo24.UseVisualStyleBackColor = true;
            // 
            // pnlOptions
            // 
            pnlOptions.BackColor = SystemColors.Window;
            pnlOptions.BackgroundImage = Properties.Resources.white_gradient;
            pnlOptions.BorderStyle = BorderStyle.FixedSingle;
            pnlOptions.Controls.Add(pnlStats);
            pnlOptions.Controls.Add(btnBackGameSettings);
            pnlOptions.Controls.Add(pnlRealisticSettings);
            pnlOptions.Controls.Add(pnlGeneralSettings);
            pnlOptions.Controls.Add(txtGameSettings);
            pnlOptions.Location = new Point(30, 23);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(1075, 590);
            pnlOptions.TabIndex = 7;
            pnlOptions.Visible = false;
            // 
            // pnlStats
            // 
            pnlStats.BorderStyle = BorderStyle.FixedSingle;
            pnlStats.Controls.Add(txtHealth);
            pnlStats.Controls.Add(cboHealth);
            pnlStats.Controls.Add(lblStats);
            pnlStats.Location = new Point(72, 319);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(363, 178);
            pnlStats.TabIndex = 17;
            // 
            // txtHealth
            // 
            txtHealth.BorderStyle = BorderStyle.FixedSingle;
            txtHealth.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtHealth.Location = new Point(255, 60);
            txtHealth.Name = "txtHealth";
            txtHealth.PlaceholderText = "Default is 20";
            txtHealth.Size = new Size(81, 23);
            txtHealth.TabIndex = 17;
            txtHealth.Visible = false;
            // 
            // cboHealth
            // 
            cboHealth.AutoSize = true;
            cboHealth.BackColor = Color.Transparent;
            cboHealth.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cboHealth.Location = new Point(12, 54);
            cboHealth.Name = "cboHealth";
            cboHealth.Size = new Size(248, 34);
            cboHealth.TabIndex = 18;
            cboHealth.Text = "Change Starting Health";
            toolTip1.SetToolTip(cboHealth, "The sponsor screen will automatically be skipped");
            cboHealth.UseVisualStyleBackColor = false;
            cboHealth.CheckedChanged += cboHealth_CheckedChanged;
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.BackColor = Color.Transparent;
            lblStats.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblStats.Location = new Point(88, 14);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(185, 37);
            lblStats.TabIndex = 16;
            lblStats.Text = "Stats Settings";
            // 
            // btnBackGameSettings
            // 
            btnBackGameSettings.BackgroundImage = Properties.Resources.button_gradient;
            btnBackGameSettings.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackGameSettings.ForeColor = SystemColors.Window;
            btnBackGameSettings.Location = new Point(938, 514);
            btnBackGameSettings.Name = "btnBackGameSettings";
            btnBackGameSettings.Size = new Size(103, 56);
            btnBackGameSettings.TabIndex = 81;
            btnBackGameSettings.Text = "Back";
            btnBackGameSettings.UseVisualStyleBackColor = true;
            btnBackGameSettings.Click += btnBackGameSettings_Click;
            // 
            // pnlRealisticSettings
            // 
            pnlRealisticSettings.BorderStyle = BorderStyle.FixedSingle;
            pnlRealisticSettings.Controls.Add(cboHunger);
            pnlRealisticSettings.Controls.Add(lblRealisticSettings);
            pnlRealisticSettings.Controls.Add(cboRealistic);
            pnlRealisticSettings.Controls.Add(cboCombatLevel);
            pnlRealisticSettings.Location = new Point(637, 108);
            pnlRealisticSettings.Name = "pnlRealisticSettings";
            pnlRealisticSettings.Size = new Size(363, 178);
            pnlRealisticSettings.TabIndex = 17;
            // 
            // cboHunger
            // 
            cboHunger.AutoSize = true;
            cboHunger.BackColor = Color.Transparent;
            cboHunger.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cboHunger.Location = new Point(17, 113);
            cboHunger.Name = "cboHunger";
            cboHunger.Size = new Size(182, 34);
            cboHunger.TabIndex = 17;
            cboHunger.Text = "Turn Off Hunger";
            toolTip1.SetToolTip(cboHunger, "Characters will lose hunger every day and will need to eat to prevent starvation unless turned off");
            cboHunger.UseVisualStyleBackColor = false;
            cboHunger.Visible = false;
            // 
            // lblRealisticSettings
            // 
            lblRealisticSettings.AutoSize = true;
            lblRealisticSettings.BackColor = Color.Transparent;
            lblRealisticSettings.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblRealisticSettings.Location = new Point(29, 14);
            lblRealisticSettings.Name = "lblRealisticSettings";
            lblRealisticSettings.Size = new Size(303, 37);
            lblRealisticSettings.TabIndex = 16;
            lblRealisticSettings.Text = "Realistic Mode Settings";
            // 
            // cboRealistic
            // 
            cboRealistic.AutoSize = true;
            cboRealistic.BackColor = Color.Transparent;
            cboRealistic.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cboRealistic.Location = new Point(17, 55);
            cboRealistic.Name = "cboRealistic";
            cboRealistic.Size = new Size(236, 34);
            cboRealistic.TabIndex = 7;
            cboRealistic.Text = "Enable Realistic Mode";
            toolTip1.SetToolTip(cboRealistic, "Characters have additional attributes like strength, morality, speed, and hunger that will affect the outcome of the game");
            cboRealistic.UseVisualStyleBackColor = false;
            cboRealistic.CheckedChanged += cboRealistic_CheckedChanged;
            // 
            // cboCombatLevel
            // 
            cboCombatLevel.AutoSize = true;
            cboCombatLevel.BackColor = Color.Transparent;
            cboCombatLevel.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cboCombatLevel.Location = new Point(17, 83);
            cboCombatLevel.Name = "cboCombatLevel";
            cboCombatLevel.Size = new Size(214, 34);
            cboCombatLevel.TabIndex = 8;
            cboCombatLevel.Text = "Show Combat Level";
            toolTip1.SetToolTip(cboCombatLevel, "Combat level determines who will go first in Realistic Mode");
            cboCombatLevel.UseVisualStyleBackColor = false;
            cboCombatLevel.Visible = false;
            // 
            // pnlGeneralSettings
            // 
            pnlGeneralSettings.BorderStyle = BorderStyle.FixedSingle;
            pnlGeneralSettings.Controls.Add(lblGeneralSettings);
            pnlGeneralSettings.Controls.Add(cboSponsor);
            pnlGeneralSettings.Controls.Add(cboShortBattles);
            pnlGeneralSettings.Location = new Point(72, 108);
            pnlGeneralSettings.Name = "pnlGeneralSettings";
            pnlGeneralSettings.Size = new Size(363, 178);
            pnlGeneralSettings.TabIndex = 15;
            // 
            // lblGeneralSettings
            // 
            lblGeneralSettings.AutoSize = true;
            lblGeneralSettings.BackColor = Color.Transparent;
            lblGeneralSettings.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblGeneralSettings.Location = new Point(72, 14);
            lblGeneralSettings.Name = "lblGeneralSettings";
            lblGeneralSettings.Size = new Size(218, 37);
            lblGeneralSettings.TabIndex = 16;
            lblGeneralSettings.Text = "General Settings";
            // 
            // cboSponsor
            // 
            cboSponsor.AutoSize = true;
            cboSponsor.BackColor = Color.Transparent;
            cboSponsor.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cboSponsor.Location = new Point(12, 83);
            cboSponsor.Name = "cboSponsor";
            cboSponsor.Size = new Size(170, 34);
            cboSponsor.TabIndex = 9;
            cboSponsor.Text = "No Sponsoring";
            toolTip1.SetToolTip(cboSponsor, "The sponsor screen will automatically be skipped");
            cboSponsor.UseVisualStyleBackColor = false;
            // 
            // cboShortBattles
            // 
            cboShortBattles.AutoSize = true;
            cboShortBattles.BackColor = Color.Transparent;
            cboShortBattles.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cboShortBattles.Location = new Point(12, 55);
            cboShortBattles.Name = "cboShortBattles";
            cboShortBattles.Size = new Size(149, 34);
            cboShortBattles.TabIndex = 5;
            cboShortBattles.Text = "Short Battles";
            toolTip1.SetToolTip(cboShortBattles, "Battles will only show significant events and the outcome");
            cboShortBattles.UseVisualStyleBackColor = false;
            // 
            // txtGameSettings
            // 
            txtGameSettings.AutoSize = true;
            txtGameSettings.BackColor = Color.Transparent;
            txtGameSettings.Font = new Font("Yu Gothic UI Semibold", 30F, FontStyle.Bold, GraphicsUnit.Point);
            txtGameSettings.Location = new Point(394, 19);
            txtGameSettings.Name = "txtGameSettings";
            txtGameSettings.Size = new Size(284, 54);
            txtGameSettings.TabIndex = 14;
            txtGameSettings.Text = "Game Settings";
            // 
            // btnBack
            // 
            btnBack.BackgroundImage = Properties.Resources.button_gradient;
            btnBack.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnBack.ForeColor = SystemColors.Window;
            btnBack.Location = new Point(857, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(147, 59);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // pnlMenu2
            // 
            pnlMenu2.BackColor = SystemColors.Window;
            pnlMenu2.BackgroundImage = (Image)resources.GetObject("pnlMenu2.BackgroundImage");
            pnlMenu2.BorderStyle = BorderStyle.FixedSingle;
            pnlMenu2.Controls.Add(pnlSettings);
            pnlMenu2.Controls.Add(label1);
            pnlMenu2.Controls.Add(cboArenas);
            pnlMenu2.Controls.Add(txtArena);
            pnlMenu2.Controls.Add(btnCustom);
            pnlMenu2.Controls.Add(btnBack);
            pnlMenu2.Controls.Add(pnlForest);
            pnlMenu2.Controls.Add(btnPreset);
            pnlMenu2.Controls.Add(grbNumberOptions);
            pnlMenu2.Location = new Point(34, 29);
            pnlMenu2.Name = "pnlMenu2";
            pnlMenu2.Size = new Size(1030, 835);
            pnlMenu2.TabIndex = 9;
            pnlMenu2.Visible = false;
            // 
            // pnlSettings
            // 
            pnlSettings.BorderStyle = BorderStyle.FixedSingle;
            pnlSettings.Controls.Add(txtSettings);
            pnlSettings.Controls.Add(btnVisualSettings);
            pnlSettings.Controls.Add(btnGameSettings);
            pnlSettings.Location = new Point(412, 531);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(348, 146);
            pnlSettings.TabIndex = 13;
            // 
            // txtSettings
            // 
            txtSettings.AutoSize = true;
            txtSettings.BackColor = Color.Transparent;
            txtSettings.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            txtSettings.Location = new Point(116, 14);
            txtSettings.Name = "txtSettings";
            txtSettings.Size = new Size(117, 37);
            txtSettings.TabIndex = 14;
            txtSettings.Text = "Settings";
            // 
            // btnVisualSettings
            // 
            btnVisualSettings.BackgroundImage = Properties.Resources.button_gradient;
            btnVisualSettings.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnVisualSettings.ForeColor = SystemColors.Window;
            btnVisualSettings.Location = new Point(177, 91);
            btnVisualSettings.Name = "btnVisualSettings";
            btnVisualSettings.Size = new Size(152, 44);
            btnVisualSettings.TabIndex = 15;
            btnVisualSettings.Text = "Visual Settings";
            toolTip1.SetToolTip(btnVisualSettings, "Fill in your own characters (No support for Realistic Mode)");
            btnVisualSettings.UseVisualStyleBackColor = true;
            btnVisualSettings.Click += btnVisualSettings_Click;
            // 
            // btnGameSettings
            // 
            btnGameSettings.BackgroundImage = Properties.Resources.button_gradient;
            btnGameSettings.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnGameSettings.ForeColor = SystemColors.Window;
            btnGameSettings.Location = new Point(19, 91);
            btnGameSettings.Name = "btnGameSettings";
            btnGameSettings.Size = new Size(152, 44);
            btnGameSettings.TabIndex = 14;
            btnGameSettings.Text = "Game Settings";
            toolTip1.SetToolTip(btnGameSettings, "Fill in your own characters (No support for Realistic Mode)");
            btnGameSettings.UseVisualStyleBackColor = true;
            btnGameSettings.Click += btnGameSettings_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(49, 494);
            label1.Name = "label1";
            label1.Size = new Size(259, 37);
            label1.TabIndex = 12;
            label1.Text = "Number of tributes:";
            // 
            // cboArenas
            // 
            cboArenas.FormattingEnabled = true;
            cboArenas.Items.AddRange(new object[] { "Serene Forest" });
            cboArenas.Location = new Point(49, 68);
            cboArenas.Name = "cboArenas";
            cboArenas.Size = new Size(245, 23);
            cboArenas.TabIndex = 10;
            cboArenas.SelectedIndexChanged += cboArenas_SelectedIndexChanged;
            // 
            // txtArena
            // 
            txtArena.AutoSize = true;
            txtArena.BackColor = Color.Transparent;
            txtArena.Font = new Font("Yu Gothic UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            txtArena.Location = new Point(41, 20);
            txtArena.Name = "txtArena";
            txtArena.Size = new Size(253, 45);
            txtArena.TabIndex = 9;
            txtArena.Text = "Pick your arena:";
            // 
            // pnlForest
            // 
            pnlForest.BackColor = SystemColors.Window;
            pnlForest.BorderStyle = BorderStyle.FixedSingle;
            pnlForest.Controls.Add(rtbForest);
            pnlForest.Controls.Add(pictureForest);
            pnlForest.Controls.Add(txtSereneForest);
            pnlForest.Location = new Point(49, 110);
            pnlForest.Name = "pnlForest";
            pnlForest.Size = new Size(711, 350);
            pnlForest.TabIndex = 11;
            // 
            // rtbForest
            // 
            rtbForest.BackColor = SystemColors.Window;
            rtbForest.BorderStyle = BorderStyle.None;
            rtbForest.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            rtbForest.Location = new Point(392, 47);
            rtbForest.Margin = new Padding(3, 3, 3, 5);
            rtbForest.Name = "rtbForest";
            rtbForest.ReadOnly = true;
            rtbForest.Size = new Size(296, 287);
            rtbForest.TabIndex = 2;
            rtbForest.Text = resources.GetString("rtbForest.Text");
            rtbForest.Visible = false;
            // 
            // pictureForest
            // 
            pictureForest.BorderStyle = BorderStyle.FixedSingle;
            pictureForest.Image = (Image)resources.GetObject("pictureForest.Image");
            pictureForest.Location = new Point(13, 53);
            pictureForest.Name = "pictureForest";
            pictureForest.Size = new Size(339, 265);
            pictureForest.TabIndex = 1;
            pictureForest.TabStop = false;
            pictureForest.Visible = false;
            // 
            // txtSereneForest
            // 
            txtSereneForest.AutoSize = true;
            txtSereneForest.Font = new Font("Yu Gothic UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtSereneForest.Location = new Point(13, 13);
            txtSereneForest.Name = "txtSereneForest";
            txtSereneForest.Size = new Size(182, 37);
            txtSereneForest.TabIndex = 0;
            txtSereneForest.Text = "Serene Forest";
            txtSereneForest.Visible = false;
            // 
            // pnlMainMenu
            // 
            pnlMainMenu.BackColor = Color.Transparent;
            pnlMainMenu.BackgroundImage = (Image)resources.GetObject("pnlMainMenu.BackgroundImage");
            pnlMainMenu.BorderStyle = BorderStyle.FixedSingle;
            pnlMainMenu.Controls.Add(btnTest);
            pnlMainMenu.Controls.Add(pictureSubLogo);
            pnlMainMenu.Controls.Add(pictureMainLog);
            pnlMainMenu.Controls.Add(btnChangelog);
            pnlMainMenu.Controls.Add(btnCharacterCreator);
            pnlMainMenu.Controls.Add(btnStart);
            pnlMainMenu.Location = new Point(34, 25);
            pnlMainMenu.Name = "pnlMainMenu";
            pnlMainMenu.Size = new Size(1714, 911);
            pnlMainMenu.TabIndex = 10;
            // 
            // btnTest
            // 
            btnTest.BackgroundImage = Properties.Resources.button_gradient;
            btnTest.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnTest.ForeColor = SystemColors.Window;
            btnTest.Location = new Point(780, 725);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(152, 58);
            btnTest.TabIndex = 5;
            btnTest.Text = "Dev Screen";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Visible = false;
            btnTest.Click += btnTest_Click;
            // 
            // pictureSubLogo
            // 
            pictureSubLogo.Image = (Image)resources.GetObject("pictureSubLogo.Image");
            pictureSubLogo.Location = new Point(494, 457);
            pictureSubLogo.Name = "pictureSubLogo";
            pictureSubLogo.Size = new Size(725, 70);
            pictureSubLogo.TabIndex = 4;
            pictureSubLogo.TabStop = false;
            // 
            // pictureMainLog
            // 
            pictureMainLog.Image = (Image)resources.GetObject("pictureMainLog.Image");
            pictureMainLog.Location = new Point(495, 230);
            pictureMainLog.Name = "pictureMainLog";
            pictureMainLog.Size = new Size(723, 221);
            pictureMainLog.TabIndex = 3;
            pictureMainLog.TabStop = false;
            // 
            // btnChangelog
            // 
            btnChangelog.BackgroundImage = Properties.Resources.button_gradient;
            btnChangelog.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnChangelog.ForeColor = SystemColors.Window;
            btnChangelog.Location = new Point(1061, 620);
            btnChangelog.Name = "btnChangelog";
            btnChangelog.Size = new Size(152, 58);
            btnChangelog.TabIndex = 2;
            btnChangelog.Text = "Changelog";
            btnChangelog.UseVisualStyleBackColor = true;
            btnChangelog.Click += btnChangelog_Click;
            // 
            // btnCharacterCreator
            // 
            btnCharacterCreator.BackgroundImage = Properties.Resources.button_gradient;
            btnCharacterCreator.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCharacterCreator.ForeColor = SystemColors.Window;
            btnCharacterCreator.Location = new Point(780, 620);
            btnCharacterCreator.Name = "btnCharacterCreator";
            btnCharacterCreator.Size = new Size(152, 58);
            btnCharacterCreator.TabIndex = 1;
            btnCharacterCreator.Text = "Character Creator";
            btnCharacterCreator.UseVisualStyleBackColor = true;
            btnCharacterCreator.Click += btnCharacterCreator_Click;
            // 
            // pnlChangelog
            // 
            pnlChangelog.BackgroundImage = (Image)resources.GetObject("pnlChangelog.BackgroundImage");
            pnlChangelog.BorderStyle = BorderStyle.FixedSingle;
            pnlChangelog.Controls.Add(rtbChangelog);
            pnlChangelog.Controls.Add(txtVersion);
            pnlChangelog.Controls.Add(txtChangelog);
            pnlChangelog.Controls.Add(btnBackChange);
            pnlChangelog.Location = new Point(30, 42);
            pnlChangelog.Name = "pnlChangelog";
            pnlChangelog.Size = new Size(1019, 519);
            pnlChangelog.TabIndex = 12;
            pnlChangelog.Visible = false;
            // 
            // rtbChangelog
            // 
            rtbChangelog.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            rtbChangelog.Location = new Point(42, 116);
            rtbChangelog.Name = "rtbChangelog";
            rtbChangelog.ReadOnly = true;
            rtbChangelog.Size = new Size(908, 300);
            rtbChangelog.TabIndex = 84;
            rtbChangelog.Text = resources.GetString("rtbChangelog.Text");
            // 
            // txtVersion
            // 
            txtVersion.AutoSize = true;
            txtVersion.BackColor = Color.Transparent;
            txtVersion.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtVersion.Location = new Point(38, 86);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(192, 21);
            txtVersion.TabIndex = 83;
            txtVersion.Text = "What's new in Version 1.1:";
            // 
            // txtChangelog
            // 
            txtChangelog.AutoSize = true;
            txtChangelog.BackColor = Color.Transparent;
            txtChangelog.Font = new Font("Yu Gothic UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            txtChangelog.Location = new Point(34, 34);
            txtChangelog.Name = "txtChangelog";
            txtChangelog.Size = new Size(177, 45);
            txtChangelog.TabIndex = 82;
            txtChangelog.Text = "Changelog";
            // 
            // btnBackChange
            // 
            btnBackChange.BackgroundImage = Properties.Resources.button_gradient;
            btnBackChange.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackChange.ForeColor = SystemColors.Window;
            btnBackChange.Location = new Point(38, 440);
            btnBackChange.Name = "btnBackChange";
            btnBackChange.Size = new Size(89, 42);
            btnBackChange.TabIndex = 81;
            btnBackChange.Text = "Back";
            btnBackChange.UseVisualStyleBackColor = true;
            btnBackChange.Click += btnBack_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(87, 307);
            label12.Name = "label12";
            label12.Size = new Size(34, 15);
            label12.TabIndex = 61;
            label12.Text = "Tag 3";
            toolTip1.SetToolTip(label12, "A set of text, this tag should be a specific category (a show for example) or left blank");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(87, 278);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 59;
            label2.Text = "Tag 2";
            toolTip1.SetToolTip(label2, "A set of text, this tag should be another main category/subcategory/specific category (can be left blank but not recommended)");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(87, 249);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 57;
            label3.Text = "Tag 1";
            toolTip1.SetToolTip(label3, "A set of text, this tag should be a main category (see below list)");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(82, 220);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 56;
            label4.Text = "Speed";
            toolTip1.SetToolTip(label4, "A number between 0-10, can have up to 2 decimal places.");
            // 
            // moralLab
            // 
            moralLab.AutoSize = true;
            moralLab.BackColor = Color.Transparent;
            moralLab.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            moralLab.Location = new Point(40, 191);
            moralLab.Name = "moralLab";
            moralLab.Size = new Size(81, 15);
            moralLab.TabIndex = 54;
            moralLab.Text = "Morality Level";
            toolTip1.SetToolTip(moralLab, "A number between 0-10, can have up to 2 decimal places. 0=Pure Evil, 5=Neutral, 10=Pure Good");
            // 
            // strengthLabel
            // 
            strengthLabel.AutoSize = true;
            strengthLabel.BackColor = Color.Transparent;
            strengthLabel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            strengthLabel.Location = new Point(69, 162);
            strengthLabel.Name = "strengthLabel";
            strengthLabel.Size = new Size(52, 15);
            strengthLabel.TabIndex = 52;
            strengthLabel.Text = "Strength";
            toolTip1.SetToolTip(strengthLabel, "A number between 0-10, can have up to 2 decimal places.");
            // 
            // pronounLabel
            // 
            pronounLabel.AutoSize = true;
            pronounLabel.BackColor = Color.Transparent;
            pronounLabel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            pronounLabel.Location = new Point(63, 133);
            pronounLabel.Name = "pronounLabel";
            pronounLabel.Size = new Size(58, 15);
            pronounLabel.TabIndex = 50;
            pronounLabel.Text = "Pronouns";
            toolTip1.SetToolTip(pronounLabel, "\"He\", \"She\", or \"They\"");
            // 
            // charIDLabel
            // 
            charIDLabel.AutoSize = true;
            charIDLabel.BackColor = Color.Transparent;
            charIDLabel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            charIDLabel.Location = new Point(78, 104);
            charIDLabel.Name = "charIDLabel";
            charIDLabel.Size = new Size(42, 15);
            charIDLabel.TabIndex = 48;
            charIDLabel.Text = "CharID";
            toolTip1.SetToolTip(charIDLabel, "A set of text.");
            // 
            // btnAll
            // 
            btnAll.BackgroundImage = Properties.Resources.button_gradient;
            btnAll.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAll.ForeColor = SystemColors.Window;
            btnAll.Location = new Point(638, 73);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(170, 46);
            btnAll.TabIndex = 78;
            btnAll.Text = "List All Characters";
            toolTip1.SetToolTip(btnAll, "Expect this to take a while to load");
            btnAll.UseVisualStyleBackColor = true;
            btnAll.Click += btnAll_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(898, 92);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Mouse over to see examples of tags";
            txtSearch.Size = new Size(208, 23);
            txtSearch.TabIndex = 74;
            toolTip1.SetToolTip(txtSearch, "Main categories include Anime, Literature, Movies, Real Life, TV Shows, Special Characters, and Video Games.");
            // 
            // pnlCharacterEntry
            // 
            pnlCharacterEntry.BackColor = SystemColors.Window;
            pnlCharacterEntry.BackgroundImage = (Image)resources.GetObject("pnlCharacterEntry.BackgroundImage");
            pnlCharacterEntry.BorderStyle = BorderStyle.FixedSingle;
            pnlCharacterEntry.Controls.Add(btnBackCharacter);
            pnlCharacterEntry.Controls.Add(txtInfo);
            pnlCharacterEntry.Controls.Add(btnAll);
            pnlCharacterEntry.Controls.Add(cboTag1);
            pnlCharacterEntry.Controls.Add(btnCharSearch);
            pnlCharacterEntry.Controls.Add(txtCharCreator);
            pnlCharacterEntry.Controls.Add(txtCharSearch);
            pnlCharacterEntry.Controls.Add(cboPronoun);
            pnlCharacterEntry.Controls.Add(btnTagSearch);
            pnlCharacterEntry.Controls.Add(charIDText);
            pnlCharacterEntry.Controls.Add(txtSearch);
            pnlCharacterEntry.Controls.Add(label12);
            pnlCharacterEntry.Controls.Add(rtbSearch);
            pnlCharacterEntry.Controls.Add(charIDLabel);
            pnlCharacterEntry.Controls.Add(tag3Text);
            pnlCharacterEntry.Controls.Add(btnAddCharacter);
            pnlCharacterEntry.Controls.Add(label2);
            pnlCharacterEntry.Controls.Add(pronounLabel);
            pnlCharacterEntry.Controls.Add(tag2Text);
            pnlCharacterEntry.Controls.Add(strengthText);
            pnlCharacterEntry.Controls.Add(label3);
            pnlCharacterEntry.Controls.Add(strengthLabel);
            pnlCharacterEntry.Controls.Add(label4);
            pnlCharacterEntry.Controls.Add(moralText);
            pnlCharacterEntry.Controls.Add(speedText);
            pnlCharacterEntry.Controls.Add(moralLab);
            pnlCharacterEntry.Location = new Point(32, 25);
            pnlCharacterEntry.Name = "pnlCharacterEntry";
            pnlCharacterEntry.Size = new Size(1345, 663);
            pnlCharacterEntry.TabIndex = 11;
            pnlCharacterEntry.Visible = false;
            // 
            // btnBackCharacter
            // 
            btnBackCharacter.BackgroundImage = Properties.Resources.button_gradient;
            btnBackCharacter.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackCharacter.ForeColor = SystemColors.Window;
            btnBackCharacter.Location = new Point(1202, 579);
            btnBackCharacter.Name = "btnBackCharacter";
            btnBackCharacter.Size = new Size(103, 56);
            btnBackCharacter.TabIndex = 80;
            btnBackCharacter.Text = "Back";
            btnBackCharacter.UseVisualStyleBackColor = true;
            btnBackCharacter.Click += btnBack_Click;
            // 
            // txtInfo
            // 
            txtInfo.AutoSize = true;
            txtInfo.BackColor = Color.Transparent;
            txtInfo.Location = new Point(40, 63);
            txtInfo.Name = "txtInfo";
            txtInfo.Size = new Size(354, 15);
            txtInfo.TabIndex = 79;
            txtInfo.Text = "See the tooltip on each attribute below for important information.";
            // 
            // cboTag1
            // 
            cboTag1.FormattingEnabled = true;
            cboTag1.Items.AddRange(new object[] { "Anime", "Literature", "Movies", "Real Life", "Special Characters", "TV Shows", "Video Games" });
            cboTag1.Location = new Point(127, 246);
            cboTag1.Name = "cboTag1";
            cboTag1.Size = new Size(191, 23);
            cboTag1.TabIndex = 63;
            // 
            // btnCharSearch
            // 
            btnCharSearch.BackgroundImage = Properties.Resources.button_gradient;
            btnCharSearch.Font = new Font("Constantia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCharSearch.ForeColor = SystemColors.Window;
            btnCharSearch.Location = new Point(1144, 40);
            btnCharSearch.Name = "btnCharSearch";
            btnCharSearch.Size = new Size(161, 33);
            btnCharSearch.TabIndex = 77;
            btnCharSearch.Text = "Search By Character";
            btnCharSearch.UseVisualStyleBackColor = true;
            btnCharSearch.Click += btnCharSearch_Click;
            // 
            // txtCharCreator
            // 
            txtCharCreator.AutoSize = true;
            txtCharCreator.BackColor = Color.Transparent;
            txtCharCreator.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            txtCharCreator.Location = new Point(36, 26);
            txtCharCreator.Name = "txtCharCreator";
            txtCharCreator.Size = new Size(183, 30);
            txtCharCreator.TabIndex = 1;
            txtCharCreator.Text = "Character Creator";
            // 
            // txtCharSearch
            // 
            txtCharSearch.BorderStyle = BorderStyle.FixedSingle;
            txtCharSearch.Location = new Point(898, 46);
            txtCharSearch.Name = "txtCharSearch";
            txtCharSearch.PlaceholderText = "See if a character is in the database";
            txtCharSearch.Size = new Size(208, 23);
            txtCharSearch.TabIndex = 76;
            // 
            // cboPronoun
            // 
            cboPronoun.FormattingEnabled = true;
            cboPronoun.Items.AddRange(new object[] { "He", "She", "They" });
            cboPronoun.Location = new Point(127, 130);
            cboPronoun.Name = "cboPronoun";
            cboPronoun.Size = new Size(191, 23);
            cboPronoun.TabIndex = 62;
            // 
            // btnTagSearch
            // 
            btnTagSearch.BackgroundImage = Properties.Resources.button_gradient;
            btnTagSearch.Font = new Font("Constantia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnTagSearch.ForeColor = SystemColors.Window;
            btnTagSearch.Location = new Point(1144, 86);
            btnTagSearch.Name = "btnTagSearch";
            btnTagSearch.Size = new Size(161, 33);
            btnTagSearch.TabIndex = 75;
            btnTagSearch.Text = "Search By Tag";
            btnTagSearch.UseVisualStyleBackColor = true;
            btnTagSearch.Click += btnTagSearch_Click;
            // 
            // charIDText
            // 
            charIDText.BorderStyle = BorderStyle.FixedSingle;
            charIDText.Location = new Point(127, 101);
            charIDText.Name = "charIDText";
            charIDText.Size = new Size(191, 23);
            charIDText.TabIndex = 47;
            // 
            // rtbSearch
            // 
            rtbSearch.Location = new Point(638, 133);
            rtbSearch.Name = "rtbSearch";
            rtbSearch.Size = new Size(667, 419);
            rtbSearch.TabIndex = 73;
            rtbSearch.Text = "";
            // 
            // tag3Text
            // 
            tag3Text.BorderStyle = BorderStyle.FixedSingle;
            tag3Text.Location = new Point(127, 304);
            tag3Text.Name = "tag3Text";
            tag3Text.Size = new Size(191, 23);
            tag3Text.TabIndex = 60;
            // 
            // btnAddCharacter
            // 
            btnAddCharacter.BackgroundImage = Properties.Resources.button_gradient;
            btnAddCharacter.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddCharacter.ForeColor = SystemColors.Window;
            btnAddCharacter.Location = new Point(190, 333);
            btnAddCharacter.Name = "btnAddCharacter";
            btnAddCharacter.Size = new Size(128, 39);
            btnAddCharacter.TabIndex = 49;
            btnAddCharacter.Text = "Add Character";
            btnAddCharacter.UseVisualStyleBackColor = true;
            btnAddCharacter.Click += btnAddCharacter_Click;
            // 
            // tag2Text
            // 
            tag2Text.BorderStyle = BorderStyle.FixedSingle;
            tag2Text.Location = new Point(127, 275);
            tag2Text.Name = "tag2Text";
            tag2Text.Size = new Size(191, 23);
            tag2Text.TabIndex = 58;
            // 
            // strengthText
            // 
            strengthText.BorderStyle = BorderStyle.FixedSingle;
            strengthText.Location = new Point(127, 159);
            strengthText.Name = "strengthText";
            strengthText.Size = new Size(191, 23);
            strengthText.TabIndex = 51;
            // 
            // moralText
            // 
            moralText.BorderStyle = BorderStyle.FixedSingle;
            moralText.Location = new Point(127, 188);
            moralText.Name = "moralText";
            moralText.Size = new Size(191, 23);
            moralText.TabIndex = 53;
            // 
            // speedText
            // 
            speedText.BorderStyle = BorderStyle.FixedSingle;
            speedText.Location = new Point(127, 217);
            speedText.Name = "speedText";
            speedText.Size = new Size(191, 23);
            speedText.TabIndex = 55;
            // 
            // pnlVisualSettings
            // 
            pnlVisualSettings.BackColor = SystemColors.Window;
            pnlVisualSettings.BackgroundImage = Properties.Resources.white_gradient;
            pnlVisualSettings.BorderStyle = BorderStyle.FixedSingle;
            pnlVisualSettings.Controls.Add(cboDefaults);
            pnlVisualSettings.Controls.Add(btnApply);
            pnlVisualSettings.Controls.Add(btnVisualSettingsBack);
            pnlVisualSettings.Controls.Add(pnlMode);
            pnlVisualSettings.Controls.Add(txtVisualSettings);
            pnlVisualSettings.Location = new Point(30, 21);
            pnlVisualSettings.Name = "pnlVisualSettings";
            pnlVisualSettings.Size = new Size(1042, 521);
            pnlVisualSettings.TabIndex = 13;
            pnlVisualSettings.Visible = false;
            // 
            // cboDefaults
            // 
            cboDefaults.AutoSize = true;
            cboDefaults.BackColor = Color.Transparent;
            cboDefaults.Font = new Font("Yu Gothic UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            cboDefaults.Location = new Point(28, 421);
            cboDefaults.Name = "cboDefaults";
            cboDefaults.Size = new Size(193, 27);
            cboDefaults.TabIndex = 83;
            cboDefaults.Text = "Make default options";
            cboDefaults.UseVisualStyleBackColor = false;
            // 
            // btnApply
            // 
            btnApply.BackgroundImage = Properties.Resources.button_gradient;
            btnApply.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnApply.ForeColor = SystemColors.Window;
            btnApply.Location = new Point(28, 454);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(103, 56);
            btnApply.TabIndex = 82;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnVisualSettingsBack
            // 
            btnVisualSettingsBack.BackgroundImage = Properties.Resources.button_gradient;
            btnVisualSettingsBack.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnVisualSettingsBack.ForeColor = SystemColors.Window;
            btnVisualSettingsBack.Location = new Point(908, 454);
            btnVisualSettingsBack.Name = "btnVisualSettingsBack";
            btnVisualSettingsBack.Size = new Size(103, 56);
            btnVisualSettingsBack.TabIndex = 81;
            btnVisualSettingsBack.Text = "Back";
            btnVisualSettingsBack.UseVisualStyleBackColor = true;
            btnVisualSettingsBack.Click += btnVisualSettingsBack_Click;
            // 
            // pnlMode
            // 
            pnlMode.BackColor = SystemColors.Menu;
            pnlMode.BackgroundImage = Properties.Resources.white_gradient;
            pnlMode.BorderStyle = BorderStyle.FixedSingle;
            pnlMode.Controls.Add(rdoDarkMode);
            pnlMode.Controls.Add(rdoLightMode);
            pnlMode.Controls.Add(txtMode);
            pnlMode.Location = new Point(28, 77);
            pnlMode.Name = "pnlMode";
            pnlMode.Size = new Size(252, 100);
            pnlMode.TabIndex = 14;
            // 
            // rdoDarkMode
            // 
            rdoDarkMode.AutoSize = true;
            rdoDarkMode.BackColor = Color.Transparent;
            rdoDarkMode.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rdoDarkMode.Location = new Point(131, 61);
            rdoDarkMode.Name = "rdoDarkMode";
            rdoDarkMode.Size = new Size(109, 25);
            rdoDarkMode.TabIndex = 17;
            rdoDarkMode.TabStop = true;
            rdoDarkMode.Text = "Dark Mode";
            rdoDarkMode.UseVisualStyleBackColor = false;
            // 
            // rdoLightMode
            // 
            rdoLightMode.AutoSize = true;
            rdoLightMode.BackColor = Color.Transparent;
            rdoLightMode.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rdoLightMode.Location = new Point(12, 61);
            rdoLightMode.Name = "rdoLightMode";
            rdoLightMode.Size = new Size(113, 25);
            rdoLightMode.TabIndex = 16;
            rdoLightMode.TabStop = true;
            rdoLightMode.Text = "Light Mode";
            rdoLightMode.UseVisualStyleBackColor = false;
            // 
            // txtMode
            // 
            txtMode.AutoSize = true;
            txtMode.BackColor = Color.Transparent;
            txtMode.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            txtMode.Location = new Point(82, 9);
            txtMode.Name = "txtMode";
            txtMode.Size = new Size(88, 37);
            txtMode.TabIndex = 15;
            txtMode.Text = "Mode";
            // 
            // txtVisualSettings
            // 
            txtVisualSettings.AutoSize = true;
            txtVisualSettings.BackColor = Color.Transparent;
            txtVisualSettings.Font = new Font("Yu Gothic UI Semibold", 30F, FontStyle.Bold, GraphicsUnit.Point);
            txtVisualSettings.Location = new Point(377, 8);
            txtVisualSettings.Name = "txtVisualSettings";
            txtVisualSettings.Size = new Size(286, 54);
            txtVisualSettings.TabIndex = 13;
            txtVisualSettings.Text = "Visual Settings";
            // 
            // pnlTest
            // 
            pnlTest.BackColor = Color.White;
            pnlTest.BorderStyle = BorderStyle.FixedSingle;
            pnlTest.Controls.Add(btnTestBack);
            pnlTest.Controls.Add(gboPlayers);
            pnlTest.Controls.Add(gboNumPlayers);
            pnlTest.Controls.Add(btnBattle);
            pnlTest.Controls.Add(rtbTest);
            pnlTest.Location = new Point(13, 10);
            pnlTest.Name = "pnlTest";
            pnlTest.Size = new Size(1735, 959);
            pnlTest.TabIndex = 14;
            pnlTest.Visible = false;
            // 
            // btnTestBack
            // 
            btnTestBack.Location = new Point(1624, 919);
            btnTestBack.Name = "btnTestBack";
            btnTestBack.Size = new Size(92, 23);
            btnTestBack.TabIndex = 4;
            btnTestBack.Text = "Close";
            btnTestBack.UseVisualStyleBackColor = true;
            btnTestBack.Click += btnTestBack_Click;
            // 
            // gboPlayers
            // 
            gboPlayers.Controls.Add(cboPlayer4Heal);
            gboPlayers.Controls.Add(cboPlayer4Explosive);
            gboPlayers.Controls.Add(cboPlayer3Heal);
            gboPlayers.Controls.Add(cboPlayer3Explosive);
            gboPlayers.Controls.Add(cboPlayer2Heal);
            gboPlayers.Controls.Add(cboPlayer2Explosive);
            gboPlayers.Controls.Add(cboPlayer1Heal);
            gboPlayers.Controls.Add(cboPlayer1Explosive);
            gboPlayers.Controls.Add(txtPlayer4Moral);
            gboPlayers.Controls.Add(txtPlayer4Speed);
            gboPlayers.Controls.Add(txtPlayer4Damage);
            gboPlayers.Controls.Add(txtPlayer3Moral);
            gboPlayers.Controls.Add(txtPlayer3Speed);
            gboPlayers.Controls.Add(txtPlayer3Damage);
            gboPlayers.Controls.Add(txtPlayer2Moral);
            gboPlayers.Controls.Add(txtPlayer2Speed);
            gboPlayers.Controls.Add(txtPlayer2Damage);
            gboPlayers.Controls.Add(txtPlayer1Moral);
            gboPlayers.Controls.Add(txtPlayer1Speed);
            gboPlayers.Controls.Add(txtPlayer1Damage);
            gboPlayers.Location = new Point(272, 18);
            gboPlayers.Name = "gboPlayers";
            gboPlayers.Size = new Size(600, 142);
            gboPlayers.TabIndex = 3;
            gboPlayers.TabStop = false;
            gboPlayers.Text = "Player Stats";
            // 
            // cboPlayer4Heal
            // 
            cboPlayer4Heal.AutoSize = true;
            cboPlayer4Heal.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboPlayer4Heal.Location = new Point(534, 111);
            cboPlayer4Heal.Name = "cboPlayer4Heal";
            cboPlayer4Heal.Size = new Size(49, 17);
            cboPlayer4Heal.TabIndex = 19;
            cboPlayer4Heal.Text = "Heal";
            cboPlayer4Heal.UseVisualStyleBackColor = true;
            // 
            // cboPlayer4Explosive
            // 
            cboPlayer4Explosive.AutoSize = true;
            cboPlayer4Explosive.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboPlayer4Explosive.Location = new Point(458, 111);
            cboPlayer4Explosive.Name = "cboPlayer4Explosive";
            cboPlayer4Explosive.Size = new Size(73, 17);
            cboPlayer4Explosive.TabIndex = 18;
            cboPlayer4Explosive.Text = "Explosive";
            cboPlayer4Explosive.UseVisualStyleBackColor = true;
            // 
            // cboPlayer3Heal
            // 
            cboPlayer3Heal.AutoSize = true;
            cboPlayer3Heal.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboPlayer3Heal.Location = new Point(389, 111);
            cboPlayer3Heal.Name = "cboPlayer3Heal";
            cboPlayer3Heal.Size = new Size(49, 17);
            cboPlayer3Heal.TabIndex = 17;
            cboPlayer3Heal.Text = "Heal";
            cboPlayer3Heal.UseVisualStyleBackColor = true;
            // 
            // cboPlayer3Explosive
            // 
            cboPlayer3Explosive.AutoSize = true;
            cboPlayer3Explosive.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboPlayer3Explosive.Location = new Point(313, 111);
            cboPlayer3Explosive.Name = "cboPlayer3Explosive";
            cboPlayer3Explosive.Size = new Size(73, 17);
            cboPlayer3Explosive.TabIndex = 16;
            cboPlayer3Explosive.Text = "Explosive";
            cboPlayer3Explosive.UseVisualStyleBackColor = true;
            // 
            // cboPlayer2Heal
            // 
            cboPlayer2Heal.AutoSize = true;
            cboPlayer2Heal.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboPlayer2Heal.Location = new Point(237, 111);
            cboPlayer2Heal.Name = "cboPlayer2Heal";
            cboPlayer2Heal.Size = new Size(49, 17);
            cboPlayer2Heal.TabIndex = 15;
            cboPlayer2Heal.Text = "Heal";
            cboPlayer2Heal.UseVisualStyleBackColor = true;
            // 
            // cboPlayer2Explosive
            // 
            cboPlayer2Explosive.AutoSize = true;
            cboPlayer2Explosive.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboPlayer2Explosive.Location = new Point(161, 111);
            cboPlayer2Explosive.Name = "cboPlayer2Explosive";
            cboPlayer2Explosive.Size = new Size(73, 17);
            cboPlayer2Explosive.TabIndex = 14;
            cboPlayer2Explosive.Text = "Explosive";
            cboPlayer2Explosive.UseVisualStyleBackColor = true;
            // 
            // cboPlayer1Heal
            // 
            cboPlayer1Heal.AutoSize = true;
            cboPlayer1Heal.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboPlayer1Heal.Location = new Point(92, 111);
            cboPlayer1Heal.Name = "cboPlayer1Heal";
            cboPlayer1Heal.Size = new Size(49, 17);
            cboPlayer1Heal.TabIndex = 13;
            cboPlayer1Heal.Text = "Heal";
            cboPlayer1Heal.UseVisualStyleBackColor = true;
            // 
            // cboPlayer1Explosive
            // 
            cboPlayer1Explosive.AutoSize = true;
            cboPlayer1Explosive.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cboPlayer1Explosive.Location = new Point(16, 111);
            cboPlayer1Explosive.Name = "cboPlayer1Explosive";
            cboPlayer1Explosive.Size = new Size(73, 17);
            cboPlayer1Explosive.TabIndex = 12;
            cboPlayer1Explosive.Text = "Explosive";
            cboPlayer1Explosive.UseVisualStyleBackColor = true;
            // 
            // txtPlayer4Moral
            // 
            txtPlayer4Moral.Location = new Point(471, 83);
            txtPlayer4Moral.Name = "txtPlayer4Moral";
            txtPlayer4Moral.PlaceholderText = "Player 4 Morality";
            txtPlayer4Moral.Size = new Size(100, 23);
            txtPlayer4Moral.TabIndex = 11;
            // 
            // txtPlayer4Speed
            // 
            txtPlayer4Speed.Location = new Point(471, 52);
            txtPlayer4Speed.Name = "txtPlayer4Speed";
            txtPlayer4Speed.PlaceholderText = "Player 4 Speed";
            txtPlayer4Speed.Size = new Size(100, 23);
            txtPlayer4Speed.TabIndex = 10;
            // 
            // txtPlayer4Damage
            // 
            txtPlayer4Damage.Location = new Point(471, 23);
            txtPlayer4Damage.Name = "txtPlayer4Damage";
            txtPlayer4Damage.PlaceholderText = "Player 4 Damage";
            txtPlayer4Damage.Size = new Size(100, 23);
            txtPlayer4Damage.TabIndex = 9;
            // 
            // txtPlayer3Moral
            // 
            txtPlayer3Moral.Location = new Point(326, 83);
            txtPlayer3Moral.Name = "txtPlayer3Moral";
            txtPlayer3Moral.PlaceholderText = "Player 3 Morality";
            txtPlayer3Moral.Size = new Size(100, 23);
            txtPlayer3Moral.TabIndex = 8;
            // 
            // txtPlayer3Speed
            // 
            txtPlayer3Speed.Location = new Point(326, 52);
            txtPlayer3Speed.Name = "txtPlayer3Speed";
            txtPlayer3Speed.PlaceholderText = "Player 3 Speed";
            txtPlayer3Speed.Size = new Size(100, 23);
            txtPlayer3Speed.TabIndex = 7;
            // 
            // txtPlayer3Damage
            // 
            txtPlayer3Damage.Location = new Point(326, 23);
            txtPlayer3Damage.Name = "txtPlayer3Damage";
            txtPlayer3Damage.PlaceholderText = "Player 3 Damage";
            txtPlayer3Damage.Size = new Size(100, 23);
            txtPlayer3Damage.TabIndex = 6;
            // 
            // txtPlayer2Moral
            // 
            txtPlayer2Moral.Location = new Point(174, 83);
            txtPlayer2Moral.Name = "txtPlayer2Moral";
            txtPlayer2Moral.PlaceholderText = "Player 2 Morality";
            txtPlayer2Moral.Size = new Size(100, 23);
            txtPlayer2Moral.TabIndex = 5;
            // 
            // txtPlayer2Speed
            // 
            txtPlayer2Speed.Location = new Point(174, 52);
            txtPlayer2Speed.Name = "txtPlayer2Speed";
            txtPlayer2Speed.PlaceholderText = "Player 2 Speed";
            txtPlayer2Speed.Size = new Size(100, 23);
            txtPlayer2Speed.TabIndex = 4;
            // 
            // txtPlayer2Damage
            // 
            txtPlayer2Damage.Location = new Point(174, 23);
            txtPlayer2Damage.Name = "txtPlayer2Damage";
            txtPlayer2Damage.PlaceholderText = "Player 2 Damage";
            txtPlayer2Damage.Size = new Size(100, 23);
            txtPlayer2Damage.TabIndex = 3;
            // 
            // txtPlayer1Moral
            // 
            txtPlayer1Moral.Location = new Point(29, 83);
            txtPlayer1Moral.Name = "txtPlayer1Moral";
            txtPlayer1Moral.PlaceholderText = "Player 1 Morality";
            txtPlayer1Moral.Size = new Size(100, 23);
            txtPlayer1Moral.TabIndex = 2;
            // 
            // txtPlayer1Speed
            // 
            txtPlayer1Speed.Location = new Point(29, 52);
            txtPlayer1Speed.Name = "txtPlayer1Speed";
            txtPlayer1Speed.PlaceholderText = "Player 1 Speed";
            txtPlayer1Speed.Size = new Size(100, 23);
            txtPlayer1Speed.TabIndex = 1;
            // 
            // txtPlayer1Damage
            // 
            txtPlayer1Damage.Location = new Point(29, 23);
            txtPlayer1Damage.Name = "txtPlayer1Damage";
            txtPlayer1Damage.PlaceholderText = "Player 1 Damage";
            txtPlayer1Damage.Size = new Size(100, 23);
            txtPlayer1Damage.TabIndex = 0;
            // 
            // gboNumPlayers
            // 
            gboNumPlayers.Controls.Add(rdoFour);
            gboNumPlayers.Controls.Add(rdoThree);
            gboNumPlayers.Controls.Add(rdoTwo);
            gboNumPlayers.Location = new Point(128, 10);
            gboNumPlayers.Name = "gboNumPlayers";
            gboNumPlayers.Size = new Size(117, 45);
            gboNumPlayers.TabIndex = 2;
            gboNumPlayers.TabStop = false;
            // 
            // rdoFour
            // 
            rdoFour.AutoSize = true;
            rdoFour.Location = new Point(79, 16);
            rdoFour.Name = "rdoFour";
            rdoFour.Size = new Size(31, 19);
            rdoFour.TabIndex = 2;
            rdoFour.TabStop = true;
            rdoFour.Text = "4";
            rdoFour.UseVisualStyleBackColor = true;
            // 
            // rdoThree
            // 
            rdoThree.AutoSize = true;
            rdoThree.Location = new Point(43, 16);
            rdoThree.Name = "rdoThree";
            rdoThree.Size = new Size(31, 19);
            rdoThree.TabIndex = 1;
            rdoThree.TabStop = true;
            rdoThree.Text = "3";
            rdoThree.UseVisualStyleBackColor = true;
            // 
            // rdoTwo
            // 
            rdoTwo.AutoSize = true;
            rdoTwo.Location = new Point(6, 16);
            rdoTwo.Name = "rdoTwo";
            rdoTwo.Size = new Size(31, 19);
            rdoTwo.TabIndex = 0;
            rdoTwo.TabStop = true;
            rdoTwo.Text = "2";
            rdoTwo.UseVisualStyleBackColor = true;
            // 
            // btnBattle
            // 
            btnBattle.Location = new Point(20, 22);
            btnBattle.Name = "btnBattle";
            btnBattle.Size = new Size(92, 23);
            btnBattle.TabIndex = 1;
            btnBattle.Text = "Battle";
            btnBattle.UseVisualStyleBackColor = true;
            btnBattle.Click += btnBattle_Click;
            // 
            // rtbTest
            // 
            rtbTest.Location = new Point(20, 166);
            rtbTest.Name = "rtbTest";
            rtbTest.Size = new Size(1661, 738);
            rtbTest.TabIndex = 0;
            rtbTest.Text = "";
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaptionText;
            BackgroundImage = Properties.Resources.white_gradient;
            ClientSize = new Size(1866, 994);
            Controls.Add(pnlOptions);
            Controls.Add(pnlMainMenu);
            Controls.Add(pnlChangelog);
            Controls.Add(pnlCharacterEntry);
            Controls.Add(pnlVisualSettings);
            Controls.Add(pnlMenu2);
            Controls.Add(pnlTest);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Start";
            Text = "Carnage";
            WindowState = FormWindowState.Maximized;
            grbNumberOptions.ResumeLayout(false);
            grbNumberOptions.PerformLayout();
            pnlOptions.ResumeLayout(false);
            pnlOptions.PerformLayout();
            pnlStats.ResumeLayout(false);
            pnlStats.PerformLayout();
            pnlRealisticSettings.ResumeLayout(false);
            pnlRealisticSettings.PerformLayout();
            pnlGeneralSettings.ResumeLayout(false);
            pnlGeneralSettings.PerformLayout();
            pnlMenu2.ResumeLayout(false);
            pnlMenu2.PerformLayout();
            pnlSettings.ResumeLayout(false);
            pnlSettings.PerformLayout();
            pnlForest.ResumeLayout(false);
            pnlForest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureForest).EndInit();
            pnlMainMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureSubLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureMainLog).EndInit();
            pnlChangelog.ResumeLayout(false);
            pnlChangelog.PerformLayout();
            pnlCharacterEntry.ResumeLayout(false);
            pnlCharacterEntry.PerformLayout();
            pnlVisualSettings.ResumeLayout(false);
            pnlVisualSettings.PerformLayout();
            pnlMode.ResumeLayout(false);
            pnlMode.PerformLayout();
            pnlTest.ResumeLayout(false);
            gboPlayers.ResumeLayout(false);
            gboPlayers.PerformLayout();
            gboNumPlayers.ResumeLayout(false);
            gboNumPlayers.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Button btnCustom;
        private Button btnPreset;
        private GroupBox grbNumberOptions;
        private RadioButton rdo24;
        private RadioButton rdo48;
        private Label lblOptions;
        private Panel pnlOptions;
        private CheckBox cboRealistic;
        private CheckBox cboCombatLevel;
        private Button btnBack;
        private CheckBox cboSponsor;
        private Panel pnlMenu2;
        private Panel pnlMainMenu;
        private Button btnChangelog;
        private Button btnCharacterCreator;
        private PictureBox pictureSubLogo;
        private PictureBox pictureMainLog;
        private CheckBox cboShortBattles;
        private Panel pnlForest;
        private ComboBox cboArenas;
        private Label txtArena;
        private RichTextBox rtbForest;
        private PictureBox pictureForest;
        private Label txtSereneForest;
        private Label label1;
        private ToolTip toolTip1;
        private Panel pnlCharacterEntry;
        private Label txtCharCreator;
        private ComboBox cboTag1;
        private ComboBox cboPronoun;
        private TextBox charIDText;
        private Label label12;
        private Label charIDLabel;
        private TextBox tag3Text;
        private Button btnAddCharacter;
        private Label label2;
        private Label pronounLabel;
        private TextBox tag2Text;
        private TextBox strengthText;
        private Label label3;
        private Label strengthLabel;
        private Label label4;
        private TextBox moralText;
        private TextBox speedText;
        private Label moralLab;
        private Button btnAll;
        private Button btnCharSearch;
        private TextBox txtCharSearch;
        private Button btnTagSearch;
        private TextBox txtSearch;
        private RichTextBox rtbSearch;
        private Label txtInfo;
        private Button btnBackCharacter;
        private Panel pnlChangelog;
        private Button btnBackChange;
        private RichTextBox rtbChangelog;
        private Label txtVersion;
        private Label txtChangelog;
        private Panel pnlSettings;
        private Label txtSettings;
        private Button btnVisualSettings;
        private Button btnGameSettings;
        private Panel pnlVisualSettings;
        private Label txtVisualSettings;
        private Panel pnlMode;
        private RadioButton rdoDarkMode;
        private RadioButton rdoLightMode;
        private Label txtMode;
        private Button btnVisualSettingsBack;
        private Button btnApply;
        private CheckBox cboDefaults;
        private Label txtGameSettings;
        private Panel pnlRealisticSettings;
        private Label lblRealisticSettings;
        private Panel pnlGeneralSettings;
        private Label lblGeneralSettings;
        private CheckBox cboHunger;
        private Button btnBackGameSettings;
        private Panel pnlStats;
        private TextBox txtHealth;
        private Label lblStats;
        private CheckBox cboHealth;
        private Button btnTest;
        private Panel pnlTest;
        private RichTextBox rtbTest;
        private GroupBox gboPlayers;
        private TextBox txtPlayer1Damage;
        private GroupBox gboNumPlayers;
        private RadioButton rdoFour;
        private RadioButton rdoThree;
        private RadioButton rdoTwo;
        private Button btnBattle;
        private CheckBox cboPlayer1Heal;
        private CheckBox cboPlayer1Explosive;
        private TextBox txtPlayer4Moral;
        private TextBox txtPlayer4Speed;
        private TextBox txtPlayer4Damage;
        private TextBox txtPlayer3Moral;
        private TextBox txtPlayer3Speed;
        private TextBox txtPlayer3Damage;
        private TextBox txtPlayer2Moral;
        private TextBox txtPlayer2Speed;
        private TextBox txtPlayer2Damage;
        private TextBox txtPlayer1Moral;
        private TextBox txtPlayer1Speed;
        private CheckBox cboPlayer4Heal;
        private CheckBox cboPlayer4Explosive;
        private CheckBox cboPlayer3Heal;
        private CheckBox cboPlayer3Explosive;
        private CheckBox cboPlayer2Heal;
        private CheckBox cboPlayer2Explosive;
        private Button btnTestBack;
    }
}