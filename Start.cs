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

        private void btnClassic_Click_1(object sender, EventArgs e)
        {

            btnClassic.Visible = false;
            btnCustom.Visible = true;
            btnPreset.Visible = true;
            grbNumberOptions.Visible = true;
            pnlTest.Visible = true;
            pnlOptions.Visible = true;
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {

            if (rdo24.Checked)
            {
                Game game = new Game(24);
                if (cboRealistic.Checked) game.Mode = "Realistic";
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                CustomCharacters24 customCharacters24 = new(game);
                this.Hide();
                customCharacters24.Show();
            }
            else if (rdo48.Checked)
            {
                Game game = new Game(48);
                if (cboRealistic.Checked) game.Mode = "Realistic";
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                CustomCharacters48 customCharacters48 = new(game);
                this.Hide();
                customCharacters48.Show();
            }
            else { MessageBox.Show("You must select the number of characters."); }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            RNG rng = new();
            List<character> charList = new List<character>();
            character test = new character("Frodo", "he");
            character test2 = new character("Darth Vader", "he");
            character test3 = new character("sans", "he");
            character test4 = new character("Monkey D. Luffy", "he");
            EventImporter ei = new EventImporter();
            Battle battle = new Battle();
            Loot loot = new Loot();
            bool flee;
            int fleeTrue = 0, fleeFalse = 0;
            double percent = 0;

            charList.Add(test);
            charList.Add(test2);
            charList.Add(test3);
            charList.Add(test4);

            //charList = rng.shuffleList(charList);

            test.setWeaponName("Sting");
            test.setWeaponAttack(2);
            test.setWeaponType("stab");
            test.setHealingAmount(2);
            test.fillHealSlot(true);
            test.Speed = 2;
            //test.HasExplosive = true;
            test2.setWeaponName("Lightsaber");
            test2.setWeaponAttack(2);
            test2.setWeaponType("slash");
            test2.setHealingAmount(1);
            test2.fillHealSlot(true);
            test2.Speed = 1;
            test3.setWeaponName("gaster blasters");
            test3.setWeaponAttack(4);
            test3.setWeaponType("Bow");
            test3.setHealingAmount(5);
            test3.fillHealSlot(true);
            test4.setWeaponName("Gum-Gum Pistol");
            test4.setWeaponAttack(5);
            test4.setHealingAmount(5);
            test4.fillHealSlot(true);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbTest.Clear();
        }

        private void btnPreset_Click(object sender, EventArgs e)
        {

            if (rdo24.Checked)
            {
                Game game = new Game(24);
                if (cboRealistic.Checked) game.Mode = "Realistic";
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                PresetCharacters24 presetCharacters24 = new PresetCharacters24(game);
                this.Hide();
                presetCharacters24.Show();
            }
            else if (rdo48.Checked)
            {
                Game game = new Game(48);
                if (cboRealistic.Checked) game.Mode = "Realistic";
                if (cboShortBattles.Checked) game.DoFullBattles = false;
                PresetCharacters48 presetCharacters48 = new PresetCharacters48(game);
                this.Hide();
                presetCharacters48.Show();
            }
            else { MessageBox.Show("You must select the number of characters."); }

        }
    }
}
