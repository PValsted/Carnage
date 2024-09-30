using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{

    /// <summary>
    /// Takes multiple characters and simulates a battle between them, with dodging,
    /// fleeing, sparing, and healing as variables that can happen every turn. Different
    /// battle mechanics are dependent on which gamemode is being played. The sentences that
    /// reflect what happens each turn are generated in part randomly and based on the
    /// attacker's weapon type. A battle continues until only 1 character is alive or
    /// 1 or more characterss have been spared or have fled.
    /// </summary>
    public class Battle
    {
        int numPlayers = 0, rand=0;
        RNG rng = new RNG();
        List<character> battleList = new List<character>();

        /// <summary>
        /// Creates a battle instance with a default of 2 players
        /// </summary>
        public Battle()
        {
          this.numPlayers = 2;
        }

        /// <summary>
        /// Creates a battle instance with a field for number of players
        /// </summary>
        public Battle(int numPlayers) { 
            this.numPlayers = numPlayers;
        }

        /// <summary>
        /// Returns number of players
        /// </summary>
        public int getNumPlayers() { 
            return numPlayers;
        }

        /// <summary>
        /// Changes number of players to a number 2 through 4
        /// </summary>
        public void setNumPlayers(int numPlayers)
        {
            if (numPlayers == 2 || numPlayers == 3 || numPlayers==4)
                this.numPlayers = numPlayers;
            else this.numPlayers = 2;
        }

        /// <summary>
        /// Returns either "a" or "an" depending on the first letter of a weapon
        /// </summary>
        public string getWeaponArticle(character character)
        {
            char firstLetter = character.WeaponName[0];

            if (firstLetter == 'a' || firstLetter == 'A' || firstLetter == 'e' || firstLetter == 'E' || firstLetter == 'i' || firstLetter == 'I' || firstLetter == 'o' || firstLetter == 'O' || firstLetter == 'u' || firstLetter == 'U') return "an";
            else return "a";
        }

        /// <summary>
        /// Returns a sentence reflecting a character's turn in a battle. The string
        /// is generated as usually one of three options for that character's weapon type.
        /// </summary>
        public string getBattleText(character char1, character char2, string type)
        {
            StringBuilder sb2 = new StringBuilder();
            int random=0;

            if (type == "Unarmed") //If attacker is unarmed
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.Name + " punched " + char2.Name + " with " + char1.PronounPosAdj.ToLower() + " bare fists.");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.Name + " jumped into the air and punched " + char2.Name + " in the " + rng.randomBodyPart() + "!");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.Name + " kicked " + char2.Name + " in the " + rng.randomBodyPart() + ".");
                }
            }
            else if (type == "slash") //If attacker weapon type is slash
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.Name + " slashed " + char2.Name + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.Name + " used a spinning move to cut " + char2.Name + " in the " + rng.randomBodyPart() + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.Name + " caught " + char2.Name + " off guard and sliced across " + char2.PronounPosAdj.ToLower() + " " + rng.randomBodyPart() + ".");
                }
            }
            else if (type == "stab") //If attacker weapon type is stab
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.Name + " stabbed " + char2.Name + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.Name + " launched " + char1.PronounRefl.ToLower() + " at " + char2.Name + " and pierced " + char2.PronounPosAdj.ToLower() + " " + rng.randomBodyPart() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.Name + " started furiously trying to stab " + char2.Name + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + " and lands a hit.");
                }
            }
            else if (type == "slash/stab") //If attacker weapon type is slash/stab
            {
                random = rng.randomInt(1, 6);

                if (random == 1)
                {
                    sb2.Append(char1.Name + " stabbed " + char2.Name + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.Name + " launched " + char1.PronounRefl.ToLower() + " at " + char2.Name + " and pierced " + char2.PronounPosAdj.ToLower() + " " + rng.randomBodyPart() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.Name + " started furiously trying to stab " + char2.Name + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + " and lands a hit.");
                }
                else if (random == 4)
                {
                    sb2.Append(char1.Name + " slashed " + char2.Name + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
                else if (random == 5)
                {
                    sb2.Append(char1.Name + " used a spinning move to cut " + char2.Name + " in the " + rng.randomBodyPart() + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
                else if (random == 6)
                {
                    sb2.Append(char1.Name + " caught " + char2.Name + " off guard and sliced across " + char2.PronounPosAdj.ToLower() + " " + rng.randomBodyPart() + ".");
                }
            }
            else if (type == "crush") //If attacker weapon type is crush
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.Name + " dashed toward " + char2.Name + " and pounded " + char2.PronounObj.ToLower() + " in the " + rng.randomBodyPart() + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.Name + " swung " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + " with all " + char1.PronounPosAdj.ToLower() + " might and landed a hit on " + char2.Name + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.Name + " violently smashed " + char2.Name + "'s " + rng.randomBodyPart() + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
            }
            else if (type == "hand") //If attacker weapon type is hand
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.Name + " ran behind " + char2.Name + " and punched " + char2.PronounObj.ToLower() + " hard in the " + rng.randomBodyPart() + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.Name + " swung " + char1.PronounPosAdj.ToLower() + " fists at " + char2.Name + " while using " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.Name + " hit " + char2.Name + " with a volley of punches and pounded " + char2.PronounObj.ToLower() + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
            }
            else if (type == "bow") //If attacker weapon type is bow
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.Name + " shot " + char2.Name + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + " and barely hit.");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.Name + " drew back " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + " and fired straight into " + char2.Name + "'s " + rng.randomBodyPart() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.Name + " aimed at " + char2.Name + "'s " + rng.randomBodyPart() + " and landed a bullseye.");
                }
            }
            else if (type == "throwing") //If attacker weapon type is throwing
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.Name + " threw " + this.getWeaponArticle(char1) + " " + char1.WeaponName + ", which hit " + char2.Name + " in the " + rng.randomBodyPart() + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.Name + " concentrated on " + char1.PronounPosAdj.ToLower() + " aim and landed a direct hit on " + char2.Name + " using " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.Name + " took out " + this.getWeaponArticle(char1) + " " + char1.WeaponName + " and launched it at " + char2.Name + ".");
                }
            }
            else if (type == "gun") //If attacker weapon type is gun
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.Name + " aimed " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + " at " + char2.Name + " and fired a round, making contact with " + char2.PronounObj.ToLower() + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.Name + " drew " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + " and shot a volley of rounds at " + char2.Name + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.Name + " took cover and shot " + char2.Name + " with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + ".");
                }
            }
            else if (type == "special") //If attacker weapon type is special (different results for specific weapons that fit into no category)
            {
                if (char1.OriginalWeaponName == "flamethrower")
                {
                    sb2.Append(char1.Name + " used " + char1.PronounPosAdj.ToLower() + " flamethrower on " + char2.Name + ", engulfing " + char2.PronounObj.ToLower() + " in flames.");
                }
                else if (char1.OriginalWeaponName == "slingshot")
                {
                    sb2.Append(char1.Name + " drew back " + char1.PronounPosAdj.ToLower() + " slingshot and flung rocks at " + char2.Name + ".");
                }
                else if (char1.OriginalWeaponName == "blowgun")
                {
                    sb2.Append(char1.Name + " blew into " + char1.PronounPosAdj.ToLower() + " blowgun and shot darts into " + char2.Name + "'s " + rng.randomBodyPart() + ".");
                }
                else if (char1.OriginalWeaponName == "whip")
                {
                    sb2.Append(char1.Name + " cracked " + char1.PronounPosAdj.ToLower() + " whip and then got a hit on " + char2.Name + ".");
                }
                else if (char1.WeaponName == "fangs")
                {
                    sb2.Append(char1.Name + " pierced " + char2.Name + " in the " + rng.randomBodyPart() + " with its fangs.");
                }
                else if (char1.OriginalWeaponName == "Sorcerer's Staff")
                {
                    if (char1.WeaponStatus == "Burning") sb2.Append(char1.Name + " summoned a fireball with " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + " and launched it at " + char2.Name + ".");
                    else if (char1.WeaponStatus == "Poison") sb2.Append(char1.Name + " conjured a cloud of stingers using " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + " and fired it at " + char2.Name + ".");
                    else sb2.Append(char1.Name + " used " + char1.PronounPosAdj.ToLower() + " " + char1.WeaponName + " to barrage " + char2.Name + " with ice spikes.");
                }
                else if (char1.OriginalWeaponName == "Nightblood")
                {
                    random = rng.randomInt(1, 3);

                    if (random == 1) sb2.Append(char1.Name + " dashed forward using Nightblood's unnatural speed and pierced " + char2.Name + " in the " + rng.randomBodyPart() + ".");
                    else if (random == 2) sb2.Append(char1.Name + " summoned a horde of demonic arms from out of the ground using Nightblood and commanded them to claw at " + char2.Name + ".");
                    else sb2.Append(char1.Name + " uttered something in an ancient language, and Nightblood flew out of " + char1.PronounPosAdj.ToLower() + " hands and straight into " + char2.Name + "'s " + rng.randomBodyPart() + ".");
                }
            }
            else if (type == "Explosive") //If attacker weapon type is explosive
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.Name + " stepped back and threw " + char1.PronounPosAdj.ToLower() + " explosive at " + char2.Name + ", who got caught slightly in the blast radius.");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.Name + " took out " + char1.PronounPosAdj.ToLower() + " explosive and chucked threw it towards " + char2.Name + "'s " + rng.randomBodyPart() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.Name + " successfully hit " + char2.Name + " with an explosive, causing lots of damage.");
                }
            }

            return sb2.ToString();
        }

        /// <summary>
        /// Decides if a character loots a defeated character's weapon, and if so replaces all the appropriate values with the loser's
        /// </summary>
        public string WeaponLooter(character victor, character loser)
        {
            StringBuilder sbWL = new StringBuilder();

            if (victor.WeaponStatus == "None") //If victor's weapon doesn't have a status
            {
                if (victor.WeaponAttack < loser.WeaponAttack && victor.WeaponName != "" && loser.WeaponStatus == "None") //If defeated player's weapon is stronger than victor's weapon and the loser has no weapon status, they replace theirs with it
                {
                    sbWL.Append(victor.Name + " replaced " + victor.PronounPosAdj.ToLower() + " " + victor.WeaponName + " with " + loser.Name + "'s " + loser.WeaponName + ".");
                    victor.WeaponAttack = loser.WeaponAttack;
                    victor.WeaponName = loser.WeaponName;
                    victor.OriginalWeaponName = victor.WeaponName;
                    victor.WeaponType = loser.WeaponType;
                }
                else if (victor.WeaponAttack < loser.WeaponAttack && victor.WeaponName != "" && loser.WeaponStatus != "None") //If defeated player's weapon is stronger than victor's weapon and the loser has a weapon status, they replace theirs with it
                {
                    sbWL.Append(victor.Name + " replaced " + victor.PronounPosAdj.ToLower() + " " + victor.WeaponName + " with " + loser.Name + "'s " + loser.WeaponName + ".");
                    victor.WeaponAttack = loser.WeaponAttack;
                    victor.WeaponName = loser.WeaponName;
                    victor.OriginalWeaponName = victor.WeaponName;
                    victor.WeaponType = loser.WeaponType;
                    victor.WeaponStatus = loser.WeaponStatus;
                }
                else if (victor.WeaponName == "" && loser.WeaponStatus == "None") //If defeated player has weapon with no status and victor has no weapon, they pick up weapon
                {
                    sbWL.Append(victor.Name + " picked up " + loser.Name + "'s " + loser.WeaponName + ".");
                    victor.WeaponAttack = loser.WeaponAttack;
                    victor.WeaponName = loser.WeaponName;
                    victor.OriginalWeaponName = victor.WeaponName;
                    victor.WeaponType = loser.WeaponType;
                }
                else if (victor.WeaponName == "" && loser.WeaponStatus != "None") //If defeated player has weapon with a status and victor has no weapon, they pick up weapon
                {
                    sbWL.Append(victor.Name + " picked up " + loser.Name + "'s " + loser.WeaponName + ".");
                    victor.WeaponAttack = loser.WeaponAttack;
                    victor.WeaponName = loser.WeaponName;
                    victor.OriginalWeaponName = victor.WeaponName;
                    victor.WeaponType = loser.WeaponType;
                    victor.WeaponStatus = loser.WeaponStatus;
                }
                else return null;
            }
            else //If victor has a weapon with a status
            {
                if (victor.WeaponAttack <= ((loser.WeaponAttack)/2) && loser.WeaponStatus == "None") //The victor will only replace their weapon with a status with one without a status if said weapon is at least 2 times stronger than theirs
                {
                    sbWL.Append(victor.Name + " replaced " + victor.PronounPosAdj.ToLower() + " " + victor.WeaponName + " with " + loser.Name + "'s " + loser.WeaponName + ".");
                    victor.WeaponAttack = loser.WeaponAttack;
                    victor.WeaponName = loser.WeaponName;
                    victor.OriginalWeaponName = victor.WeaponName;
                    victor.WeaponType = loser.WeaponType;
                    victor.WeaponStatus = "None";
                }
                else if (victor.WeaponAttack < loser.WeaponAttack && loser.WeaponStatus != "None") //If both players have a weapon status the victor takes the stronger one
                {
                    sbWL.Append(victor.Name + " replaced " + victor.PronounPosAdj.ToLower() + " " + victor.WeaponName + " with " + loser.Name + "'s " + loser.WeaponName + ".");
                    victor.WeaponAttack = loser.WeaponAttack;
                    victor.WeaponName = loser.WeaponName;
                    victor.OriginalWeaponName = victor.WeaponName;
                    victor.WeaponType = loser.WeaponType;
                    victor.WeaponStatus = loser.WeaponStatus;
                }
                else return null;
            }

            return sbWL.ToString();
        }

        /// <summary>
        /// If a character has a status effect, applies the appropriate damage to the player and returns a message reflecting this
        /// </summary>
        public string StatusEffect(character char1, Game game)
        {
            StringBuilder sbSE = new StringBuilder();

            if (char1.GetStatus("Burning")==true)
            {
                rand = rng.randomInt(1, 2); //Character takes 1 or 2 damage
                char1.hurt(rand);
                sbSE.AppendLine("-- " + char1.Name + " took " + rand + " damage from Burning.");

                if (char1.Health > 0)
                {
                    rand = rng.randomInt(1, 10);
                    if (rand <= 3) //30% chance for burning to to clear
                    {
                        sbSE.AppendLine("-- " + char1.Name + "'s Burning was extinguished.");
                        char1.RemoveStatus("Burning");
                    }
                }
                else
                {
                    char1.IsAlive = false;
                }
            }

            if (char1.GetStatus("Poison")==true && char1.IsAlive==true)
            {
                rand = rng.randomInt(1, 10);
                if (rand <= 3) //30% chance to take 2 or 3 damage
                {
                    rand = rng.randomInt(2, 3);
                    char1.hurt(rand);
                    sbSE.AppendLine("-- " + char1.Name + " took " + rand + " damage from Poison.");
                }
                if (char1.Health <= 0)
                {
                    char1.IsAlive = false;
                }
            }

            return sbSE.ToString();
        }

        /// <summary>
        /// Simulates a battle between 2, 3, or 4 characters based on the number of players. Depending on the gamemode
        /// being played, it is decided what action a character will take on their turn and what order they take
        /// turns in. Health is modified based on how much damage an opposing character's weapon can cause, and unless
        /// the player flees or is spared, the battle ends when only 1 character is left standing. The events of the battle
        /// are returned as a string.
        /// </summary>
        public string BattleEvent(character char1, character char2, character char3, character char4, Game game) 
        {
            StringBuilder sb = new StringBuilder();
            bool crit = false, dodge = false, flee = false, doesFlee = false, useExplosive = false, spare = false, doesSpare = false, spot0Attack = true;

            if (this.getNumPlayers() == 2) //If battle is between 2 players, only first 2 passed in are added to the battle list
            {
                battleList.Add(char1);
                battleList.Add(char2);

                sb.AppendLine("A battle has broken out between " + battleList[0].Name + " and " + battleList[1].Name + ".");
            }

            if (this.getNumPlayers() == 3) //If battle is between 3 players, only first 3 passed in are added to the battle list
            {
                battleList.Add(char1);
                battleList.Add(char2);
                battleList.Add(char3);

                sb.AppendLine("A battle has broken out between " + battleList[0].Name + ", " + battleList[1].Name + ", and " + battleList[2].Name + ".");
            }

            if (this.getNumPlayers() == 4) //If battle is between 4 players, all 4 passed in are added to the battle list
            {
                battleList.Add(char1);
                battleList.Add(char2);
                battleList.Add(char3);
                battleList.Add(char4);

                sb.AppendLine("A battle has broken out between " + battleList[0].Name + ", " + battleList[1].Name + 
                    ", " + battleList[2].Name + ", and " + battleList[3].Name + ".");
            }

            if (game.IsRaining==true) //If anyone has Burning and it's raining, the status is cleared at the beginning of the battle
            {
                for (int i = 0; i < battleList.Count; i++) 
                {
                    if (battleList[i].GetStatus("Burning")==true)
                    {
                        battleList[i].RemoveStatus("Burning");
                        sb.AppendLine("-- " + battleList[i].Name + "'s Burning was extinguished from the rain.");
                    }
                }
            }

            while (battleList.Count > 1) //When a character is out of the battle, they are removed, and until there is only 1 left, the loop cycles turns
            {
                battleList = rng.shuffleList(battleList); //list is shuffled every turn to randomize who is taking a turn 

                crit = rng.critAttack();
                dodge = rng.dodge();
                flee = rng.flee();
                useExplosive = rng.useExplosive();
                spare = rng.spare();

                if (game.Mode == "Realistic") spot0Attack = rng.player1Attack(battleList[0], battleList[1]); //If the gamemode is Realistic, the decision on which character attacks this turn is skewed by combat level
                else spot0Attack = true; //Otherwise, the character in the first spot on the shuffled list attacks every time (pure randomness)

                if (battleList[0].Health > 0 && battleList[1].Health > 0) //If there is more than 1 character alive in the battle
                {
                    //Decides if player will flee
                    if (battleList[0].Health <= battleList[1].Health / 2 && flee == true )
                    {
                        if (game.Mode == "Classic") //Classic flee, 50-50
                        {
                            int random = rng.randomInt(0, 1);
                            if (random == 0)
                            {
                                if (battleList[0].GetStatus("Frozen") == true) doesFlee = false; //Player cannot flee if Frozen
                                else doesFlee = true;
                            }
                            else
                            {
                                doesFlee = false;
                            }
                        }
                        else if (game.Mode == "Realistic")
                        {
                            doesFlee = rng.advancedFlee(battleList[0], battleList[1]); //Realistic flee, based on player speeds
                        }

                        if (doesFlee == true && battleList.Count == 2) //If only 2 players are left, player successfully flees and battle ends
                        {
                            sb.AppendLine("-- " + battleList[0].Name + " attempted to flee and was successful.");
                            break;
                        }
                        else if (doesFlee == true && battleList.Count != 2) //If more than 2 players are left, player successfully flees and battle continues
                        {
                            sb.AppendLine("-- " + battleList[0].Name + " attempted to flee and was successful.");
                            battleList.Remove(battleList[0]);
                            continue;
                        }
                        else //Player fails to flee, but no damage is taken as punishment
                        {
                            if (game.DoFullBattles==true) sb.AppendLine("-- " + battleList[0].Name + " attempted to flee, but " + battleList[1].Name + " was too quick and cornered " + battleList[0].PronounObj.ToLower() + ".");
                        }

                    }

                    //Player uses healing item if they have one stored and their health is 8 or lower
                    if (battleList[0].Health<=8 && battleList[0].HealSlotFilled==true)
                    {
                        battleList[0].heal(battleList[0].HealingAmount, game, battleList[0].HealingName);
                        battleList[0].Health = Math.Round(battleList[0].Health, 2);
                        if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList[0].Name + " is at low health so " + battleList[0].PronounSub.ToLower()
                                                                      + " used " + battleList[0].PronounPosAdj.ToLower() + " " + battleList[0].HealingName + " to heal to " + battleList[0].Health.ToString() + " health.");
                        battleList[0].HealSlotFilled = false;
                    }

                    //If player is close to death and they are poisoned with an antidote, they use the antidote
                    if (battleList[0].Health<=8 && battleList[0].GetStatus("Poison") == true && battleList[0].HasAntidote == true)
                    {
                        battleList[0].RemoveStatus("Poison");
                        battleList[0].HasAntidote=false;
                        if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList[0].Name + " used " + battleList[0].PronounPosAdj.ToLower() + " antidote to cure " + battleList[0].PronounPosAdj.ToLower() + " poison.");
                    }

                    //Decides if attacked player will be spared
                    if (battleList[1].Health <=5 && spare==true) //If victim has 5 or less health and spare is true
                    {
                        if (game.Mode=="Classic") //Classic spare, 50-50
                        {
                            int random = rng.randomInt(0, 1);

                            if (random == 0)
                            {
                                doesSpare = true;
                            }
                            else
                            {
                                doesSpare = false;
                            }
                        }
                        else if (game.Mode == "Realistic")
                        {
                            doesSpare = rng.advancedSpare(battleList[0]); //Realistic spare, based on player Morality Level
                        }


                        if (doesSpare == true && battleList.Count == 2) //If only 2 players are left, attacker spares victim and battle ends
                        {
                            sb.AppendLine("-- " + battleList[0].Name + " saw " + battleList[1].Name + " was weak and decided to spare " + battleList[1].PronounPosAdj.ToLower() + " life." );
                            break;
                        }
                        else if (doesSpare == true && battleList.Count != 2) //If more than 2 players are left, attacker spares victim and battle continues
                        {
                            sb.AppendLine("-- " + battleList[0].Name + " saw " + battleList[1].Name + " was weak and decided to spare " + battleList[1].PronounPosAdj.ToLower() + " life, allowing " + battleList[1].PronounObj.ToLower() + " to escape the battle.");
                            battleList.Remove(battleList[1]);
                            continue;
                        }
                        else //Attacker does not spare victim
                        {
                            if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList[1].Name + " begged for " + battleList[0].Name + " to spare " + battleList[1].PronounPosAdj.ToLower() + " life, but " + battleList[0].PronounSub.ToLower() + " refused.");
                        }
                    }

                    //Decides whether player dodges
                    if (dodge == true)
                    {
                        if (crit == false) //Player dodges and does 2 damage in return
                        {
                            if (spot0Attack == true) //If classic mode or character 0 is stronger (realistic mode)
                            {
                                battleList[0].hurt(2);
                                battleList[0].Health = Math.Round(battleList[0].Health, 2);
                                if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList[1].Name + " dodged " + battleList[0].Name + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList[1], battleList[0], "Unarmed") + " " + battleList[0].Name + " is at " + battleList[0].Health + " health.");
                            }
                            else //If character 1 is stronger (realistic mode)
                            {
                                battleList[1].hurt(2);
                                battleList[1].Health = Math.Round(battleList[1].Health, 2);
                                if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList[0].Name + " dodged " + battleList[1].Name + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList[0], battleList[1], "Unarmed") + " " + battleList[1].Name + " is at " + battleList[1].Health + " health.");
                            }
                            
                        }
                        else //Player dodges and does a critical hit for 3 damage in return
                        {
                            if (spot0Attack == true) //If classic mode or character 0 is stronger (realistic mode)
                            {
                                battleList[0].hurt(3);
                                battleList[0].Health = Math.Round(battleList[0].Health, 2);
                                if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList[1].Name + " dodged " + battleList[0].Name + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList[1], battleList[0], "Unarmed") + " Critical hit! " + battleList[0].Name + " is at " + battleList[0].Health + " health.");
                            }
                            else //If character 1 is stronger (realistic mode)
                            {
                                battleList[1].hurt(3);
                                battleList[1].Health = Math.Round(battleList[1].Health, 2);
                                if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList[0].Name + " dodged " + battleList[1].Name + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList[0], battleList[0], "Unarmed") + " Critical hit! " + battleList[1].Name + " is at " + battleList[1].Health + " health.");
                            }
                        }
                    }
                    else if (dodge == false) //Player does not dodge
                    {
                        if (spot0Attack == true) //If classic mode or character 0 is stronger (realistic mode)
                        {
                            if (game.IsRaining == true) //If raining, there's a 10% chance a character misses their attack
                            {
                                rand = rng.randomInt(1, 10);
                                if (rand == 1) 
                                {
                                    sb.AppendLine("-- " + battleList[0].Name + " tried to attack " + battleList[1].Name + ", but the rain caused " + battleList[0].PronounObj.ToLower() + " to miss.");
                                    continue;
                                }
                            }

                            //Freeze takes effect
                            if (battleList[0].GetStatus("Freeze") == true)
                            {
                                rand = rng.randomInt(1, 10);
                                if (rand <= 2)
                                {
                                    sb.AppendLine("-- " + battleList[0].Name + " tried to attack " + battleList[1].Name + " and missed because of Freeze.");
                                    continue;
                                }
                            }

                            if (battleList[0].WeaponName == "") //If player does not have a weapon, they do an unarmed attack
                            {
                                if (useExplosive == true && battleList[0].HasExplosive == true) //Player is unarmed and uses explosive if value is true
                                {
                                    int damage = rng.explosionDamage();

                                    battleList[1].hurt(damage);
                                    battleList[1].Health = Math.Round(battleList[1].Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList[0], battleList[1], "Explosive") + " It did " + damage + " damage. " + battleList[1].Name + " is at " + battleList[1].Health + " health.");
                                    battleList[0].HasExplosive = false;
                                }
                                else if (crit == false) //Player does normal unarmed attack
                                {
                                    battleList[1].hurt(battleList[0].WeaponAttack);
                                    battleList[1].Health = Math.Round(battleList[1].Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("--- " + this.getBattleText(battleList[0], battleList[1], "Unarmed") + " " + battleList[1].Name + " is at " + battleList[1].Health + " health.");
                                }
                                else //Player does critical unarmed attack
                                {
                                    battleList[1].hurt(1.5 * battleList[0].WeaponAttack);
                                    battleList[1].Health = Math.Round(battleList[1].Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList[0], battleList[1], "Unarmed") + " Critical hit! " + battleList[1].Name + " is at " + battleList[1].Health + " health.");
                                }
                            }
                            else //If player does have a weapon, they attack based on their weapon type
                            {
                                if (useExplosive == true && battleList[0].HasExplosive == true) //Player is armed and uses explosive if value is true
                                {
                                    int damage = rng.explosionDamage();

                                    battleList[1].hurt(damage);
                                    battleList[1].Health = Math.Round(battleList[1].Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList[0], battleList[1], "Explosive") + " It did " + damage + " damage. " + battleList[1].Name + " is at " + battleList[1].Health + " health.");
                                    battleList[0].HasExplosive = false;
                                }
                                else if (crit == false) //Player is armed and attacks based on their weapon type
                                {
                                    if (game.Mode=="Classic") battleList[1].hurt((battleList[0].WeaponAttack)); //Classic mode attack
                                    else battleList[1].hurt((battleList[0].WeaponAttack)+battleList[0].Strength/4); //Realistic mode attack, weapon attack + some strength

                                    battleList[1].Health = Math.Round(battleList[1].Health, 2);

                                    if (game.DoFullBattles == true) sb.AppendLine("--- " + this.getBattleText(battleList[0], battleList[1], battleList[0].WeaponType) + " " + battleList[1].Name + " is at " + battleList[1].Health + " health.");

                                    if (battleList[0].WeaponStatus != "None" && battleList[1].GetStatus(battleList[0].WeaponStatus) == false && battleList[1].Health > 0) //If attacker has a weapon that causes a status effect and the receiver doesn't already have it, the effect is afflicted
                                    {
                                        battleList[1].AddStatus(battleList[0].WeaponStatus);

                                        if (battleList[1].GetStatus("Freeze") == true && game.Mode == "Realistic") battleList[1].Speed -= 2; //If effect is Freeze the character's speed is lowered by 2

                                        if (game.DoFullBattles == true && (game.IsRaining == false || (game.IsRaining == true && battleList[0].WeaponStatus != "Burning"))) sb.AppendLine("-- " + battleList[1].Name + " was afflicted with " + battleList[0].WeaponStatus + ".");
                                        else if (battleList[1].GetStatus("Burning") == true && game.IsRaining == true) battleList[1].RemoveStatus("Burning"); //If raining, Burning is removed
                                    }
                                    
                                }
                                else //Player is armed and does critical attack based on their weapon type
                                {
                                    if (game.Mode == "Classic") battleList[1].hurt(1.5*(battleList[0].WeaponAttack)); //Classic mode attack
                                    else battleList[1].hurt(1.5*((battleList[0].WeaponAttack) + battleList[0].Strength / 4)); //Realistic mode attack, weapon attack + some strength

                                    battleList[1].Health = Math.Round(battleList[1].Health, 2);

                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList[0], battleList[1], battleList[0].WeaponType) + " Critical hit! " + battleList[1].Name + " is at " + battleList[1].Health + " health.");

                                    if (battleList[0].WeaponStatus != "None" && battleList[1].GetStatus(battleList[0].WeaponStatus) == false && battleList[1].Health > 0) //If attacker has a weapon that causes a status effect and the receiver doesn't already have it, the effect is afflicted
                                    {
                                        battleList[1].AddStatus(battleList[0].WeaponStatus);

                                        if (battleList[1].GetStatus("Freeze") == true && game.Mode == "Realistic") battleList[1].Speed -= 2; //If effect is Freeze the character's speed is lowered by 2

                                        if (game.DoFullBattles == true && (game.IsRaining == false || (game.IsRaining == true && battleList[0].WeaponStatus != "Burning"))) sb.AppendLine("-- " + battleList[1].Name + " was afflicted with " + battleList[0].WeaponStatus + ".");
                                        else if (battleList[1].GetStatus("Burning") == true && game.IsRaining == true) battleList[1].RemoveStatus("Burning"); //If raining, Burning is removed
                                    }                       
                                }  
                            }
                            if (battleList[0].HasStatuses() == true) sb.Append(StatusEffect(battleList[0], game));

                            if (battleList[0].IsAlive == false && battleList[1].IsAlive == true) //If character dies to status effect, this ensures the other player doesn't get credit from the kill
                            {
                                if (battleList[0].GetStatus("Poison") == true) sb.AppendLine("- " + battleList[0].Name + " couldn't find an antidote and died to Poison.");
                                else if (battleList[0].GetStatus("Burning") == true) sb.AppendLine("- " + battleList[0].Name + " burnt to death.");

                                battleList.Remove(battleList[0]);
                                continue;
                            }
                            else if (battleList[0].IsAlive == false && battleList[1].IsAlive == false) //If both characters die during turn, the one who did the killing blow before dying still gets credit
                            {
                                battleList[0].Kills++;
                                battleList[0].AddKill(battleList[1].Name);
                                sb.AppendLine("- " + battleList[1].Name + " has been defeated by " + battleList[0].Name + ". ");

                                if (battleList[0].GetStatus("Poison") == true) sb.AppendLine("- " + battleList[0].Name + " couldn't find an antidote and died to Poison.");
                                else if (battleList[0].GetStatus("Burning") == true) sb.AppendLine("- " + battleList[0].Name + " burnt to death.");

                                battleList.Remove(battleList[0]);
                                continue;
                            }

                        }
                        else //If character 1 is stronger (realistic mode)
                        {
                            if (game.IsRaining == true) //If raining, there's a 10% chance a character misses their attack
                            {
                                rand = rng.randomInt(1, 10);
                                if (rand == 1)
                                {
                                    sb.AppendLine("-- " + battleList[1].Name + " tried to attack " + battleList[0].Name + ", but the rain caused " + battleList[1].PronounObj.ToLower() + " to miss.");
                                    continue;
                                }
                            }

                            //Freeze takes effect
                            if (battleList[1].GetStatus("Freeze") == true)
                            {
                                rand = rng.randomInt(1, 10);
                                if (rand <= 2)
                                {
                                    sb.AppendLine("-- " + battleList[1].Name + " tried to attack " + battleList[0].Name + " and missed because of Freeze.");
                                    continue;
                                }
                            }

                            if (battleList[1].WeaponName == "") //If player does not have a weapon, they do an unarmed attack
                            {
                                if (useExplosive == true && battleList[1].HasExplosive == true) //Player is unarmed and uses explosive if value is true
                                {
                                    int damage = rng.explosionDamage();

                                    battleList[0].hurt(damage);
                                    battleList[0].Health = Math.Round(battleList[0].Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList[1], battleList[0], "Explosive") + " It did " + damage + " damage. " + battleList[0].Name + " is at " + battleList[0].Health + " health.");
                                    battleList[1].HasExplosive = false;
                                }
                                else if (crit == false) //Player does normal unarmed attack
                                {
                                    battleList[0].hurt(battleList[1].WeaponAttack);
                                    battleList[0].Health = Math.Round(battleList[0].Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("--- " + this.getBattleText(battleList[1], battleList[0], "Unarmed") + " " + battleList[0].Name + " is at " + battleList[0].Health + " health.");
                                }
                                else //Player does critical unarmed attack
                                {
                                    battleList[0].hurt(1.5 * battleList[1].WeaponAttack);
                                    battleList[0].Health = Math.Round(battleList[0].Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList[1], battleList[0], "Unarmed") + " Critical hit! " + battleList[0].Name + " is at " + battleList[0].Health + " health.");
                                }
                            }
                            else //If player does have a weapon, they attack based on their weapon type
                            {
                                if (useExplosive == true && battleList[1].HasExplosive == true) //Player is armed and uses explosive if value is true
                                {
                                    int damage = rng.explosionDamage();

                                    battleList[0].hurt(damage);
                                    battleList[0].Health = Math.Round(battleList[0].Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList[1], battleList[0], "Explosive") + " It did " + damage + " damage. " + battleList[0].Name + " is at " + battleList[0].Health + " health.");
                                    battleList[1].HasExplosive = false;
                                }
                                else if (crit == false) //Player is armed and attacks based on their weapon type
                                {
                                    if (game.Mode == "Classic") battleList[0].hurt((battleList[1].WeaponAttack)); //Classic mode attack
                                    else battleList[0].hurt((battleList[1].WeaponAttack) + battleList[1].Strength / 4); //Realistic mode attack, weapon attack + some strength

                                    battleList[0].Health = Math.Round(battleList[0].Health, 2);

                                    if (game.DoFullBattles == true) sb.AppendLine("--- " + this.getBattleText(battleList[1], battleList[0], battleList[1].WeaponType) + " " + battleList[0].Name + " is at " + battleList[0].Health + " health.");

                                    if (battleList[1].WeaponStatus != "None" && battleList[0].GetStatus(battleList[1].WeaponStatus) == false && battleList[0].Health > 0) //If attacker has a weapon that causes a status effect and the receiver doesn't already have it, the effect is afflicted
                                    {
                                        battleList[0].AddStatus(battleList[1].WeaponStatus);

                                        if (battleList[0].GetStatus("Freeze") == true && game.Mode=="Realistic") battleList[0].Speed -= 2; //If effect is Freeze the character's speed is lowered by 2

                                        if (game.DoFullBattles == true && (game.IsRaining == false || (game.IsRaining == true && battleList[1].WeaponStatus != "Burning"))) sb.AppendLine("-- " + battleList[0].Name + " was afflicted with " + battleList[1].WeaponStatus + ".");
                                        else if (battleList[0].GetStatus("Burning") == true && game.IsRaining == true) battleList[0].RemoveStatus("Burning"); //If raining, Burning is removed
                                    }
                                }
                                else //Player is armed and does critical attack based on their weapon type
                                {
                                    if (game.Mode == "Classic") battleList[0].hurt((1.5*battleList[1].WeaponAttack)); //Classic mode attack
                                    else battleList[0].hurt(1.5 * ((battleList[1].WeaponAttack) + battleList[1].Strength / 4)); //Realistic mode attack, weapon attack + some strength

                                    battleList[0].Health = Math.Round(battleList[0].Health, 2);

                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList[1], battleList[0], battleList[1].WeaponType) + " Critical hit! " + battleList[0].Name + " is at " + battleList[0].Health + " health.");

                                    if (battleList[1].WeaponStatus != "None" && battleList[0].GetStatus(battleList[1].WeaponStatus) == false && battleList[0].Health > 0) //If attacker has a weapon that causes a status effect and the receiver doesn't already have it, the effect is afflicted
                                    {
                                        battleList[0].AddStatus(battleList[1].WeaponStatus);

                                        if (battleList[0].GetStatus("Freeze") == true && game.Mode == "Realistic") battleList[0].Speed -= 2; //If effect is Freeze the character's speed is lowered by 2

                                        if (game.DoFullBattles == true && (game.IsRaining == false || (game.IsRaining == true && battleList[1].WeaponStatus != "Burning"))) sb.AppendLine("-- " + battleList[0].Name + " was afflicted with " + battleList[1].WeaponStatus + ".");
                                        else if (battleList[0].GetStatus("Burning") == true && game.IsRaining == true) battleList[0].RemoveStatus("Burning"); //If raining, Burning is removed
                                    }
                                }
                            }

                            if (battleList[1].HasStatuses() == true) sb.Append(StatusEffect(battleList[1], game));

                            if (battleList[1].IsAlive == false && battleList[0].IsAlive == true) //If character dies to status effect, this ensures the other player doesn't get credit from the kill
                            {
                                if (battleList[1].GetStatus("Poison") == true) sb.AppendLine("- " + battleList[1].Name + " couldn't find an antidote and died to Poison.");
                                else if (battleList[1].GetStatus("Burning") == true) sb.AppendLine("- " + battleList[1].Name + " burnt to death.");

                                battleList.Remove(battleList[1]);
                                continue;
                            }
                            else if (battleList[1].IsAlive == false && battleList[0].IsAlive == false) //If both characters die during turn, the one who did the killing blow before dying still gets credit
                            {
                                battleList[1].Kills++;
                                battleList[1].AddKill(battleList[0].Name);
                                sb.AppendLine("- " + battleList[0].Name + " has been defeated by " + battleList[1].Name + ". ");

                                if (battleList[1].GetStatus("Poison") == true) sb.AppendLine("- " + battleList[1].Name + " couldn't find an antidote and died to Poison.");
                                else if (battleList[1].GetStatus("Burning") == true) sb.AppendLine("- " + battleList[1].Name + " burnt to death.");

                                battleList.Remove(battleList[1]);
                                continue;
                            }
                        }
                    }
                } //End character's turn

                //Happens after the character's turn if the character they are facing has been defeated, has fled, or has been spared
                if (battleList[1].IsAlive == false) //If player 1 is defeated
                {
                    battleList[0].Kills++;
                    battleList[0].AddKill(battleList[1].Name);
                    sb.Append("- " + battleList[1].Name + " has been defeated by " + battleList[0].Name + ". ");

                    if (battleList[1].WeaponType != "Unarmed") //If defeated player has a weapon
                    {
                        sb.AppendLine(WeaponLooter(battleList[0], battleList[1]));
                    }
                    else sb.AppendLine();

                    //Decides if loser's healing item will be looted
                    if (battleList[1].HealSlotFilled==true && battleList[0].Health <= game.StartHealth)
                    {
                        if ((battleList[0].Health + battleList[1].HealingAmount) <= (game.StartHealth-1.5)) //If player can benefit from healing in the moment they do
                        {
                            battleList[0].heal(battleList[1].HealingAmount, game, battleList[1].HealingName);
                            sb.AppendLine("-- " + battleList[0].Name + " healed to " + battleList[0].Health + " health using " + battleList[1].Name + "'s " + battleList[1].HealingName + ".");
                        }
                        else if ((battleList[0].Health + battleList[1].HealingAmount) > (game.StartHealth - 1.5) && battleList[0].HealSlotFilled==false) //If player has an open healing slot they store for later
                        {
                            battleList[0].HealingName = battleList[1].HealingName;
                            battleList[0].HealingAmount = battleList[1].HealingAmount;
                            battleList[0].HealSlotFilled = true;
                            sb.AppendLine("-- " + battleList[0].Name + " took " + battleList[1].Name + "'s " + battleList[1].HealingName + " and saved it for later.");
                        }
                    }
                    
                    //Decides if loser's antidote will be looted
                    if (battleList[0].HasAntidote==false && battleList[1].HasAntidote==true)
                    {
                        if (battleList[0].GetStatus("Poison")==true) //If player has poison they cure it
                        {
                            battleList[0].RemoveStatus("Poison");
                            sb.AppendLine("-- " + battleList[0].Name + " used " + battleList[1].Name + "'s antidote to cure " + battleList[0].PronounPosAdj.ToLower() + " poison.");
                        }
                        else //If player doesn't have poison they store it for later
                        {
                            battleList[0].HasAntidote = true;
                            sb.AppendLine("-- " + battleList[0].Name + " took " + battleList[1].Name + "'s antidote and saved it for later.");
                        }
                    }

                    battleList.Remove(battleList[1]); //Character is removed from the list
                }               
                else if (battleList[0].IsAlive == false) //If character 0 is defeated
                {
                    battleList[1].Kills++;
                    battleList[1].AddKill(battleList[0].Name);
                    sb.Append("- " + battleList[0].Name + " has been defeated by " + battleList[1].Name + ". ");
                    if (battleList[0].WeaponType != "Unarmed") //If defeated player has a weapon
                    {
                        sb.AppendLine(WeaponLooter(battleList[1], battleList[0]));
                    }
                    else sb.AppendLine();

                    //Decides if loser's healing item will be looted
                    if (battleList[0].HealSlotFilled == true && battleList[1].Health <= game.StartHealth)
                    {
                        if ((battleList[1].Health + battleList[0].HealingAmount) <= (game.StartHealth - 1.5)) //If player can benefit from healing in the moment they do
                        {
                            battleList[1].heal(battleList[0].HealingAmount, game, battleList[0].HealingName);
                            sb.AppendLine("-- " + battleList[1].Name + " healed to " + battleList[1].Health + " health using " + battleList[0].Name + "'s " + battleList[0].HealingName + ".");
                        }
                        else if ((battleList[1].Health + battleList[0].HealingAmount) > (game.StartHealth - 1.5) && battleList[1].HealSlotFilled == false) //If player has an open healing slot they store for later
                        {
                            battleList[1].HealingName = battleList[0].HealingName;
                            battleList[1].HealingAmount = battleList[0].HealingAmount;
                            battleList[1].HealSlotFilled = true;
                            sb.AppendLine("-- " + battleList[1].Name + " took " + battleList[0].Name + "'s " + battleList[0].HealingName + " and saved it for later.");
                        }
                    }

                    //Decides if loser's antidote will be looted
                    if (battleList[1].HasAntidote == false && battleList[0].HasAntidote == true)
                    {
                        if (battleList[1].GetStatus("Poison") == true) //If player has poison they cure it
                        {
                            battleList[1].RemoveStatus("Poison");
                            sb.AppendLine("-- " + battleList[1].Name + " used " + battleList[0].Name + "'s antidote to cure " + battleList[1].PronounPosAdj.ToLower() + " poison.");
                        }
                        else //If player doesn't have poison they store it for later
                        {
                            battleList[1].HasAntidote = true;
                            sb.AppendLine("-- " + battleList[1].Name + " took " + battleList[0].Name + "'s antidote and saved it for later.");
                        }
                    }

                    battleList.Remove(battleList[0]); //Character is removed from the list
                }
            }

            if (battleList[0].Health == 0) battleList.Remove(battleList[0]); //If character dies from status effect ensures the appropriate final message is displayed

            if (battleList.Count == 1) //If only one player remains, battle is over
            {
                if (battleList[0].Kills == 1) //If victor has 1 kill
                {
                    sb.AppendLine("*** " + battleList[0].Name + " has emerged victorious with " + battleList[0].Health +
                                  " health remaining and " + battleList[0].Kills + " kill. ***");
                }
                else //If victor has more than 1 kill
                {
                    sb.AppendLine("*** " + battleList[0].Name + " has emerged victorious with " + battleList[0].Health +
                                  " health remaining and " + battleList[0].Kills + " kills. ***");
                }
            }
            else if (battleList.Count == 0) //If battle ends with no survivors
            {
                sb.AppendLine("*** The battle ended with no survivors. ***");
            }
            else //If battle ends because one or more players fled
            {
                sb.AppendLine("*** The battle ended with " + battleList[0].Name + " at " + battleList[0].Health +
                                 " health and " + battleList[1].Name + " at " + battleList[1].Health +
                                 " health. ***");
            }

            //If poison was not cured during the battle any surviving players cure it now if they have the means to do so
            for (int i = 0; i < battleList.Count; i++)
            {
                if (battleList[i].GetStatus("Poison") == true && battleList[i].HasAntidote == true)
                {
                    battleList[i].RemoveStatus("Poison");
                    battleList[i].HasAntidote = false;
                    if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList[i].Name + " used " + battleList[i].PronounPosAdj.ToLower() + " antidote to cure " + battleList[i].PronounPosAdj.ToLower() + " poison.");
                }
            }

            rand = rng.randomInt(1, 2); //50% chance for Freeze to wear off at end of battle
            if (rand == 1)
            {
                for (int i = 0; i < battleList.Count; i++) 
                { 
                    if (battleList[i].GetStatus("Freeze")==true)
                    {
                        battleList[i].RemoveStatus("Freeze");
                        sb.AppendLine("-- " + battleList[i].Name + "'s Freeze wore off.");
                        battleList[i].Speed = battleList[i].StartSpeed; //Speed goes back to what it originally was
                    }
                }
            }

            battleList.Clear();

            return sb.ToString();
        }

        /// <summary>
        /// Simulates a battle between a character and an NPC. This is the same as a normal
        /// battle event, except characters can't flee or be spared. The winner cannot pick up
        /// the loser's weapon and a kill is not given to them.
        /// </summary>
        public string NPCBattleEvent(character char1, character char2, Game game, bool allowLooting)
        {

            StringBuilder sb3 = new StringBuilder();
            bool crit = false, dodge = false,  useExplosive = false;

            battleList.Add(char1);
            battleList.Add(char2);

            sb3.AppendLine("A battle has broken out between " + battleList[0].Name + " and " + battleList[1].Name + ".");

            while (battleList.Count > 1) //When a character is out of the battle, they are removed, and until there is only 1 left, the loop cycles turns
            {
                battleList = rng.shuffleList(battleList);

                crit = rng.critAttack();
                dodge = rng.dodge();
                useExplosive = rng.useExplosive();

                if (battleList[1].IsAlive == true) //If both characters are alive at the beginning of the turn
                {
                    //Player uses healing item if they have one stored and their health is 8 or lower
                    if (battleList[0].Health <= 8 && battleList[0].HealSlotFilled == true)
                    {
                        battleList[0].heal(battleList[0].HealingAmount, game, battleList[0].HealingName);
                        if (game.DoFullBattles == true) sb3.AppendLine("-- " + battleList[0].Name + " is at low health so " + battleList[0].PronounSub.ToLower()
                                                                       + " used " + battleList[0].PronounPosAdj.ToLower() + " " + battleList[0].HealingName + " to heal to " + battleList[0].Health.ToString() + " health.");
                        battleList[0].HealSlotFilled = false;
                    }

                    //If player is close to death and they are poisoned with an antidote, they use the antidote
                    if (battleList[0].Health <= 8 && battleList[0].GetStatus("Poison") == true && battleList[0].HasAntidote == true)
                    {
                        battleList[0].RemoveStatus("Poison");
                        battleList[0].HasAntidote = false;
                        if (game.DoFullBattles == true) sb3.AppendLine("-- " + battleList[0].Name + " used " + battleList[0].PronounPosAdj.ToLower() + " antidote to cure " + battleList[0].PronounPosAdj.ToLower() + " poison.");
                    }

                    //Decides whether player dodges
                    if (dodge == true)
                    {
                        if (crit == false) //Player dodges and does 2 damage in return
                        {
                            battleList[0].hurt(2);
                            battleList[0].Health = Math.Round(battleList[0].Health, 2);
                            if (game.DoFullBattles == true) sb3.AppendLine("-- " + battleList[1].Name + " dodged " + battleList[0].Name + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList[1], battleList[0], battleList[1].WeaponType) + " " + battleList[0].Name + " is at " + battleList[0].Health + " health.");
                        }
                        else //Player dodges and does a critical hit for 3 damage in return
                        {
                            battleList[0].hurt(3);
                            battleList[0].Health = Math.Round(battleList[0].Health, 2);
                            if (game.DoFullBattles == true) sb3.AppendLine("-- " + battleList[1].Name + " dodged " + battleList[0].Name + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList[1], battleList[0], battleList[1].WeaponType) + " Critical hit! " + battleList[0].Name + " is at " + battleList[0].Health + " health.");
                        }
                    }
                    else if (dodge == false) //Player does not dodge
                    {
                        if (game.IsRaining == true) //If raining, there's a 10% chance a character misses their attack
                        {
                            rand = rng.randomInt(1, 10);
                            if (rand == 1)
                            {
                                sb3.AppendLine("-- " + battleList[0].Name + " tried to attack " + battleList[1].Name + ", but the rain caused " + battleList[0].PronounObj.ToLower() + " to miss.");
                                continue;
                            }
                        }

                        //Freeze takes effect
                        if (battleList[0].GetStatus("Freeze") == true)
                        {
                            rand = rng.randomInt(1, 10);
                            if (rand <= 2)
                            {
                                sb3.AppendLine("-- " + battleList[0].Name + " tried to attack " + battleList[1].Name + " and missed because of Freeze.");
                                continue;
                            }
                        }

                        if (battleList[0].WeaponName == "") //If player does not have a weapon, they do an unarmed attack
                        {
                            if (useExplosive == true && battleList[0].HasExplosive == true) //Player is unarmed and uses explosive if value is true
                            {
                                int damage = rng.explosionDamage();

                                battleList[1].hurt(damage);
                                battleList[1].Health = Math.Round(battleList[1].Health, 2);
                                if (game.DoFullBattles == true) sb3.AppendLine("-- " + this.getBattleText(battleList[0], battleList[1], "Explosive") + " It did " + damage + " damage. " + battleList[1].Name + " is at " + battleList[1].Health + " health.");
                                battleList[0].HasExplosive = false;
                            }
                            else if (crit == false) //Player does normal unarmed attack
                            {
                                battleList[1].hurt(battleList[0].WeaponAttack);
                                battleList[1].Health = Math.Round(battleList[1].Health, 2);
                                if (game.DoFullBattles == true) sb3.AppendLine("--- " + this.getBattleText(battleList[0], battleList[1], "Unarmed") + " " + battleList[1].Name + " is at " + battleList[1].Health + " health.");
                            }
                            else //Player does critical unarmed attack
                            {
                                battleList[1].hurt(1.5 * battleList[0].WeaponAttack);
                                battleList[1].Health = Math.Round(battleList[1].Health, 2);
                                if (game.DoFullBattles == true) sb3.AppendLine("-- " + this.getBattleText(battleList[0], battleList[1], "Unarmed") + " Critical hit! " + battleList[1].Name + " is at " + battleList[1].Health + " health.");
                            }
                        }
                        else //If player does have a weapon, they attack based on their weapon type
                        {
                            if (useExplosive == true && battleList[0].HasExplosive == true) //Player is armed and uses explosive if value is true
                            {
                                int damage = rng.explosionDamage();

                                battleList[1].hurt(damage);
                                battleList[1].Health = Math.Round(battleList[1].Health, 2);
                                if (game.DoFullBattles == true) sb3.AppendLine("-- " + this.getBattleText(battleList[0], battleList[1], "Explosive") + " It did " + damage + " damage. " + battleList[1].Name + " is at " + battleList[1].Health + " health.");
                                battleList[0].HasExplosive = false;
                            }
                            else if (crit == false) //Player is armed and attacks based on their weapon type
                            {
                                battleList[1].hurt((battleList[0].WeaponAttack));
                                battleList[1].Health = Math.Round(battleList[1].Health, 2);

                                if (game.DoFullBattles == true) sb3.AppendLine("--- " + this.getBattleText(battleList[0], battleList[1], battleList[0].WeaponType) + " " + battleList[1].Name + " is at " + battleList[1].Health + " health.");

                                if (battleList[0].WeaponStatus != "None" && battleList[1].GetStatus(battleList[0].WeaponStatus) == false && battleList[1].Health > 0) //If attacker has a weapon that causes a status effect and the receiver doesn't already have it, the effect is afflicted
                                {
                                    battleList[1].AddStatus(battleList[0].WeaponStatus);

                                    if (battleList[1].GetStatus("Freeze") == true && game.Mode == "Realistic") battleList[1].Speed -= 2; //If effect is Freeze the character's speed is lowered by 2

                                    if (game.DoFullBattles == true && (game.IsRaining == false || (game.IsRaining == true && battleList[0].WeaponStatus != "Burning"))) sb3.AppendLine("-- " + battleList[1].Name + " was afflicted with " + battleList[0].WeaponStatus + ".");
                                    else if (battleList[1].GetStatus("Burning") == true && game.IsRaining == true) battleList[1].RemoveStatus("Burning"); //If raining, Burning is removed
                                }
    
                            }
                            else //Player is armed and does critical attack based on their weapon type
                            {
                                battleList[1].hurt(1.5 * (battleList[0].WeaponAttack));
                                battleList[1].Health = Math.Round(battleList[1].Health, 2);

                                if (game.DoFullBattles == true) sb3.AppendLine("-- " + this.getBattleText(battleList[0], battleList[1], battleList[0].WeaponType) + " Critical hit! " + battleList[1].Name + " is at " + battleList[1].Health + " health.");

                                if (battleList[0].WeaponStatus != "None" && battleList[1].GetStatus(battleList[0].WeaponStatus) == false && battleList[1].Health > 0) //If attacker has a weapon that causes a status effect and the receiver doesn't already have it, the effect is afflicted
                                {
                                    battleList[1].AddStatus(battleList[0].WeaponStatus);

                                    if (battleList[1].GetStatus("Freeze") == true && game.Mode == "Realistic") battleList[1].Speed -= 2; //If effect is Freeze the character's speed is lowered by 2

                                    if (game.DoFullBattles == true && (game.IsRaining == false || (game.IsRaining == true && battleList[0].WeaponStatus != "Burning"))) sb3.AppendLine("-- " + battleList[1].Name + " was afflicted with " + battleList[0].WeaponStatus + ".");
                                    else if (battleList[1].GetStatus("Burning") == true && game.IsRaining == true) battleList[1].RemoveStatus("Burning"); //If raining, Burning is removed
                                }
                            }
                        }
                    }
                }

                if (battleList[1].IsAlive == false) //If the attacked player is dead
                {
                    sb3.Append("- " + battleList[1].Name + " has been defeated. ");

                    if (allowLooting == true && battleList[0].IsNPC == false) sb3.AppendLine(this.WeaponLooter(battleList[0], battleList[1])); //If player is allowed to take the NPC's weapon they attempt to
                    else sb3.AppendLine();

                    //Decides if loser's healing item will be looted
                    if (battleList[1].HealSlotFilled == true && battleList[0].Health <= game.StartHealth && allowLooting == true && battleList[0].IsNPC == false)
                    {
                        if ((battleList[0].Health + battleList[1].HealingAmount) <= (game.StartHealth - 1.5)) //If player can benefit from healing in the moment they do
                        {
                            battleList[0].heal(battleList[1].HealingAmount, game, battleList[1].HealingName);
                            sb3.AppendLine("-- " + battleList[0].Name + " healed to " + battleList[0].Health + " health using " + battleList[1].Name + "'s " + battleList[1].HealingName + ".");
                        }
                        else if ((battleList[0].Health + battleList[1].HealingAmount) > (game.StartHealth - 1.5) && battleList[0].HealSlotFilled == false) //If player has an open healing slot they store for later
                        {
                            battleList[0].HealingName = battleList[1].HealingName;
                            battleList[0].HealingAmount = battleList[1].HealingAmount;
                            battleList[0].HealSlotFilled = true;
                            sb3.AppendLine("-- " + battleList[0].Name + " took " + battleList[1].Name + "'s " + battleList[1].HealingName + " and saved it for later.");
                        }
                    }

                    //Decides if loser's antidote will be looted
                    if (battleList[0].HasAntidote == false && battleList[1].HasAntidote == true && allowLooting == true && battleList[0].IsNPC == false)
                    {
                        if (battleList[0].GetStatus("Poison") == true) //If player has poison they cure it
                        {
                            battleList[0].RemoveStatus("Poison");
                            sb3.AppendLine("-- " + battleList[0].Name + " used " + battleList[1].Name + "'s antidote to cure " + battleList[0].PronounPosAdj.ToLower() + " poison.");
                        }
                        else //If player doesn't have poison they store it for later
                        {
                            battleList[1].HasAntidote = true;
                            sb3.AppendLine("-- " + battleList[0].Name + " took " + battleList[1].Name + "'s antidote and saved it for later.");
                        }
                    }

                    battleList.Remove(battleList[1]);
                }
            }

            if (battleList.Count == 1) //If only one player remains, battle is over
            {
                sb3.Append("*** " + battleList[0].Name + " has emerged victorious with " + battleList[0].Health + " health. ***");
            }


            if (battleList[0].GetStatus("Poison") == true && battleList[0].HasAntidote == true)
            {
                battleList[0].RemoveStatus("Poison");
                battleList[0].HasAntidote = false;
                if (game.DoFullBattles == true) sb3.Append("\n-- " + battleList[0].Name + " used " + battleList[0].PronounPosAdj.ToLower() + " antidote to cure " + battleList[0].PronounPosAdj.ToLower() + " poison.");
            }

            rand = rng.randomInt(1, 2); //50% chance for Freeze to wear off at end of battle
            if (rand == 1)
            {
                if (battleList[0].GetStatus("Freeze") == true && battleList[0].IsNPC==false)
                {
                    battleList[0].RemoveStatus("Freeze");
                    sb3.Append("\n-- " + battleList[0].Name + "'s Freeze wore off.");
                    battleList[0].Speed = battleList[0].StartSpeed; //Speed goes back to what it originally was
                }
            }

            battleList.Clear();

            return sb3.ToString();
        }

    }
}
