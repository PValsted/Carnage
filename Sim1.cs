using Org.BouncyCastle.Pqc.Crypto.Lms;
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
    public partial class Sim1 : Form
    {
        List<character> charList = new();
        List<character> tempCharList = new();
        List<character> dayCharList = new();
        List<character> deathCharList = new();
        List<character> tempDeathCharList = new();
        List<int> intList = new List<int>();
        RNG rng = new();
        Day day = new Day();
        Bloodbath bb = new();
        Feast feast = new();
        ArenaEvent ae = new();
        int i = 0, unassignedPlayers, deathCount = 0;
        bool isSponsor = false;
        Game game;
        StatUpdater su = new StatUpdater();
        Loot loot = new Loot();
        string type1, type2, type3;
        double rand1, rand2, rand3;
        string[] lootArray1 = new string[4];
        string[] lootArray2 = new string[4];
        string[] lootArray3 = new string[4];

        public Sim1(List<character> charList, Game game)
        {
            InitializeComponent();
            this.charList = charList;

            for (int i = 0; i < charList.Count; i++)
            {
                tempCharList.Add(charList[i]);
            }

            this.game = game;
            game.ActivePlayers = game.Players;
            unassignedPlayers = game.Players;

            this.bloodbath();
        }

        private void bloodbath()
        {
            rtbText.AppendText(bb.doBloodbath(game, tempCharList));

            for (int i = 0; i < tempCharList.Count; i++)
            {
                if (tempCharList[i].aliveCheck() == false)
                {
                    deathCharList.Add(tempCharList[i]);
                    tempDeathCharList.Add(tempCharList[i]);
                    deathCount++;
                    game.BloodbathDeaths++;
                }
            }

            for (int j = 0; j < tempDeathCharList.Count; j++)
            {
                tempCharList.Remove(tempDeathCharList.ElementAt(j));
            }

            game.IsDeath = true;
            game.IsDay = false;
        }

        private void dayEvents()
        {
            for (int i = 0; i < tempCharList.Count; i++)
            {
                dayCharList.Add(tempCharList[i]);
            }

            if (game.ActivePlayers > 1)
            {
                rtbText.AppendText(day.DoDay(game, dayCharList));

                for (int j = 0; j < dayCharList.Count; j++)
                {
                    if (dayCharList.ElementAt(j).IsAlive == false)
                    {
                        deathCharList.Add(dayCharList.ElementAt(j));
                        tempDeathCharList.Add(dayCharList[j]);
                        deathCount++;
                    }
                }

                dayCharList.Clear();

                for (int j = 0; j < tempDeathCharList.Count; j++)
                {
                    tempCharList.Remove(tempDeathCharList.ElementAt(j));
                }

                game.Day++;
            }

            if (tempCharList.Count == 1)
            {
                game.IsActive = false;
                game.IsDeath = false;
                game.IsDay = false;
            }

            if (game.IsActive == true)
            {
                game.IsDeath = true;
                game.IsDay = false;
            }
        }

        private void doFeast()
        {
            rtbText.AppendText(feast.doFeast(game, tempCharList));

            for (int i = 0; i < tempCharList.Count; i++)
            {
                if (tempCharList[i].aliveCheck() == false)
                {
                    deathCharList.Add(tempCharList[i]);
                    tempDeathCharList.Add(tempCharList[i]);
                    deathCount++;
                    game.FeastDeaths++;
                }
            }

            for (int j = 0; j < tempDeathCharList.Count; j++)
            {
                tempCharList.Remove(tempDeathCharList.ElementAt(j));
            }

            if (tempCharList.Count == 1)
            {
                game.IsActive = false;
                game.IsDeath = false;
                game.IsDay = false;
            }
            else
            {
                game.IsDeath = true;
                game.IsDay = false;
                game.HadFeast = true;
            }
        }

        private void doArenaEvent()
        {
            game.Events++;
            rtbText.AppendText(ae.doArenaEvent(game, tempCharList));

            for (int i = 0; i < tempCharList.Count; i++)
            {
                if (tempCharList[i].aliveCheck() == false)
                {
                    deathCharList.Add(tempCharList[i]);
                    tempDeathCharList.Add(tempCharList[i]);
                    deathCount++;
                    game.ArenaEventDeaths++;
                }
            }

            for (int j = 0; j < tempDeathCharList.Count; j++)
            {
                tempCharList.Remove(tempDeathCharList.ElementAt(j));
            }

            if (tempCharList.Count == 1)
            {
                game.IsActive = false;
                game.IsDeath = false;
                game.IsEvent = false;
                game.IsDay = false;
            }
            else
            {
                game.IsDeath = true;
                game.IsEvent = false;
                game.IsDay = false;
            }
        }

        private void deathsScreen()
        {
            btnStats.Visible = true;

            if (deathCount > 1) rtbText.AppendText("As night falls, " + deathCount + " cannon shots are fired. The following tributes have perished, and their names and images are displayed in the sky:\n\n");
            else if (deathCount == 1) rtbText.AppendText("As night falls, " + deathCount + " cannon shot is fired. The following tribute has perished, and their name and image is displayed in the sky:\n\n");
            else rtbText.AppendText("As night falls, no cannon shots are fired. The tributes are thankful for a peaceful day.\n");
            for (int i = 0; i < tempDeathCharList.Count; i++)
            {
                if (tempDeathCharList.ElementAt(i).Kills == 1)
                {
                    rtbText.AppendText(tempDeathCharList.ElementAt(i).getName() + " from District " + tempDeathCharList[i].District + ": " + tempDeathCharList.ElementAt(i).Kills + " kill\n");
                }
                else if (tempDeathCharList.ElementAt(i).Kills > 1)
                {
                    rtbText.AppendText(tempDeathCharList.ElementAt(i).getName() + " from District " + tempDeathCharList[i].District + ": " + tempDeathCharList.ElementAt(i).Kills + " kills\n");
                }
                else
                {
                    rtbText.AppendText(tempDeathCharList.ElementAt(i).getName() + " from District " + tempDeathCharList[i].District + "\n");
                }
            }
            rtbText.AppendText("\n");
            tempDeathCharList.Clear();
            game.ActivePlayers -= deathCount;
            rtbText.AppendText(game.ActivePlayers + " remain.\n");
            deathCount = 0;

            game.IsDeath = false;
            if (tempCharList.Count() >= 3 && game.DoSponsor == true) isSponsor = true;
            else game.IsDay = true;
        }

        private void winnerScreen()
        {
            if (tempCharList[0].Kills == 1)
            {
                lblWinner.Text = tempCharList[0].getName() + " from District " + tempCharList[0].District + " is the winner with " + tempCharList[0].Kills + " kill!";
            }
            else
            {
                lblWinner.Text = tempCharList[0].getName() + " from District " + tempCharList[0].District + " is the winner with " + tempCharList[0].Kills + " kills!";
            }

            rtbPlaces.AppendText(su.Places(deathCharList, tempCharList[0], game));
            rtbKills.AppendText(su.Kills(deathCharList, tempCharList[0], game));
            rtbGeneralStats.AppendText(su.GeneralStats(deathCharList, tempCharList[0], game));

        }

        private void sponsorScreen()
        {
            pnlMain.Hide();
            pnlSponsor.Show();

            intList.Clear();

            intList = rng.RandomIntList(tempCharList.Count, 3);

            //Random Alive Player 1
            if (game.Mode == "Classic")
            {
                rboPlayer1Sponsor.Text = tempCharList[intList[0]].Name + ": " + tempCharList[intList[0]].Health + " health";
            }
            else
            {
                rboPlayer1Sponsor.Text = tempCharList[intList[0]].Name + ": " + tempCharList[intList[0]].Health + " health, " + tempCharList[intList[0]].Hunger + " hunger";
            }
            //Random Alive Player 2
            if (game.Mode == "Classic")
            {
                rboPlayer2Sponsor.Text = tempCharList[intList[1]].Name + ": " + tempCharList[intList[1]].Health + " health";
            }
            else
            {
                rboPlayer2Sponsor.Text = tempCharList[intList[1]].Name + ": " + tempCharList[intList[1]].Health + " health, " + tempCharList[intList[1]].Hunger + " hunger";
            }
            //Random Alive Player 3
            if (game.Mode == "Classic")
            {
                rboPlayer3Sponsor.Text = tempCharList[intList[2]].Name + ": " + tempCharList[intList[2]].Health + " health";
            }
            else
            {
                rboPlayer3Sponsor.Text = tempCharList[intList[2]].Name + ": " + tempCharList[intList[2]].Health + " health, " + tempCharList[intList[2]].Hunger + " hunger";
            }

            type1 = loot.SponsorItemType(tempCharList[intList[0]], game);
            type2 = loot.SponsorItemType(tempCharList[intList[1]], game);
            type3 = loot.SponsorItemType(tempCharList[intList[2]], game);

            //Decides item for Player 1
            if (type1 == "Healing")
            {
                rand1 = Double.Parse(rng.randomInt(3, 8).ToString());

                txtPlayer1Item.Text = "Sponsor Medkit: Heals " + rand1 + " health";
            }
            else if (type1 == "Any Weapon")
            {
                int randomRarity = rng.randomInt(1, 10);

                if (randomRarity == 1) lootArray1 = loot.getLoot("Rare", "Weapon");
                else if (randomRarity == 2 || randomRarity == 3) lootArray1 = loot.getLoot("Uncommon", "Weapon");
                else lootArray1 = loot.getLoot("Common", "Weapon");

                if (lootArray1[1] != "explosive") txtPlayer1Item.Text = "Weapon: " + lootArray1[0] + ", " + Double.Parse(lootArray1[2]) + " damage";
                else
                {
                    txtPlayer1Item.Text = "Explosive";
                }
            }
            else if (type1 == "Hunger")
            {
                rand1 = Double.Parse(rng.randomInt(3, 8).ToString());

                txtPlayer1Item.Text = "Sponsor Food: Refills " + rand1 + " hunger";
            }
            else if (type1 == "Explosive")
            {
                txtPlayer1Item.Text = "Explosive";
            }
            else
            {
                txtPlayer1Item.Text = "Permanent boost of 2 attack to player's weapon";
            }

            //Decides item for Player 2
            if (type2 == "Healing")
            {
                rand2 = Double.Parse(rng.randomInt(3, 8).ToString());

                txtPlayer2Item.Text = "Sponsor Medkit: Heals " + rand2 + " health";
            }
            else if (type2 == "Any Weapon")
            {
                int randomRarity = rng.randomInt(1, 10);

                if (randomRarity == 1) lootArray2 = loot.getLoot("Rare", "Weapon");
                else if (randomRarity == 2 || randomRarity == 3) lootArray2 = loot.getLoot("Uncommon", "Weapon");
                else lootArray2 = loot.getLoot("Common", "Weapon");

                if (lootArray2[1] != "explosive") txtPlayer2Item.Text = "Weapon: " + lootArray2[0] + ", " + Double.Parse(lootArray2[2]) + " damage";
                else
                {
                    txtPlayer2Item.Text = "Explosive";
                }
            }
            else if (type2 == "Hunger")
            {
                rand2 = Double.Parse(rng.randomInt(3, 8).ToString());

                txtPlayer2Item.Text = "Sponsor Food: Refills " + rand2 + " hunger";
            }
            else if (type2 == "Explosive")
            {
                txtPlayer2Item.Text = "Explosive";
            }
            else
            {
                txtPlayer2Item.Text = "Permanent boost of 2 attack to player's weapon";
            }

            //Decides item for Player 3
            if (type3 == "Healing")
            {
                rand3 = Double.Parse(rng.randomInt(3, 8).ToString());

                txtPlayer3Item.Text = "Sponsor Medkit: Heals " + rand3 + " health";
            }
            else if (type3 == "Any Weapon")
            {
                int randomRarity = rng.randomInt(1, 10);

                if (randomRarity == 1) lootArray3 = loot.getLoot("Rare", "Weapon");
                else if (randomRarity == 2 || randomRarity == 3) lootArray3 = loot.getLoot("Uncommon", "Weapon");
                else lootArray3 = loot.getLoot("Common", "Weapon");

                if (lootArray3[1] != "explosive") txtPlayer3Item.Text = "Weapon: " + lootArray3[0] + ", " + Double.Parse(lootArray3[2]) + " damage";
                else
                {
                    txtPlayer3Item.Text = "Explosive";
                }

            }
            else if (type3 == "Hunger")
            {
                rand3 = Double.Parse(rng.randomInt(3, 8).ToString());

                txtPlayer3Item.Text = "Sponsor Food: Refills " + rand3 + " hunger";
            }
            else if (type3 == "Explosive")
            {
                txtPlayer3Item.Text = "Explosive";
            }
            else
            {
                txtPlayer3Item.Text = "Permanent boost of 2 attack to player's weapon";
            }

            isSponsor = false;
            btnStats.Visible = false;

            int eventChance = rng.randomInt(1, 6);
            if (game.Events == 1) eventChance = rng.randomInt(1, 10);

            if (game.ActivePlayers <= game.Players / 4 && game.HadFeast == false)
            {
                game.IsFeast = true;
            }
            else if (eventChance == 1 && game.Events < 2 && game.Day > 1 && game.ActivePlayers > 2)
            {
                game.IsEvent = true;
            }
            else
            {
                game.IsDay = true;
            }
        }

        private void updateStats()
        {
            if (game.Players == 24) //Screen for 24 players
            {
                //District 1
                lblD1C1Name.Text = su.UpdateName("D1C1", tempCharList, deathCharList); lblD1C2Name.Text = su.UpdateName("D1C2", tempCharList, deathCharList);
                lblD1C1Health.Text = su.UpdateHealth("D1C1", tempCharList, game); lblD1C2Health.Text = su.UpdateHealth("D1C2", tempCharList, game);
                lblD1C1Weapon.Text = su.UpdateWeapon("D1C1", tempCharList, game); lblD1C2Weapon.Text = su.UpdateWeapon("D1C2", tempCharList, game);
                //District 2
                lblD2C1Name.Text = su.UpdateName("D2C1", tempCharList, deathCharList); lblD2C2Name.Text = su.UpdateName("D2C2", tempCharList, deathCharList);
                lblD2C1Health.Text = su.UpdateHealth("D2C1", tempCharList, game); lblD2C2Health.Text = su.UpdateHealth("D2C2", tempCharList, game);
                lblD2C1Weapon.Text = su.UpdateWeapon("D2C1", tempCharList, game); lblD2C2Weapon.Text = su.UpdateWeapon("D2C2", tempCharList, game);
                //District 3
                lblD3C1Name.Text = su.UpdateName("D3C1", tempCharList, deathCharList); lblD3C2Name.Text = su.UpdateName("D3C2", tempCharList, deathCharList);
                lblD3C1Health.Text = su.UpdateHealth("D3C1", tempCharList, game); lblD3C2Health.Text = su.UpdateHealth("D3C2", tempCharList, game);
                lblD3C1Weapon.Text = su.UpdateWeapon("D3C1", tempCharList, game); lblD3C2Weapon.Text = su.UpdateWeapon("D3C2", tempCharList, game);
                //District 4
                lblD4C1Name.Text = su.UpdateName("D4C1", tempCharList, deathCharList); lblD4C2Name.Text = su.UpdateName("D4C2", tempCharList, deathCharList);
                lblD4C1Health.Text = su.UpdateHealth("D4C1", tempCharList, game); lblD4C2Health.Text = su.UpdateHealth("D4C2", tempCharList, game);
                lblD4C1Weapon.Text = su.UpdateWeapon("D4C1", tempCharList, game); lblD4C2Weapon.Text = su.UpdateWeapon("D4C2", tempCharList, game);
                //District 5
                lblD5C1Name.Text = su.UpdateName("D5C1", tempCharList, deathCharList); lblD5C2Name.Text = su.UpdateName("D5C2", tempCharList, deathCharList);
                lblD5C1Health.Text = su.UpdateHealth("D5C1", tempCharList, game); lblD5C2Health.Text = su.UpdateHealth("D5C2", tempCharList, game);
                lblD5C1Weapon.Text = su.UpdateWeapon("D5C1", tempCharList, game); lblD5C2Weapon.Text = su.UpdateWeapon("D5C2", tempCharList, game);
                //District 6
                lblD6C1Name.Text = su.UpdateName("D6C1", tempCharList, deathCharList); lblD6C2Name.Text = su.UpdateName("D6C2", tempCharList, deathCharList);
                lblD6C1Health.Text = su.UpdateHealth("D6C1", tempCharList, game); lblD6C2Health.Text = su.UpdateHealth("D6C2", tempCharList, game);
                lblD6C1Weapon.Text = su.UpdateWeapon("D6C1", tempCharList, game); lblD6C2Weapon.Text = su.UpdateWeapon("D6C2", tempCharList, game);
                //District 7
                lblD7C1Name.Text = su.UpdateName("D7C1", tempCharList, deathCharList); lblD7C2Name.Text = su.UpdateName("D7C2", tempCharList, deathCharList);
                lblD7C1Health.Text = su.UpdateHealth("D7C1", tempCharList, game); lblD7C2Health.Text = su.UpdateHealth("D7C2", tempCharList, game);
                lblD7C1Weapon.Text = su.UpdateWeapon("D7C1", tempCharList, game); lblD7C2Weapon.Text = su.UpdateWeapon("D7C2", tempCharList, game);
                //District 8
                lblD8C1Name.Text = su.UpdateName("D8C1", tempCharList, deathCharList); lblD8C2Name.Text = su.UpdateName("D8C2", tempCharList, deathCharList);
                lblD8C1Health.Text = su.UpdateHealth("D8C1", tempCharList, game); lblD8C2Health.Text = su.UpdateHealth("D8C2", tempCharList, game);
                lblD8C1Weapon.Text = su.UpdateWeapon("D8C1", tempCharList, game); lblD8C2Weapon.Text = su.UpdateWeapon("D8C2", tempCharList, game);
                //District 9
                lblD9C1Name.Text = su.UpdateName("D9C1", tempCharList, deathCharList); lblD9C2Name.Text = su.UpdateName("D9C2", tempCharList, deathCharList);
                lblD9C1Health.Text = su.UpdateHealth("D9C1", tempCharList, game); lblD9C2Health.Text = su.UpdateHealth("D9C2", tempCharList, game);
                lblD9C1Weapon.Text = su.UpdateWeapon("D9C1", tempCharList, game); lblD9C2Weapon.Text = su.UpdateWeapon("D9C2", tempCharList, game);
                //District 10
                lblD10C1Name.Text = su.UpdateName("D10C1", tempCharList, deathCharList); lblD10C2Name.Text = su.UpdateName("D10C2", tempCharList, deathCharList);
                lblD10C1Health.Text = su.UpdateHealth("D10C1", tempCharList, game); lblD10C2Health.Text = su.UpdateHealth("D10C2", tempCharList, game);
                lblD10C1Weapon.Text = su.UpdateWeapon("D10C1", tempCharList, game); lblD10C2Weapon.Text = su.UpdateWeapon("D10C2", tempCharList, game);
                //District 11
                lblD11C1Name.Text = su.UpdateName("D11C1", tempCharList, deathCharList); lblD11C2Name.Text = su.UpdateName("D11C2", tempCharList, deathCharList);
                lblD11C1Health.Text = su.UpdateHealth("D11C1", tempCharList, game); lblD11C2Health.Text = su.UpdateHealth("D11C2", tempCharList, game);
                lblD11C1Weapon.Text = su.UpdateWeapon("D11C1", tempCharList, game); lblD11C2Weapon.Text = su.UpdateWeapon("D11C2", tempCharList, game);
                //District 12
                lblD12C1Name.Text = su.UpdateName("D12C1", tempCharList, deathCharList); lblD12C2Name.Text = su.UpdateName("D12C2", tempCharList, deathCharList);
                lblD12C1Health.Text = su.UpdateHealth("D12C1", tempCharList, game); lblD12C2Health.Text = su.UpdateHealth("D12C2", tempCharList, game);
                lblD12C1Weapon.Text = su.UpdateWeapon("D12C1", tempCharList, game); lblD12C2Weapon.Text = su.UpdateWeapon("D12C2", tempCharList, game);
            }
            else //Screen for 48 players
            {
                //District 1
                lblNameD1C1.Text = su.UpdateName("D1C1", tempCharList, deathCharList); lblNameD1C2.Text = su.UpdateName("D1C2", tempCharList, deathCharList);
                lblNameD1C3.Text = su.UpdateName("D1C3", tempCharList, deathCharList); lblNameD1C4.Text = su.UpdateName("D1C4", tempCharList, deathCharList);
                lblHealthD1C1.Text = su.UpdateHealth("D1C1", tempCharList, game); lblHealthD1C2.Text = su.UpdateHealth("D1C2", tempCharList, game);
                lblHealthD1C3.Text = su.UpdateHealth("D1C3", tempCharList, game); lblHealthD1C4.Text = su.UpdateHealth("D1C4", tempCharList, game);
                lblWeaponD1C1.Text = su.UpdateWeapon("D1C1", tempCharList, game); lblWeaponD1C2.Text = su.UpdateWeapon("D1C2", tempCharList, game);
                lblWeaponD1C3.Text = su.UpdateWeapon("D1C3", tempCharList, game); lblWeaponD1C4.Text = su.UpdateWeapon("D1C4", tempCharList, game);
                //District 2
                lblNameD2C1.Text = su.UpdateName("D2C1", tempCharList, deathCharList); lblNameD2C2.Text = su.UpdateName("D2C2", tempCharList, deathCharList);
                lblNameD2C3.Text = su.UpdateName("D2C3", tempCharList, deathCharList); lblNameD2C4.Text = su.UpdateName("D2C4", tempCharList, deathCharList);
                lblHealthD2C1.Text = su.UpdateHealth("D2C1", tempCharList, game); lblHealthD2C2.Text = su.UpdateHealth("D2C2", tempCharList, game);
                lblHealthD2C3.Text = su.UpdateHealth("D2C3", tempCharList, game); lblHealthD2C4.Text = su.UpdateHealth("D2C4", tempCharList, game);
                lblWeaponD2C1.Text = su.UpdateWeapon("D2C1", tempCharList, game); lblWeaponD2C2.Text = su.UpdateWeapon("D2C2", tempCharList, game);
                lblWeaponD2C3.Text = su.UpdateWeapon("D2C3", tempCharList, game); lblWeaponD2C4.Text = su.UpdateWeapon("D2C4", tempCharList, game);
                //District 3
                lblNameD3C1.Text = su.UpdateName("D3C1", tempCharList, deathCharList); lblNameD3C2.Text = su.UpdateName("D3C2", tempCharList, deathCharList);
                lblNameD3C3.Text = su.UpdateName("D3C3", tempCharList, deathCharList); lblNameD3C4.Text = su.UpdateName("D3C4", tempCharList, deathCharList);
                lblHealthD3C1.Text = su.UpdateHealth("D3C1", tempCharList, game); lblHealthD3C2.Text = su.UpdateHealth("D3C2", tempCharList, game);
                lblHealthD3C3.Text = su.UpdateHealth("D3C3", tempCharList, game); lblHealthD3C4.Text = su.UpdateHealth("D3C4", tempCharList, game);
                lblWeaponD3C1.Text = su.UpdateWeapon("D3C1", tempCharList, game); lblWeaponD3C2.Text = su.UpdateWeapon("D3C2", tempCharList, game);
                lblWeaponD3C3.Text = su.UpdateWeapon("D3C3", tempCharList, game); lblWeaponD3C4.Text = su.UpdateWeapon("D3C4", tempCharList, game);
                //District 4
                lblNameD4C1.Text = su.UpdateName("D4C1", tempCharList, deathCharList); lblNameD4C2.Text = su.UpdateName("D4C2", tempCharList, deathCharList);
                lblNameD4C3.Text = su.UpdateName("D4C3", tempCharList, deathCharList); lblNameD4C4.Text = su.UpdateName("D4C4", tempCharList, deathCharList);
                lblHealthD4C1.Text = su.UpdateHealth("D4C1", tempCharList, game); lblHealthD4C2.Text = su.UpdateHealth("D4C2", tempCharList, game);
                lblHealthD4C3.Text = su.UpdateHealth("D4C3", tempCharList, game); lblHealthD4C4.Text = su.UpdateHealth("D4C4", tempCharList, game);
                lblWeaponD4C1.Text = su.UpdateWeapon("D4C1", tempCharList, game); lblWeaponD4C2.Text = su.UpdateWeapon("D4C2", tempCharList, game);
                lblWeaponD4C3.Text = su.UpdateWeapon("D4C3", tempCharList, game); lblWeaponD4C4.Text = su.UpdateWeapon("D4C4", tempCharList, game);
                //District 5
                lblNameD5C1.Text = su.UpdateName("D5C1", tempCharList, deathCharList); lblNameD5C2.Text = su.UpdateName("D5C2", tempCharList, deathCharList);
                lblNameD5C3.Text = su.UpdateName("D5C3", tempCharList, deathCharList); lblNameD5C4.Text = su.UpdateName("D5C4", tempCharList, deathCharList);
                lblHealthD5C1.Text = su.UpdateHealth("D5C1", tempCharList, game); lblHealthD5C2.Text = su.UpdateHealth("D5C2", tempCharList, game);
                lblHealthD5C3.Text = su.UpdateHealth("D5C3", tempCharList, game); lblHealthD5C4.Text = su.UpdateHealth("D5C4", tempCharList, game);
                lblWeaponD5C1.Text = su.UpdateWeapon("D5C1", tempCharList, game); lblWeaponD5C2.Text = su.UpdateWeapon("D5C2", tempCharList, game);
                lblWeaponD5C3.Text = su.UpdateWeapon("D5C3", tempCharList, game); lblWeaponD5C4.Text = su.UpdateWeapon("D5C4", tempCharList, game);
                //District 6
                lblNameD6C1.Text = su.UpdateName("D6C1", tempCharList, deathCharList); lblNameD6C2.Text = su.UpdateName("D6C2", tempCharList, deathCharList);
                lblNameD6C3.Text = su.UpdateName("D6C3", tempCharList, deathCharList); lblNameD6C4.Text = su.UpdateName("D6C4", tempCharList, deathCharList);
                lblHealthD6C1.Text = su.UpdateHealth("D6C1", tempCharList, game); lblHealthD6C2.Text = su.UpdateHealth("D6C2", tempCharList, game);
                lblHealthD6C3.Text = su.UpdateHealth("D6C3", tempCharList, game); lblHealthD6C4.Text = su.UpdateHealth("D6C4", tempCharList, game);
                lblWeaponD6C1.Text = su.UpdateWeapon("D6C1", tempCharList, game); lblWeaponD6C2.Text = su.UpdateWeapon("D6C2", tempCharList, game);
                lblWeaponD6C3.Text = su.UpdateWeapon("D6C3", tempCharList, game); lblWeaponD6C4.Text = su.UpdateWeapon("D6C4", tempCharList, game);
                //District 7
                lblNameD7C1.Text = su.UpdateName("D7C1", tempCharList, deathCharList); lblNameD7C2.Text = su.UpdateName("D7C2", tempCharList, deathCharList);
                lblNameD7C3.Text = su.UpdateName("D7C3", tempCharList, deathCharList); lblNameD7C4.Text = su.UpdateName("D7C4", tempCharList, deathCharList);
                lblHealthD7C1.Text = su.UpdateHealth("D7C1", tempCharList, game); lblHealthD7C2.Text = su.UpdateHealth("D7C2", tempCharList, game);
                lblHealthD7C3.Text = su.UpdateHealth("D7C3", tempCharList, game); lblHealthD7C4.Text = su.UpdateHealth("D7C4", tempCharList, game);
                lblWeaponD7C1.Text = su.UpdateWeapon("D7C1", tempCharList, game); lblWeaponD7C2.Text = su.UpdateWeapon("D7C2", tempCharList, game);
                lblWeaponD7C3.Text = su.UpdateWeapon("D7C3", tempCharList, game); lblWeaponD7C4.Text = su.UpdateWeapon("D7C4", tempCharList, game);
                //District 8
                lblNameD8C1.Text = su.UpdateName("D8C1", tempCharList, deathCharList); lblNameD8C2.Text = su.UpdateName("D8C2", tempCharList, deathCharList);
                lblNameD8C3.Text = su.UpdateName("D8C3", tempCharList, deathCharList); lblNameD8C4.Text = su.UpdateName("D8C4", tempCharList, deathCharList);
                lblHealthD8C1.Text = su.UpdateHealth("D8C1", tempCharList, game); lblHealthD8C2.Text = su.UpdateHealth("D8C2", tempCharList, game);
                lblHealthD8C3.Text = su.UpdateHealth("D8C3", tempCharList, game); lblHealthD8C4.Text = su.UpdateHealth("D8C4", tempCharList, game);
                lblWeaponD8C1.Text = su.UpdateWeapon("D8C1", tempCharList, game); lblWeaponD8C2.Text = su.UpdateWeapon("D8C2", tempCharList, game);
                lblWeaponD8C3.Text = su.UpdateWeapon("D8C3", tempCharList, game); lblWeaponD8C4.Text = su.UpdateWeapon("D8C4", tempCharList, game);
                //District 9
                lblNameD9C1.Text = su.UpdateName("D9C1", tempCharList, deathCharList); lblNameD9C2.Text = su.UpdateName("D9C2", tempCharList, deathCharList);
                lblNameD9C3.Text = su.UpdateName("D9C3", tempCharList, deathCharList); lblNameD9C4.Text = su.UpdateName("D9C4", tempCharList, deathCharList);
                lblHealthD9C1.Text = su.UpdateHealth("D9C1", tempCharList, game); lblHealthD9C2.Text = su.UpdateHealth("D9C2", tempCharList, game);
                lblHealthD9C3.Text = su.UpdateHealth("D9C3", tempCharList, game); lblHealthD9C4.Text = su.UpdateHealth("D9C4", tempCharList, game);
                lblWeaponD9C1.Text = su.UpdateWeapon("D9C1", tempCharList, game); lblWeaponD9C2.Text = su.UpdateWeapon("D9C2", tempCharList, game);
                lblWeaponD9C3.Text = su.UpdateWeapon("D9C3", tempCharList, game); lblWeaponD9C4.Text = su.UpdateWeapon("D9C4", tempCharList, game);
                //District 10
                lblNameD10C1.Text = su.UpdateName("D10C1", tempCharList, deathCharList); lblNameD10C2.Text = su.UpdateName("D10C2", tempCharList, deathCharList);
                lblNameD10C3.Text = su.UpdateName("D10C3", tempCharList, deathCharList); lblNameD10C4.Text = su.UpdateName("D10C4", tempCharList, deathCharList);
                lblHealthD10C1.Text = su.UpdateHealth("D10C1", tempCharList, game); lblHealthD10C2.Text = su.UpdateHealth("D10C2", tempCharList, game);
                lblHealthD10C3.Text = su.UpdateHealth("D10C3", tempCharList, game); lblHealthD10C4.Text = su.UpdateHealth("D10C4", tempCharList, game);
                lblWeaponD10C1.Text = su.UpdateWeapon("D10C1", tempCharList, game); lblWeaponD10C2.Text = su.UpdateWeapon("D10C2", tempCharList, game);
                lblWeaponD10C3.Text = su.UpdateWeapon("D10C3", tempCharList, game); lblWeaponD10C4.Text = su.UpdateWeapon("D10C4", tempCharList, game);
                //District 11
                lblNameD11C1.Text = su.UpdateName("D11C1", tempCharList, deathCharList); lblNameD11C2.Text = su.UpdateName("D11C2", tempCharList, deathCharList);
                lblNameD11C3.Text = su.UpdateName("D11C3", tempCharList, deathCharList); lblNameD11C4.Text = su.UpdateName("D11C4", tempCharList, deathCharList);
                lblHealthD11C1.Text = su.UpdateHealth("D11C1", tempCharList, game); lblHealthD11C2.Text = su.UpdateHealth("D11C2", tempCharList, game);
                lblHealthD11C3.Text = su.UpdateHealth("D11C3", tempCharList, game); lblHealthD11C4.Text = su.UpdateHealth("D11C4", tempCharList, game);
                lblWeaponD11C1.Text = su.UpdateWeapon("D11C1", tempCharList, game); lblWeaponD11C2.Text = su.UpdateWeapon("D11C2", tempCharList, game);
                lblWeaponD11C3.Text = su.UpdateWeapon("D11C3", tempCharList, game); lblWeaponD11C4.Text = su.UpdateWeapon("D11C4", tempCharList, game);
                //District 12
                lblNameD12C1.Text = su.UpdateName("D12C1", tempCharList, deathCharList); lblNameD12C2.Text = su.UpdateName("D12C2", tempCharList, deathCharList);
                lblNameD12C3.Text = su.UpdateName("D12C3", tempCharList, deathCharList); lblNameD12C4.Text = su.UpdateName("D12C4", tempCharList, deathCharList);
                lblHealthD12C1.Text = su.UpdateHealth("D12C1", tempCharList, game); lblHealthD12C2.Text = su.UpdateHealth("D12C2", tempCharList, game);
                lblHealthD12C3.Text = su.UpdateHealth("D12C3", tempCharList, game); lblHealthD12C4.Text = su.UpdateHealth("D12C4", tempCharList, game);
                lblWeaponD12C1.Text = su.UpdateWeapon("D12C1", tempCharList, game); lblWeaponD12C2.Text = su.UpdateWeapon("D12C2", tempCharList, game);
                lblWeaponD12C3.Text = su.UpdateWeapon("D12C3", tempCharList, game); lblWeaponD12C4.Text = su.UpdateWeapon("D12C4", tempCharList, game);

            }

        }

        private void btnMainContinue_Click(object sender, EventArgs e)
        {
            rtbText.Clear();
            if (game.IsDay == true)
            {
                btnStats.Visible = false;
                this.dayEvents();
            }
            else if (game.IsDeath == true) this.deathsScreen();
            else if (isSponsor == true) this.sponsorScreen();
            else if (game.IsFeast == true && game.HadFeast == false)
            {
                btnStats.Visible = false;
                this.doFeast();
            }
            else if (game.IsEvent == true)
            {
                btnStats.Visible = false;
                this.doArenaEvent();
            }
            else if (game.IsActive == false)
            {
                this.winnerScreen();
                pnlMain.Hide();
                pnlWinner.Show();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Start start = new Start();

            this.Hide();
            start.Show();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            pnlMain.Hide();
            this.updateStats();
            if (game.Players == 24)
            {
                pnl24.Show();
            }
            else
            {
                pnlStats48.Show();
            }
        }

        private void btnStatBack_Click(object sender, EventArgs e)
        {
            pnl24.Hide();
            pnlMain.Show();
        }

        private void btnBack48_Click(object sender, EventArgs e)
        {
            pnlStats48.Hide();
            pnlMain.Show();
        }
        private void btnSponsorContinue_Click(object sender, EventArgs e)
        {
            if (rboPlayer1Sponsor.Checked == true || rboPlayer2Sponsor.Checked == true || rboPlayer3Sponsor.Checked == true) //If no player is selected, nobody will be sponsored
            {
                //If Player 1 is sponsored
                if (rboPlayer1Sponsor.Checked == true)
                {
                    if (type1 == "Healing")
                    {
                        tempCharList[intList[0]].heal(rand1);
                    }
                    else if (type1 == "Any Weapon")
                    {
                        if (lootArray1[1] != "explosive")
                        {
                            tempCharList[intList[0]].setWeaponName(lootArray1[0]);
                            tempCharList[intList[0]].setWeaponAttack(Double.Parse(lootArray1[2]));
                            tempCharList[intList[0]].setWeaponType(lootArray1[1]);
                        }
                        else
                        {
                            tempCharList[intList[0]].HasExplosive = true;
                        }
                    }
                    else if (type1 == "Hunger")
                    {
                        tempCharList[intList[0]].Hunger += rand1;
                    }
                    else if (type1 == "Explosive")
                    {
                        tempCharList[intList[0]].HasExplosive = true;
                    }
                    else
                    {
                        tempCharList[intList[0]].setWeaponAttack(tempCharList[intList[0]].getWeaponAttack() + 2);
                    }
                }

                //If Player 2 is sponsored
                if (rboPlayer2Sponsor.Checked == true)
                {
                    if (type2 == "Healing")
                    {
                        tempCharList[intList[1]].heal(rand2);
                    }
                    else if (type2 == "Any Weapon")
                    {
                        if (lootArray2[1] != "explosive")
                        {
                            tempCharList[intList[1]].setWeaponName(lootArray2[0]);
                            tempCharList[intList[1]].setWeaponAttack(Double.Parse(lootArray2[2]));
                            tempCharList[intList[1]].setWeaponType(lootArray2[1]);
                        }
                        else
                        {
                            tempCharList[intList[1]].HasExplosive = true;
                        }
                    }
                    else if (type2 == "Hunger")
                    {
                        tempCharList[intList[1]].Hunger += rand2;
                    }
                    else if (type2 == "Explosive")
                    {
                        tempCharList[intList[1]].HasExplosive = true;
                    }
                    else
                    {
                        tempCharList[intList[1]].setWeaponAttack(tempCharList[intList[1]].getWeaponAttack() + 2);
                    }
                }

                //If Player 3 is sponsored
                if (rboPlayer3Sponsor.Checked == true)
                {
                    if (type3 == "Healing")
                    {
                        tempCharList[intList[2]].heal(rand3);
                    }
                    else if (type3 == "Any Weapon")
                    {
                        if (lootArray3[1] != "explosive")
                        {
                            tempCharList[intList[2]].setWeaponName(lootArray3[0]);
                            tempCharList[intList[2]].setWeaponAttack(Double.Parse(lootArray3[2]));
                            tempCharList[intList[2]].setWeaponType(lootArray3[1]);
                        }
                        else
                        {
                            tempCharList[intList[2]].HasExplosive = true;
                        }
                    }
                    else if (type3 == "Hunger")
                    {
                        tempCharList[intList[2]].Hunger += rand3;
                    }
                    else if (type3 == "Explosive")
                    {
                        tempCharList[intList[2]].HasExplosive = true;
                    }
                    else
                    {
                        tempCharList[intList[2]].setWeaponAttack(tempCharList[intList[2]].getWeaponAttack() + 2);
                    }
                }
            }

            pnlSponsor.Hide();
            if (game.IsDay == true)
            {
                this.dayEvents();
            }
            else if (game.IsFeast == true && game.HadFeast == false)
            {
                btnStats.Visible = false;
                this.doFeast();
            }
            else if (game.IsEvent == true)
            {
                btnStats.Visible = false;
                this.doArenaEvent();
            }
            pnlMain.Show();
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            rboPlayer1Sponsor.Checked = false;
            rboPlayer2Sponsor.Checked = false;
            rboPlayer3Sponsor.Checked = false;
        }
    }
}
