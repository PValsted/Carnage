using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{
    public class Loot
    {
        RNG rng = new RNG();        

        public string[] getLoot(string rarity, string type)
        {
            string[] csvLines = new string[4];
            string[] lootArray = new string[4];
            bool doBreak = false;
            int length, rand;
            
            if (type=="Weapon") csvLines = System.IO.File.ReadAllLines(@"..\..\..\loot.csv");
            else
            {
                int randomType = rng.randomInt(0, 3);

                if (randomType == 0) //Read healing loot table csv file
                {
                    csvLines = System.IO.File.ReadAllLines(@"..\..\..\healloot.csv");
                }
                else //Read weapon loot table csv file
                {
                    csvLines = System.IO.File.ReadAllLines(@"..\..\..\loot.csv");
                }
            }

            length = csvLines.Length - 1;

            if (rarity == "Common") //Give item that is likely common with small chance of uncommon
            {
                int randomRarity = rng.randomInt(0, 5);

                if (randomRarity == 0) //Uncommon item (1 in 6 chance)
                {
                    while (doBreak == false)
                    {
                        rand = rng.randomInt(0, length);

                        lootArray = csvLines[rand].Split(',');

                        if (lootArray[3] == "Uncommon") doBreak = true;
                        else continue;
                    }
                }
                else //Common item (5 in 6 chance)
                {
                    while (doBreak == false)
                    {
                        rand = rng.randomInt(0, length);

                        lootArray = csvLines[rand].Split(',');

                        if (lootArray[3] == "Common") doBreak = true;
                        else continue;
                    }
                }
            }
            else if (rarity == "Uncommon") //Give item that is likely uncommon with small chance of rare
            {
                int randomRarity = rng.randomInt(0, 5);

                if (randomRarity == 0) //Rare item (1 in 6 chance)
                {
                    while (doBreak == false)
                    {
                        rand = rng.randomInt(0, length);

                        lootArray = csvLines[rand].Split(',');

                        if (lootArray[3] == "Rare") doBreak = true;
                        else continue;
                    }
                }
                else //Uncommon item (5 in 6 chance)
                {
                    while (doBreak == false)
                    {
                        rand = rng.randomInt(0, length);

                        lootArray = csvLines[rand].Split(',');

                        if (lootArray[3] == "Uncommon") doBreak = true;
                        else continue;
                    }
                }
            }
            else if (rarity == "Rare") //Give item that is likely rare with small chance of being uncommon
            {
                int randomRarity = rng.randomInt(0, 5);

                if (randomRarity >= 0 && randomRarity < 2) //Uncommon item (1 in 3 chance)
                {
                    while (doBreak == false)
                    {
                        rand = rng.randomInt(0, length);

                        lootArray = csvLines[rand].Split(',');

                        if (lootArray[3] == "Uncommon") doBreak = true;
                        else continue;
                    }
                }
                else //Rare item (2 in 3 chance)
                {
                    while (doBreak == false)
                    {
                        rand = rng.randomInt(0, length);

                        lootArray = csvLines[rand].Split(',');

                        if (lootArray[3] == "Rare") doBreak = true;
                        else continue;
                    }
                }
            }
            return lootArray;

        }
        public string lootEvent(character character, string rarity)
        {
            string[] lootArray;
            lootArray = this.getLoot(rarity,"Both");
            StringBuilder sb = new StringBuilder();

            if (lootArray[1]=="healing")
            {
                if (character.getHealth() < 20)
                {
                    character.heal(Double.Parse(lootArray[2]));
                    sb.AppendLine(character.getName() + " found a " + lootArray[0] + " and used it to heal up to " + character.getHealth() + " health.");
                }
                else if (character.getHealth() == 20 && character.isHealSlotFilled() == false)
                {
                    character.setHealingAmount(Double.Parse(lootArray[2]));
                    character.fillHealSlot(true);
                    if (character.getPronounSub()=="They") 
                    {
                        sb.AppendLine(character.getName() + " found a " + lootArray[0] + ". " + character.getName() + " is at full health so they save it for later.");
                    }
                    else
                    {
                        sb.AppendLine(character.getName() + " found a " + lootArray[0] + ". " + character.getName() + " is at full health so " + character.getPronounSub().ToLower() + " save it for later.");
                    }
                    
                }
                else if (character.getHealth() == 20 && character.isHealSlotFilled() == true && character.getHealingAmount() < Double.Parse(lootArray[2]))
                {
                    character.setHealingAmount(Double.Parse(lootArray[2]));
                    sb.AppendLine(character.getName() + " found a " + lootArray[0] + ". " + character.getName() + " replaced " + character.getPronounPosAdj().ToLower() + " previous healing item with this superior one.");
                }
                else
                {
                    sb.AppendLine(character.getName() + " found a " + lootArray[0] + ".");
                }
            }
            else if (lootArray[1] == "explosive")
            {
                if (character.HasExplosive==false)
                {
                    character.HasExplosive = true;
                    sb.AppendLine(character.getName() + " found a " + lootArray[0] + ".");
                }
                else
                {
                    sb.AppendLine(character.getName() + " found a " + lootArray[0] + ".");
                }
            }
            else
            {
                if (character.getWeaponName() == "")
                {
                    character.setWeaponName(lootArray[0]);
                    character.setWeaponAttack(Double.Parse(lootArray[2]));
                    character.setWeaponType(lootArray[1]);
                    sb.AppendLine(character.getName() + " found a " + character.getWeaponName() + ".");
                }
                else if (character.getWeaponAttack() < Double.Parse(lootArray[2]) && character.getWeaponName() != "")
                {
                    sb.AppendLine(character.getName() + " found a " + lootArray[0] + ". " + character.getPronounSub() + " replaced " + character.getPronounPosAdj().ToLower() + " " + character.getWeaponName() + ".");
                    character.setWeaponName(lootArray[0]);
                    character.setWeaponAttack(Double.Parse(lootArray[2]));
                    character.setWeaponType(lootArray[1]);
                }
                else
                {
                    sb.AppendLine(character.getName() + " found a " + character.getWeaponName() + ".");
                }
            }

            return sb.ToString();
        }

        public string potionEvent(character character, Game game)
        {
            StringBuilder sb2 = new StringBuilder();
            int rand=0;
            if (game.Mode=="Realistic") rand = rng.randomInt(0, 5);
            else rand = rng.randomInt(0, 2);

            if (rand == 0) //Health boost
            {
                character.Health = 25;
                sb2.Append(character.getName() + " felt all injuries heal, and even felt healthier than ever before. " + character.getName() + " is now at 25 health.");               
            }
            else if (rand == 1) //Super strength
            {
                character.setWeaponAttack(6.5);
                character.setWeaponType("Unarmed");
                character.setWeaponName("");
                if (game.Mode=="Realistic") character.CombatLevel = Math.Round(((character.Speed + character.Strength) / 4), 2);
                sb2.Append(character.getName() + " felt a wave of strength flow in. " + character.getPronounSub() + " is now stronger than before, and doesn't feel the need to use a weapon.");
            }
            else if (rand == 2) //Hurt 5 damage
            {
                character.hurt(5);
                sb2.Append(character.getName() + " felt a horrible pain in " + character.getPronounPosAdj().ToLower() + " " + rng.randomBodyPart() + ". This was clearly not a desirable outcome. " + character.getName() + " took 5 damage.");
            }
            else if (rand == 3) //Full hunger
            {
                character.Hunger=10;
                sb2.Append(character.getName() + " felt " + character.getPronounPosAdj().ToLower() + " hunger disappear, as if haven eaten a three-course meal.");
            }
            else if (rand == 4) //Super speed
            {
                character.Speed=10;
                character.CombatLevel = Math.Round(((character.Speed + character.Strength) / 4), 2);
                sb2.Append(character.getName() + " suddenly felt as light as a feather, and is now super fast.");
            }
            else if (rand == 5) //Morality swap
            {
                if (character.Morality > 6) //If morality is 6 or higher
                {
                    character.Morality = 1;
                    sb2.Append(character.getName() + " started seeing red and felt all sense of morality vanish.");
                }
                else if (character.Morality <= 6 && character.Morality >= 4) //If morality is between 4 and 6
                {                
                    character.Morality = 9;
                    sb2.Append(character.getName() + " started feeling a warm fuzzy feeling and decided being morally grey wasn't the right path anymore.");
                
                }
                else //If morality is below 4
                {
                    character.Morality = 9;
                    sb2.Append(character.getName() + " started feeling a warm fuzzy feeling and decided being villainous wasn't the right path anymore.");
                }
            }

            return sb2.ToString();
        }

        public string SponsorItemType(character character, Game game)
        {
            if (character.Health <= 8)
            {
                return "Healing";
            }
            else if (character.getWeaponName() == "")
            {
                return "Any Weapon";
            }
            else if (game.Mode=="Realistic" && character.Hunger <= 3) 
            {
                return "Hunger";
            }
            else if (character.HasExplosive==false)
            {
                return "Explosive";
            }
            else
            {
                return "Boost";
            }
        }

    }
}
