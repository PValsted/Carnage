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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            btnStart = new Button();
            btnCustom = new Button();
            btnPreset = new Button();
            grbNumberOptions = new GroupBox();
            rdo48 = new RadioButton();
            rdo24 = new RadioButton();
            cboShortBattles = new CheckBox();
            lblOptions = new Label();
            pnlOptions = new Panel();
            cboSponsor = new CheckBox();
            cboCombatLevel = new CheckBox();
            cboRealistic = new CheckBox();
            btnBack = new Button();
            pnlMenu2 = new Panel();
            panel1 = new Panel();
            grbNumberOptions.SuspendLayout();
            pnlOptions.SuspendLayout();
            pnlMenu2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.Location = new Point(91, 55);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(152, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnClassic_Click;
            // 
            // btnCustom
            // 
            btnCustom.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCustom.Location = new Point(15, 22);
            btnCustom.Name = "btnCustom";
            btnCustom.Size = new Size(152, 23);
            btnCustom.TabIndex = 1;
            btnCustom.Text = "Use Custom Characters";
            btnCustom.UseVisualStyleBackColor = true;
            btnCustom.Visible = false;
            btnCustom.Click += btnCustom_Click;
            // 
            // btnPreset
            // 
            btnPreset.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPreset.Location = new Point(15, 64);
            btnPreset.Name = "btnPreset";
            btnPreset.Size = new Size(152, 23);
            btnPreset.TabIndex = 2;
            btnPreset.Text = "Use Preset Characters";
            btnPreset.UseVisualStyleBackColor = true;
            btnPreset.Visible = false;
            btnPreset.Click += btnPreset_Click;
            // 
            // grbNumberOptions
            // 
            grbNumberOptions.Controls.Add(rdo48);
            grbNumberOptions.Controls.Add(rdo24);
            grbNumberOptions.Location = new Point(187, 12);
            grbNumberOptions.Name = "grbNumberOptions";
            grbNumberOptions.Size = new Size(126, 84);
            grbNumberOptions.TabIndex = 3;
            grbNumberOptions.TabStop = false;
            grbNumberOptions.Visible = false;
            // 
            // rdo48
            // 
            rdo48.AutoSize = true;
            rdo48.Location = new Point(17, 46);
            rdo48.Name = "rdo48";
            rdo48.Size = new Size(96, 19);
            rdo48.TabIndex = 1;
            rdo48.TabStop = true;
            rdo48.Text = "48 Characters";
            rdo48.UseVisualStyleBackColor = true;
            // 
            // rdo24
            // 
            rdo24.AutoSize = true;
            rdo24.Location = new Point(17, 21);
            rdo24.Name = "rdo24";
            rdo24.Size = new Size(96, 19);
            rdo24.TabIndex = 0;
            rdo24.TabStop = true;
            rdo24.Text = "24 Characters";
            rdo24.UseVisualStyleBackColor = true;
            // 
            // cboShortBattles
            // 
            cboShortBattles.AutoSize = true;
            cboShortBattles.Location = new Point(3, 44);
            cboShortBattles.Name = "cboShortBattles";
            cboShortBattles.Size = new Size(92, 19);
            cboShortBattles.TabIndex = 5;
            cboShortBattles.Text = "Short Battles";
            cboShortBattles.UseVisualStyleBackColor = true;
            // 
            // lblOptions
            // 
            lblOptions.AutoSize = true;
            lblOptions.Location = new Point(3, 4);
            lblOptions.Name = "lblOptions";
            lblOptions.Size = new Size(52, 15);
            lblOptions.TabIndex = 6;
            lblOptions.Text = "Options:";
            // 
            // pnlOptions
            // 
            pnlOptions.Controls.Add(cboSponsor);
            pnlOptions.Controls.Add(cboCombatLevel);
            pnlOptions.Controls.Add(cboRealistic);
            pnlOptions.Controls.Add(lblOptions);
            pnlOptions.Controls.Add(cboShortBattles);
            pnlOptions.Location = new Point(328, 22);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(264, 88);
            pnlOptions.TabIndex = 7;
            pnlOptions.Visible = false;
            // 
            // cboSponsor
            // 
            cboSponsor.AutoSize = true;
            cboSponsor.Location = new Point(3, 66);
            cboSponsor.Name = "cboSponsor";
            cboSponsor.Size = new Size(105, 19);
            cboSponsor.TabIndex = 9;
            cboSponsor.Text = "No Sponsoring";
            cboSponsor.UseVisualStyleBackColor = true;
            // 
            // cboCombatLevel
            // 
            cboCombatLevel.AutoSize = true;
            cboCombatLevel.Location = new Point(112, 22);
            cboCombatLevel.Name = "cboCombatLevel";
            cboCombatLevel.Size = new Size(131, 19);
            cboCombatLevel.TabIndex = 8;
            cboCombatLevel.Text = "Show Combat Level";
            cboCombatLevel.UseVisualStyleBackColor = true;
            cboCombatLevel.Visible = false;
            // 
            // cboRealistic
            // 
            cboRealistic.AutoSize = true;
            cboRealistic.Location = new Point(3, 22);
            cboRealistic.Name = "cboRealistic";
            cboRealistic.Size = new Size(103, 19);
            cboRealistic.TabIndex = 7;
            cboRealistic.Text = "Realistic Mode";
            cboRealistic.UseVisualStyleBackColor = true;
            cboRealistic.CheckedChanged += cboRealistic_CheckedChanged;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBack.Location = new Point(15, 105);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Visible = false;
            btnBack.Click += btnBack_Click;
            // 
            // pnlMenu2
            // 
            pnlMenu2.Controls.Add(btnCustom);
            pnlMenu2.Controls.Add(btnBack);
            pnlMenu2.Controls.Add(pnlOptions);
            pnlMenu2.Controls.Add(btnPreset);
            pnlMenu2.Controls.Add(grbNumberOptions);
            pnlMenu2.Location = new Point(27, 31);
            pnlMenu2.Name = "pnlMenu2";
            pnlMenu2.Size = new Size(620, 210);
            pnlMenu2.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnStart);
            panel1.Location = new Point(27, 282);
            panel1.Name = "panel1";
            panel1.Size = new Size(620, 271);
            panel1.TabIndex = 10;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 579);
            Controls.Add(panel1);
            Controls.Add(pnlMenu2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Start";
            Text = "Carnage";
            WindowState = FormWindowState.Maximized;
            grbNumberOptions.ResumeLayout(false);
            grbNumberOptions.PerformLayout();
            pnlOptions.ResumeLayout(false);
            pnlOptions.PerformLayout();
            pnlMenu2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Button btnCustom;
        private Button btnPreset;
        private GroupBox grbNumberOptions;
        private RadioButton rdo24;
        private RadioButton rdo48;
        private CheckBox cboShortBattles;
        private Label lblOptions;
        private Panel pnlOptions;
        private CheckBox cboRealistic;
        private CheckBox cboCombatLevel;
        private Button btnBack;
        private CheckBox cboSponsor;
        private Panel pnlMenu2;
        private Panel panel1;
    }
}