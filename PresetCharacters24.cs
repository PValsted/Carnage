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

        private void button1_Click(object sender, EventArgs e)
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
            stringList.Add(txtD1C1.Text); stringList.Add(txtD1C2.Text); stringList.Add(txtD2C1.Text); stringList.Add(txtD2C2.Text);
            stringList.Add(txtD3C1.Text); stringList.Add(txtD3C2.Text); stringList.Add(txtD4C1.Text); stringList.Add(txtD4C2.Text);
            stringList.Add(txtD5C1.Text); stringList.Add(txtD5C2.Text); stringList.Add(txtD6C1.Text); stringList.Add(txtD6C2.Text);
            stringList.Add(txtD7C1.Text); stringList.Add(txtD7C2.Text); stringList.Add(txtD8C1.Text); stringList.Add(txtD8C2.Text);
            stringList.Add(txtD9C1.Text); stringList.Add(txtD9C2.Text); stringList.Add(txtD10C1.Text); stringList.Add(txtD10C2.Text);
            stringList.Add(txtD11C1.Text); stringList.Add(txtD11C2.Text); stringList.Add(txtD12C1.Text); stringList.Add(txtD12C2.Text);

            if (ci.CheckList(stringList, 24) == "")
            {
                rtbSearch.Clear();
                if (game.Mode=="Classic") charList = ci.ConvertToCharacters(stringList, "Classic", 24);
                else if (game.Mode=="Realistic") charList = ci.ConvertToCharacters(stringList, "Realistic", 24);

                charList = rng.shuffleList(charList);

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

        private void btnAll_Click(object sender, EventArgs e)
        {
            rtbSearch.Clear();
            rtbSearch.AppendText(ci.ShowAll());
        }
    }
}
