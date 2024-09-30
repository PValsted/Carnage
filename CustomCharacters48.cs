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
    /// This form provides the necessary code to make the custom character
    /// screen for 48 characters functional. It allows for the user-defined names
    /// and corresponding pronouns to be passed into corresponding character objects
    /// that will then make up the simulation.
    /// </summary>
    public partial class CustomCharacters48 : Form
    {
        List<character> charList = new List<character>();
        Game game;
        String pronoun;
        RNG rng = new RNG();
        VisualSettings vs = new VisualSettings();

        public CustomCharacters48(Game game, VisualSettings vs)
        {
            InitializeComponent();
            this.game = game;
            this.vs = vs;
            this.ApplyVisualEffectsToWindow();
        }

        /// <summary>
        /// Creates all 48 characters using the passed-in values
        /// and puts them in a list which is passed into the simulation.
        /// </summary>
        private void btnEnterCharacters_Click(object sender, EventArgs e)
        {
            //instantiates all 24 characters
            character charD1C1 = new character("D1C1", 1, game);
            character charD1C2 = new character("D1C2", 1, game);
            character charD1C3 = new character("D1C3", 1, game);
            character charD1C4 = new character("D1C4", 1, game);
            character charD2C1 = new character("D2C1", 2, game);
            character charD2C2 = new character("D2C2", 2, game);
            character charD2C3 = new character("D2C3", 2, game);
            character charD2C4 = new character("D2C4", 2, game);
            character charD3C1 = new character("D3C1", 3, game);
            character charD3C2 = new character("D3C2", 3, game);
            character charD3C3 = new character("D3C3", 3, game);
            character charD3C4 = new character("D3C4", 3, game);
            character charD4C1 = new character("D4C1", 4, game);
            character charD4C2 = new character("D4C2", 4, game);
            character charD4C3 = new character("D4C3", 4, game);
            character charD4C4 = new character("D4C4", 4, game);
            character charD5C1 = new character("D5C1", 5, game);
            character charD5C2 = new character("D5C2", 5, game);
            character charD5C3 = new character("D5C3", 5, game);
            character charD5C4 = new character("D5C4", 5, game);
            character charD6C1 = new character("D6C1", 6, game);
            character charD6C2 = new character("D6C2", 6, game);
            character charD6C3 = new character("D6C3", 6, game);
            character charD6C4 = new character("D6C4", 6, game);
            character charD7C1 = new character("D7C1", 7, game);
            character charD7C2 = new character("D7C2", 7, game);
            character charD7C3 = new character("D7C3", 7, game);
            character charD7C4 = new character("D7C4", 7, game);
            character charD8C1 = new character("D8C1", 8, game);
            character charD8C2 = new character("D8C2", 8, game);
            character charD8C3 = new character("D8C3", 8, game);
            character charD8C4 = new character("D8C4", 8, game);
            character charD9C1 = new character("D9C1", 9, game);
            character charD9C2 = new character("D9C2", 9, game);
            character charD9C3 = new character("D9C3", 9, game);
            character charD9C4 = new character("D9C4", 9, game);
            character charD10C1 = new character("D10C1", 10, game);
            character charD10C2 = new character("D10C2", 10, game);
            character charD10C3 = new character("D10C3", 10, game);
            character charD10C4 = new character("D10C4", 10, game);
            character charD11C1 = new character("D11C1", 11, game);
            character charD11C2 = new character("D11C2", 11, game);
            character charD11C3 = new character("D11C3", 11, game);
            character charD11C4 = new character("D11C4", 11, game);
            character charD12C1 = new character("D12C1", 12, game);
            character charD12C2 = new character("D12C2", 12, game);
            character charD12C3 = new character("D12C3", 12, game);
            character charD12C4 = new character("D12C4", 12, game);

            //checks to make sure a name is entered on every line or the below code won't execute
            if (txtD1C1.Text.Length != 0 && txtD1C2.Text.Length != 0 && txtD1C3.Text.Length != 0 && txtD1C4.Text.Length != 0 &&
                txtD2C1.Text.Length != 0 && txtD2C2.Text.Length != 0 && txtD2C3.Text.Length != 0 && txtD2C4.Text.Length != 0 &&
                txtD3C1.Text.Length != 0 && txtD3C2.Text.Length != 0 && txtD3C3.Text.Length != 0 && txtD3C4.Text.Length != 0 &&
                txtD4C1.Text.Length != 0 && txtD4C2.Text.Length != 0 && txtD4C3.Text.Length != 0 && txtD4C4.Text.Length != 0 &&
                txtD5C1.Text.Length != 0 && txtD5C2.Text.Length != 0 && txtD5C3.Text.Length != 0 && txtD5C4.Text.Length != 0 &&
                txtD6C1.Text.Length != 0 && txtD6C2.Text.Length != 0 && txtD6C3.Text.Length != 0 && txtD6C4.Text.Length != 0 &&
                txtD7C1.Text.Length != 0 && txtD7C2.Text.Length != 0 && txtD7C3.Text.Length != 0 && txtD7C4.Text.Length != 0 &&
                txtD8C1.Text.Length != 0 && txtD8C2.Text.Length != 0 && txtD8C3.Text.Length != 0 && txtD8C4.Text.Length != 0 &&
                txtD9C1.Text.Length != 0 && txtD9C2.Text.Length != 0 && txtD9C3.Text.Length != 0 && txtD9C4.Text.Length != 0 &&
                txtD10C1.Text.Length != 0 && txtD10C2.Text.Length != 0 && txtD10C3.Text.Length != 0 && txtD10C4.Text.Length != 0 &&
                txtD11C1.Text.Length != 0 && txtD11C2.Text.Length != 0 && txtD11C3.Text.Length != 0 && txtD11C4.Text.Length != 0 &&
                txtD12C1.Text.Length != 0 && txtD12C2.Text.Length != 0 && txtD12C3.Text.Length != 0 && txtD12C4.Text.Length != 0)
            {
                //checks to make sure one of the pronouns is selected on every line or the below code won't execute
                if ((rdoMaleD1C1.Checked || rdoFemaleD1C1.Checked || rdoTheyD1C1.Checked) && (rdoMaleD1C2.Checked || rdoFemaleD1C2.Checked || rdoTheyD1C2.Checked) &&
                    (rdoMaleD1C3.Checked || rdoFemaleD1C3.Checked || rdoTheyD1C3.Checked) && (rdoMaleD1C4.Checked || rdoFemaleD1C4.Checked || rdoTheyD1C4.Checked) &&
                    (rdoMaleD2C1.Checked || rdoFemaleD2C1.Checked || rdoTheyD2C1.Checked) && (rdoMaleD2C2.Checked || rdoFemaleD2C2.Checked || rdoTheyD2C2.Checked) &&
                    (rdoMaleD2C3.Checked || rdoFemaleD2C3.Checked || rdoTheyD2C3.Checked) && (rdoMaleD2C4.Checked || rdoFemaleD2C4.Checked || rdoTheyD2C4.Checked) &&
                    (rdoMaleD3C1.Checked || rdoFemaleD3C1.Checked || rdoTheyD3C1.Checked) && (rdoMaleD3C2.Checked || rdoFemaleD3C2.Checked || rdoTheyD3C2.Checked) &&
                    (rdoMaleD3C3.Checked || rdoFemaleD3C3.Checked || rdoTheyD3C3.Checked) && (rdoMaleD3C4.Checked || rdoFemaleD3C4.Checked || rdoTheyD3C4.Checked) &&
                    (rdoMaleD4C1.Checked || rdoFemaleD4C1.Checked || rdoTheyD4C1.Checked) && (rdoMaleD4C2.Checked || rdoFemaleD4C2.Checked || rdoTheyD4C2.Checked) &&
                    (rdoMaleD4C3.Checked || rdoFemaleD4C3.Checked || rdoTheyD4C3.Checked) && (rdoMaleD4C4.Checked || rdoFemaleD4C4.Checked || rdoTheyD4C4.Checked) &&
                    (rdoMaleD5C1.Checked || rdoFemaleD5C1.Checked || rdoTheyD5C1.Checked) && (rdoMaleD5C2.Checked || rdoFemaleD5C2.Checked || rdoTheyD5C2.Checked) &&
                    (rdoMaleD5C3.Checked || rdoFemaleD5C3.Checked || rdoTheyD5C3.Checked) && (rdoMaleD5C4.Checked || rdoFemaleD5C4.Checked || rdoTheyD5C4.Checked) &&
                    (rdoMaleD6C1.Checked || rdoFemaleD6C1.Checked || rdoTheyD6C1.Checked) && (rdoMaleD6C2.Checked || rdoFemaleD6C2.Checked || rdoTheyD6C2.Checked) &&
                    (rdoMaleD6C3.Checked || rdoFemaleD6C3.Checked || rdoTheyD6C3.Checked) && (rdoMaleD6C4.Checked || rdoFemaleD6C4.Checked || rdoTheyD6C4.Checked) &&
                    (rdoMaleD7C1.Checked || rdoFemaleD7C1.Checked || rdoTheyD7C1.Checked) && (rdoMaleD7C2.Checked || rdoFemaleD7C2.Checked || rdoTheyD7C2.Checked) &&
                    (rdoMaleD7C3.Checked || rdoFemaleD7C3.Checked || rdoTheyD7C3.Checked) && (rdoMaleD7C4.Checked || rdoFemaleD7C4.Checked || rdoTheyD7C4.Checked) &&
                    (rdoMaleD8C1.Checked || rdoFemaleD8C1.Checked || rdoTheyD8C1.Checked) && (rdoMaleD8C2.Checked || rdoFemaleD8C2.Checked || rdoTheyD8C2.Checked) &&
                    (rdoMaleD8C3.Checked || rdoFemaleD8C3.Checked || rdoTheyD8C3.Checked) && (rdoMaleD8C4.Checked || rdoFemaleD8C4.Checked || rdoTheyD8C4.Checked) &&
                    (rdoMaleD9C1.Checked || rdoFemaleD9C1.Checked || rdoTheyD9C1.Checked) && (rdoMaleD9C2.Checked || rdoFemaleD9C2.Checked || rdoTheyD9C2.Checked) &&
                    (rdoMaleD9C3.Checked || rdoFemaleD9C3.Checked || rdoTheyD9C3.Checked) && (rdoMaleD9C4.Checked || rdoFemaleD9C4.Checked || rdoTheyD9C4.Checked) &&
                    (rdoMaleD10C1.Checked || rdoFemaleD10C1.Checked || rdoTheyD10C1.Checked) && (rdoMaleD10C2.Checked || rdoFemaleD10C2.Checked || rdoTheyD10C2.Checked) &&
                    (rdoMaleD10C3.Checked || rdoFemaleD10C3.Checked || rdoTheyD10C3.Checked) && (rdoMaleD10C4.Checked || rdoFemaleD10C4.Checked || rdoTheyD10C4.Checked) &&
                    (rdoMaleD11C1.Checked || rdoFemaleD11C1.Checked || rdoTheyD11C1.Checked) && (rdoMaleD11C2.Checked || rdoFemaleD11C2.Checked || rdoTheyD11C2.Checked) &&
                    (rdoMaleD11C3.Checked || rdoFemaleD11C3.Checked || rdoTheyD11C3.Checked) && (rdoMaleD11C4.Checked || rdoFemaleD11C4.Checked || rdoTheyD11C4.Checked) &&
                    (rdoMaleD12C1.Checked || rdoFemaleD12C1.Checked || rdoTheyD12C1.Checked) && (rdoMaleD12C2.Checked || rdoFemaleD12C2.Checked || rdoTheyD12C2.Checked) &&
                    (rdoMaleD12C3.Checked || rdoFemaleD12C3.Checked || rdoTheyD12C3.Checked) && (rdoMaleD12C4.Checked || rdoFemaleD12C4.Checked || rdoTheyD12C4.Checked))
                {

                    //District 1 Character 1
                    if (rdoMaleD1C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD1C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD1C1.Checked) { pronoun = "they"; }

                    charD1C1.Name = txtD1C1.Text;
                    charD1C1.setPronoun(pronoun);
                    charList.Add(charD1C1);

                    //District 1 Character 2
                    if (rdoMaleD1C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD1C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD1C2.Checked) { pronoun = "they"; }

                    charD1C2.Name = txtD1C2.Text;
                    charD1C2.setPronoun(pronoun);
                    charList.Add(charD1C2);

                    //District 1 Character 3
                    if (rdoMaleD1C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD1C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD1C3.Checked) { pronoun = "they"; }

                    charD1C3.Name = txtD1C3.Text;
                    charD1C3.setPronoun(pronoun);
                    charList.Add(charD1C3);

                    //District 1 Character 4
                    if (rdoMaleD1C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD1C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD1C4.Checked) { pronoun = "they"; }

                    charD1C4.Name = txtD1C4.Text;
                    charD1C4.setPronoun(pronoun);
                    charList.Add(charD1C4);

                    //District 2 Character 1
                    if (rdoMaleD2C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD2C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD2C1.Checked) { pronoun = "they"; }

                    charD2C1.Name = txtD2C1.Text;
                    charD2C1.setPronoun(pronoun);
                    charList.Add(charD2C1);

                    //District 2 Character 2
                    if (rdoMaleD2C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD2C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD2C2.Checked) { pronoun = "they"; }

                    charD2C2.Name = txtD2C2.Text;
                    charD2C2.setPronoun(pronoun);
                    charList.Add(charD2C2);

                    //District 2 Character 3
                    if (rdoMaleD2C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD2C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD2C3.Checked) { pronoun = "they"; }

                    charD2C3.Name = txtD2C3.Text;
                    charD2C3.setPronoun(pronoun);
                    charList.Add(charD2C3);

                    //District 2 Character 4
                    if (rdoMaleD2C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD2C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD2C4.Checked) { pronoun = "they"; }

                    charD2C4.Name = txtD2C4.Text;
                    charD2C4.setPronoun(pronoun);
                    charList.Add(charD2C4);

                    //District 3 Character 1
                    if (rdoMaleD3C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD3C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD3C1.Checked) { pronoun = "they"; }

                    charD3C1.Name = txtD3C1.Text;
                    charD3C1.setPronoun(pronoun);
                    charList.Add(charD3C1);

                    //District 3 Character 2
                    if (rdoMaleD3C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD3C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD3C2.Checked) { pronoun = "they"; }

                    charD3C2.Name = txtD3C2.Text;
                    charD3C2.setPronoun(pronoun);
                    charList.Add(charD3C2);

                    //District 3 Character 3
                    if (rdoMaleD3C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD3C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD3C3.Checked) { pronoun = "they"; }

                    charD3C3.Name = txtD3C3.Text;
                    charD3C3.setPronoun(pronoun);
                    charList.Add(charD3C3);

                    //District 3 Character 4
                    if (rdoMaleD3C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD3C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD3C4.Checked) { pronoun = "they"; }

                    charD3C4.Name = txtD3C4.Text;
                    charD3C4.setPronoun(pronoun);
                    charList.Add(charD3C4);

                    //District 4 Character 1
                    if (rdoMaleD4C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD4C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD4C1.Checked) { pronoun = "they"; }

                    charD4C1.Name = txtD4C1.Text;
                    charD4C1.setPronoun(pronoun);
                    charList.Add(charD4C1);

                    //District 4 Character 2
                    if (rdoMaleD4C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD4C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD4C2.Checked) { pronoun = "they"; }

                    charD4C2.Name = txtD4C2.Text;
                    charD4C2.setPronoun(pronoun);
                    charList.Add(charD4C2);

                    //District 4 Character 3
                    if (rdoMaleD4C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD4C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD4C3.Checked) { pronoun = "they"; }

                    charD4C3.Name = txtD4C3.Text;
                    charD4C3.setPronoun(pronoun);
                    charList.Add(charD4C3);

                    //District 4 Character 4
                    if (rdoMaleD4C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD4C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD4C4.Checked) { pronoun = "they"; }

                    charD4C4.Name = txtD4C4.Text;
                    charD4C4.setPronoun(pronoun);
                    charList.Add(charD4C4);

                    //District 5 Character 1
                    if (rdoMaleD5C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD5C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD5C1.Checked) { pronoun = "they"; }

                    charD5C1.Name = txtD5C1.Text;
                    charD5C1.setPronoun(pronoun);
                    charList.Add(charD5C1);

                    //District 5 Character 2
                    if (rdoMaleD5C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD5C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD5C2.Checked) { pronoun = "they"; }

                    charD5C2.Name = txtD5C2.Text;
                    charD5C2.setPronoun(pronoun);
                    charList.Add(charD5C2);

                    //District 5 Character 3
                    if (rdoMaleD5C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD5C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD5C3.Checked) { pronoun = "they"; }

                    charD5C3.Name = txtD5C3.Text;
                    charD5C3.setPronoun(pronoun);
                    charList.Add(charD5C3);

                    //District 5 Character 4
                    if (rdoMaleD5C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD5C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD5C4.Checked) { pronoun = "they"; }

                    charD5C4.Name = txtD5C4.Text;
                    charD5C4.setPronoun(pronoun);
                    charList.Add(charD5C4);

                    //District 6 Character 1
                    if (rdoMaleD6C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD6C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD6C1.Checked) { pronoun = "they"; }

                    charD6C1.Name = txtD6C1.Text;
                    charD6C1.setPronoun(pronoun);
                    charList.Add(charD6C1);

                    //District 6 Character 2
                    if (rdoMaleD6C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD6C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD6C2.Checked) { pronoun = "they"; }

                    charD6C2.Name = txtD6C2.Text;
                    charD6C2.setPronoun(pronoun);
                    charList.Add(charD6C2);

                    //District 6 Character 3
                    if (rdoMaleD6C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD6C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD6C3.Checked) { pronoun = "they"; }

                    charD6C3.Name = txtD6C3.Text;
                    charD6C3.setPronoun(pronoun);
                    charList.Add(charD6C3);

                    //District 6 Character 4
                    if (rdoMaleD6C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD6C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD6C4.Checked) { pronoun = "they"; }

                    charD6C4.Name = txtD6C4.Text;
                    charD6C4.setPronoun(pronoun);
                    charList.Add(charD6C4);

                    //District 7 Character 1
                    if (rdoMaleD7C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD7C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD7C1.Checked) { pronoun = "they"; }

                    charD7C1.Name = txtD7C1.Text;
                    charD7C1.setPronoun(pronoun);
                    charList.Add(charD7C1);

                    //District 7 Character 2
                    if (rdoMaleD7C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD7C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD7C2.Checked) { pronoun = "they"; }

                    charD7C2.Name = txtD7C2.Text;
                    charD7C2.setPronoun(pronoun);
                    charList.Add(charD7C2);

                    //District 7 Character 3
                    if (rdoMaleD7C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD7C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD7C3.Checked) { pronoun = "they"; }

                    charD7C3.Name = txtD7C3.Text;
                    charD7C3.setPronoun(pronoun);
                    charList.Add(charD7C3);

                    //District 7 Character 4
                    if (rdoMaleD7C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD7C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD7C4.Checked) { pronoun = "they"; }

                    charD7C4.Name = txtD7C4.Text;
                    charD7C4.setPronoun(pronoun);
                    charList.Add(charD7C4);

                    //District 8 Character 1
                    if (rdoMaleD8C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD8C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD8C1.Checked) { pronoun = "they"; }

                    charD8C1.Name = txtD8C1.Text;
                    charD8C1.setPronoun(pronoun);
                    charList.Add(charD8C1);

                    //District 8 Character 2
                    if (rdoMaleD8C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD8C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD8C2.Checked) { pronoun = "they"; }

                    charD8C2.Name = txtD8C2.Text;
                    charD8C2.setPronoun(pronoun);
                    charList.Add(charD8C2);

                    //District 8 Character 3
                    if (rdoMaleD8C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD8C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD8C3.Checked) { pronoun = "they"; }

                    charD8C3.Name = txtD8C3.Text;
                    charD8C3.setPronoun(pronoun);
                    charList.Add(charD8C3);

                    //District 8 Character 4
                    if (rdoMaleD8C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD8C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD8C4.Checked) { pronoun = "they"; }

                    charD8C4.Name = txtD8C4.Text;
                    charD8C4.setPronoun(pronoun);
                    charList.Add(charD8C4);

                    //District 9 Character 1
                    if (rdoMaleD9C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD9C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD9C1.Checked) { pronoun = "they"; }

                    charD9C1.Name = txtD9C1.Text;
                    charD9C1.setPronoun(pronoun);
                    charList.Add(charD9C1);

                    //District 9 Character 2
                    if (rdoMaleD9C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD9C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD9C2.Checked) { pronoun = "they"; }

                    charD9C2.Name = txtD9C2.Text;
                    charD9C2.setPronoun(pronoun);
                    charList.Add(charD9C2);

                    //District 9 Character 3
                    if (rdoMaleD9C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD9C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD9C3.Checked) { pronoun = "they"; }

                    charD9C3.Name = txtD9C3.Text;
                    charD9C3.setPronoun(pronoun);
                    charList.Add(charD9C3);

                    //District 9 Character 4
                    if (rdoMaleD9C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD9C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD9C4.Checked) { pronoun = "they"; }

                    charD9C4.Name = txtD9C4.Text;
                    charD9C4.setPronoun(pronoun);
                    charList.Add(charD9C4);

                    //District 10 Character 1
                    if (rdoMaleD10C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD10C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD10C1.Checked) { pronoun = "they"; }

                    charD10C1.Name = txtD10C1.Text;
                    charD10C1.setPronoun(pronoun);
                    charList.Add(charD10C1);

                    //District 10 Character 2
                    if (rdoMaleD10C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD10C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD10C2.Checked) { pronoun = "they"; }

                    charD10C2.Name = txtD10C2.Text;
                    charD10C2.setPronoun(pronoun);
                    charList.Add(charD10C2);

                    //District 10 Character 3
                    if (rdoMaleD10C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD10C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD10C3.Checked) { pronoun = "they"; }

                    charD10C3.Name = txtD10C3.Text;
                    charD10C3.setPronoun(pronoun);
                    charList.Add(charD10C3);

                    //District 10 Character 4
                    if (rdoMaleD10C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD10C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD10C4.Checked) { pronoun = "they"; }

                    charD10C4.Name = txtD10C4.Text;
                    charD10C4.setPronoun(pronoun);
                    charList.Add(charD10C4);

                    //District 11 Character 1
                    if (rdoMaleD11C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD11C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD11C1.Checked) { pronoun = "they"; }

                    charD11C1.Name = txtD11C1.Text;
                    charD11C1.setPronoun(pronoun);
                    charList.Add(charD11C1);

                    //District 11 Character 2
                    if (rdoMaleD11C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD11C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD11C2.Checked) { pronoun = "they"; }

                    charD11C2.Name = txtD11C2.Text;
                    charD11C2.setPronoun(pronoun);
                    charList.Add(charD11C2);

                    //District 11 Character 3
                    if (rdoMaleD11C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD11C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD11C3.Checked) { pronoun = "they"; }

                    charD11C3.Name = txtD11C3.Text;
                    charD11C3.setPronoun(pronoun);
                    charList.Add(charD11C3);

                    //District 11 Character 4
                    if (rdoMaleD11C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD11C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD11C4.Checked) { pronoun = "they"; }

                    charD11C4.Name = txtD11C4.Text;
                    charD11C4.setPronoun(pronoun);
                    charList.Add(charD11C4);

                    //District 12 Character 1
                    if (rdoMaleD12C1.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD12C1.Checked) { pronoun = "she"; }
                    else if (rdoTheyD12C1.Checked) { pronoun = "they"; }

                    charD12C1.Name = txtD12C1.Text;
                    charD12C1.setPronoun(pronoun);
                    charList.Add(charD12C1);

                    //District 12 Character 2
                    if (rdoMaleD12C2.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD12C2.Checked) { pronoun = "she"; }
                    else if (rdoTheyD12C2.Checked) { pronoun = "they"; }

                    charD12C2.Name = txtD12C2.Text;
                    charD12C2.setPronoun(pronoun);
                    charList.Add(charD12C2);

                    //District 12 Character 3
                    if (rdoMaleD12C3.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD12C3.Checked) { pronoun = "she"; }
                    else if (rdoTheyD12C3.Checked) { pronoun = "they"; }

                    charD12C3.Name = txtD12C3.Text;
                    charD12C3.setPronoun(pronoun);
                    charList.Add(charD12C3);

                    //District 12 Character 4
                    if (rdoMaleD12C4.Checked) { pronoun = "he"; }
                    else if (rdoFemaleD12C4.Checked) { pronoun = "she"; }
                    else if (rdoTheyD12C4.Checked) { pronoun = "they"; }

                    charD12C4.Name = txtD12C4.Text;
                    charD12C4.setPronoun(pronoun);
                    charList.Add(charD12C4);

                    charList = rng.shuffleList(charList);

                    //The instance of the simulator form is created with the newly-generated character list and game passed in
                    Simulation game1 = new Simulation(charList, game, vs);

                    this.Hide();
                    game1.Show();

                }
                else MessageBox.Show("You must select pronouns for all characters."); //Message box shows if a pronoun isn't selected for every character
            }
            else MessageBox.Show("You must enter a name for all characters."); //Message box shows if a name isn't entered for every character
        }

        /// <summary>
        /// Returns the user to the start menu form
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Start start = new Start(vs);

            start.Show();
            this.Hide();
        }

        private void ApplyVisualEffectsToWindow()
        {
            if (vs.Mode == "Light")
            {
                this.BackgroundImage = Properties.Resources.yellow_gradient;
                panelCharacterSelect.BackColor = System.Drawing.Color.White;
                panelCharacterSelect.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.super_dark_gradient;
                panelCharacterSelect.BackColor = System.Drawing.Color.DimGray;
                panelCharacterSelect.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
