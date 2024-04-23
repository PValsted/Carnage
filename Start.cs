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

    /// <summary>
    /// This form functions as the starting point and main menu of the program. It contains options for
    /// starting a simulator, adding characters to the MySQL Database, and viewing the changelog.
    /// </summary>
    public partial class Start : Form
    {
        CharacterImporter ci = new CharacterImporter();

        public Start()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Switches to the simulator set-up panel
        /// </summary>
        private void btnClassic_Click(object sender, EventArgs e)
        {
            pnlMainMenu.Hide();
            pnlMenu2.Show();
        }

        /// <summary>
        /// Switches over to the custom characters form for the appropriate number of characters.
        /// Records the game options checked off by the user as well.
        /// </summary>
        private void btnCustom_Click(object sender, EventArgs e)
        {

            if (rdo24.Checked) //If 24 characters
            {
                Game game = new Game(24);
                if (cboRealistic.Checked) { MessageBox.Show("Custom character selection with Realistic Mode not yet implemented. Proceeding with Classic Mode."); };
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                if (cboSponsor.Checked) game.DoSponsor = false;
                CustomCharacters24 customCharacters24 = new(game);
                this.Hide();
                customCharacters24.Show();
            }
            else if (rdo48.Checked) //If 48 characters
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

        /// <summary>
        /// Switches over to the preset characters form for the appropriate number of characters.
        /// Records the game options checked off by the user as well.
        /// </summary>
        private void btnPreset_Click(object sender, EventArgs e)
        {

            if (rdo24.Checked) //If 24 characters
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
            else if (rdo48.Checked) //If 48 characters
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

        /// <summary>
        /// If the realistic mode option is checked off by the user, the combat level
        /// option becomes visible.
        /// </summary>
        private void cboRealistic_CheckedChanged(object sender, EventArgs e)
        {
            cboCombatLevel.Visible = true;
        }

        /// <summary>
        /// The back button is found on the three panels that the main panel leads to and
        /// it returns the user back to the main panel.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlMenu2.Hide();
            pnlCharacterEntry.Hide();
            pnlChangelog.Hide();
            pnlMainMenu.Show();
        }

        /// <summary>
        /// When the arena is selected the panel below is filled with the appropriate information about the arena.
        /// </summary>
        private void cboArenas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboArenas.SelectedIndex == 0)
            {
                txtSereneForest.Show();
                pictureForest.Show();
                rtbForest.Show();
            }
        }

        /// <summary>
        /// Takes the values entered in the text boxes or selected from the combo box and inserts
        /// a character entry into the MySQL Database using them. It also checks to make sure
        /// the right values are entered and that the character won't be a duplicate.
        /// </summary>
        private void btnAddCharacter_Click(object sender, EventArgs e)
        {
            if (charIDText.Text == "" || cboPronoun.SelectedIndex == -1 || moralText.Text == "" || strengthText.Text == "" || speedText.Text == "" || cboTag1.SelectedIndex == -1) //Makes sure the right attributes are filled in
            {
                MessageBox.Show("You are trying to add a character with fields that cannot be blank.\n");
            }
            else if (ci.characterCount(charIDText.Text) != 0) //Ensures duplicate characters aren't entered
            {
                MessageBox.Show("You are trying to add an already existing character.\n");
                charIDText.Text = "";
                cboPronoun.SelectedIndex = -1;
                moralText.Text = "";
                strengthText.Text = "";
                speedText.Text = "";
                cboTag1.SelectedIndex = -1;
                tag2Text.Text = "";
                tag3Text.Text = "";
            }
            else //Inserts values into the MySQL Database
            {
                ci.insert(charIDText.Text, cboPronoun.GetItemText(cboPronoun.SelectedItem), moralText.Text, strengthText.Text, speedText.Text, cboTag1.GetItemText(cboTag1.SelectedItem), tag2Text.Text, tag3Text.Text);
                charIDText.Text = "";
                cboPronoun.SelectedIndex = -1;
                moralText.Text = "";
                strengthText.Text = "";
                speedText.Text = "";
                cboTag1.SelectedIndex = -1;
                tag2Text.Text = "";
                tag3Text.Text = "";
            }
        }

        /// <summary>
        /// Pulls a list of every character currently entered into the database
        /// and displays it in the rich text box.
        /// </summary>
        private void btnAll_Click(object sender, EventArgs e)
        {
            rtbSearch.Clear();
            rtbSearch.AppendText(ci.ShowAll());
        }

        /// <summary>
        /// Clears the rich text box and inputs text confirming if a user-entered character
        /// is in the MySQL Database or not.
        /// </summary>
        private void btnCharSearch_Click(object sender, EventArgs e)
        {
            int count = ci.characterCount(txtCharSearch.Text);

            if (count == 0) //Character is not in database
            {
                rtbSearch.Clear();
                rtbSearch.AppendText("Character " + txtCharSearch.Text + " not found. Please choose someone else or search by tag to get a list.");
            }
            else //Character is in database
            {
                rtbSearch.Clear();
                rtbSearch.AppendText("Character " + txtCharSearch.Text + " found. Enter this name exactly as entered here in any text box to the left to include them in the simulation.");
            }
        }

        /// <summary>
        /// Clears the rich text box and fills it with a list of characters
        /// matching a user-entered tag.
        /// </summary>
        private void btnTagSearch_Click(object sender, EventArgs e)
        {
            rtbSearch.Clear();
            rtbSearch.AppendText(ci.searchTag(txtSearch.Text));
        }

        /// <summary>
        /// Switches over to the character creator panel
        /// </summary>
        private void btnCharacterCreator_Click(object sender, EventArgs e)
        {
            pnlMainMenu.Hide();
            pnlCharacterEntry.Show();
        }

        /// <summary>
        /// Switches over to the changelog panel
        /// </summary>
        private void btnChangelog_Click(object sender, EventArgs e)
        {
            pnlMainMenu.Hide();
            pnlChangelog.Show();
        }

    }
}
