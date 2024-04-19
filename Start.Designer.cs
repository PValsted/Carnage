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
            btnClassic = new Button();
            btnCustom = new Button();
            btnPreset = new Button();
            grbNumberOptions = new GroupBox();
            rdo48 = new RadioButton();
            rdo24 = new RadioButton();
            pnlTest = new Panel();
            btnClear = new Button();
            btnTest = new Button();
            rtbTest = new RichTextBox();
            cboShortBattles = new CheckBox();
            lblOptions = new Label();
            pnlOptions = new Panel();
            cboRealistic = new CheckBox();
            grbNumberOptions.SuspendLayout();
            pnlTest.SuspendLayout();
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
            btnClassic.Click += btnClassic_Click_1;
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
            // pnlTest
            // 
            pnlTest.Controls.Add(btnClear);
            pnlTest.Controls.Add(btnTest);
            pnlTest.Controls.Add(rtbTest);
            pnlTest.Location = new Point(48, 175);
            pnlTest.Name = "pnlTest";
            pnlTest.Size = new Size(729, 251);
            pnlTest.TabIndex = 4;
            pnlTest.Visible = false;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(639, 100);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(639, 129);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(75, 23);
            btnTest.TabIndex = 1;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // rtbTest
            // 
            rtbTest.Location = new Point(3, 3);
            rtbTest.Name = "rtbTest";
            rtbTest.Size = new Size(630, 245);
            rtbTest.TabIndex = 0;
            rtbTest.Text = "";
            // 
            // cboShortBattles
            // 
            cboShortBattles.AutoSize = true;
            cboShortBattles.Location = new Point(3, 42);
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
            pnlOptions.Controls.Add(cboRealistic);
            pnlOptions.Controls.Add(lblOptions);
            pnlOptions.Controls.Add(cboShortBattles);
            pnlOptions.Location = new Point(361, 47);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(132, 74);
            pnlOptions.TabIndex = 7;
            pnlOptions.Visible = false;
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
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlOptions);
            Controls.Add(pnlTest);
            Controls.Add(grbNumberOptions);
            Controls.Add(btnPreset);
            Controls.Add(btnCustom);
            Controls.Add(btnClassic);
            Name = "Start";
            Text = "Start";
            grbNumberOptions.ResumeLayout(false);
            grbNumberOptions.PerformLayout();
            pnlTest.ResumeLayout(false);
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
        private Panel pnlTest;
        private Button btnTest;
        private RichTextBox rtbTest;
        private Button btnClear;
        private CheckBox cboShortBattles;
        private Label lblOptions;
        private Panel pnlOptions;
        private CheckBox cboRealistic;
    }
}