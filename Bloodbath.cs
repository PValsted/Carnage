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
    public class Bloodbath
    {
        RNG rng = new RNG();
        EventImporter ei = new EventImporter();
        Battle battle = new Battle();
        Loot loot = new Loot();

        public string doBloodbath(Game game, List<character> list)
        {
            StringBuilder sb = new StringBuilder();
            int i=0, unassignedPlayers=game.Players;
            string eventType;

            if (game.FunValue >= 10)
            {
                sb.AppendLine(game.Players + " contestants stand on their platforms in a circle. In the middle lies a large metal cornucopia, full of loot available to those bold enough to approach it. The countdown begins...and the game starts.\n");
            }
            else
            {
                sb.AppendLine(game.Players + " contestants stand on their platforms in a circle. In the middle lies a large metal cornucopia, full of loot available to those bold enough to approach it. The loot appears to be more valuable than usual. The countdown begins...and the game starts.\n");
            }

            rng.shuffleList(list);

            while (i < list.Count)
            {
                eventType = rng.randomBBEventType();

                if (eventType == "Regular")
                {
                   int random = rng.randomInt(1, 3);

                    if (unassignedPlayers >= 2 && random == 3)
                    {
                        random = rng.randomInt(1, 3);

                        if (random == 1)
                        {
                            sb.AppendLine(list[i].getName() + " broke every one of " + list[i + 1].getName() + "'s fingers for a ham sandwhich.\n");
                            if (game.Mode == "Realistic")
                            {
                                double rand = rng.randomDouble(3);
                                list[i].Hunger += rand;
                            }
                        }
                        else if (random == 2)
                        {
                            sb.AppendLine(list[i].getName() + " punched " + list[i + 1].getName() + " in the " + rng.randomBodyPart() + " over a backpack only to find it was empty.\n");
                        }
                        else
                        {
                            sb.AppendLine(list[i].getName() + " and " + list[i + 1].getName() + " saw each other and decided to run opposite directions.\n");
                        }

                        i=i+2;
                        unassignedPlayers = unassignedPlayers - 2;
                    }
                    else
                    {
                        random = rng.randomInt(1, 6);

                        if (random == 1)
                        {
                            sb.AppendLine(list[i].getName() + " found clean water just outside the cornucopia.\n");
                        }
                        else if (random == 2)
                        {
                            sb.AppendLine(list[i].getName() + " grabbed firemaking supplies from the cornucopia.\n");
                        }
                        else if (random == 3)
                        {
                            sb.AppendLine(list[i].getName() + " decided to run away from the cornucopia.\n");
                        }
                        else if (random == 4)
                        {
                            sb.AppendLine(list[i].getName() + " saw a number of fighters in the cornucopia and ran the other way.\n");
                        }
                        else if (random == 5)
                        {
                            sb.AppendLine(list[i].getName() + " examined " + list[i].getPronounPosAdj().ToLower() + " surroundings and determined " + list[i].getPronounSub().ToLower() + " could not approach the cornucopia.\n");
                        }
                        else
                        {
                            sb.AppendLine(list[i].getName() + " sprained " + list[i].getPronounPosAdj().ToLower() + " ankle running away from the cornucopia.\n");
                        }
                        unassignedPlayers--;
                        i++;
                    }

                }
                else if (eventType == "Gain")
                {
                    int random = rng.randomInt(1, 7);
                    if (game.FunValue >= 10 && random > 2)
                    {
                        sb.AppendLine("After sneaking into the cornucopia, " + loot.lootEvent(list[i], "Common"));
                    }
                    else if (game.FunValue < 10 && random > 2)
                    {
                        sb.AppendLine("After sneaking into the cornucopia, " + loot.lootEvent(list[i], "Rare"));
                    }
                    else
                    {
                        sb.AppendLine("Just inside the cornucopia, " + list[i].Name + " found some food.\n");
                        if (game.Mode=="Realistic")
                        {
                            double rand = rng.randomDouble(4);
                            list[i].Hunger += rand;
                        }
                    }
                    unassignedPlayers--;
                    i++;
                }
                else if (eventType == "Battle")
                {
                    if (unassignedPlayers >= 2)
                    {
                        if (game.FunValue >= 10)
                        {
                            sb.AppendLine(list[i].getName() + " ran into the cornucopia to grab supplies but was ambushed by " + list[i + 1].getName() + ". Just before this, " + loot.lootEvent(list[i + 1], "Common") + battle.BattleEvent(list[i], list[i + 1], list[i + 1], list[i + 1], game));
                        }
                        else
                        {
                            sb.AppendLine(list[i].getName() + " ran into the cornucopia to grab supplies but was ambushed by " + list[i + 1].getName() + ". Just before this, " + loot.lootEvent(list[i + 1], "Rare") + battle.BattleEvent(list[i], list[i + 1], list[i + 1], list[i + 1], game));
                        }

                        i = i + 2;
                        unassignedPlayers = unassignedPlayers - 2;
                    }
                    else continue;
                }
                else if (eventType == "Death")
                {
                    sb.AppendLine(list[i].getName() + " stepped off the platform too early and blew up.\n");
                    list[i].IsAlive = false;

                    unassignedPlayers--;
                    i++;
                }
            }

            return sb.ToString();
        }
    }
}
