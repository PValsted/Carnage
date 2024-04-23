using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{

    /// <summary>
    /// This class is designed to select a random item from a loot table based on
    /// rarity values and item types and apply it to a character, documenting the
    /// actions with a string builder which is returned as a string.
    /// </summary>
    public class Loot
    {
        RNG rng = new RNG();

        /// <summary>
        /// Based on the rarity level passed in, a loot table contained on a local csv file is
        /// randomly selected and converted into an array which is returned to be used
        /// to apply it to the character.
        /// </summary>
        public string[] getLoot(string rarity, string type)
        {
            string[] csvLines = new string[4];
            string[] lootArray = new string[4];
            bool doBreak = false;
            int length, rand;
            
            if (type=="Weapon") csvLines = System.IO.File.ReadAllLines(@"..\..\..\loot.csv"); //If the method calls specifically for a weapon
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
                    while (doBreak == false) //Cycles through items in loot table until an Uncommon one is selected
                    {
                        rand = rng.randomInt(0, length);

                        lootArray = csvLines[rand].Split(',');

                        if (lootArray[3] == "Uncommon") doBreak = true;
                        else continue;
                    }
                }
                else //Common item (5 in 6 chance)
                {
                    while (doBreak == false) //Cycles through items in loot table until a Common one is selected
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
                    while (doBreak == false) //Cycles through items in loot table until a Rare one is selected
                    {
                        rand = rng.randomInt(0, length);

                        lootArray = csvLines[rand].Split(',');

                        if (lootArray[3] == "Rare") doBreak = true;
                        else continue;
                    }
                }
                else //Uncommon item (5 in 6 chance)
                {
                    while (doBreak == false) //Cycles through items in loot table until an Uncommon one is selected
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
                    while (doBreak == false) //Cycles through items in loot table until an Uncommon one is selected
                    {
                        rand = rng.randomInt(0, length);

                        lootArray = csvLines[rand].Split(',');

                        if (lootArray[3] == "Uncommon") doBreak = true;
                        else continue;
                    }
                }
                else //Rare item (2 in 3 chance)
                {
                    while (doBreak == false)//Cycles through items in loot table until a Rare one is selected
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

        /// <summary>
        /// Based on the rarity level passed in, a loot table is retrieved in array form and
        /// applied to the character based on the values contained in the array. This text is
        /// recorded using a string builder and returned as a string to be displayed.
        /// </summary>
        public string lootEvent(character character, string rarity)
        {
            string[] lootArray;
            lootArray = this.getLoot(rarity,"Both");
            StringBuilder sb = new StringBuilder();

            if (lootArray[1]=="healing") //If the loot item is a healing item, character is healed or the item is saved for later
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
                        sb.AppendLine(character.getName() + " found a " + lootArray[0] + ". " + character.getName() + " is at full health so " + character.getPronounSub().ToLower() + " saves it for later.");
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
            else if (lootArray[1] == "explosive") //If loot item is an explosive, the character's explosive slot is filled assuming they don't already have one
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
            else //If loot item is a weapon, the character's appropriate values are changed to equip it, assuming they don't already have a better weapon
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


        /// <summary>
        /// 1 of 3 (if Classic) or 1 of 6 (if Realistic) effects is selected to be applied to
        /// a character to represent a potion effect. This takes care of any negative or positive
        /// changes the potion effect has and returns the result in string form.
        /// </summary>
        public string potionEvent(character character, Game game)
        {
            StringBuilder sb2 = new StringBuilder();
            int rand=0;
            if (game.Mode=="Realistic") rand = rng.randomInt(0, 5); //6 options if realistic
            else rand = rng.randomInt(0, 2); //3 options if classic

            if (rand == 0) //Health boost of 5 extra health
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

        /// <summary>
        /// For the sponsor screen, the type of item a character needs most is decided
        /// in order of most to least dire and returned as a string so the main form
        /// can make decisions based on the returned type.
        /// </summary>
        public string SponsorItemType(character character, Game game)
        {
            if (character.Health <= 8) //If character health is 8 or lower, they need to be healed
            {
                return "Healing";
            }
            else if (character.getWeaponName() == "") //If character has no weapon, they need one
            {
                return "Any Weapon";
            }
            else if (game.Mode=="Realistic" && character.Hunger <= 3) //If it's realistic mode and the character hunger is 3 or lower, they need to be fed
            {
                return "Hunger";
            }
            else if (character.HasExplosive==false) //If the character has no explosive, they could use one
            {
                return "Explosive";
            }
            else //If character needs none of the above, they get a weapon damage boost of 2
            {
                return "Boost";
            }
        }

    }
}
