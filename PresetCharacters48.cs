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
    public partial class PresetCharacters48 : Form
    {
        CharacterImporter ci = new CharacterImporter();
        List<character> charList = new List<character>();
        List<string> stringList = new List<string>();
        RNG rng = new RNG();
        Game game;

        public PresetCharacters48(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void clearText()
        {
            txtD1C1.Clear(); txtD1C2.Clear(); txtD1C3.Clear(); txtD1C4.Clear();
            txtD2C1.Clear(); txtD2C2.Clear(); txtD2C3.Clear(); txtD2C4.Clear();
            txtD3C1.Clear(); txtD3C2.Clear(); txtD3C3.Clear(); txtD3C4.Clear();
            txtD4C1.Clear(); txtD4C2.Clear(); txtD4C3.Clear(); txtD4C4.Clear();
            txtD5C1.Clear(); txtD5C2.Clear(); txtD5C3.Clear(); txtD5C4.Clear();
            txtD6C1.Clear(); txtD6C2.Clear(); txtD6C3.Clear(); txtD6C4.Clear();
            txtD7C1.Clear(); txtD7C2.Clear(); txtD7C3.Clear(); txtD7C4.Clear();
            txtD8C1.Clear(); txtD8C2.Clear(); txtD8C3.Clear(); txtD8C4.Clear();
            txtD9C1.Clear(); txtD9C2.Clear(); txtD9C3.Clear(); txtD9C4.Clear();
            txtD10C1.Clear(); txtD10C2.Clear(); txtD10C3.Clear(); txtD10C4.Clear();
            txtD11C1.Clear(); txtD11C2.Clear(); txtD11C3.Clear(); txtD11C4.Clear();
            txtD12C1.Clear(); txtD12C2.Clear(); txtD12C3.Clear(); txtD12C4.Clear();
        }

        private void btnTagSearch_Click(object sender, EventArgs e)
        {
            rtbSearch.Clear();
            rtbSearch.AppendText(ci.searchTag(txtSearch.Text));
        }

        private void btnCharSearch_Click(object sender, EventArgs e)
        {
            int count = ci.characterCount(txtCharSearch.Text);

            if (count == 0)
            {
                rtbSearch.Clear();
                rtbSearch.AppendText("Character " + txtCharSearch.Text + " not found. Please choose someone else or search by tag to get a list.");
            }
            else
            {
                rtbSearch.Clear();
                rtbSearch.AppendText("Character " + txtCharSearch.Text + " found. Enter this name exactly as entered here in any text box to the left to include them in the simulation.");
            }
        }

        private void btnEnterCharacters_Click(object sender, EventArgs e)
        {
            stringList.Clear();
            stringList.Add(txtD1C1.Text); stringList.Add(txtD1C2.Text); stringList.Add(txtD1C3.Text); stringList.Add(txtD1C4.Text);
            stringList.Add(txtD2C1.Text); stringList.Add(txtD2C2.Text); stringList.Add(txtD2C3.Text); stringList.Add(txtD2C4.Text);
            stringList.Add(txtD3C1.Text); stringList.Add(txtD3C2.Text); stringList.Add(txtD3C3.Text); stringList.Add(txtD3C4.Text);
            stringList.Add(txtD4C1.Text); stringList.Add(txtD4C2.Text); stringList.Add(txtD4C3.Text); stringList.Add(txtD4C4.Text);
            stringList.Add(txtD5C1.Text); stringList.Add(txtD5C2.Text); stringList.Add(txtD5C3.Text); stringList.Add(txtD5C4.Text);
            stringList.Add(txtD6C1.Text); stringList.Add(txtD6C2.Text); stringList.Add(txtD6C3.Text); stringList.Add(txtD6C4.Text);
            stringList.Add(txtD7C1.Text); stringList.Add(txtD7C2.Text); stringList.Add(txtD7C3.Text); stringList.Add(txtD7C4.Text);
            stringList.Add(txtD8C1.Text); stringList.Add(txtD8C2.Text); stringList.Add(txtD8C3.Text); stringList.Add(txtD8C4.Text);
            stringList.Add(txtD9C1.Text); stringList.Add(txtD9C2.Text); stringList.Add(txtD9C3.Text); stringList.Add(txtD9C4.Text);
            stringList.Add(txtD10C1.Text); stringList.Add(txtD10C2.Text); stringList.Add(txtD10C3.Text); stringList.Add(txtD10C4.Text);
            stringList.Add(txtD11C1.Text); stringList.Add(txtD11C2.Text); stringList.Add(txtD11C3.Text); stringList.Add(txtD11C4.Text);
            stringList.Add(txtD12C1.Text); stringList.Add(txtD12C2.Text); stringList.Add(txtD12C3.Text); stringList.Add(txtD12C4.Text);

            if (ci.CheckList(stringList, 48) == "")
            {
                rtbSearch.Clear();
                if (game.Mode == "Classic") charList = ci.ConvertToCharacters(stringList, "Classic", 48);
                else if (game.Mode == "Realistic") charList = ci.ConvertToCharacters(stringList, "Realistic", 48);

                charList = rng.shuffleList(charList);

                if (game.ShowCombatLevel == true)
                {
                    for (int i = 0; i < charList.Count; i++)
                    {
                        charList[i].Name = charList[i].Name + " (" + charList[i].CombatLevel + ")";
                    }
                }

                Sim1 game1 = new Sim1(charList, game);

                this.Hide();
                game1.Show();
            }
            else
            {
                rtbSearch.Clear();
                rtbSearch.AppendText(ci.CheckList(stringList, 24));
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            stringList.Clear();
            this.clearText();

            stringList = ci.Randomize(48);

            txtD1C1.Text = stringList[0]; txtD1C2.Text = stringList[1]; txtD1C3.Text = stringList[2]; txtD1C4.Text = stringList[3];
            txtD2C1.Text = stringList[4]; txtD2C2.Text = stringList[5]; txtD2C3.Text = stringList[6]; txtD2C4.Text = stringList[7];
            txtD3C1.Text = stringList[8]; txtD3C2.Text = stringList[9]; txtD3C3.Text = stringList[10]; txtD3C4.Text = stringList[11];
            txtD4C1.Text = stringList[12]; txtD4C2.Text = stringList[13]; txtD4C3.Text = stringList[14]; txtD4C4.Text = stringList[15];
            txtD5C1.Text = stringList[16]; txtD5C2.Text = stringList[17]; txtD5C3.Text = stringList[18]; txtD5C4.Text = stringList[19];
            txtD6C1.Text = stringList[20]; txtD6C2.Text = stringList[21]; txtD6C3.Text = stringList[22]; txtD6C4.Text = stringList[23];
            txtD7C1.Text = stringList[24]; txtD7C2.Text = stringList[25]; txtD7C3.Text = stringList[26]; txtD7C4.Text = stringList[27];
            txtD8C1.Text = stringList[28]; txtD8C2.Text = stringList[29]; txtD8C3.Text = stringList[30]; txtD8C4.Text = stringList[31];
            txtD9C1.Text = stringList[32]; txtD9C2.Text = stringList[33]; txtD9C3.Text = stringList[34]; txtD9C4.Text = stringList[35];
            txtD10C1.Text = stringList[36]; txtD10C2.Text = stringList[37]; txtD10C3.Text = stringList[38]; txtD10C4.Text = stringList[39];
            txtD11C1.Text = stringList[40]; txtD11C2.Text = stringList[41]; txtD11C3.Text = stringList[42]; txtD11C4.Text = stringList[43];
            txtD12C1.Text = stringList[44]; txtD12C2.Text = stringList[45]; txtD12C3.Text = stringList[46]; txtD12C4.Text = stringList[47];
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            rtbSearch.Clear();
            rtbSearch.AppendText(ci.ShowAll());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Start start = new Start();

            start.Show();
            this.Hide();
        }
    }
}
