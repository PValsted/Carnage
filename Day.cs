using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{
    public class Day
    {
        RNG rng = new RNG();
        EventImporter ei = new EventImporter();
        Battle battle = new Battle();
        Loot loot = new Loot();
        Exploration explore = new Exploration();

        public string DoDay(Game game, List<character> list)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0, unassignedPlayers = game.ActivePlayers, playerCount=2;
            double rand;
            string eventType;
            List<character> tempList = new List<character>();

            sb.AppendLine("Day " + game.Day + " begins.\n");
            rng.shuffleList(list);

            if (game.Mode == "Realistic")
            {
                for (i = 0; i < list.Count; i++)
                {
                    if (unassignedPlayers!=1)
                    {
                        rand = rng.randomDouble(2.5);
                        list[i].Hunger = Math.Round(list[i].Hunger-rand,2);
                        if (list[i].Hunger <= 0)
                        {
                            sb.AppendLine(list[i].Name + " starved to death.\n");
                            unassignedPlayers--;
                            tempList.Add(list[i]);
                        }
                    }

                }
                for (i=0; i < tempList.Count;i++)
                {
                    list.Remove(tempList[i]);
                }
            }

            i = 0;

            while (i < list.Count)
            {                
                eventType = rng.randomEventType(game);

                    if (eventType == "Regular")
                    {
                        sb.AppendLine(ei.regularEvent(list.ElementAt(i), game));
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Gain")
                    {
                        sb.AppendLine(ei.gainEvent(list.ElementAt(i), game));
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Explore")
                    {
                        sb.AppendLine(explore.explorationEvent(list.ElementAt(i), game));
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Death" && game.ActivePlayers > 3)
                    {
                        sb.AppendLine(ei.deathEvent(list.ElementAt(i), game));
                        unassignedPlayers--;
                        i++;
                    }
                    else if (eventType == "Battle")
                    {
                        playerCount = rng.randomPlayerCount();
                        battle.setNumPlayers(playerCount);

                        if (unassignedPlayers >= 4 && playerCount == 4)
                        {
                            sb.AppendLine(battle.BattleEvent(list.ElementAt(i), list.ElementAt(i + 1), list.ElementAt(i + 2), list.ElementAt(i + 3), game));

                            i += playerCount;
                            unassignedPlayers -= 4;
                        }
                        else if (unassignedPlayers >= 3 && playerCount == 3)
                        {
                            sb.AppendLine(battle.BattleEvent(list.ElementAt(i), list.ElementAt(i + 1), list.ElementAt(i + 2), list.ElementAt(i + 2), game));

                            i += playerCount;
                            unassignedPlayers -= 3;
                        }
                        else if (unassignedPlayers >= 2 && playerCount == 2)
                        {
                            sb.AppendLine(battle.BattleEvent(list.ElementAt(i), list.ElementAt(i + 1), list.ElementAt(i + 1), list.ElementAt(i + 1), game));

                            i += playerCount;
                            unassignedPlayers -= 2;
                        }
                        else continue;
                    }
                    else continue;
            }

            for (i = 0; i < tempList.Count; i++)
            {
                tempList[i].IsAlive = false;
                list.Add(tempList[i]);
            }

            return sb.ToString();

        }
    }
}
