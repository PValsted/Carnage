namespace Carnage
{
    partial class PresetCharacters48
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetCharacters48));
            btnAll = new Button();
            btnCharSearch = new Button();
            txtCharSearch = new TextBox();
            btnTagSearch = new Button();
            txtSearch = new TextBox();
            rtbSearch = new RichTextBox();
            btnRandom = new Button();
            btnEnterCharacters = new Button();
            txtD12C2 = new TextBox();
            lblD12 = new Label();
            txtD12C1 = new TextBox();
            txtD11C2 = new TextBox();
            lblD11 = new Label();
            txtD11C1 = new TextBox();
            txtD10C2 = new TextBox();
            lblD10 = new Label();
            txtD10C1 = new TextBox();
            txtD9C2 = new TextBox();
            lblD9 = new Label();
            panelCharacterSelect = new Panel();
            btnBack = new Button();
            lblWarning = new Label();
            txtD12C4 = new TextBox();
            txtD12C3 = new TextBox();
            txtD8C4 = new TextBox();
            txtD8C3 = new TextBox();
            txtD4C4 = new TextBox();
            txtD4C3 = new TextBox();
            txtD11C4 = new TextBox();
            txtD11C3 = new TextBox();
            txtD7C4 = new TextBox();
            txtD7C3 = new TextBox();
            txtD3C4 = new TextBox();
            txtD3C3 = new TextBox();
            txtD10C4 = new TextBox();
            txtD10C3 = new TextBox();
            txtD6C4 = new TextBox();
            txtD6C3 = new TextBox();
            txtD2C4 = new TextBox();
            txtD2C3 = new TextBox();
            txtD9C4 = new TextBox();
            txtD9C3 = new TextBox();
            txtD5C4 = new TextBox();
            txtD5C3 = new TextBox();
            txtD1C4 = new TextBox();
            txtD1C3 = new TextBox();
            txtD9C1 = new TextBox();
            txtD8C2 = new TextBox();
            lblD8 = new Label();
            txtD8C1 = new TextBox();
            txtD7C2 = new TextBox();
            lblD7 = new Label();
            txtD7C1 = new TextBox();
            txtD6C2 = new TextBox();
            lblD6 = new Label();
            txtD6C1 = new TextBox();
            txtD5C2 = new TextBox();
            lblD5 = new Label();
            txtD5C1 = new TextBox();
            txtD4C2 = new TextBox();
            lblD4 = new Label();
            txtD4C1 = new TextBox();
            txtD3C2 = new TextBox();
            lblD3 = new Label();
            txtD3C1 = new TextBox();
            txtD2C2 = new TextBox();
            lblD2 = new Label();
            txtD2C1 = new TextBox();
            txtD1C2 = new TextBox();
            lblD1 = new Label();
            txtD1C1 = new TextBox();
            toolTip2 = new ToolTip(components);
            toolTip1 = new ToolTip(components);
            panelCharacterSelect.SuspendLayout();
            SuspendLayout();
            // 
            // btnAll
            // 
            btnAll.BackgroundImage = Properties.Resources.button_gradient;
            btnAll.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAll.ForeColor = SystemColors.Window;
            btnAll.Location = new Point(896, 37);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(154, 33);
            btnAll.TabIndex = 72;
            btnAll.Text = "List All Characters";
            toolTip1.SetToolTip(btnAll, "Expect this to take a while to load");
            btnAll.UseVisualStyleBackColor = true;
            btnAll.Click += btnAll_Click;
            // 
            // btnCharSearch
            // 
            btnCharSearch.BackgroundImage = Properties.Resources.button_gradient;
            btnCharSearch.Font = new Font("Constantia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCharSearch.ForeColor = SystemColors.Window;
            btnCharSearch.Location = new Point(1288, 17);
            btnCharSearch.Name = "btnCharSearch";
            btnCharSearch.Size = new Size(131, 23);
            btnCharSearch.TabIndex = 71;
            btnCharSearch.Text = "Search By Character";
            btnCharSearch.UseVisualStyleBackColor = true;
            btnCharSearch.Click += btnCharSearch_Click;
            // 
            // txtCharSearch
            // 
            txtCharSearch.BorderStyle = BorderStyle.FixedSingle;
            txtCharSearch.Location = new Point(1074, 17);
            txtCharSearch.Name = "txtCharSearch";
            txtCharSearch.PlaceholderText = "See if a character is in the database";
            txtCharSearch.Size = new Size(208, 23);
            txtCharSearch.TabIndex = 70;
            // 
            // btnTagSearch
            // 
            btnTagSearch.BackgroundImage = Properties.Resources.button_gradient;
            btnTagSearch.Font = new Font("Constantia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnTagSearch.ForeColor = SystemColors.Window;
            btnTagSearch.Location = new Point(1288, 47);
            btnTagSearch.Name = "btnTagSearch";
            btnTagSearch.Size = new Size(131, 23);
            btnTagSearch.TabIndex = 69;
            btnTagSearch.Text = "Search By Tag";
            btnTagSearch.UseVisualStyleBackColor = true;
            btnTagSearch.Click += btnTagSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(1074, 47);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Mouse over to see examples of tags";
            txtSearch.Size = new Size(208, 23);
            txtSearch.TabIndex = 68;
            toolTip2.SetToolTip(txtSearch, "Try also searching specifics, like the name of a show");
            toolTip1.SetToolTip(txtSearch, "Main categories include Anime, Literature, Movies, Real Life, TV Shows, Special Characters, and Video Games.");
            // 
            // rtbSearch
            // 
            rtbSearch.Location = new Point(896, 87);
            rtbSearch.Name = "rtbSearch";
            rtbSearch.Size = new Size(523, 592);
            rtbSearch.TabIndex = 67;
            rtbSearch.Text = "";
            // 
            // btnRandom
            // 
            btnRandom.BackgroundImage = Properties.Resources.button_gradient;
            btnRandom.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRandom.ForeColor = SystemColors.Window;
            btnRandom.Location = new Point(34, 23);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(111, 33);
            btnRandom.TabIndex = 66;
            btnRandom.Text = "Randomize";
            toolTip1.SetToolTip(btnRandom, "Fills each box with a random character from the database!");
            btnRandom.UseVisualStyleBackColor = true;
            btnRandom.Click += btnRandom_Click;
            // 
            // btnEnterCharacters
            // 
            btnEnterCharacters.BackgroundImage = Properties.Resources.button_gradient;
            btnEnterCharacters.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnterCharacters.ForeColor = SystemColors.Window;
            btnEnterCharacters.Location = new Point(34, 703);
            btnEnterCharacters.Name = "btnEnterCharacters";
            btnEnterCharacters.Size = new Size(151, 62);
            btnEnterCharacters.TabIndex = 64;
            btnEnterCharacters.Text = "Enter Characters";
            btnEnterCharacters.UseVisualStyleBackColor = true;
            btnEnterCharacters.Click += btnEnterCharacters_Click;
            // 
            // txtD12C2
            // 
            txtD12C2.BorderStyle = BorderStyle.FixedSingle;
            txtD12C2.Location = new Point(631, 595);
            txtD12C2.Name = "txtD12C2";
            txtD12C2.Size = new Size(208, 23);
            txtD12C2.TabIndex = 36;
            // 
            // lblD12
            // 
            lblD12.AutoSize = true;
            lblD12.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD12.Location = new Point(631, 539);
            lblD12.Name = "lblD12";
            lblD12.Size = new Size(81, 21);
            lblD12.TabIndex = 35;
            lblD12.Text = "District 12";
            // 
            // txtD12C1
            // 
            txtD12C1.BorderStyle = BorderStyle.FixedSingle;
            txtD12C1.Location = new Point(631, 566);
            txtD12C1.Name = "txtD12C1";
            txtD12C1.Size = new Size(208, 23);
            txtD12C1.TabIndex = 34;
            // 
            // txtD11C2
            // 
            txtD11C2.BorderStyle = BorderStyle.FixedSingle;
            txtD11C2.Location = new Point(631, 437);
            txtD11C2.Name = "txtD11C2";
            txtD11C2.Size = new Size(208, 23);
            txtD11C2.TabIndex = 33;
            // 
            // lblD11
            // 
            lblD11.AutoSize = true;
            lblD11.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD11.Location = new Point(631, 381);
            lblD11.Name = "lblD11";
            lblD11.Size = new Size(78, 21);
            lblD11.TabIndex = 32;
            lblD11.Text = "District 11";
            // 
            // txtD11C1
            // 
            txtD11C1.BorderStyle = BorderStyle.FixedSingle;
            txtD11C1.Location = new Point(631, 408);
            txtD11C1.Name = "txtD11C1";
            txtD11C1.Size = new Size(208, 23);
            txtD11C1.TabIndex = 31;
            // 
            // txtD10C2
            // 
            txtD10C2.BorderStyle = BorderStyle.FixedSingle;
            txtD10C2.Location = new Point(631, 281);
            txtD10C2.Name = "txtD10C2";
            txtD10C2.Size = new Size(208, 23);
            txtD10C2.TabIndex = 30;
            // 
            // lblD10
            // 
            lblD10.AutoSize = true;
            lblD10.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD10.Location = new Point(631, 225);
            lblD10.Name = "lblD10";
            lblD10.Size = new Size(81, 21);
            lblD10.TabIndex = 29;
            lblD10.Text = "District 10";
            // 
            // txtD10C1
            // 
            txtD10C1.BorderStyle = BorderStyle.FixedSingle;
            txtD10C1.Location = new Point(631, 252);
            txtD10C1.Name = "txtD10C1";
            txtD10C1.Size = new Size(208, 23);
            txtD10C1.TabIndex = 28;
            // 
            // txtD9C2
            // 
            txtD9C2.BorderStyle = BorderStyle.FixedSingle;
            txtD9C2.Location = new Point(631, 124);
            txtD9C2.Name = "txtD9C2";
            txtD9C2.Size = new Size(208, 23);
            txtD9C2.TabIndex = 27;
            // 
            // lblD9
            // 
            lblD9.AutoSize = true;
            lblD9.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD9.Location = new Point(631, 68);
            lblD9.Name = "lblD9";
            lblD9.Size = new Size(75, 21);
            lblD9.TabIndex = 26;
            lblD9.Text = "District 9";
            // 
            // panelCharacterSelect
            // 
            panelCharacterSelect.AutoScroll = true;
            panelCharacterSelect.BackColor = SystemColors.Window;
            panelCharacterSelect.BorderStyle = BorderStyle.FixedSingle;
            panelCharacterSelect.Controls.Add(btnBack);
            panelCharacterSelect.Controls.Add(lblWarning);
            panelCharacterSelect.Controls.Add(txtD12C4);
            panelCharacterSelect.Controls.Add(txtD12C3);
            panelCharacterSelect.Controls.Add(txtD8C4);
            panelCharacterSelect.Controls.Add(txtD8C3);
            panelCharacterSelect.Controls.Add(txtD4C4);
            panelCharacterSelect.Controls.Add(txtD4C3);
            panelCharacterSelect.Controls.Add(txtD11C4);
            panelCharacterSelect.Controls.Add(txtD11C3);
            panelCharacterSelect.Controls.Add(txtD7C4);
            panelCharacterSelect.Controls.Add(txtD7C3);
            panelCharacterSelect.Controls.Add(txtD3C4);
            panelCharacterSelect.Controls.Add(txtD3C3);
            panelCharacterSelect.Controls.Add(txtD10C4);
            panelCharacterSelect.Controls.Add(txtD10C3);
            panelCharacterSelect.Controls.Add(txtD6C4);
            panelCharacterSelect.Controls.Add(txtD6C3);
            panelCharacterSelect.Controls.Add(txtD2C4);
            panelCharacterSelect.Controls.Add(txtD2C3);
            panelCharacterSelect.Controls.Add(txtD9C4);
            panelCharacterSelect.Controls.Add(txtD9C3);
            panelCharacterSelect.Controls.Add(txtD5C4);
            panelCharacterSelect.Controls.Add(txtD5C3);
            panelCharacterSelect.Controls.Add(txtD1C4);
            panelCharacterSelect.Controls.Add(txtD1C3);
            panelCharacterSelect.Controls.Add(btnAll);
            panelCharacterSelect.Controls.Add(btnCharSearch);
            panelCharacterSelect.Controls.Add(txtCharSearch);
            panelCharacterSelect.Controls.Add(btnTagSearch);
            panelCharacterSelect.Controls.Add(txtSearch);
            panelCharacterSelect.Controls.Add(rtbSearch);
            panelCharacterSelect.Controls.Add(btnRandom);
            panelCharacterSelect.Controls.Add(btnEnterCharacters);
            panelCharacterSelect.Controls.Add(txtD12C2);
            panelCharacterSelect.Controls.Add(lblD12);
            panelCharacterSelect.Controls.Add(txtD12C1);
            panelCharacterSelect.Controls.Add(txtD11C2);
            panelCharacterSelect.Controls.Add(lblD11);
            panelCharacterSelect.Controls.Add(txtD11C1);
            panelCharacterSelect.Controls.Add(txtD10C2);
            panelCharacterSelect.Controls.Add(lblD10);
            panelCharacterSelect.Controls.Add(txtD10C1);
            panelCharacterSelect.Controls.Add(txtD9C2);
            panelCharacterSelect.Controls.Add(lblD9);
            panelCharacterSelect.Controls.Add(txtD9C1);
            panelCharacterSelect.Controls.Add(txtD8C2);
            panelCharacterSelect.Controls.Add(lblD8);
            panelCharacterSelect.Controls.Add(txtD8C1);
            panelCharacterSelect.Controls.Add(txtD7C2);
            panelCharacterSelect.Controls.Add(lblD7);
            panelCharacterSelect.Controls.Add(txtD7C1);
            panelCharacterSelect.Controls.Add(txtD6C2);
            panelCharacterSelect.Controls.Add(lblD6);
            panelCharacterSelect.Controls.Add(txtD6C1);
            panelCharacterSelect.Controls.Add(txtD5C2);
            panelCharacterSelect.Controls.Add(lblD5);
            panelCharacterSelect.Controls.Add(txtD5C1);
            panelCharacterSelect.Controls.Add(txtD4C2);
            panelCharacterSelect.Controls.Add(lblD4);
            panelCharacterSelect.Controls.Add(txtD4C1);
            panelCharacterSelect.Controls.Add(txtD3C2);
            panelCharacterSelect.Controls.Add(lblD3);
            panelCharacterSelect.Controls.Add(txtD3C1);
            panelCharacterSelect.Controls.Add(txtD2C2);
            panelCharacterSelect.Controls.Add(lblD2);
            panelCharacterSelect.Controls.Add(txtD2C1);
            panelCharacterSelect.Controls.Add(txtD1C2);
            panelCharacterSelect.Controls.Add(lblD1);
            panelCharacterSelect.Controls.Add(txtD1C1);
            panelCharacterSelect.Location = new Point(24, 20);
            panelCharacterSelect.Name = "panelCharacterSelect";
            panelCharacterSelect.Size = new Size(1451, 791);
            panelCharacterSelect.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackgroundImage = Properties.Resources.button_gradient;
            btnBack.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.ForeColor = SystemColors.Window;
            btnBack.Location = new Point(688, 703);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(151, 62);
            btnBack.TabIndex = 98;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblWarning.Location = new Point(191, 727);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(338, 15);
            lblWarning.TabIndex = 99;
            lblWarning.Text = "Expect a small wait time as the program loads the characters in.";
            // 
            // txtD12C4
            // 
            txtD12C4.BorderStyle = BorderStyle.FixedSingle;
            txtD12C4.Location = new Point(631, 653);
            txtD12C4.Name = "txtD12C4";
            txtD12C4.Size = new Size(208, 23);
            txtD12C4.TabIndex = 98;
            // 
            // txtD12C3
            // 
            txtD12C3.BorderStyle = BorderStyle.FixedSingle;
            txtD12C3.Location = new Point(631, 624);
            txtD12C3.Name = "txtD12C3";
            txtD12C3.Size = new Size(208, 23);
            txtD12C3.TabIndex = 97;
            // 
            // txtD8C4
            // 
            txtD8C4.BorderStyle = BorderStyle.FixedSingle;
            txtD8C4.Location = new Point(330, 653);
            txtD8C4.Name = "txtD8C4";
            txtD8C4.Size = new Size(208, 23);
            txtD8C4.TabIndex = 96;
            // 
            // txtD8C3
            // 
            txtD8C3.BorderStyle = BorderStyle.FixedSingle;
            txtD8C3.Location = new Point(330, 624);
            txtD8C3.Name = "txtD8C3";
            txtD8C3.Size = new Size(208, 23);
            txtD8C3.TabIndex = 95;
            // 
            // txtD4C4
            // 
            txtD4C4.BorderStyle = BorderStyle.FixedSingle;
            txtD4C4.Location = new Point(34, 653);
            txtD4C4.Name = "txtD4C4";
            txtD4C4.Size = new Size(208, 23);
            txtD4C4.TabIndex = 94;
            // 
            // txtD4C3
            // 
            txtD4C3.BorderStyle = BorderStyle.FixedSingle;
            txtD4C3.Location = new Point(34, 624);
            txtD4C3.Name = "txtD4C3";
            txtD4C3.Size = new Size(208, 23);
            txtD4C3.TabIndex = 93;
            // 
            // txtD11C4
            // 
            txtD11C4.BorderStyle = BorderStyle.FixedSingle;
            txtD11C4.Location = new Point(631, 495);
            txtD11C4.Name = "txtD11C4";
            txtD11C4.Size = new Size(208, 23);
            txtD11C4.TabIndex = 92;
            // 
            // txtD11C3
            // 
            txtD11C3.BorderStyle = BorderStyle.FixedSingle;
            txtD11C3.Location = new Point(631, 466);
            txtD11C3.Name = "txtD11C3";
            txtD11C3.Size = new Size(208, 23);
            txtD11C3.TabIndex = 91;
            // 
            // txtD7C4
            // 
            txtD7C4.BorderStyle = BorderStyle.FixedSingle;
            txtD7C4.Location = new Point(330, 495);
            txtD7C4.Name = "txtD7C4";
            txtD7C4.Size = new Size(208, 23);
            txtD7C4.TabIndex = 90;
            // 
            // txtD7C3
            // 
            txtD7C3.BorderStyle = BorderStyle.FixedSingle;
            txtD7C3.Location = new Point(330, 466);
            txtD7C3.Name = "txtD7C3";
            txtD7C3.Size = new Size(208, 23);
            txtD7C3.TabIndex = 89;
            // 
            // txtD3C4
            // 
            txtD3C4.BorderStyle = BorderStyle.FixedSingle;
            txtD3C4.Location = new Point(34, 495);
            txtD3C4.Name = "txtD3C4";
            txtD3C4.Size = new Size(208, 23);
            txtD3C4.TabIndex = 88;
            // 
            // txtD3C3
            // 
            txtD3C3.BorderStyle = BorderStyle.FixedSingle;
            txtD3C3.Location = new Point(34, 466);
            txtD3C3.Name = "txtD3C3";
            txtD3C3.Size = new Size(208, 23);
            txtD3C3.TabIndex = 87;
            // 
            // txtD10C4
            // 
            txtD10C4.BorderStyle = BorderStyle.FixedSingle;
            txtD10C4.Location = new Point(631, 339);
            txtD10C4.Name = "txtD10C4";
            txtD10C4.Size = new Size(208, 23);
            txtD10C4.TabIndex = 86;
            // 
            // txtD10C3
            // 
            txtD10C3.BorderStyle = BorderStyle.FixedSingle;
            txtD10C3.Location = new Point(631, 310);
            txtD10C3.Name = "txtD10C3";
            txtD10C3.Size = new Size(208, 23);
            txtD10C3.TabIndex = 85;
            // 
            // txtD6C4
            // 
            txtD6C4.BorderStyle = BorderStyle.FixedSingle;
            txtD6C4.Location = new Point(330, 339);
            txtD6C4.Name = "txtD6C4";
            txtD6C4.Size = new Size(208, 23);
            txtD6C4.TabIndex = 84;
            // 
            // txtD6C3
            // 
            txtD6C3.BorderStyle = BorderStyle.FixedSingle;
            txtD6C3.Location = new Point(330, 310);
            txtD6C3.Name = "txtD6C3";
            txtD6C3.Size = new Size(208, 23);
            txtD6C3.TabIndex = 83;
            // 
            // txtD2C4
            // 
            txtD2C4.BorderStyle = BorderStyle.FixedSingle;
            txtD2C4.Location = new Point(34, 339);
            txtD2C4.Name = "txtD2C4";
            txtD2C4.Size = new Size(208, 23);
            txtD2C4.TabIndex = 82;
            // 
            // txtD2C3
            // 
            txtD2C3.BorderStyle = BorderStyle.FixedSingle;
            txtD2C3.Location = new Point(34, 310);
            txtD2C3.Name = "txtD2C3";
            txtD2C3.Size = new Size(208, 23);
            txtD2C3.TabIndex = 81;
            // 
            // txtD9C4
            // 
            txtD9C4.BorderStyle = BorderStyle.FixedSingle;
            txtD9C4.Location = new Point(631, 182);
            txtD9C4.Name = "txtD9C4";
            txtD9C4.Size = new Size(208, 23);
            txtD9C4.TabIndex = 80;
            // 
            // txtD9C3
            // 
            txtD9C3.BorderStyle = BorderStyle.FixedSingle;
            txtD9C3.Location = new Point(631, 153);
            txtD9C3.Name = "txtD9C3";
            txtD9C3.Size = new Size(208, 23);
            txtD9C3.TabIndex = 79;
            // 
            // txtD5C4
            // 
            txtD5C4.BorderStyle = BorderStyle.FixedSingle;
            txtD5C4.Location = new Point(330, 182);
            txtD5C4.Name = "txtD5C4";
            txtD5C4.Size = new Size(208, 23);
            txtD5C4.TabIndex = 78;
            // 
            // txtD5C3
            // 
            txtD5C3.BorderStyle = BorderStyle.FixedSingle;
            txtD5C3.Location = new Point(330, 153);
            txtD5C3.Name = "txtD5C3";
            txtD5C3.Size = new Size(208, 23);
            txtD5C3.TabIndex = 77;
            // 
            // txtD1C4
            // 
            txtD1C4.BorderStyle = BorderStyle.FixedSingle;
            txtD1C4.Location = new Point(34, 182);
            txtD1C4.Name = "txtD1C4";
            txtD1C4.Size = new Size(208, 23);
            txtD1C4.TabIndex = 74;
            // 
            // txtD1C3
            // 
            txtD1C3.BorderStyle = BorderStyle.FixedSingle;
            txtD1C3.Location = new Point(34, 153);
            txtD1C3.Name = "txtD1C3";
            txtD1C3.Size = new Size(208, 23);
            txtD1C3.TabIndex = 73;
            // 
            // txtD9C1
            // 
            txtD9C1.BorderStyle = BorderStyle.FixedSingle;
            txtD9C1.Location = new Point(631, 95);
            txtD9C1.Name = "txtD9C1";
            txtD9C1.Size = new Size(208, 23);
            txtD9C1.TabIndex = 25;
            // 
            // txtD8C2
            // 
            txtD8C2.BorderStyle = BorderStyle.FixedSingle;
            txtD8C2.Location = new Point(330, 595);
            txtD8C2.Name = "txtD8C2";
            txtD8C2.Size = new Size(208, 23);
            txtD8C2.TabIndex = 24;
            // 
            // lblD8
            // 
            lblD8.AutoSize = true;
            lblD8.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD8.Location = new Point(330, 539);
            lblD8.Name = "lblD8";
            lblD8.Size = new Size(75, 21);
            lblD8.TabIndex = 23;
            lblD8.Text = "District 8";
            // 
            // txtD8C1
            // 
            txtD8C1.BorderStyle = BorderStyle.FixedSingle;
            txtD8C1.Location = new Point(330, 566);
            txtD8C1.Name = "txtD8C1";
            txtD8C1.Size = new Size(208, 23);
            txtD8C1.TabIndex = 22;
            // 
            // txtD7C2
            // 
            txtD7C2.BorderStyle = BorderStyle.FixedSingle;
            txtD7C2.Location = new Point(330, 437);
            txtD7C2.Name = "txtD7C2";
            txtD7C2.Size = new Size(208, 23);
            txtD7C2.TabIndex = 21;
            // 
            // lblD7
            // 
            lblD7.AutoSize = true;
            lblD7.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD7.Location = new Point(330, 381);
            lblD7.Name = "lblD7";
            lblD7.Size = new Size(75, 21);
            lblD7.TabIndex = 20;
            lblD7.Text = "District 7";
            // 
            // txtD7C1
            // 
            txtD7C1.BorderStyle = BorderStyle.FixedSingle;
            txtD7C1.Location = new Point(330, 408);
            txtD7C1.Name = "txtD7C1";
            txtD7C1.Size = new Size(208, 23);
            txtD7C1.TabIndex = 19;
            // 
            // txtD6C2
            // 
            txtD6C2.BorderStyle = BorderStyle.FixedSingle;
            txtD6C2.Location = new Point(330, 281);
            txtD6C2.Name = "txtD6C2";
            txtD6C2.Size = new Size(208, 23);
            txtD6C2.TabIndex = 18;
            // 
            // lblD6
            // 
            lblD6.AutoSize = true;
            lblD6.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD6.Location = new Point(330, 225);
            lblD6.Name = "lblD6";
            lblD6.Size = new Size(75, 21);
            lblD6.TabIndex = 17;
            lblD6.Text = "District 6";
            // 
            // txtD6C1
            // 
            txtD6C1.BorderStyle = BorderStyle.FixedSingle;
            txtD6C1.Location = new Point(330, 252);
            txtD6C1.Name = "txtD6C1";
            txtD6C1.Size = new Size(208, 23);
            txtD6C1.TabIndex = 16;
            // 
            // txtD5C2
            // 
            txtD5C2.BorderStyle = BorderStyle.FixedSingle;
            txtD5C2.Location = new Point(330, 124);
            txtD5C2.Name = "txtD5C2";
            txtD5C2.Size = new Size(208, 23);
            txtD5C2.TabIndex = 15;
            // 
            // lblD5
            // 
            lblD5.AutoSize = true;
            lblD5.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD5.Location = new Point(330, 68);
            lblD5.Name = "lblD5";
            lblD5.Size = new Size(75, 21);
            lblD5.TabIndex = 14;
            lblD5.Text = "District 5";
            // 
            // txtD5C1
            // 
            txtD5C1.BorderStyle = BorderStyle.FixedSingle;
            txtD5C1.Location = new Point(330, 95);
            txtD5C1.Name = "txtD5C1";
            txtD5C1.Size = new Size(208, 23);
            txtD5C1.TabIndex = 13;
            // 
            // txtD4C2
            // 
            txtD4C2.BorderStyle = BorderStyle.FixedSingle;
            txtD4C2.Location = new Point(34, 595);
            txtD4C2.Name = "txtD4C2";
            txtD4C2.Size = new Size(208, 23);
            txtD4C2.TabIndex = 12;
            // 
            // lblD4
            // 
            lblD4.AutoSize = true;
            lblD4.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD4.Location = new Point(34, 542);
            lblD4.Name = "lblD4";
            lblD4.Size = new Size(75, 21);
            lblD4.TabIndex = 11;
            lblD4.Text = "District 4";
            // 
            // txtD4C1
            // 
            txtD4C1.BorderStyle = BorderStyle.FixedSingle;
            txtD4C1.Location = new Point(34, 566);
            txtD4C1.Name = "txtD4C1";
            txtD4C1.Size = new Size(208, 23);
            txtD4C1.TabIndex = 10;
            // 
            // txtD3C2
            // 
            txtD3C2.BorderStyle = BorderStyle.FixedSingle;
            txtD3C2.Location = new Point(34, 437);
            txtD3C2.Name = "txtD3C2";
            txtD3C2.Size = new Size(208, 23);
            txtD3C2.TabIndex = 9;
            // 
            // lblD3
            // 
            lblD3.AutoSize = true;
            lblD3.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD3.Location = new Point(34, 384);
            lblD3.Name = "lblD3";
            lblD3.Size = new Size(75, 21);
            lblD3.TabIndex = 8;
            lblD3.Text = "District 3";
            // 
            // txtD3C1
            // 
            txtD3C1.BorderStyle = BorderStyle.FixedSingle;
            txtD3C1.Location = new Point(34, 408);
            txtD3C1.Name = "txtD3C1";
            txtD3C1.Size = new Size(208, 23);
            txtD3C1.TabIndex = 7;
            // 
            // txtD2C2
            // 
            txtD2C2.BorderStyle = BorderStyle.FixedSingle;
            txtD2C2.Location = new Point(34, 281);
            txtD2C2.Name = "txtD2C2";
            txtD2C2.Size = new Size(208, 23);
            txtD2C2.TabIndex = 6;
            // 
            // lblD2
            // 
            lblD2.AutoSize = true;
            lblD2.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD2.Location = new Point(34, 228);
            lblD2.Name = "lblD2";
            lblD2.Size = new Size(75, 21);
            lblD2.TabIndex = 5;
            lblD2.Text = "District 2";
            // 
            // txtD2C1
            // 
            txtD2C1.BorderStyle = BorderStyle.FixedSingle;
            txtD2C1.Location = new Point(34, 252);
            txtD2C1.Name = "txtD2C1";
            txtD2C1.Size = new Size(208, 23);
            txtD2C1.TabIndex = 4;
            // 
            // txtD1C2
            // 
            txtD1C2.BorderStyle = BorderStyle.FixedSingle;
            txtD1C2.Location = new Point(34, 124);
            txtD1C2.Name = "txtD1C2";
            txtD1C2.Size = new Size(208, 23);
            txtD1C2.TabIndex = 3;
            // 
            // lblD1
            // 
            lblD1.AutoSize = true;
            lblD1.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblD1.Location = new Point(34, 71);
            lblD1.Name = "lblD1";
            lblD1.Size = new Size(72, 21);
            lblD1.TabIndex = 2;
            lblD1.Text = "District 1";
            // 
            // txtD1C1
            // 
            txtD1C1.BorderStyle = BorderStyle.FixedSingle;
            txtD1C1.Location = new Point(34, 95);
            txtD1C1.Name = "txtD1C1";
            txtD1C1.Size = new Size(208, 23);
            txtD1C1.TabIndex = 1;
            // 
            // toolTip2
            // 
            toolTip2.AutomaticDelay = 3000;
            // 
            // PresetCharacters48
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1499, 830);
            Controls.Add(panelCharacterSelect);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PresetCharacters48";
            Text = "Enter Preset Characters";
            WindowState = FormWindowState.Maximized;
            panelCharacterSelect.ResumeLayout(false);
            panelCharacterSelect.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAll;
        private ToolTip toolTip1;
        private Button btnCharSearch;
        private TextBox txtCharSearch;
        private Button btnTagSearch;
        private TextBox txtSearch;
        private ToolTip toolTip2;
        private RichTextBox rtbSearch;
        private Button btnRandom;
        private Button btnEnterCharacters;
        private TextBox txtD12C2;
        private Label lblD12;
        private TextBox txtD12C1;
        private TextBox txtD11C2;
        private Label lblD11;
        private TextBox txtD11C1;
        private TextBox txtD10C2;
        private Label lblD10;
        private TextBox txtD10C1;
        private TextBox txtD9C2;
        private Label lblD9;
        private Panel panelCharacterSelect;
        private TextBox txtD10C4;
        private TextBox txtD10C3;
        private TextBox txtD6C4;
        private TextBox txtD6C3;
        private TextBox txtD2C4;
        private TextBox txtD2C3;
        private TextBox txtD9C4;
        private TextBox txtD9C3;
        private TextBox txtD5C4;
        private TextBox txtD5C3;
        private TextBox txtD1C4;
        private TextBox txtD1C3;
        private TextBox txtD9C1;
        private TextBox txtD8C2;
        private Label lblD8;
        private TextBox txtD8C1;
        private TextBox txtD7C2;
        private Label lblD7;
        private TextBox txtD7C1;
        private TextBox txtD6C2;
        private Label lblD6;
        private TextBox txtD6C1;
        private TextBox txtD5C2;
        private Label lblD5;
        private TextBox txtD5C1;
        private TextBox txtD4C2;
        private Label lblD4;
        private TextBox txtD4C1;
        private TextBox txtD3C2;
        private Label lblD3;
        private TextBox txtD3C1;
        private TextBox txtD2C2;
        private Label lblD2;
        private TextBox txtD2C1;
        private TextBox txtD1C2;
        private Label lblD1;
        private TextBox txtD1C1;
        private TextBox txtD4C4;
        private TextBox txtD4C3;
        private TextBox txtD11C4;
        private TextBox txtD11C3;
        private TextBox txtD7C4;
        private TextBox txtD7C3;
        private TextBox txtD3C4;
        private TextBox txtD3C3;
        private TextBox txtD12C4;
        private TextBox txtD12C3;
        private TextBox txtD8C4;
        private TextBox txtD8C3;
        private Label lblWarning;
        private Button btnBack;
    }
}