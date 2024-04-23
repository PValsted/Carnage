using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carnage
{

    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void btnClassic_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnCustom.Visible = true;
            btnPreset.Visible = true;
            grbNumberOptions.Visible = true;
            pnlOptions.Visible = true;
            btnBack.Visible = true;
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {

            if (rdo24.Checked)
            {
                Game game = new Game(24);
                if (cboRealistic.Checked) { MessageBox.Show("Custom character selection with Realistic Mode not yet implemented. Proceeding with Classic Mode."); };
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                if (cboSponsor.Checked) game.DoSponsor = false;
                CustomCharacters24 customCharacters24 = new(game);
                this.Hide();
                customCharacters24.Show();
            }
            else if (rdo48.Checked)
            {
                Game game = new Game(48);
                if (cboRealistic.Checked) { MessageBox.Show("Custom character selection with Realistic Mode not yet implemented. Proceeding with Classic Mode."); };
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                if (cboSponsor.Checked) game.DoSponsor = false;
                CustomCharacters48 customCharacters48 = new(game);
                this.Hide();
                customCharacters48.Show();
            }
            else { MessageBox.Show("You must select the number of characters."); }
        }

        private void btnPreset_Click(object sender, EventArgs e)
        {

            if (rdo24.Checked)
            {
                Game game = new Game(24);
                if (cboRealistic.Checked) game.Mode = "Realistic";
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                if (cboCombatLevel.Checked && cboRealistic.Checked) game.ShowCombatLevel = true;
                if (cboSponsor.Checked) game.DoSponsor = false;
                PresetCharacters24 presetCharacters24 = new PresetCharacters24(game);
                this.Hide();
                presetCharacters24.Show();
            }
            else if (rdo48.Checked)
            {
                Game game = new Game(48);
                if (cboRealistic.Checked) game.Mode = "Realistic";
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                if (cboCombatLevel.Checked && cboRealistic.Checked) game.ShowCombatLevel = true;
                if (cboSponsor.Checked) game.DoSponsor = false;
                PresetCharacters48 presetCharacters48 = new PresetCharacters48(game);
                this.Hide();
                presetCharacters48.Show();
            }
            else { MessageBox.Show("You must select the number of characters."); }

        }

        private void cboRealistic_CheckedChanged(object sender, EventArgs e)
        {
            cboCombatLevel.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnStart.Visible = true;
            btnCustom.Visible = false;
            btnPreset.Visible = false;
            btnBack.Visible = false;
            grbNumberOptions.Visible = false;
            pnlOptions.Visible = false;
        }
    }
}
