﻿using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{

    /// <summary>
    /// Simulates through the events of The Feast, which happens once close to the end of every simulation. Based on
    /// a randomly generated event type, every character has an action and the events are recorded by a string
    /// builder and returned as a string. The effects of the events modify the character's attributes along the way.
    /// </summary>
    public class Feast
    {
        RNG rng = new RNG();
        EventImporter ei = new EventImporter();
        Battle battle = new Battle();
        Loot loot = new Loot();

        /// <summary>
        /// Uses a while loop and a randomly-generated event type to cycle through the passed-in
        /// list of characters and return the events and their consequences as a string
        /// </summary>
        public string doFeast(Game game, List<character> list)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0, unassignedPlayers = game.ActivePlayers, doRain; //Unassigned players variable keeps track of how many players have not been selected for an event to ensure the index doesn't go out of range
            string eventType;

            sb.AppendLine("The Feast\n");
            sb.AppendLine("With " + game.ActivePlayers + " contestants left, it's announced that the Cornucopia has been replenished with new weapons, healing items, food, and more. However, approaching the center brings great risk of death.\n");
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
                eventType = rng.randomFeastEventType();

                if (eventType == "None") //Character does not participate and nothing happens to them
                {
                    int random = rng.randomInt(1, 3);

                    if (random == 1)
                    {
                        sb.AppendLine(list[i].Name + " decided " + list[i].PronounSub.ToLower() + " had too much to lose and did not go to The Feast.\n");
                    }
                    else if (random == 2)
                    {
                        sb.AppendLine(list[i].Name + " approached the center, but saw another competitor and decided it was not worth it.\n");
                    }
                    else
                    {
                        sb.AppendLine(list[i].Name + " started going to The Feast, but had a bad feeling and changed " + list[i].PronounPosAdj.ToLower() + " mind.\n");
                    }

                    i++;
                    unassignedPlayers--;
                }               
                else if (eventType == "Gain") //Character gains loot or is fed
                {
                    int random = rng.randomInt(1, 5);
                    double rand = Math.Round(rng.randomDouble(4), 2);

                    if (random == 1)
                    {
                        sb.AppendLine("Having been close to the center already, and seeing nobody around, " + loot.lootEvent(list[i], "Uncommon", game));
                        unassignedPlayers--;
                        i++;
                    }
                    else if (random == 2 && unassignedPlayers >= 2)
                    {
                        sb.AppendLine(list[i].Name + " and " + list[i+1].Name + " ran into each other and decided to have a temporary truce, and they each grabbed an item from inside the Cornucopia and left.\n" + loot.lootEvent(list[i], "Uncommon", game) + loot.lootEvent(list[i+1], "Uncommon", game));
                        unassignedPlayers=unassignedPlayers-2;
                        i=i+2;
                    }
                    else if (random == 3)
                    {
                        sb.AppendLine("Sneaking past another competitor, " + loot.lootEvent(list[i], "Uncommon", game));
                        unassignedPlayers--;
                        i++;
                    }
                    else if (random == 4)
                    {
                        sb.AppendLine(list[i].Name + " found some food in the Cornucopia and ate it.\n");
                        if (game.Mode=="Realistic" && game.DoHunger==true) list[i].Hunger += rand;
                        unassignedPlayers--;
                        i++;
                    }
                    else if (random == 5)
                    {
                        sb.AppendLine(list[i].Name + " found some water in the Cornucopia.\n");
                        unassignedPlayers--;
                        i++;
                    }
                    else
                    {
                        sb.AppendLine("Being the last to arrive at an already picked-over Cornucopia, " + loot.lootEvent(list[i], "Common", game));
                        unassignedPlayers--;
                        i++;
                    }
                }
                else if (eventType == "Battle") //Character gets into a battle with another character
                {
                    int random = rng.randomInt(1, 3);
                    if (unassignedPlayers >= 2)
                    {
                        if (random == 1)
                        {
                            sb.AppendLine(list[i].Name + " ran into the cornucopia to grab supplies but was ambushed by " + list[i + 1].Name + ".\n" + battle.BattleEvent(list[i], list[i + 1], list[i + 1], list[i + 1], game));
                        }
                        else if (random == 2)
                        {
                            sb.AppendLine("Before " + list[i].Name + " got to the center, " + list[i].PronounSub.ToLower() + " ran into " + list[i + 1].Name + ", who was also en route.\n" + battle.BattleEvent(list[i], list[i + 1], list[i + 1], list[i + 1], game));
                        }
                        else if (random == 3)
                        {
                            sb.AppendLine("Upon arriving at The Feast, " + list[i].Name + " had the misfortune of running into " + list[i+1].Name + ", who stuck around to attack arriving competitors. Before this, " + loot.lootEvent(list[i+1], "Uncommon", game) + battle.BattleEvent(list[i], list[i + 1], list[i + 1], list[i + 1], game));
                        }

                        i = i + 2;
                        unassignedPlayers = unassignedPlayers - 2;
                    }
                    else continue; //If there are fewer unnassigned players than the chosen player count, a different event type is selected for the character
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
