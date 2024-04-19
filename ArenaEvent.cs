using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{
    public class ArenaEvent
    {
        RNG rng = new();
        EventImporter ei = new();
        Battle battle = new();
        bool doneMonkey = false, doneEggs = false, doneFrost = false, doneBombs = false;

        public string doArenaEvent(Game game, List<character> list) 
        {
            int rand = rng.randomInt(1,4);

            if (rand == 1)
            {
                if (doneMonkey==false)
                {
                    return killerMonkeys(game, list);
                }
                else
                {
                    rand = rng.randomInt(1, 3);
                    if (rand==1) return Eggs(game, list);
                    else if (rand==2) return frost(game, list);
                    else return bombTrees(game, list);
                }
            }
            else if (rand == 2)
            {
                if (doneEggs == false)
                {
                    return Eggs(game, list);
                }
                else
                {
                    rand = rng.randomInt(1, 3);
                    if (rand == 1) return killerMonkeys(game, list);
                    else if (rand == 2) return frost(game, list);
                    else return bombTrees(game, list);
                }
            }
            else if (rand == 3)
            {
                if (doneFrost == false)
                {
                    return frost(game, list);
                }
                else
                {
                    rand = rng.randomInt(1, 3);
                    if (rand == 1) return Eggs(game, list);
                    else if (rand == 2) return killerMonkeys(game, list);
                    else return bombTrees(game, list);
                }
            }
            else
            {
                if (doneBombs == false)
                {
                    return bombTrees(game, list);
                }
                else
                {
                    rand = rng.randomInt(1, 3);
                    if (rand == 1) return Eggs(game, list);
                    else if (rand == 2) return frost(game, list);
                    else return killerMonkeys(game, list);
                }
            }


        }

        public string killerMonkeys(Game game, List<character> list)
        {
            StringBuilder sb = new();
            string[] csvLines = new string[3];
            string[] monkeyArray = new string[3];
            int i = 0, rand, length, unassignedPlayers = game.ActivePlayers;
            string eventText;
            character monkey = new("a killer monkey", "They");

            //NPC that can attack players this event
            monkey.setWeaponAttack(3.5);
            monkey.IsNPC = true;

            csvLines = System.IO.File.ReadAllLines(@"..\..\..\eventmonkeys.csv");
            length = csvLines.Length - 1;

            sb.AppendLine("Arena Event - Killer Monkeys\n");
            sb.AppendLine("Alarms blare throughout the arena. It’s announced that killer monkeys have been released all around. Specifically, these apes were trained to consume human flesh and were then starved for several days.\n");

            while (i < list.Count) //While list hasn't been exhausted
            {
                rand = rng.randomInt(0, length);
                monkeyArray = csvLines[rand].Split(',');
                monkey.Health = 10;
                monkey.IsAlive = true;

                if (monkeyArray[1] == "1") //If event involves 1 player
                {
                    eventText = ei.replaceText(monkeyArray[0], list[i]);

                    if (monkeyArray[2] == "None")
                    {
                        sb.AppendLine(eventText+"\n");
                    }
                    else if (monkeyArray[2] == "NPCBattle")
                    {
                        sb.AppendLine(eventText + battle.NPCBattleEvent(list[i], monkey, game)+"\n");
                    }

                    i++;
                    unassignedPlayers--;
                }
                else if (monkeyArray[1] == "2" && unassignedPlayers >= 2) //If event involves 2 players
                {
                    eventText = ei.replaceText(monkeyArray[0], list[i], list[i+1]);

                    if (monkeyArray[2] == "None")
                    {
                        sb.AppendLine(eventText + "\n");
                    }
                    else if (monkeyArray[2] == "NPCBattle2")
                    {
                        sb.AppendLine(eventText + battle.NPCBattleEvent(list[i + 1], monkey, game) + "\n");
                    }

                    i += 2;
                    unassignedPlayers -= 2;

                }
                else continue;

            }

            doneMonkey = true;

            return sb.ToString();
        }

        public string Eggs(Game game, List<character> list)
        {
            StringBuilder sb2 = new();
            string[] csvLines = new string[3];
            string[] eggArray = new string[3];
            int i = 0, rand, length, unassignedPlayers = game.ActivePlayers, randChar;
            string eventText;
            character raptor = new("a megaraptor", "They");
            character tracker = new("a tracker jacker", "They");
            character basilisk = new("a basilisk minor", "They");
            character randomCharacter;

            //3 types of NPC enemies can attack players in this event
            raptor.setWeaponAttack(3.5);
            raptor.setWeaponName("claws");
            raptor.setWeaponType("slash");
            raptor.IsNPC = true;
            tracker.setWeaponAttack(2);
            tracker.setWeaponName("stinger");
            tracker.setWeaponType("stab");
            tracker.IsNPC = true;
            basilisk.setWeaponAttack(3);
            basilisk.setWeaponName("fangs");
            basilisk.setWeaponType("special");
            basilisk.IsNPC = true;

            csvLines = System.IO.File.ReadAllLines(@"..\..\..\eventegg.csv");
            length = csvLines.Length - 1;

            sb2.AppendLine("Arena Event - Eggs\n");
            sb2.AppendLine("Alarms blare throughout the arena. It’s announced that mysterious eggs have been placed all around. No other information is given to the competitors.\n");

            while (i < list.Count) //While list hasn't been exhausted
            {
                rand = rng.randomInt(0, length);
                randChar = rng.randomInt(1, 3);
                eggArray = csvLines[rand].Split(',');

                raptor.Health = 10;
                raptor.IsAlive = true;
                tracker.Health = 10;
                tracker.IsAlive = true;
                basilisk.Health = 10;
                basilisk.IsAlive = true;

                if (randChar==1)
                {
                    randomCharacter = raptor;
                }
                else if (randChar==2)
                {
                    randomCharacter = tracker;
                }
                else
                {
                    randomCharacter = basilisk;
                }

                if (eggArray[1] == "1") //If event involves 1 player
                {
                    eventText = ei.replaceText(eggArray[0], list[i]);

                    if (eggArray[2] == "None")
                    {
                        sb2.AppendLine(eventText + "\n");
                    }
                    else if (eggArray[2] == "NPCBattle")
                    {
                        sb2.AppendLine(eventText + battle.NPCBattleEvent(list[i], randomCharacter, game) + "\n");
                    }
                    else if (eggArray[2] == "Damage")
                    {
                        list[i].hurt(10);
                        if (list[i].IsAlive==true) //If player survives egg
                        {
                            sb2.AppendLine(eventText + list[i].getName() + " took 10 damage.\n");
                        }
                        else //If egg kills player
                        {
                            sb2.AppendLine(eventText + list[i].getName() + " succumbed to " + list[i].getPronounPosAdj().ToLower() + " injuries.\n");
                        }                        
                    }

                    i++;
                    unassignedPlayers--;
                }
                else if (eggArray[1] == "2" && unassignedPlayers >= 2) //If event involves 2 players
                {
                    eventText = ei.replaceText(eggArray[0], list[i], list[i + 1]);

                    sb2.AppendLine(eventText + "\n");
                    list[i].Kills++;
                    list[i+1].hurt(100);

                    i += 2;
                    unassignedPlayers -= 2;
                }
                else continue;
            }

            doneEggs = true;

            return sb2.ToString();
        }

        public string frost(Game game, List<character> list)
        {
            StringBuilder sb3 = new();
            string[] csvLines = new string[3];
            string[] frostArray = new string[3];
            int i = 0, rand, length, unassignedPlayers = game.ActivePlayers;
            string eventText;

            csvLines = System.IO.File.ReadAllLines(@"..\..\..\eventfrost.csv");
            length = csvLines.Length - 1;

            sb3.AppendLine("Arena Event - Killer Frost\n");
            sb3.AppendLine("Alarms blare throughout the arena. It’s announced that the temperature of the arena will be reduced to 0 degrees Celsius. The warm climate very rapidly becomes frigid, and it starts to snow.\n");

            while (i < list.Count) //While list hasn't been exhausted
            {
                rand = rng.randomInt(0, length);
                frostArray = csvLines[rand].Split(',');


                if (frostArray[1] == "1") //If event involves 1 player
                {
                    eventText = ei.replaceText(frostArray[0], list[i]);

                    if (frostArray[2] == "None")
                    {
                        sb3.AppendLine(eventText + "\n");
                    }
                    else if (frostArray[2] == "Death")
                    {
                        sb3.AppendLine(eventText + "\n");
                        list[i].hurt(100);
                    }

                    i++;
                    unassignedPlayers--;
                }
                else if (frostArray[1] == "2" && unassignedPlayers >= 2) //If event involves 2 players
                {
                    eventText = ei.replaceText(frostArray[0], list[i], list[i + 1]);

                    sb3.AppendLine(eventText + "\n");

                    i += 2;
                    unassignedPlayers -= 2;
                }
                else continue;
            }

            doneFrost = true;

            return sb3.ToString();
        }

        public string bombTrees(Game game, List<character> list)
        {
            StringBuilder sb4 = new();
            string[] csvLines = new string[3];
            string[] bombArray = new string[3];
            int i = 0, rand, length, unassignedPlayers = game.ActivePlayers;
            string eventText;

            csvLines = System.IO.File.ReadAllLines(@"..\..\..\eventbombtrees.csv");
            length = csvLines.Length - 1;

            sb4.AppendLine("Arena Event - Bomb Trees\n");
            sb4.AppendLine("Alarms blare throughout the arena. It’s announced that approximately a fourth of the trees around the arena have been turned into bombs. With very few unforested areas, the arena has become very unstable.\n");

            while (i < list.Count) //While list hasn't been exhausted
            {
                rand = rng.randomInt(0, length);
                bombArray = csvLines[rand].Split(',');


                if (bombArray[1] == "1") //If event involves 1 player
                {
                    eventText = ei.replaceText(bombArray[0], list[i]);

                    if (bombArray[2] == "None")
                    {
                        sb4.AppendLine(eventText + "\n");
                    }
                    else if (bombArray[2] == "Death")
                    {
                        sb4.AppendLine(eventText + "\n");
                        list[i].hurt(100);
                    }

                    i++;
                    unassignedPlayers--;
                }
                else if (bombArray[1] == "2" && unassignedPlayers >= 2) //If event involves 2 players
                {
                    eventText = ei.replaceText(bombArray[0], list[i], list[i + 1]);

                    if (bombArray[2] == "Death")
                    {
                        sb4.AppendLine(eventText + "\n");
                        list[i+1].hurt(100);
                        list[i].Kills++;
                    }
                    else if (bombArray[2] == "Deathx2")
                    {
                        sb4.AppendLine(eventText + "\n");
                        list[i].hurt(100);
                        list[i + 1].hurt(100);
                    }
                    else if (bombArray[2] == "Battle")
                    {
                        sb4.AppendLine(eventText + " " + battle.BattleEvent(list[i], list[i+1], list[i + 1], list[i + 1], game));
                    }

                    i += 2;
                    unassignedPlayers -= 2;
                }
                else continue;
            }

            doneBombs = true;

            return sb4.ToString();
        }
    }
}
