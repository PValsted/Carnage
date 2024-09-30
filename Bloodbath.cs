using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Carnage
{

    /// <summary>
    /// Simulates through the events of a Bloodbath, which happens at the start of every simulation. Based on
    /// a randomly generated event type, every character has an action and the events are recorded by a string
    /// builder and returned as a string. The effects of the events modify the character's attributes along the way.
    /// </summary>
    public class Bloodbath
    {
        RNG rng = new RNG();
        EventImporter ei = new EventImporter();
        Battle battle = new Battle();
        Loot loot = new Loot();

        /// <summary>
        /// Uses a while loop and a randomly-generated event type to cycle through the passed-in
        /// list of characters and return the events and their consequences as a string.
        /// </summary>
        public string doBloodbath(Game game, List<character> list)
        {
            StringBuilder sb = new StringBuilder();
            int i=0, unassignedPlayers=game.Players, doRain; //Unassigned players variable keeps track of how many players have not been selected for an event to ensure the index doesn't go out of range
            string eventType;

            if (game.FunValue >= 20) //If game's fun value is 0-20, all loot generated is rare
            {
                sb.AppendLine(game.Players + " contestants stand on their platforms in a circle. In the middle lies a large metal cornucopia, full of loot available to those bold enough to approach it. The countdown begins...and the game starts.\n");
            }
            else //The default, common loot is what generates
            {
                sb.AppendLine(game.Players + " contestants stand on their platforms in a circle. In the middle lies a large metal cornucopia, full of loot available to those bold enough to approach it. The loot appears to be more valuable than usual. The countdown begins...and the game starts.\n");
            }

            rng.shuffleList(list);

            doRain = rng.randomInt(1, 10); //1 in 10 chance it starts raining on any given day
            if (doRain == 1)
            {
                game.IsRaining = true;
                sb.AppendLine("Rain starts to downpour in the arena.\n");
            }

            //While loop simulates the events for every character
            while (i < list.Count) //While list hasn't been exhausted
            {
                eventType = rng.randomBBEventType(); //Random type of event selected

                if (eventType == "Regular") //Events with no consequences
                {
                   int random = rng.randomInt(1, 3);

                    if (unassignedPlayers >= 2 && random == 3) //Regular event with 2 characters involved
                    {
                        random = rng.randomInt(1, 3);

                        if (random == 1)
                        {
                            sb.AppendLine(list[i].Name + " broke every one of " + list[i + 1].Name + "'s fingers for a ham sandwich.\n");
                            if (game.Mode == "Realistic" && game.DoHunger == true)
                            {
                                double rand = rng.randomDouble(3);
                                list[i].Hunger += rand;
                            }
                            list[i + 1].Health -= 2;
                        }
                        else if (random == 2)
                        {
                            sb.AppendLine(list[i].Name + " punched " + list[i + 1].Name + " in the " + rng.randomBodyPart() + " over a backpack only to find it was empty.\n");
                        }
                        else
                        {
                            sb.AppendLine(list[i].Name + " and " + list[i + 1].Name + " saw each other and decided to run opposite directions.\n");
                        }

                        i=i+2;
                        unassignedPlayers = unassignedPlayers - 2;
                    }
                    else //Regular event with 1 player involved
                    {
                        random = rng.randomInt(1, 6);

                        if (random == 1)
                        {
                            sb.AppendLine(list[i].Name + " found clean water just outside the cornucopia.\n");
                        }
                        else if (random == 2)
                        {
                            sb.AppendLine(list[i].Name + " grabbed firemaking supplies from the cornucopia.\n");
                        }
                        else if (random == 3)
                        {
                            sb.AppendLine(list[i].Name + " decided to run away from the cornucopia.\n");
                        }
                        else if (random == 4)
                        {
                            sb.AppendLine(list[i].Name + " saw a number of fighters in the cornucopia and ran the other way.\n");
                        }
                        else if (random == 5)
                        {
                            sb.AppendLine(list[i].Name + " examined " + list[i].PronounPosAdj.ToLower() + " surroundings and determined " + list[i].PronounSub.ToLower() + " could not approach the cornucopia.\n");
                        }
                        else
                        {
                            sb.AppendLine(list[i].Name + " sprained " + list[i].PronounPosAdj.ToLower() + " ankle running away from the cornucopia.\n");
                        }
                        unassignedPlayers--;
                        i++;
                    }
                }
                else if (eventType == "Gain") //Event where character gains an item--a weapon or healing item
                {
                    int random = rng.randomInt(1, 7);
                    if (game.FunValue >= 10 && random > 2)
                    {
                        sb.AppendLine("After sneaking into the cornucopia, " + loot.lootEvent(list[i], "Common", game));
                    }
                    else if (game.FunValue <= 20 && random > 2)
                    {
                        sb.AppendLine("After sneaking into the cornucopia, " + loot.lootEvent(list[i], "Rare", game));
                    }
                    else
                    {
                        sb.AppendLine("Just inside the cornucopia, " + list[i].Name + " found some food.\n");
                        if (game.Mode == "Realistic" && game.DoHunger == true)
                        {
                            double rand = rng.randomDouble(4);
                            list[i].Hunger += rand;
                        }
                    }
                    unassignedPlayers--;
                    i++;
                }
                else if (eventType == "Battle") //2 characters battle with one of them getting a weapon beforehand
                {
                    if (unassignedPlayers >= 2)
                    {
                        if (game.FunValue >= 10)
                        {
                            sb.AppendLine(list[i].Name + " ran into the cornucopia to grab supplies but was ambushed by " + list[i + 1].Name + ". Just before this, " + loot.lootEvent(list[i + 1], "Common", game) + battle.BattleEvent(list[i], list[i + 1], list[i + 1], list[i + 1], game));
                        }
                        else
                        {
                            sb.AppendLine(list[i].Name + " ran into the cornucopia to grab supplies but was ambushed by " + list[i + 1].Name + ". Just before this, " + loot.lootEvent(list[i + 1], "Rare", game) + battle.BattleEvent(list[i], list[i + 1], list[i + 1], list[i + 1], game));
                        }

                        i = i + 2;
                        unassignedPlayers = unassignedPlayers - 2;
                    }
                    else continue;
                }
                else if (eventType == "Death") //1 character dies outside of combat
                {
                    sb.AppendLine(list[i].Name + " stepped off the platform too early and blew up.\n");
                    list[i].IsAlive = false;

                    unassignedPlayers--;
                    i++;
                }
            }

            if (game.IsRaining == true) //If it's raining it stops at the end of the day
            {
                game.IsRaining = false;
                sb.AppendLine("The rain subsides for now.");
            }

            return sb.ToString();
        }
    }
}
