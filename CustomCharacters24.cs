using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carnage
{
    public partial class CustomCharacters24 : Form
    {
        List<character> charList = new List<character>();
        Game game;
        String pronoun;
        RNG rng = new RNG();

        public CustomCharacters24(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        public void fillIn()
        {
            txtD1C1.Text = "1";
            txtD1C2.Text = "2";
            txtD2C1.Text = "3";
            txtD2C2.Text = "4";
            txtD3C1.Text = "5";
            txtD3C2.Text = "6";
            txtD4C1.Text = "7";
            txtD4C2.Text = "8";
            txtD5C1.Text = "9";
            txtD5C2.Text = "10";
            txtD6C1.Text = "11";
            txtD6C2.Text = "12";
            txtD7C1.Text = "13";
            txtD7C2.Text = "14";
            txtD8C1.Text = "15";
            txtD8C2.Text = "16";
            txtD9C1.Text = "17";
            txtD9C2.Text = "18";
            txtD10C1.Text = "19";
            txtD10C2.Text = "20";
            txtD11C1.Text = "21";
            txtD11C2.Text = "22";
            txtD12C1.Text = "23";
            txtD12C2.Text = "24";
        }

        public void btnEnterCharacters_Click(object sender, EventArgs e)
        {
            //instantiates all 24 characters
            character charD1C1 = new character(1);
            character charD1C2 = new character(1);
            character charD2C1 = new character(2);
            character charD2C2 = new character(2);
            character charD3C1 = new character(3);
            character charD3C2 = new character(3);
            character charD4C1 = new character(4);
            character charD4C2 = new character(4);
            character charD5C1 = new character(5);
            character charD5C2 = new character(5);
            character charD6C1 = new character(6);
            character charD6C2 = new character(6);
            character charD7C1 = new character(7);
            character charD7C2 = new character(7);
            character charD8C1 = new character(8);
            character charD8C2 = new character(8);
            character charD9C1 = new character(9);
            character charD9C2 = new character(9);
            character charD10C1 = new character(10);
            character charD10C2 = new character(10);
            character charD11C1 = new character(11);
            character charD11C2 = new character(11);
            character charD12C1 = new character(12);
            character charD12C2 = new character(12);

            //checks to make sure a name is entered on every line or the below code won't execute
            if (txtD1C1.Text.Length != 0 && txtD1C2.Text.Length != 0 && txtD2C1.Text.Length != 0 && txtD2C2.Text.Length != 0 && txtD3C1.Text.Length != 0 && txtD3C2.Text.Length != 0 &&
                txtD4C1.Text.Length != 0 && txtD4C2.Text.Length != 0 && txtD5C1.Text.Length != 0 && txtD5C2.Text.Length != 0 && txtD6C1.Text.Length != 0 && txtD6C2.Text.Length != 0 &&
                txtD7C1.Text.Length != 0 && txtD7C2.Text.Length != 0 && txtD8C1.Text.Length != 0 && txtD8C2.Text.Length != 0 && txtD9C1.Text.Length != 0 && txtD9C2.Text.Length != 0 &&
                txtD10C1.Text.Length != 0 && txtD10C2.Text.Length != 0 && txtD11C1.Text.Length != 0 && txtD11C2.Text.Length != 0 && txtD12C1.Text.Length != 0 && txtD12C2.Text.Length != 0)
            {
                //checks to make sure one of the pronouns is selected on every line or the below code won't execute
                //if ((rdoMaleD1C1.Checked || rdoFemaleD1C1.Checked || rdoTheyD1C1.Checked) && (rdoMaleD1C2.Checked || rdoFemaleD1C2.Checked || rdoTheyD1C2.Checked) &&
                //    (rdoMaleD2C1.Checked || rdoFemaleD2C1.Checked || rdoTheyD2C1.Checked) && (rdoMaleD2C2.Checked || rdoFemaleD2C2.Checked || rdoTheyD2C2.Checked) &&
                //    (rdoMaleD3C1.Checked || rdoFemaleD3C1.Checked || rdoTheyD3C1.Checked) && (rdoMaleD3C2.Checked || rdoFemaleD3C2.Checked || rdoTheyD3C2.Checked) &&
                //    (rdoMaleD4C1.Checked || rdoFemaleD4C1.Checked || rdoTheyD4C1.Checked) && (rdoMaleD4C2.Checked || rdoFemaleD4C2.Checked || rdoTheyD4C2.Checked) &&
                //    (rdoMaleD5C1.Checked || rdoFemaleD5C1.Checked || rdoTheyD5C1.Checked) && (rdoMaleD5C2.Checked || rdoFemaleD5C2.Checked || rdoTheyD5C2.Checked) &&
                //    (rdoMaleD6C1.Checked || rdoFemaleD6C1.Checked || rdoTheyD6C1.Checked) && (rdoMaleD6C2.Checked || rdoFemaleD6C2.Checked || rdoTheyD6C2.Checked) &&
                //    (rdoMaleD7C1.Checked || rdoFemaleD7C1.Checked || rdoTheyD7C1.Checked) && (rdoMaleD7C2.Checked || rdoFemaleD7C2.Checked || rdoTheyD7C2.Checked) &&
                //    (rdoMaleD8C1.Checked || rdoFemaleD8C1.Checked || rdoTheyD8C1.Checked) && (rdoMaleD8C2.Checked || rdoFemaleD8C2.Checked || rdoTheyD8C2.Checked) &&
                //    (rdoMaleD9C1.Checked || rdoFemaleD9C1.Checked || rdoTheyD9C1.Checked) && (rdoMaleD9C2.Checked || rdoFemaleD9C2.Checked || rdoTheyD9C2.Checked) &&
                //    (rdoMaleD10C1.Checked || rdoFemaleD10C1.Checked || rdoTheyD10C1.Checked) && (rdoMaleD10C2.Checked || rdoFemaleD10C2.Checked || rdoTheyD10C2.Checked) &&
                //    (rdoMaleD11C1.Checked || rdoFemaleD11C1.Checked || rdoTheyD11C1.Checked) && (rdoMaleD11C2.Checked || rdoFemaleD11C2.Checked || rdoTheyD11C2.Checked) &&
                //    (rdoMaleD12C1.Checked || rdoFemaleD12C1.Checked || rdoTheyD12C1.Checked) && (rdoMaleD12C2.Checked || rdoFemaleD12C2.Checked || rdoTheyD12C2.Checked))
                //{
                //District 1 Character 1
                if (rdoMaleD1C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD1C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD1C1.Checked) { pronoun = "they"; }

                charD1C1.setName(txtD1C1.Text);
                charD1C1.setPronoun(pronoun);
                charList.Add(charD1C1);

                //District 1 Character 2
                if (rdoMaleD1C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD1C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD1C2.Checked) { pronoun = "they"; }

                charD1C2.setName(txtD1C2.Text);
                charD1C2.setPronoun(pronoun);
                charList.Add(charD1C2);

                //District 2 Character 1
                if (rdoMaleD2C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD2C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD2C1.Checked) { pronoun = "they"; }

                charD2C1.setName(txtD2C1.Text);
                charD2C1.setPronoun(pronoun);
                charList.Add(charD2C1);

                //District 2 Character 2
                if (rdoMaleD2C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD2C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD2C2.Checked) { pronoun = "they"; }

                charD2C2.setName(txtD2C2.Text);
                charD2C2.setPronoun(pronoun);
                charList.Add(charD2C2);

                //District 3 Character 1
                if (rdoMaleD3C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD3C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD3C1.Checked) { pronoun = "they"; }

                charD3C1.setName(txtD3C1.Text);
                charD3C1.setPronoun(pronoun);
                charList.Add(charD3C1);

                //District 3 Character 2
                if (rdoMaleD3C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD3C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD3C2.Checked) { pronoun = "they"; }

                charD3C2.setName(txtD3C2.Text);
                charD3C2.setPronoun(pronoun);
                charList.Add(charD3C2);

                //District 4 Character 1
                if (rdoMaleD4C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD4C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD4C1.Checked) { pronoun = "they"; }

                charD4C1.setName(txtD4C1.Text);
                charD4C1.setPronoun(pronoun);
                charList.Add(charD4C1);

                //District 4 Character 2
                if (rdoMaleD4C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD4C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD4C2.Checked) { pronoun = "they"; }

                charD4C2.setName(txtD4C2.Text);
                charD4C2.setPronoun(pronoun);
                charList.Add(charD4C2);

                //District 5 Character 1
                if (rdoMaleD5C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD5C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD5C1.Checked) { pronoun = "they"; }

                charD5C1.setName(txtD5C1.Text);
                charD5C1.setPronoun(pronoun);
                charList.Add(charD5C1);

                //District 5 Character 2
                if (rdoMaleD5C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD5C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD5C2.Checked) { pronoun = "they"; }

                charD5C2.setName(txtD5C2.Text);
                charD5C2.setPronoun(pronoun);
                charList.Add(charD5C2);

                //District 6 Character 1
                if (rdoMaleD6C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD6C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD6C1.Checked) { pronoun = "they"; }

                charD6C1.setName(txtD6C1.Text);
                charD6C1.setPronoun(pronoun);
                charList.Add(charD6C1);

                //District 6 Character 2
                if (rdoMaleD6C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD6C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD6C2.Checked) { pronoun = "they"; }

                charD6C2.setName(txtD6C2.Text);
                charD6C2.setPronoun(pronoun);
                charList.Add(charD6C2);

                //District 7 Character 1
                if (rdoMaleD7C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD7C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD7C1.Checked) { pronoun = "they"; }

                charD7C1.setName(txtD7C1.Text);
                charD7C1.setPronoun(pronoun);
                charList.Add(charD7C1);

                //District 7 Character 2
                if (rdoMaleD7C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD7C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD7C2.Checked) { pronoun = "they"; }

                charD7C2.setName(txtD7C2.Text);
                charD7C2.setPronoun(pronoun);
                charList.Add(charD7C2);

                //District 8 Character 1
                if (rdoMaleD8C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD8C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD8C1.Checked) { pronoun = "they"; }

                charD8C1.setName(txtD8C1.Text);
                charD8C1.setPronoun(pronoun);
                charList.Add(charD8C1);

                //District 8 Character 2
                if (rdoMaleD8C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD8C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD8C2.Checked) { pronoun = "they"; }

                charD8C2.setName(txtD8C2.Text);
                charD8C2.setPronoun(pronoun);
                charList.Add(charD8C2);

                //District 9 Character 1
                if (rdoMaleD9C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD9C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD9C1.Checked) { pronoun = "they"; }

                charD9C1.setName(txtD9C1.Text);
                charD9C1.setPronoun(pronoun);
                charList.Add(charD9C1);

                //District 9 Character 2
                if (rdoMaleD9C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD9C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD9C2.Checked) { pronoun = "they"; }

                charD9C2.setName(txtD9C2.Text);
                charD9C2.setPronoun(pronoun);
                charList.Add(charD9C2);

                //District 10 Character 1
                if (rdoMaleD10C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD10C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD10C1.Checked) { pronoun = "they"; }

                charD10C1.setName(txtD10C1.Text);
                charD10C1.setPronoun(pronoun);
                charList.Add(charD10C1);

                //District 10 Character 2
                if (rdoMaleD10C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD10C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD10C2.Checked) { pronoun = "they"; }

                charD10C2.setName(txtD10C2.Text);
                charD10C2.setPronoun(pronoun);
                charList.Add(charD10C2);

                //District 11 Character 1
                if (rdoMaleD11C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD11C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD11C1.Checked) { pronoun = "they"; }

                charD11C1.setName(txtD11C1.Text);
                charD11C1.setPronoun(pronoun);
                charList.Add(charD11C1);

                //District 11 Character 2
                if (rdoMaleD11C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD11C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD11C2.Checked) { pronoun = "they"; }

                charD11C2.setName(txtD11C2.Text);
                charD11C2.setPronoun(pronoun);
                charList.Add(charD11C2);

                //District 12 Character 1
                if (rdoMaleD12C1.Checked) { pronoun = "he"; }
                else if (rdoFemaleD12C1.Checked) { pronoun = "she"; }
                else if (rdoTheyD12C1.Checked) { pronoun = "they"; }

                charD12C1.setName(txtD12C1.Text);
                charD12C1.setPronoun(pronoun);
                charList.Add(charD12C1);

                //District 12 Character 2
                if (rdoMaleD12C2.Checked) { pronoun = "he"; }
                else if (rdoFemaleD12C2.Checked) { pronoun = "she"; }
                else if (rdoTheyD12C2.Checked) { pronoun = "they"; }

                charD12C2.setName(txtD12C2.Text);
                charD12C2.setPronoun(pronoun);
                charList.Add(charD12C2);

                charList = rng.shuffleList(charList);

                Sim1 game1 = new Sim1(charList, game);

                this.Hide();
                game1.Show();

            }
            // else MessageBox.Show("You must select pronouns for all characters.");
            //}
            //else { MessageBox.Show("You must enter a name for all characters."); }
        }

        private void btnFillIn_Click(object sender, EventArgs e)
        {
            this.fillIn();
        }
    }
}

