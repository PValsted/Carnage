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
            lblOptions = new Label();
            pnlOptions = new Panel();
            cboSponsor = new CheckBox();
            cboCombatLevel = new CheckBox();
            cboRealistic = new CheckBox();
            cboShortBattles = new CheckBox();
            btnBack = new Button();
            pnlMenu2 = new Panel();
            label1 = new Label();
            cboArenas = new ComboBox();
            txtArena = new Label();
            pnlForest = new Panel();
            rtbForest = new RichTextBox();
            pictureForest = new PictureBox();
            txtSereneForest = new Label();
            pnlMainMenu = new Panel();
            pictureSubLogo = new PictureBox();
            pictureMainLog = new PictureBox();
            btnChangelog = new Button();
            btnCharacterCreator = new Button();
            pnlChangelog = new Panel();
            richTextBox1 = new RichTextBox();
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
            grbNumberOptions.SuspendLayout();
            pnlOptions.SuspendLayout();
            pnlMenu2.SuspendLayout();
            pnlForest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureForest).BeginInit();
            pnlMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureSubLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureMainLog).BeginInit();
            pnlChangelog.SuspendLayout();
            pnlCharacterEntry.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackgroundImage = Properties.Resources.button_gradient;
            btnStart.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = SystemColors.Window;
            btnStart.Location = new Point(298, 476);
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
            btnCustom.Location = new Point(49, 522);
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
            btnPreset.Location = new Point(241, 522);
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
            grbNumberOptions.Location = new Point(49, 389);
            grbNumberOptions.Name = "grbNumberOptions";
            grbNumberOptions.Size = new Size(245, 118);
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
            // lblOptions
            // 
            lblOptions.AutoSize = true;
            lblOptions.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblOptions.Location = new Point(3, 4);
            lblOptions.Name = "lblOptions";
            lblOptions.Size = new Size(139, 25);
            lblOptions.TabIndex = 6;
            lblOptions.Text = "Game Options:";
            // 
            // pnlOptions
            // 
            pnlOptions.BackColor = SystemColors.Window;
            pnlOptions.BorderStyle = BorderStyle.FixedSingle;
            pnlOptions.Controls.Add(cboSponsor);
            pnlOptions.Controls.Add(cboCombatLevel);
            pnlOptions.Controls.Add(cboRealistic);
            pnlOptions.Controls.Add(lblOptions);
            pnlOptions.Controls.Add(cboShortBattles);
            pnlOptions.Location = new Point(312, 361);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(264, 146);
            pnlOptions.TabIndex = 7;
            // 
            // cboSponsor
            // 
            cboSponsor.AutoSize = true;
            cboSponsor.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboSponsor.Location = new Point(3, 60);
            cboSponsor.Name = "cboSponsor";
            cboSponsor.Size = new Size(134, 25);
            cboSponsor.TabIndex = 9;
            cboSponsor.Text = "No Sponsoring";
            toolTip1.SetToolTip(cboSponsor, "The sponsor screen will automatically be skipped");
            cboSponsor.UseVisualStyleBackColor = true;
            // 
            // cboCombatLevel
            // 
            cboCombatLevel.AutoSize = true;
            cboCombatLevel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboCombatLevel.Location = new Point(3, 116);
            cboCombatLevel.Name = "cboCombatLevel";
            cboCombatLevel.Size = new Size(167, 25);
            cboCombatLevel.TabIndex = 8;
            cboCombatLevel.Text = "Show Combat Level";
            toolTip1.SetToolTip(cboCombatLevel, "Combat level determines who will go first in Realistic Mode");
            cboCombatLevel.UseVisualStyleBackColor = true;
            cboCombatLevel.Visible = false;
            // 
            // cboRealistic
            // 
            cboRealistic.AutoSize = true;
            cboRealistic.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboRealistic.Location = new Point(3, 88);
            cboRealistic.Name = "cboRealistic";
            cboRealistic.Size = new Size(130, 25);
            cboRealistic.TabIndex = 7;
            cboRealistic.Text = "Realistic Mode";
            toolTip1.SetToolTip(cboRealistic, "Characters have additional attributes like strength, morality, speed, and hunger that will affect the outcome of the game");
            cboRealistic.UseVisualStyleBackColor = true;
            cboRealistic.CheckedChanged += cboRealistic_CheckedChanged;
            // 
            // cboShortBattles
            // 
            cboShortBattles.AutoSize = true;
            cboShortBattles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboShortBattles.Location = new Point(3, 32);
            cboShortBattles.Name = "cboShortBattles";
            cboShortBattles.Size = new Size(117, 25);
            cboShortBattles.TabIndex = 5;
            cboShortBattles.Text = "Short Battles";
            toolTip1.SetToolTip(cboShortBattles, "Battles will only show significant events and the outcome");
            cboShortBattles.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.BackgroundImage = Properties.Resources.button_gradient;
            btnBack.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnBack.ForeColor = SystemColors.Window;
            btnBack.Location = new Point(487, 21);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(89, 42);
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
            pnlMenu2.Controls.Add(label1);
            pnlMenu2.Controls.Add(cboArenas);
            pnlMenu2.Controls.Add(txtArena);
            pnlMenu2.Controls.Add(btnCustom);
            pnlMenu2.Controls.Add(btnBack);
            pnlMenu2.Controls.Add(pnlForest);
            pnlMenu2.Controls.Add(pnlOptions);
            pnlMenu2.Controls.Add(btnPreset);
            pnlMenu2.Controls.Add(grbNumberOptions);
            pnlMenu2.Location = new Point(34, 29);
            pnlMenu2.Name = "pnlMenu2";
            pnlMenu2.Size = new Size(624, 605);
            pnlMenu2.TabIndex = 9;
            pnlMenu2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(49, 361);
            label1.Name = "label1";
            label1.Size = new Size(182, 25);
            label1.TabIndex = 12;
            label1.Text = "Number of tributes:";
            // 
            // cboArenas
            // 
            cboArenas.FormattingEnabled = true;
            cboArenas.Items.AddRange(new object[] { "Serene Forest" });
            cboArenas.Location = new Point(49, 69);
            cboArenas.Name = "cboArenas";
            cboArenas.Size = new Size(167, 23);
            cboArenas.TabIndex = 10;
            cboArenas.SelectedIndexChanged += cboArenas_SelectedIndexChanged;
            // 
            // txtArena
            // 
            txtArena.AutoSize = true;
            txtArena.BackColor = Color.Transparent;
            txtArena.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtArena.Location = new Point(49, 33);
            txtArena.Name = "txtArena";
            txtArena.Size = new Size(149, 25);
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
            pnlForest.Size = new Size(527, 237);
            pnlForest.TabIndex = 11;
            // 
            // rtbForest
            // 
            rtbForest.BackColor = SystemColors.Window;
            rtbForest.BorderStyle = BorderStyle.None;
            rtbForest.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            rtbForest.Location = new Point(289, 53);
            rtbForest.Margin = new Padding(3, 3, 3, 5);
            rtbForest.Name = "rtbForest";
            rtbForest.ReadOnly = true;
            rtbForest.Size = new Size(222, 168);
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
            pictureForest.Size = new Size(254, 168);
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
            pnlMainMenu.Controls.Add(pictureSubLogo);
            pnlMainMenu.Controls.Add(pictureMainLog);
            pnlMainMenu.Controls.Add(btnChangelog);
            pnlMainMenu.Controls.Add(btnCharacterCreator);
            pnlMainMenu.Controls.Add(btnStart);
            pnlMainMenu.Location = new Point(34, 25);
            pnlMainMenu.Name = "pnlMainMenu";
            pnlMainMenu.Size = new Size(1311, 698);
            pnlMainMenu.TabIndex = 10;
            // 
            // pictureSubLogo
            // 
            pictureSubLogo.Image = (Image)resources.GetObject("pictureSubLogo.Image");
            pictureSubLogo.Location = new Point(293, 313);
            pictureSubLogo.Name = "pictureSubLogo";
            pictureSubLogo.Size = new Size(725, 70);
            pictureSubLogo.TabIndex = 4;
            pictureSubLogo.TabStop = false;
            // 
            // pictureMainLog
            // 
            pictureMainLog.Image = (Image)resources.GetObject("pictureMainLog.Image");
            pictureMainLog.Location = new Point(294, 86);
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
            btnChangelog.Location = new Point(860, 476);
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
            btnCharacterCreator.Location = new Point(579, 476);
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
            pnlChangelog.Controls.Add(richTextBox1);
            pnlChangelog.Controls.Add(txtVersion);
            pnlChangelog.Controls.Add(txtChangelog);
            pnlChangelog.Controls.Add(btnBackChange);
            pnlChangelog.Location = new Point(30, 42);
            pnlChangelog.Name = "pnlChangelog";
            pnlChangelog.Size = new Size(451, 435);
            pnlChangelog.TabIndex = 12;
            pnlChangelog.Visible = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(42, 116);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(364, 229);
            richTextBox1.TabIndex = 84;
            richTextBox1.Text = "Release version!";
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
            txtVersion.Text = "What's new in Version 1.0:";
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
            btnBackChange.Location = new Point(42, 361);
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
            btnAll.Location = new Point(425, 53);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(154, 33);
            btnAll.TabIndex = 78;
            btnAll.Text = "List All Characters";
            toolTip1.SetToolTip(btnAll, "Expect this to take a while to load");
            btnAll.UseVisualStyleBackColor = true;
            btnAll.Click += btnAll_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(603, 63);
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
            pnlCharacterEntry.Size = new Size(1005, 421);
            pnlCharacterEntry.TabIndex = 11;
            pnlCharacterEntry.Visible = false;
            // 
            // btnBackCharacter
            // 
            btnBackCharacter.BackgroundImage = Properties.Resources.button_gradient;
            btnBackCharacter.Font = new Font("Constantia", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackCharacter.ForeColor = SystemColors.Window;
            btnBackCharacter.Location = new Point(859, 362);
            btnBackCharacter.Name = "btnBackCharacter";
            btnBackCharacter.Size = new Size(89, 42);
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
            btnCharSearch.Location = new Point(817, 33);
            btnCharSearch.Name = "btnCharSearch";
            btnCharSearch.Size = new Size(131, 23);
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
            txtCharSearch.Location = new Point(603, 33);
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
            btnTagSearch.Location = new Point(817, 63);
            btnTagSearch.Name = "btnTagSearch";
            btnTagSearch.Size = new Size(131, 23);
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
            rtbSearch.Location = new Point(425, 103);
            rtbSearch.Name = "rtbSearch";
            rtbSearch.Size = new Size(523, 239);
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
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1378, 748);
            Controls.Add(pnlMainMenu);
            Controls.Add(pnlMenu2);
            Controls.Add(pnlCharacterEntry);
            Controls.Add(pnlChangelog);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Start";
            Text = "Carnage";
            WindowState = FormWindowState.Maximized;
            grbNumberOptions.ResumeLayout(false);
            grbNumberOptions.PerformLayout();
            pnlOptions.ResumeLayout(false);
            pnlOptions.PerformLayout();
            pnlMenu2.ResumeLayout(false);
            pnlMenu2.PerformLayout();
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
        private RichTextBox richTextBox1;
        private Label txtVersion;
        private Label txtChangelog;
    }
}