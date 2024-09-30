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
            string[] csvLines = new string[5];
            string[] lootArray = new string[5];
            bool doBreak = false;
            int length, rand;
            
            if (type=="Weapon") csvLines = System.IO.File.ReadAllLines(@"loot.csv"); //If the method calls specifically for a weapon
            else
            {
                int randomType = rng.randomInt(0, 3);

                if (randomType == 0) //Read healing loot table csv file
                {
                    csvLines = System.IO.File.ReadAllLines(@"healloot.csv");
                }
                else //Read weapon loot table csv file
                {
                    csvLines = System.IO.File.ReadAllLines(@"loot.csv");
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

        public string getWeaponArticle(string weaponName)
        {
            char firstLetter = weaponName[0];

            if (firstLetter == 'a' || firstLetter == 'A' || firstLetter == 'e' || firstLetter == 'E' || firstLetter == 'i' || firstLetter == 'I' || firstLetter == 'o' || firstLetter == 'O' || firstLetter == 'u' || firstLetter == 'U') return "an";
            else return "a";
        }

        /// <summary>
        /// Based on the rarity level passed in, a loot table is retrieved in array form and
        /// applied to the character based on the values contained in the array. This text is
        /// recorded using a string builder and returned as a string to be displayed.
        /// </summary>
        public string lootEvent(character character, string rarity, Game game)
        {
            string[] lootArray;
            lootArray = this.getLoot(rarity,"Both");
            string prevWeapon = character.WeaponName;
            StringBuilder sb = new StringBuilder();

            if (lootArray[1]=="healing") //If the loot item is a healing item, character is healed or the item is saved for later
            {
                if (character.Health + Double.Parse(lootArray[2]) <= game.StartHealth)
                {
                    character.heal(Double.Parse(lootArray[2]), game, lootArray[0]);
                    sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + " and used it to heal up to " + character.Health + " health.");
                }
                else if (character.Health + Double.Parse(lootArray[2]) > game.StartHealth && character.HealSlotFilled == false)
                {
                    character.HealingAmount = Double.Parse(lootArray[2]);
                    character.HealingName = lootArray[0];
                    character.HealSlotFilled = true;
                    if (character.PronounSub=="They") 
                    {
                        sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + ". " + character.Name + " does not need it currently, so they save it for later.");
                    }
                    else
                    {
                        sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + ". " + character.Name + " does not need it currently, so " + character.PronounSub.ToLower() + " saves it for later.");
                    }
                    
                }
                else if (character.Health + Double.Parse(lootArray[2]) > game.StartHealth && character.HealSlotFilled == true && character.HealingAmount < Double.Parse(lootArray[2]))
                {
                    character.HealingAmount = Double.Parse(lootArray[2]);
                    character.HealingName = lootArray[0];
                    sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + ". " + character.Name + " replaced " + character.PronounPosAdj.ToLower() + " previous healing item with this superior one.");
                }
                else
                {
                    sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + ".");
                }
            }
            else if (lootArray[1] == "antidote") //If the loot item is an antidote
            {
                if (character.GetStatus("Poison") == true)
                {
                    sb.AppendLine(character.Name + " finds an antidote and uses it to cure " + character.PronounPosAdj.ToLower() + " Poison.");
                    character.RemoveStatus("Poison");
                }
                else if (character.GetStatus("Poison") == false && character.HasAntidote == false)
                {
                    sb.AppendLine(character.Name + " finds an antidote and saves it for later.");
                    character.HasAntidote = true;
                }
                else sb.AppendLine(character.Name + " finds an antidote.");
            }
            else if (lootArray[1] == "explosive") //If loot item is an explosive, the character's explosive slot is filled assuming they don't already have one
            {
                if (character.HasExplosive==false)
                {
                    character.HasExplosive = true;
                    sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + ".");
                }
                else
                {
                    sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + ".");
                }
            }
            else //If loot item is a weapon, the character's appropriate values are changed to equip it, assuming they don't already have a better weapon
            {
                if (character.WeaponName == "") //If character has no weapon they automatically take this
                {
                    character.WeaponName = lootArray[0];
                    character.OriginalWeaponName = lootArray[0];
                    character.WeaponAttack = Double.Parse(lootArray[2]);
                    character.WeaponType = lootArray[1];
                    character.WeaponStatus = lootArray[5];
                    sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + character.WeaponName + ".");
                }
                else if (character.WeaponAttack < Double.Parse(lootArray[2]) && character.WeaponName != "" && character.WeaponStatus=="None") //If character has weapon that is weaker than the loot they take this
                {
                    character.WeaponName = lootArray[0];
                    character.OriginalWeaponName = lootArray[0];
                    character.WeaponAttack = Double.Parse(lootArray[2]);
                    character.WeaponType = lootArray[1];
                    character.WeaponStatus = lootArray[5];
                    sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + ". " + character.PronounSub + " replaced " + character.PronounPosAdj.ToLower() + " " + prevWeapon + ".");
                }
                else if (character.WeaponAttack <= (Double.Parse(lootArray[2])/2) && character.WeaponName != "" && character.WeaponStatus != "None") //If character has weapon with a status and the loot has no status and the attack is at least 2 times stronger they take this
                {
                    character.WeaponName = lootArray[0];
                    character.OriginalWeaponName = lootArray[0];
                    character.WeaponAttack = Double.Parse(lootArray[2]);
                    character.WeaponType = lootArray[1];
                    character.WeaponStatus = lootArray[5];
                    sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + ". " + character.PronounSub + " replaced " + character.PronounPosAdj.ToLower() + " " + prevWeapon + ".");
                }
                else if (character.WeaponAttack < Double.Parse(lootArray[2]) && character.WeaponName != "" && character.WeaponStatus != "None" && lootArray[5] != "None") //If character has weapon with status and the loot has status they take the stronger one
                {
                    character.WeaponName = lootArray[0];
                    character.OriginalWeaponName = lootArray[0];
                    character.WeaponAttack = Double.Parse(lootArray[2]);
                    character.WeaponType = lootArray[1];
                    character.WeaponStatus = lootArray[5];
                    sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + ". " + character.PronounSub + " replaced " + character.PronounPosAdj.ToLower() + " " + prevWeapon + ".");
                }
                else //The loot is not better than what they have
                {
                    sb.AppendLine(character.Name + " found " + this.getWeaponArticle(lootArray[0]) + " " + lootArray[0] + ".");
                }
            }

            return sb.ToString();
        }


        /// <summary>
        /// 1 of 4 (if Classic) or 1 of 7 (if Realistic) effects is selected to be applied to
        /// a character to represent a potion effect. This takes care of any negative or positive
        /// changes the potion effect has and returns the result in string form.
        /// </summary>
        public string potionEvent(character character, Game game)
        {
            StringBuilder sb2 = new StringBuilder();
            int rand=0;

            if (game.Mode == "Realistic" && game.DoHunger == true) rand = rng.randomInt(0, 6); //7 options if realistic and hunger is enabled
            else if (game.Mode == "Realistic" && game.DoHunger == false) rand = rng.randomInt(0, 5); //6 options if realistic and hunger is disabled
            else rand = rng.randomInt(0, 3); //4 options if classic

            if (character.HasStatuses()==false && rand==3) //Ensures the healing status effects option only happens if character has any to begin with
            { 
                while (rand==3)
                {
                    if (game.Mode == "Realistic" && game.DoHunger == true) rand = rng.randomInt(0, 6);
                    else if (game.Mode == "Realistic" && game.DoHunger == false) rand = rng.randomInt(0, 5);
                    else rand = rng.randomInt(0, 2);
                }
            }

            if (rand == 0) //Health boost of 5 extra health
            {
                character.Health = 25;
                sb2.Append(character.Name + " felt all injuries heal, and even felt healthier than ever before. " + character.Name + " is now at 25 health.");               
            }
            else if (rand == 1) //Super strength
            {
                character.WeaponAttack = 6.5;
                character.WeaponType = "Unarmed";
                character.WeaponName = "";
                character.OriginalWeaponName = character.WeaponName;
                if (game.Mode=="Realistic") character.CombatLevel = Math.Round(((character.Speed + character.Strength) / 4), 2);
                sb2.Append(character.Name + " felt a wave of strength flow in. " + character.PronounSub + " is now stronger than before, and doesn't feel the need to use a weapon.");
            }
            else if (rand == 2) //Hurt 5 damage
            {
                character.hurt(5);
                sb2.Append(character.Name + " felt a horrible pain in " + character.PronounPosAdj.ToLower() + " " + rng.randomBodyPart() + ". This was clearly not a desirable outcome. " + character.Name + " took 5 damage.");
            }
            else if (rand == 3) //Cures all effects
            {
                character.ClearStatuses();
                sb2.Append(character.Name + " felt all " + character.PronounPosAdj.ToLower() + " ailments ease. " + character.Name + " was cured of all status effects.");
            }
            else if (rand == 4) //Super speed
            {
                character.Speed=10;
                character.CombatLevel = Math.Round(((character.Speed + character.Strength) / 4), 2);
                sb2.Append(character.Name + " suddenly felt as light as a feather, and is now super fast.");
            }
            else if (rand == 5) //Morality swap
            {
                if (character.Morality > 6) //If morality is 6 or higher
                {
                    character.Morality = 1;
                    sb2.Append(character.Name + " started seeing red and felt all sense of morality vanish.");
                }
                else if (character.Morality <= 6 && character.Morality >= 4) //If morality is between 4 and 6
                {                
                    character.Morality = 9;
                    sb2.Append(character.Name + " started feeling a warm fuzzy feeling and decided being morally grey wasn't the right path anymore.");
                
                }
                else //If morality is below 4
                {
                    character.Morality = 9;
                    sb2.Append(character.Name + " started feeling a warm fuzzy feeling and decided being villainous wasn't the right path anymore.");
                }
            }
            else if (rand == 6) //Full hunger
            {
                character.Hunger = 10;
                sb2.Append(character.Name + " felt " + character.PronounPosAdj.ToLower() + " hunger disappear, as if haven eaten a three-course meal.");
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
            int random;

            if (character.Health <= 5) //If character health is 5 or lower, they need to be healed
            {
                return "Healing";
            }
            else if (game.Mode == "Realistic" && character.Hunger <= 3 && game.DoHunger == true) //If it's realistic mode and the character hunger is 3 or lower, they need to be fed
            {
                return "Hunger";
            }

            else if (character.WeaponName == "") //If character has no weapon, they need one
            {
                return "Any Weapon";
            }
            else if (character.HasStatuses()==true) //If character has any status effects, clear them
            {
                return "HealStatuses";
            }
            else if (character.HasExplosive==false) //If the character has no explosive, they could use one
            {
                return "Explosive";
            }
            else //If character needs none of the above, they get a weapon damage boost of 2 or Weapon Status
            {
                if (character.WeaponStatus == "None") //Can only get status if the player does not already have one
                {
                    random = rng.randomInt(0, 2);
                    if (random == 0) return "Status";
                    else return "Boost";
                }
                else return "Boost";
            }
        }

    }
}
