using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carnage
{

    /// <summary>
    /// This form runs and manages the entire simulation with
    /// support from almost every single class. It iterates through different
    /// character lists to ensure they each have a turn for Bloodbath, Days,
    /// Arena Events, and the Feast. It also keeps track of whether each
    /// character is alive and records them as dead to be displayed on a
    /// deaths screen after every day. It also keeps track of characters'
    /// stats and updates the stats screen that can be viewed after each
    /// Day ends. It allows the user to sponsor one of three random players at the
    /// end of each Day as well by randomly selecting something they each need and
    /// applying it to them if selected. Finally, it goes to the winner's screen
    /// and displays stats about the simulation upon its completion.
    /// </summary>
    public partial class Simulation : Form
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

        /// <summary>
        /// Upon initializaion, the game options and list are imported and
        /// a duplicate list is filled so that the original one stays intact.
        /// The unassigned players value is calculated at the start and then
        /// the simulation begins with the Bloodbath.
        /// </summary>
        public Simulation(List<character> charList, Game game)
        {
            InitializeComponent();
            this.charList = charList;

            for (int i = 0; i < charList.Count; i++)
            {
                tempCharList.Add(charList[i]);
            }

            this.game = game;
            game.ActivePlayers = game.Players;
            unassignedPlayers = game.Players; //Unassigned players variable keeps track of how many players have not been selected for an event to ensure the index doesn't go out of range

            this.bloodbath();
        }

        /// <summary>
        /// Calls an instance of the Bloodbath and fills the rich text box with
        /// the list of events, then records the deaths resulting from it and
        /// removes them from the list
        /// </summary>
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

            game.IsDeath = true; //Goes to death screen next
            game.IsDay = false;
        }

        /// <summary>
        /// Calls an instance of a Day and fills the rich text box with
        /// the list of events, then records the deaths resulting from it and
        /// removes them from the list
        /// </summary>
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
                game.Day++; //Number of days incremented by 1
            }
            if (tempCharList.Count == 1) // If only 1 player remains after this Day, the game state is set to being finished
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

        /// <summary>
        /// Calls an instance of the Feast and fills the rich text box with
        /// the list of events, then records the deaths resulting from it and
        /// removes them from the list
        /// </summary>
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

            if (tempCharList.Count == 1) //If only 1 player remains after the Feast, the game state is set to being finished (this is highly unlikely by this point in the simulation)
            {
                game.IsActive = false;
                game.IsDeath = false;
                game.IsDay = false;
            }
            else
            {
                game.IsDeath = true;
                game.IsDay = false;
                game.HadFeast = true; //Ensures The Feast cannot happen again
            }
        }

        /// <summary>
        /// Calls an instance of an Arena Event and fills the rich text box with
        /// the list of events, then records the deaths resulting from it and
        /// removes them from the list
        /// </summary>
        private void doArenaEvent()
        {
            game.Events++; //Number of events increases by 1 (only 2 can occur at most)
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

            if (tempCharList.Count == 1) //If only 1 player remains after the Feast, the game state is set to being finished
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

        /// <summary>
        /// Deals with the displayed text on the Deaths screen. Each character who died during a specific set of events is
        /// listed in order, and then any variables relating to deaths are reset and the number of active players is modified.
        /// If there are at least 3 players left, and sponsoring is enabled, the sponsor screen will be allowed next; otherwise
        /// the simulation proceeds to the next Day.
        /// </summary>
        private void deathsScreen()
        {
            btnStats.Visible = true; //On this screen users may view player stats

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
            else //If there are more than 3 players left, or if sponsoring is disabled, the next set of events is determined here
            {
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
        }


        /// <summary>
        /// Deals with the displayed text on the Winner screen. The winner's name is displayed, and
        /// three separate lists of stats are displayed about the game as a whole. The user
        /// is given the option to return to the main menu.
        /// </summary>
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

            rtbPlaces.AppendText(su.Places(deathCharList, tempCharList[0], game)); //Displays the order in which every character finished
            rtbKills.AppendText(su.Kills(deathCharList, tempCharList[0], game)); //Displays a list of characters sorted by number of kills
            rtbGeneralStats.AppendText(su.GeneralStats(deathCharList, tempCharList[0], game)); //Displayes general stats about the game

        }

        /// <summary>
        /// Randomly selects three active players and determines an item they need most. The character's name,
        /// health, and hunger (if realistic mode) are displayed next to a corresponding radio button, and
        /// the item that is generated is displayed to the right. If the user selects one of these characters,
        /// the item is applied to them upon continuing. They may skip by not selecting any option or disable
        /// this feature on the main menu.
        /// </summary>
        private void sponsorScreen()
        {
            pnlMain.Hide();
            pnlSponsor.Show();

            intList.Clear();

            intList = rng.RandomIntList(tempCharList.Count, 3); //3 random characters selected

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

            //Item types determined
            type1 = loot.SponsorItemType(tempCharList[intList[0]], game); 
            type2 = loot.SponsorItemType(tempCharList[intList[1]], game);
            type3 = loot.SponsorItemType(tempCharList[intList[2]], game);

            //Decides item for Player 1
            if (type1 == "Healing") //If type is healing, character will be healed a random amount from 3 to 8
            {
                rand1 = Double.Parse(rng.randomInt(3, 8).ToString());

                txtPlayer1Item.Text = "Sponsor Medkit: Heals " + rand1 + " health";
            }
            else if (type1 == "Any Weapon") //If type is weapon, character will receive loot of a random rarity, skewed toward common
            {
                int randomRarity = rng.randomInt(1, 10);

                if (randomRarity == 1) lootArray1 = loot.getLoot("Rare", "Weapon");
                else if (randomRarity == 2 || randomRarity == 3) lootArray1 = loot.getLoot("Uncommon", "Weapon");
                else lootArray1 = loot.getLoot("Common", "Weapon");

                if (lootArray1[1] != "explosive") txtPlayer1Item.Text = "Weapon: " + lootArray1[0] + ", " + Double.Parse(lootArray1[2]) + " damage"; //If type is not explosive, weapon info displayed
                else //If type is explosive, no specific info is displayed
                {
                    txtPlayer1Item.Text = "Explosive";
                }
            }
            else if (type1 == "Hunger") //If type is hunger, character will be fed a random amount from 3 to 8
            {
                rand1 = Double.Parse(rng.randomInt(3, 8).ToString());

                txtPlayer1Item.Text = "Sponsor Food: Refills " + rand1 + " hunger";
            }
            else if (type1 == "Explosive") //If type is explosive, character will gain an explosive
            {
                txtPlayer1Item.Text = "Explosive";
            }
            else //If it's decided character doesn't need any of the above, they will get a weapon attack increase of 2 damage
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

            //The next set of events is determined here
            int eventChance = rng.randomInt(1, 6);
            if (game.Events == 1) eventChance = rng.randomInt(1, 10);

            if (game.ActivePlayers <= game.Players / 4 && game.HadFeast == false) //Feast will happen when a quarter (or less) of the original players remain
            {
                game.IsFeast = true;
            }
            else if (eventChance == 1 && game.Events < 2 && game.Day > 1 && game.ActivePlayers > 2) //Arena Event will happen 1 in 6 times assuming there are more than 2 alive characters, it isn't day 1, and there haven't been 2 Events already
            {
                game.IsEvent = true;
            }
            else
            {
                game.IsDay = true;
            }
        }

        /// <summary>
        /// Takes the current values of every character's stats and updates the character stats panel
        /// with the correct values. These are different depending on the gamemode.
        /// </summary>
        private void updateStats()
        {
            if (game.Players == 24) //Screen for 24 players
            {
                //All 24 character's stats are updated

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
                //All 48 character's stats are updated

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

        /// <summary>
        /// When the continue button is pressed, the rich text box is cleared and the pre-determined
        /// set of events that is supposed to take place next is generated by calling
        /// the appropriate local method.
        /// </summary>
        private void btnMainContinue_Click(object sender, EventArgs e)
        {
            rtbText.Clear();
            if (game.IsDay == true) //A Day will happen
            {
                btnStats.Visible = false;
                this.dayEvents();
            }
            else if (game.IsDeath == true) this.deathsScreen(); //The deaths screen will appear
            else if (isSponsor == true) this.sponsorScreen(); //The sponsor screen will appear
            else if (game.IsFeast == true && game.HadFeast == false) //The Feast will happen if it hasn't already
            {
                btnStats.Visible = false;
                this.doFeast();
            }
            else if (game.IsEvent == true) //An Arena Event will happen
            {
                btnStats.Visible = false;
                this.doArenaEvent();
            }
            else if (game.IsActive == false) //The game is over, the winner's screen will appear
            {
                this.winnerScreen();
                pnlMain.Hide();
                pnlWinner.Show();
            }
        }

        /// <summary>
        /// When the back button is pressed, the user is taken back to the main menu
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Start start = new Start();

            this.Hide();
            start.Show();
        }

        /// <summary>
        /// When the stats button is pressed, the stats panel corresponding to the number of
        /// original players is shown
        /// </summary>
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

        /// <summary>
        /// When this button on the 24 characters stats panel is pressed, the user returns to the main panel
        /// </summary>
        private void btnStatBack_Click(object sender, EventArgs e)
        {
            pnl24.Hide();
            pnlMain.Show();
        }

        /// <summary>
        /// When this button on the 48 characters stats panel is pressed, the user returns to the main panel
        /// </summary>
        private void btnBack48_Click(object sender, EventArgs e)
        {
            pnlStats48.Hide();
            pnlMain.Show();
        }

        /// <summary>
        /// When the continue button is pressed on the sponsor panel, the user's choice is recorded and the item
        /// corresponding with that choice is applied to the given character. If no radio button is selected,
        /// no character is sponsored.
        /// </summary>
        private void btnSponsorContinue_Click(object sender, EventArgs e)
        {
            if (rboPlayer1Sponsor.Checked == true || rboPlayer2Sponsor.Checked == true || rboPlayer3Sponsor.Checked == true) //If no player is selected, nobody will be sponsored
            {
                //If Player 1 is sponsored
                if (rboPlayer1Sponsor.Checked == true)
                {
                    if (type1 == "Healing") //Heals character
                    {
                        tempCharList[intList[0]].heal(rand1);
                    }
                    else if (type1 == "Any Weapon") //Gives character weapon/explosive
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
                    else if (type1 == "Hunger") //Feeds character
                    {
                        tempCharList[intList[0]].Hunger += rand1;
                    }
                    else if (type1 == "Explosive") //Gives character explosive
                    {
                        tempCharList[intList[0]].HasExplosive = true;
                    }
                    else //Boosts character's weapon attack by 2
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

            //Proceeds with the pre-determined next set of events
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

        /// <summary>
        /// When the deselect button is pressed on the sponsor screen, the radio buttons are deselected (in case one of them is accidentally selected and user wishes to skip)
        /// </summary>
        private void btnDeselect_Click(object sender, EventArgs e)
        {
            rboPlayer1Sponsor.Checked = false;
            rboPlayer2Sponsor.Checked = false;
            rboPlayer3Sponsor.Checked = false;
        }
    }
}
