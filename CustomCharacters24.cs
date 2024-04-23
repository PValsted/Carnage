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

    /// <summary>
    /// This form provides the necessary code to make the custom character
    /// screen for 24 characters functional. It allows for the user-defined names
    /// and corresponding pronouns to be passed into corresponding character objects
    /// that will then make up the simulation.
    /// </summary>
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

        /// <summary>
        /// Creates all 24 characters using the passed-in values
        /// and puts them in a list which is passed into the simulation.
        /// </summary>
        public void btnEnterCharacters_Click(object sender, EventArgs e)
        {
            //instantiates all 24 characters
            character charD1C1 = new character("D1C1", 1);
            character charD1C2 = new character("D1C2", 1);
            character charD2C1 = new character("D2C1", 2);
            character charD2C2 = new character("D2C2", 2);
            character charD3C1 = new character("D3C1", 3);
            character charD3C2 = new character("D3C2", 3);
            character charD4C1 = new character("D4C1", 4);
            character charD4C2 = new character("D4C2", 4);
            character charD5C1 = new character("D5C1", 5);
            character charD5C2 = new character("D5C2", 5);
            character charD6C1 = new character("D6C1", 6);
            character charD6C2 = new character("D6C2", 6);
            character charD7C1 = new character("D7C1", 7);
            character charD7C2 = new character("D7C2", 7);
            character charD8C1 = new character("D8C1", 8);
            character charD8C2 = new character("D8C2", 8);
            character charD9C1 = new character("D9C1", 9);
            character charD9C2 = new character("D9C2", 9);
            character charD10C1 = new character("D10C1", 10);
            character charD10C2 = new character("D10C2", 10);
            character charD11C1 = new character("D11C1", 11);
            character charD11C2 = new character("D11C2", 11);
            character charD12C1 = new character("D12C1", 12);
            character charD12C2 = new character("D12C2", 12);

            //checks to make sure a name is entered on every line or the below code won't execute
            if (txtD1C1.Text.Length != 0 && txtD1C2.Text.Length != 0 && txtD2C1.Text.Length != 0 && txtD2C2.Text.Length != 0 && txtD3C1.Text.Length != 0 && txtD3C2.Text.Length != 0 &&
                txtD4C1.Text.Length != 0 && txtD4C2.Text.Length != 0 && txtD5C1.Text.Length != 0 && txtD5C2.Text.Length != 0 && txtD6C1.Text.Length != 0 && txtD6C2.Text.Length != 0 &&
                txtD7C1.Text.Length != 0 && txtD7C2.Text.Length != 0 && txtD8C1.Text.Length != 0 && txtD8C2.Text.Length != 0 && txtD9C1.Text.Length != 0 && txtD9C2.Text.Length != 0 &&
                txtD10C1.Text.Length != 0 && txtD10C2.Text.Length != 0 && txtD11C1.Text.Length != 0 && txtD11C2.Text.Length != 0 && txtD12C1.Text.Length != 0 && txtD12C2.Text.Length != 0)
            {
                //checks to make sure one of the pronouns is selected on every line or the below code won't execute
                if ((rdoMaleD1C1.Checked || rdoFemaleD1C1.Checked || rdoTheyD1C1.Checked) && (rdoMaleD1C2.Checked || rdoFemaleD1C2.Checked || rdoTheyD1C2.Checked) &&
                    (rdoMaleD2C1.Checked || rdoFemaleD2C1.Checked || rdoTheyD2C1.Checked) && (rdoMaleD2C2.Checked || rdoFemaleD2C2.Checked || rdoTheyD2C2.Checked) &&
                    (rdoMaleD3C1.Checked || rdoFemaleD3C1.Checked || rdoTheyD3C1.Checked) && (rdoMaleD3C2.Checked || rdoFemaleD3C2.Checked || rdoTheyD3C2.Checked) &&
                    (rdoMaleD4C1.Checked || rdoFemaleD4C1.Checked || rdoTheyD4C1.Checked) && (rdoMaleD4C2.Checked || rdoFemaleD4C2.Checked || rdoTheyD4C2.Checked) &&
                    (rdoMaleD5C1.Checked || rdoFemaleD5C1.Checked || rdoTheyD5C1.Checked) && (rdoMaleD5C2.Checked || rdoFemaleD5C2.Checked || rdoTheyD5C2.Checked) &&
                    (rdoMaleD6C1.Checked || rdoFemaleD6C1.Checked || rdoTheyD6C1.Checked) && (rdoMaleD6C2.Checked || rdoFemaleD6C2.Checked || rdoTheyD6C2.Checked) &&
                    (rdoMaleD7C1.Checked || rdoFemaleD7C1.Checked || rdoTheyD7C1.Checked) && (rdoMaleD7C2.Checked || rdoFemaleD7C2.Checked || rdoTheyD7C2.Checked) &&
                    (rdoMaleD8C1.Checked || rdoFemaleD8C1.Checked || rdoTheyD8C1.Checked) && (rdoMaleD8C2.Checked || rdoFemaleD8C2.Checked || rdoTheyD8C2.Checked) &&
                    (rdoMaleD9C1.Checked || rdoFemaleD9C1.Checked || rdoTheyD9C1.Checked) && (rdoMaleD9C2.Checked || rdoFemaleD9C2.Checked || rdoTheyD9C2.Checked) &&
                    (rdoMaleD10C1.Checked || rdoFemaleD10C1.Checked || rdoTheyD10C1.Checked) && (rdoMaleD10C2.Checked || rdoFemaleD10C2.Checked || rdoTheyD10C2.Checked) &&
                    (rdoMaleD11C1.Checked || rdoFemaleD11C1.Checked || rdoTheyD11C1.Checked) && (rdoMaleD11C2.Checked || rdoFemaleD11C2.Checked || rdoTheyD11C2.Checked) &&
                    (rdoMaleD12C1.Checked || rdoFemaleD12C1.Checked || rdoTheyD12C1.Checked) && (rdoMaleD12C2.Checked || rdoFemaleD12C2.Checked || rdoTheyD12C2.Checked))
                {
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

                    //The instance of the simulator form is created with the newly-generated character list and game passed in
                    Simulation game1 = new Simulation(charList, game);

                    this.Hide();
                    game1.Show();

                }
                else MessageBox.Show("You must select pronouns for all characters."); //Message box shows if a pronoun isn't selected for every character
            }
            else MessageBox.Show("You must enter a name for all characters.");  //Message box shows if a name isn't entered for every character
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

