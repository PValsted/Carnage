using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{

    /// <summary>
    /// Simulates through the events of a day, which is the standard series of events that represents
    /// one day in the simulator. Each instance of this happening is represented by an event involving
    /// every player, the nature of which is randomly selected each time. Using many randomly-generated variables,
    /// some of which are determined by gamemode, one or more characters perform an action with different consequences
    /// that are taken into effect within the class.
    /// </summary>
    public class Day
    {
        RNG rng = new RNG();
        EventImporter ei = new EventImporter();
        Battle battle = new Battle();
        Loot loot = new Loot();
        Exploration explore = new Exploration();

        /// <summary>
        /// Takes the game attributes and list of alive players and selects an event for one or more of them at
        /// a time. This is repeated until every character has been selected once, and the events are recorded
        /// by a string builder and returned as a string. The consequences of each event are taken into effect
        /// within this method.
        /// </summary>
        public string DoDay(Game game, List<character> list)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0, unassignedPlayers = game.ActivePlayers, playerCount=2; //Unassigned players variable keeps track of how many players have not been selected for an event to ensure the index doesn't go out of range
            double rand;
            string eventType;
            List<character> tempList = new List<character>();

            sb.AppendLine("Day " + game.Day + " begins.\n");
            rng.shuffleList(list);

            if (game.Mode == "Realistic") //If the gamemode is Realistic, each player loses a random amound of hunger between 0 and 2.5 at the start of every day
            {
                for (i = 0; i < list.Count; i++)
                {
                    if (unassignedPlayers!=1) //Ensures last character alive does not starve to death and cause game to end with no winner
                    {
                        rand = rng.randomDouble(2.5);
                        list[i].Hunger = Math.Round(list[i].Hunger-rand,2);
                        if (list[i].Hunger <= 0) //If this loss of hunger causes a character's hunger to drop below 0, the character dies
                        {
                            sb.AppendLine(list[i].Name + " starved to death.\n");
                            unassignedPlayers--;
                            tempList.Add(list[i]);
                        }
                    }

                }
                for (i=0; i < tempList.Count;i++)
                {
                    list.Remove(tempList[i]); //If a character starves, they are removed from the list that cycles through events below
                }
            }

            i = 0;

            //While loop simulates the events for every character
            while (i < list.Count) //While list hasn't been exhausted
            {                
                eventType = rng.randomEventType(game); //Event type decides what kind of event a character will go through at random, with different events being more likely at different points in the simulation

                    if (eventType == "Regular") //If type is regular, an standard event with few consequences is selected
                    {
                        sb.AppendLine(ei.regularEvent(list.ElementAt(i), game));
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Gain") //If type is gain, character obtains a weapon or means of healing
                    {
                        sb.AppendLine(ei.gainEvent(list.ElementAt(i), game));
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Explore") //If type is explore, character goes through an exploration event
                    {
                        sb.AppendLine(explore.explorationEvent(list.ElementAt(i), game));
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Death" && game.ActivePlayers > 3) //If type is death, character dies outside of combat; cannot happen if only 2 players remain
                    {
                        sb.AppendLine(ei.deathEvent(list.ElementAt(i), game));
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Battle") //If type is battle, a battle is simulated between 2, 3, or 4 characters, which is decided at random
                    {
                        playerCount = rng.randomPlayerCount();
                        battle.setNumPlayers(playerCount);

                        if (unassignedPlayers >= 4 && playerCount == 4) //If battle is selected to be between 4 players, as long as there are at least 4 unassigned remaining characters
                        {
                            sb.AppendLine(battle.BattleEvent(list.ElementAt(i), list.ElementAt(i + 1), list.ElementAt(i + 2), list.ElementAt(i + 3), game));

                            i += playerCount;
                            unassignedPlayers -= 4; 
                        }
                        else if (unassignedPlayers >= 3 && playerCount == 3) //If battle is selected to be between 3 players, as long as there are at least 3 unassigned remaining characters
                    {
                            sb.AppendLine(battle.BattleEvent(list.ElementAt(i), list.ElementAt(i + 1), list.ElementAt(i + 2), list.ElementAt(i + 2), game));

                            i += playerCount;
                            unassignedPlayers -= 3;
                        }
                        else if (unassignedPlayers >= 2 && playerCount == 2) //If battle is selected to be between 2 players, as long as there are at least 2 unassigned remaining characters
                    {
                            sb.AppendLine(battle.BattleEvent(list.ElementAt(i), list.ElementAt(i + 1), list.ElementAt(i + 1), list.ElementAt(i + 1), game));

                            i += playerCount;
                            unassignedPlayers -= 2;
                        }
                        else continue; //If the player count is selected to be greater than the number of players remaining, event type is re-rolled
                    }
                    else continue; //If an invalid type is somehow selected, the event type is re-rolled
            }

            //Any characters who starved to death before the events were cycled through are added back to the list to be taken care of in the main form
            for (i = 0; i < tempList.Count; i++)
            {
                tempList[i].IsAlive = false;
                list.Add(tempList[i]);
            }

            return sb.ToString();

        }
    }
}
