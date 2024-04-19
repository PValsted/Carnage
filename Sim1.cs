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
        List<character> deathCharList = new();
        List<character> tempDeathCharList = new();
        RNG rng = new();
        EventImporter ei = new();
        Battle battle = new();
        Bloodbath bb = new();
        Feast feast = new();
        Exploration explore = new();
        ArenaEvent ae = new();
        int playerCount = 1, i = 0, unassignedPlayers, deathCount = 0;
        string eventType = string.Empty;
        Game game;


        public Sim1(List<character> charList, Game game)
        {
            InitializeComponent();
            this.charList = charList;
            tempCharList = charList;

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
                    deathCount++;
                }
            }

            tempDeathCharList = deathCharList;

            for (int j = 0; j < tempDeathCharList.Count; j++)
            {
                tempCharList.Remove(tempDeathCharList.ElementAt(j));
            }

            game.IsDeath = true;
            game.IsDay = false;
        }

        private void dayEvents()
        {
            unassignedPlayers = tempCharList.Count;

            if (game.ActivePlayers > 1)
            {
                rtbText.AppendText("Day " + game.Day + " begins.\n\n");
                rng.shuffleList(tempCharList);
                i = 0;

                while (i < tempCharList.Count)
                {
                    eventType = rng.randomEventType(game);


                    if (eventType == "Regular")
                    {
                        rtbText.AppendText(ei.regularEvent(tempCharList.ElementAt(i)) + "\n" + "\n");
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Gain")
                    {
                        rtbText.AppendText(ei.gainEvent(tempCharList.ElementAt(i)) + "\n");
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Explore")
                    {
                        rtbText.AppendText(explore.explorationEvent(tempCharList.ElementAt(i), game) + "\n");
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Battle")
                    {
                        playerCount = rng.randomPlayerCount();
                        battle.setNumPlayers(playerCount);

                        if (unassignedPlayers >= 4 && playerCount == 4)
                        {
                            rtbText.AppendText(battle.BattleEvent(tempCharList.ElementAt(i), tempCharList.ElementAt(i + 1), tempCharList.ElementAt(i + 2), tempCharList.ElementAt(i + 3), game) + "\n");

                            i += playerCount;
                            unassignedPlayers -= 4;
                        }
                        else if (unassignedPlayers >= 3 && playerCount == 3)
                        {
                            rtbText.AppendText(battle.BattleEvent(tempCharList.ElementAt(i), tempCharList.ElementAt(i + 1), tempCharList.ElementAt(i + 2), tempCharList.ElementAt(i + 2), game) + "\n");

                            i += playerCount;
                            unassignedPlayers -= 3;
                        }
                        else if (unassignedPlayers >= 2 && playerCount == 2)
                        {
                            rtbText.AppendText(battle.BattleEvent(tempCharList.ElementAt(i), tempCharList.ElementAt(i + 1), tempCharList.ElementAt(i + 1), tempCharList.ElementAt(i + 1), game) + "\n");

                            i += playerCount;
                            unassignedPlayers -= 2;
                        }
                    }
                }

                for (int j = 0; j < tempCharList.Count; j++)
                {
                    if (tempCharList.ElementAt(j).IsAlive == false)
                    {
                        deathCharList.Add(tempCharList.ElementAt(j));
                        deathCount++;
                    }
                }

                tempDeathCharList = deathCharList;

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
                    deathCount++;
                }
            }

            tempDeathCharList = deathCharList;

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
                    deathCount++;
                }
            }

            tempDeathCharList = deathCharList;

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
            if (deathCount > 1) rtbText.AppendText("As night falls, " + deathCount + " cannon shots are fired. The following tributes have perished, and their names and images are displayed in the sky:\n\n");
            else if (deathCount == 1) rtbText.AppendText("As night falls, " + deathCount + " cannon shot is fired. The following tribute has perished, and their name and image is displayed in the sky:\n\n");
            else rtbText.AppendText("As night falls, no cannon shots are fired. The tributes are thankful for a peaceful day.\n");
            while (tempDeathCharList.Count > 0)
            {
                if (tempDeathCharList.ElementAt(0).Kills == 1)
                {
                    rtbText.AppendText(tempDeathCharList.ElementAt(0).getName() + " from District " + tempDeathCharList[0].District + ": " + tempDeathCharList.ElementAt(0).Kills + " kill\n");
                }
                else if (tempDeathCharList.ElementAt(0).Kills > 1)
                {
                    rtbText.AppendText(tempDeathCharList.ElementAt(0).getName() + " from District " + tempDeathCharList[0].District + ": " + tempDeathCharList.ElementAt(0).Kills + " kills\n");
                }
                else
                {
                    rtbText.AppendText(tempDeathCharList.ElementAt(0).getName() + " from District " + tempDeathCharList[0].District + "\n");
                }
                tempDeathCharList.Remove(tempDeathCharList.ElementAt(0));

            }
            rtbText.AppendText("\n");
            game.ActivePlayers -= deathCount;
            rtbText.AppendText(game.ActivePlayers + " remain.\n");
            deathCount = 0;

            int eventChance = rng.randomInt(1, 6);
            if (game.Events == 1) eventChance = rng.randomInt(1, 10);

            if (game.ActivePlayers <= game.Players / 4 && game.HadFeast == false)
            {
                game.IsDeath = false;
                game.IsFeast = true;
            }
            else if (eventChance == 1 && game.Events < 2 && game.Day > 1 && game.ActivePlayers > 2)
            {
                game.IsDeath = false;
                game.IsEvent = true;
            }
            else
            {
                game.IsDeath = false;
                game.IsDay = true;
            }
        }

        private void winnerScreen()
        {
            if (tempCharList[0].Kills == 1)
            {
                rtbText.AppendText(tempCharList[0].getName() + " from District " + tempCharList[0].District + " is the winner with " + tempCharList[0].Kills + " kill!");
            }
            else
            {
                rtbText.AppendText(tempCharList[0].getName() + " from District " + tempCharList[0].District + " is the winner with " + tempCharList[0].Kills + " kills!");
            }

        }

        private void btnMainContinue_Click(object sender, EventArgs e)
        {
            rtbText.Clear();
            if (game.IsDay == true) this.dayEvents();
            else if (game.IsDeath == true) this.deathsScreen();
            else if (game.IsFeast == true && game.HadFeast == false) this.doFeast();
            else if (game.IsEvent == true) this.doArenaEvent();
            else if (game.IsActive == false) this.winnerScreen();
        }


    }
}
