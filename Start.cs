using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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
        VisualSettings vs = new VisualSettings();

        public Start()
        {
            InitializeComponent();
            this.ApplyVisualEffectsToWindow();
        }

        public Start(VisualSettings vs)
        {
            InitializeComponent();
            this.vs = vs;
            this.ApplyVisualEffectsToWindow();
        }

        /// <summary>
        /// Switches to the simulator set-up panel
        /// </summary>
        private void btnClassic_Click(object sender, EventArgs e)
        {
            pnlMainMenu.Hide();
            pnlMenu2.Show();
            cboArenas.SelectedIndex = 0;
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
                if (cboHealth.Checked) game.StartHealth = Double.Parse(txtHealth.Text);
                CustomCharacters24 customCharacters24 = new(game, vs);
                this.Hide();
                customCharacters24.Show();
            }
            else if (rdo48.Checked) //If 48 characters
            {
                Game game = new Game(48);
                if (cboRealistic.Checked) { MessageBox.Show("Custom character selection with Realistic Mode not yet implemented. Proceeding with Classic Mode."); };
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                if (cboSponsor.Checked) game.DoSponsor = false;
                if (cboHealth.Checked) game.StartHealth = Double.Parse(txtHealth.Text);
                CustomCharacters48 customCharacters48 = new(game, vs);
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
                if (cboHunger.Checked && cboRealistic.Checked) game.DoHunger = false;
                if (cboSponsor.Checked) game.DoSponsor = false;
                if (cboHealth.Checked) game.StartHealth = Double.Parse(txtHealth.Text);
                PresetCharacters24 presetCharacters24 = new PresetCharacters24(game, vs);
                this.Hide();
                presetCharacters24.Show();
            }
            else if (rdo48.Checked) //If 48 characters
            {
                Game game = new Game(48);
                if (cboRealistic.Checked) game.Mode = "Realistic";
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                if (cboCombatLevel.Checked && cboRealistic.Checked) game.ShowCombatLevel = true;
                if (cboHunger.Checked && cboRealistic.Checked) game.DoHunger = false;
                if (cboSponsor.Checked) game.DoSponsor = false;
                if (cboHealth.Checked) game.StartHealth = Double.Parse(txtHealth.Text);
                PresetCharacters48 presetCharacters48 = new PresetCharacters48(game, vs);
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
            cboHunger.Visible = true;
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

        private void ApplyVisualEffects()
        {
            if (rdoLightMode.Checked)
            {
                vs.Mode = "Light";
                using (StreamWriter writetext = new StreamWriter("visualoptions.txt"))
                {
                    writetext.WriteLine("Light");
                }
            }
            if (rdoDarkMode.Checked)
            {
                vs.Mode = "Dark";
                using (StreamWriter writetext = new StreamWriter("visualoptions.txt"))
                {
                    writetext.WriteLine("Dark");
                }
            }
        }

        private void ApplyVisualEffectsToWindow()
        {
            if (vs.Mode == "Light")
            {
                this.BackgroundImage = Properties.Resources.white_gradient;
                //Visual Settings Panel
                pnlVisualSettings.BackgroundImage = Properties.Resources.white_gradient;
                txtVisualSettings.ForeColor = System.Drawing.Color.Black;
                pnlMode.BackgroundImage = Properties.Resources.white_gradient;
                pnlMode.ForeColor = System.Drawing.Color.Black;
                cboDefaults.ForeColor = System.Drawing.Color.Black;
                //Game Settings Panel
                pnlOptions.BackgroundImage = Properties.Resources.white_gradient;
                pnlOptions.ForeColor = System.Drawing.Color.Black;
                pnlGeneralSettings.BackColor = System.Drawing.Color.White;
                pnlGeneralSettings.ForeColor = System.Drawing.Color.Black;
                pnlRealisticSettings.BackColor = System.Drawing.Color.White;
                pnlRealisticSettings.ForeColor = System.Drawing.Color.Black;
                pnlStats.BackColor = System.Drawing.Color.White;
                pnlStats.ForeColor = System.Drawing.Color.Black;
                //Game Start Panel
                pnlMenu2.BackgroundImage = Properties.Resources.white_gradient;
                pnlMenu2.ForeColor = System.Drawing.Color.Black;
                pnlSettings.BackColor = System.Drawing.Color.White;
                txtSettings.ForeColor = System.Drawing.Color.Black;
                //Character Creation Panel
                pnlCharacterEntry.BackgroundImage = Properties.Resources.white_gradient;
                pnlCharacterEntry.ForeColor = System.Drawing.Color.Black;
                //Changelog
                pnlChangelog.BackgroundImage = Properties.Resources.white_gradient;
                pnlChangelog.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.super_dark_gradient;
                //Visual Settings Panel
                pnlVisualSettings.BackgroundImage = null;
                pnlVisualSettings.BackColor = System.Drawing.Color.DimGray;
                txtVisualSettings.ForeColor = System.Drawing.Color.White;
                pnlMode.BackgroundImage = null;
                pnlMode.BackColor = System.Drawing.Color.Transparent;
                pnlMode.ForeColor = System.Drawing.Color.White;
                cboDefaults.ForeColor = System.Drawing.Color.White;
                //Game Settings Panel
                pnlOptions.BackgroundImage = null;
                pnlOptions.BackColor = System.Drawing.Color.DimGray;
                pnlOptions.ForeColor = System.Drawing.Color.White;
                pnlGeneralSettings.BackColor = System.Drawing.Color.Transparent;
                pnlGeneralSettings.ForeColor = System.Drawing.Color.White;
                pnlRealisticSettings.BackColor = System.Drawing.Color.Transparent;
                pnlRealisticSettings.ForeColor = System.Drawing.Color.White;
                pnlStats.BackColor = System.Drawing.Color.Transparent;
                pnlStats.ForeColor = System.Drawing.Color.White;
                //Game Start Panel
                pnlMenu2.BackgroundImage = null;
                pnlMenu2.BackColor = System.Drawing.Color.DimGray;
                pnlMenu2.ForeColor = System.Drawing.Color.White;
                pnlSettings.BackColor = System.Drawing.Color.Transparent;
                txtSettings.ForeColor = System.Drawing.Color.White;
                txtSereneForest.ForeColor = System.Drawing.Color.Black;
                //Character Creation Panel
                pnlCharacterEntry.BackgroundImage = null;
                pnlCharacterEntry.BackColor = System.Drawing.Color.DimGray;
                pnlCharacterEntry.ForeColor = System.Drawing.Color.White;
                //Changelog
                pnlChangelog.BackgroundImage = null;
                pnlChangelog.BackColor = System.Drawing.Color.DimGray;
                pnlChangelog.ForeColor = System.Drawing.Color.White;

            }
        }

        /// <summary>
        /// Switches over to the Visual Settings panel
        /// </summary>
        private void btnVisualSettings_Click(object sender, EventArgs e)
        {
            pnlMenu2.Hide();
            pnlVisualSettings.Show();
        }

        /// <summary>
        /// Switches back to the game start screen with the selected options applied
        /// </summary>
        private void btnVisualSettingsBack_Click(object sender, EventArgs e)
        {
            pnlVisualSettings.Hide();
            pnlMenu2.Show();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.ApplyVisualEffects();
            this.ApplyVisualEffectsToWindow();
        }

        private void btnBackGameSettings_Click(object sender, EventArgs e)
        {
            if (cboHealth.Checked)
            {
                if (txtHealth.Text == "")
                {
                    MessageBox.Show("Starting health text box must not be left blank!\n");
                }
                else if (Double.Parse(txtHealth.Text) <= 0) //If starting health is less than or equal to 0, the game will never start, so this checks that
                {
                    MessageBox.Show("Starting health must be higher than 0!\n");
                }
                else
                {
                    pnlOptions.Hide();
                    pnlMenu2.Show();
                }
            }
            else
            {
                pnlOptions.Hide();
                pnlMenu2.Show();
            }


        }

        private void btnGameSettings_Click(object sender, EventArgs e)
        {
            pnlMenu2.Hide();
            pnlOptions.Show();
        }

        private void cboHealth_CheckedChanged(object sender, EventArgs e)
        {
            txtHealth.Show();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            pnlMainMenu.Hide();
            pnlTest.Show();
        }

        private void btnTestBack_Click(object sender, EventArgs e)
        {
            pnlTest.Hide();
            pnlMainMenu.Show();
        }

        /// <summary>
        /// Creates a test battle based on the selected values solely for the developer's purposes. This screen is
        /// impossible to navigate to normally.
        /// </summary>
        private string TestBattle()
        {
            Battle battle = new Battle();
            Game game = new Game(4);
            Loot loot = new Loot();
            character char1 = new character();
            character char2 = new character();
            character char3 = new character();
            character char4 = new character();
            StringBuilder sb = new StringBuilder();
            RNG rng = new RNG();

            game.Mode = "Realistic";
            //game.IsRaining = true;

            //Char 1
            char1.Name = "Frodo";
            if (txtPlayer1Damage.Text != "") char1.WeaponAttack = Double.Parse(txtPlayer1Damage.Text);
            else char1.Strength = 2;
            if (txtPlayer1Speed.Text != "") char1.Speed = Double.Parse(txtPlayer1Speed.Text);
            else char1.Speed = 3;
            if (txtPlayer1Moral.Text != "") char1.Morality = Double.Parse(txtPlayer1Moral.Text);
            else char1.Morality = 5;
            if (cboPlayer1Explosive.Checked) char1.HasExplosive = true;
            if (cboPlayer1Heal.Checked)
            {
                char1.HealSlotFilled = true;
                char1.HealingAmount = 5;
            }
            sb.AppendLine("After sneaking into the cornucopia, " + loot.lootEvent(char1, "Common", game));

            //Char 2
            char2.Name = "Darth Vader";
            if (txtPlayer2Damage.Text != "") char2.WeaponAttack = Double.Parse(txtPlayer2Damage.Text);
            else char2.Strength = 2;
            if (txtPlayer2Speed.Text != "") char2.Speed = Double.Parse(txtPlayer2Speed.Text);
            else char2.Speed = 3;
            if (txtPlayer2Moral.Text != "") char2.Morality = Double.Parse(txtPlayer2Moral.Text);
            else char2.Morality = 5;
            if (cboPlayer2Explosive.Checked) char2.HasExplosive = true;
            if (cboPlayer2Heal.Checked)
            {
                char2.HealSlotFilled = true;
                char2.HealingAmount = 5;
            }
            sb.AppendLine("After sneaking into the cornucopia, " + loot.lootEvent(char2, "Common", game));

            //Char 3
            char3.Name = "Deadpool";
            if (txtPlayer3Damage.Text != "") char3.WeaponAttack = Double.Parse(txtPlayer3Damage.Text);
            else char3.Strength = 2;
            if (txtPlayer3Speed.Text != "") char3.Speed = Double.Parse(txtPlayer3Speed.Text);
            else char3.Speed = 3;
            if (txtPlayer3Moral.Text != "") char3.Morality = Double.Parse(txtPlayer3Moral.Text);
            else char3.Morality = 5;
            if (cboPlayer3Explosive.Checked) char3.HasExplosive = true;
            if (cboPlayer3Heal.Checked)
            {
                char3.HealSlotFilled = true;
                char3.HealingAmount = 5;
            }
            sb.AppendLine("After sneaking into the cornucopia, " + loot.lootEvent(char3, "Common", game));

            //Char 4
            char4.Name = "Ron Swanson";
            if (txtPlayer4Damage.Text != "") char4.WeaponAttack = Double.Parse(txtPlayer4Damage.Text);
            else char4.Strength = 2;
            if (txtPlayer4Speed.Text != "") char4.Speed = Double.Parse(txtPlayer4Speed.Text);
            else char4.Speed = 3;
            if (txtPlayer4Moral.Text != "") char4.Morality = Double.Parse(txtPlayer4Moral.Text);
            else char4.Morality = 5;
            if (cboPlayer4Explosive.Checked) char4.HasExplosive = true;
            if (cboPlayer4Heal.Checked)
            {
                char4.HealSlotFilled = true;
                char4.HealingAmount = 5;
            }
            sb.AppendLine("After sneaking into the cornucopia, " + loot.lootEvent(char4, "Common", game));

            if (rdoTwo.Checked)
            {
                battle.setNumPlayers(2);
                sb.AppendLine(battle.BattleEvent(char1, char2, char2, char2, game));
            }
            else if (rdoThree.Checked)
            {
                battle.setNumPlayers(3);
                sb.AppendLine(battle.BattleEvent(char1, char2, char3, char3, game));
            }
            else if (rdoFour.Checked)
            {
                battle.setNumPlayers(4);
                sb.AppendLine(battle.BattleEvent(char1, char2, char3, char4, game));
            }

            return sb.ToString();
        }

        private void btnBattle_Click(object sender, EventArgs e)
        {
            rtbTest.Clear();
            rtbTest.AppendText(this.TestBattle());
        }

    }
}
