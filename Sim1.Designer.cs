namespace Carnage
{
    partial class Sim1
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
            rtbText = new RichTextBox();
            pnlMain = new Panel();
            btnMainContinue = new Button();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // rtbText
            // 
            rtbText.BackColor = Color.LightGoldenrodYellow;
            rtbText.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            rtbText.Location = new Point(6, 0);
            rtbText.Margin = new Padding(6);
            rtbText.Name = "rtbText";
            rtbText.ReadOnly = true;
            rtbText.Size = new Size(1826, 866);
            rtbText.TabIndex = 0;
            rtbText.Text = "";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(btnMainContinue);
            pnlMain.Controls.Add(rtbText);
            pnlMain.Location = new Point(12, 12);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1838, 910);
            pnlMain.TabIndex = 2;
            // 
            // btnMainContinue
            // 
            btnMainContinue.Location = new Point(19, 875);
            btnMainContinue.Name = "btnMainContinue";
            btnMainContinue.Size = new Size(94, 23);
            btnMainContinue.TabIndex = 0;
            btnMainContinue.Text = "Continue";
            btnMainContinue.UseVisualStyleBackColor = true;
            btnMainContinue.Click += btnMainContinue_Click;
            // 
            // Sim1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1859, 934);
            Controls.Add(pnlMain);
            Name = "Sim1";
            Text = "Carnage";
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbText;
        private Panel pnlMain;
        private Button btnMainContinue;
    }
}