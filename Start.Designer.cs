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
            btnClassic = new Button();
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
            grbNumberOptions.SuspendLayout();
            pnlOptions.SuspendLayout();
            SuspendLayout();
            // 
            // btnClassic
            // 
            btnClassic.Location = new Point(48, 47);
            btnClassic.Name = "btnClassic";
            btnClassic.Size = new Size(152, 23);
            btnClassic.TabIndex = 0;
            btnClassic.Text = "Classic Mode";
            btnClassic.UseVisualStyleBackColor = true;
            btnClassic.Click += btnClassic_Click;
            // 
            // btnCustom
            // 
            btnCustom.Location = new Point(48, 47);
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
            btnPreset.Location = new Point(48, 89);
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
            grbNumberOptions.Location = new Point(220, 37);
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
            pnlOptions.Location = new Point(361, 47);
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
            btnBack.Location = new Point(48, 130);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Visible = false;
            btnBack.Click += btnBack_Click;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(pnlOptions);
            Controls.Add(grbNumberOptions);
            Controls.Add(btnPreset);
            Controls.Add(btnCustom);
            Controls.Add(btnClassic);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Start";
            Text = "Carnage";
            WindowState = FormWindowState.Maximized;
            grbNumberOptions.ResumeLayout(false);
            grbNumberOptions.PerformLayout();
            pnlOptions.ResumeLayout(false);
            pnlOptions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnClassic;
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
    }
}