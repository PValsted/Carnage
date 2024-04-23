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
    /// This form provides the necessary code to make the preset character
    /// screen for 24 characters functional. It allows for user-defined names
    /// that correctly match the names of characters in the MySQL Database to be
    /// imported and then to be passed into corresponding character objects
    /// that will then make up the simulation. It includes code to check to make
    /// sure the names are valid and a way to randomly select 24 characters that
    /// are in the database.
    /// </summary>
    public partial class PresetCharacters24 : Form
    {
        CharacterImporter ci = new CharacterImporter();
        List<character> charList = new List<character>();
        List<string> stringList = new List<string>();
        RNG rng = new RNG();
        Game game;

        public PresetCharacters24(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        /// <summary>
        /// Clears the text out of all 24 text boxes so that
        /// it can be replaced with other text.
        /// </summary>
        private void clearText()
        {
            txtD1C1.Clear(); txtD1C2.Clear();
            txtD2C1.Clear(); txtD2C2.Clear();
            txtD3C1.Clear(); txtD3C2.Clear();
            txtD4C1.Clear(); txtD4C2.Clear();
            txtD5C1.Clear(); txtD5C2.Clear();
            txtD6C1.Clear(); txtD6C2.Clear();
            txtD7C1.Clear(); txtD7C2.Clear();
            txtD8C1.Clear(); txtD8C2.Clear();
            txtD9C1.Clear(); txtD9C2.Clear();
            txtD10C1.Clear(); txtD10C2.Clear();
            txtD11C1.Clear(); txtD11C2.Clear();
            txtD12C1.Clear(); txtD12C2.Clear();
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
        /// Takes each of the user-entered character names, confirms they all exist in the MySQL Database
        /// (specifies which ones are not if necessary), and puts them into a list of strings. This list of strings
        /// is passed on to the CharacterImporter to pull any other associated character attributes and turn all
        /// of it into a list of characters, which is then sent to the simulator form to begin the simulation.
        /// </summary>
        private void btnEnterCharacters_Click(object sender, EventArgs e)
        {
            stringList.Clear();
            stringList.Add(txtD1C1.Text); stringList.Add(txtD1C2.Text); stringList.Add(txtD2C1.Text); stringList.Add(txtD2C2.Text);
            stringList.Add(txtD3C1.Text); stringList.Add(txtD3C2.Text); stringList.Add(txtD4C1.Text); stringList.Add(txtD4C2.Text);
            stringList.Add(txtD5C1.Text); stringList.Add(txtD5C2.Text); stringList.Add(txtD6C1.Text); stringList.Add(txtD6C2.Text);
            stringList.Add(txtD7C1.Text); stringList.Add(txtD7C2.Text); stringList.Add(txtD8C1.Text); stringList.Add(txtD8C2.Text);
            stringList.Add(txtD9C1.Text); stringList.Add(txtD9C2.Text); stringList.Add(txtD10C1.Text); stringList.Add(txtD10C2.Text);
            stringList.Add(txtD11C1.Text); stringList.Add(txtD11C2.Text); stringList.Add(txtD12C1.Text); stringList.Add(txtD12C2.Text);

            if (ci.CheckList(stringList, 24) == "") //If no results are returned when inquiring about which characters are not in the database, every character name entered is valid
            {
                rtbSearch.Clear();
                if (game.Mode == "Classic") charList = ci.ConvertToCharacters(stringList, "Classic", 24); //If classic: pronouns are paired with the names to create 24 characters
                else if (game.Mode == "Realistic") charList = ci.ConvertToCharacters(stringList, "Realistic", 24); //If realistic: pronouns, speed, strength, and morality are paired with the names to create 24 characters

                charList = rng.shuffleList(charList);

                if (game.ShowCombatLevel == true) //If the show combat level option is checked on the start menu, each character's combat level is added after their name
                {
                    for (int i = 0; i < charList.Count; i++)
                    {
                        charList[i].Name = charList[i].Name + " (" + charList[i].CombatLevel + ")";
                    }
                }

                //Passes list of characters and game settings into the simulator to begin
                Simulation game1 = new Simulation(charList, game);

                this.Hide();
                game1.Show();
            }
            else //If any characters are not found, these specific names are displayed in the rich text box so that they can be identified and changed
            {
                rtbSearch.Clear();
                rtbSearch.AppendText(ci.CheckList(stringList, 24));
            }
        }

        /// <summary>
        /// Using data from the MySQL Database and random int generation, a list of
        /// 24 random valid database characters is returned and each name fills in
        /// a different text box. This allows the game to start much quicker with
        /// valid characters ready to go.
        /// </summary>
        private void btnRandom_Click(object sender, EventArgs e)
        {
             stringList.Clear();
            this.clearText();

            stringList = ci.Randomize(24);

            txtD1C1.Text = stringList[0]; txtD1C2.Text = stringList[1];
            txtD2C1.Text = stringList[2]; txtD2C2.Text = stringList[3];
            txtD3C1.Text = stringList[4]; txtD3C2.Text = stringList[5];
            txtD4C1.Text = stringList[6]; txtD4C2.Text = stringList[7];
            txtD5C1.Text = stringList[8]; txtD5C2.Text = stringList[9];
            txtD6C1.Text = stringList[10]; txtD6C2.Text = stringList[11];
            txtD7C1.Text = stringList[12]; txtD7C2.Text = stringList[13];
            txtD8C1.Text = stringList[14]; txtD8C2.Text = stringList[15];
            txtD9C1.Text = stringList[16]; txtD9C2.Text = stringList[17];
            txtD10C1.Text = stringList[18]; txtD10C2.Text = stringList[19];
            txtD11C1.Text = stringList[20]; txtD11C2.Text = stringList[21];
            txtD12C1.Text = stringList[22]; txtD12C2.Text = stringList[23];
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
        /// Returns the user to the start menu form
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Start start = new Start();

            start.Show();
            this.Hide();
        }
    }
}
