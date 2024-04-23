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
        int numPlayers = 0;
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
                    sb2.Append(char1.getName() + " punched " + char2.getName() + " with " + char1.getPronounPosAdj().ToLower() + " bare fists.");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.getName() + " jumped into the air and punched " + char2.getName() + " in the " + rng.randomBodyPart() + "!");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.getName() + " kicked " + char2.getName() + " in the " + rng.randomBodyPart() + ".");
                }
            }
            else if (type == "slash") //If attacker weapon type is slash
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.getName() + " slashed " + char2.getName() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.getName() + " used a spinning move to cut " + char2.getName() + " in the " + rng.randomBodyPart() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.getName() + " caught " + char2.getName() + " off guard and sliced across " + char2.getPronounPosAdj().ToLower() + " " + rng.randomBodyPart() + ".");
                }
            }
            else if (type == "stab") //If attacker weapon type is stab
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.getName() + " stabbed " + char2.getName() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.getName() + " launched " + char1.getPronounRefl().ToLower() + " at " + char2.getName() + " and pierced " + char2.getPronounPosAdj().ToLower() + " " + rng.randomBodyPart() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.getName() + " started furiously trying to stab " + char2.getName() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + " and lands a hit.");
                }
            }
            else if (type == "slash/stab") //If attacker weapon type is slash/stab
            {
                random = rng.randomInt(1, 6);

                if (random == 1)
                {
                    sb2.Append(char1.getName() + " stabbed " + char2.getName() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.getName() + " launched " + char1.getPronounRefl().ToLower() + " at " + char2.getName() + " and pierced " + char2.getPronounPosAdj().ToLower() + " " + rng.randomBodyPart() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.getName() + " started furiously trying to stab " + char2.getName() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + " and lands a hit.");
                }
                else if (random == 4)
                {
                    sb2.Append(char1.getName() + " slashed " + char2.getName() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
                else if (random == 5)
                {
                    sb2.Append(char1.getName() + " used a spinning move to cut " + char2.getName() + " in the " + rng.randomBodyPart() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
                else if (random == 6)
                {
                    sb2.Append(char1.getName() + " caught " + char2.getName() + " off guard and sliced across " + char2.getPronounPosAdj().ToLower() + " " + rng.randomBodyPart() + ".");
                }
            }
            else if (type == "crush") //If attacker weapon type is crush
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.getName() + " dashed toward " + char2.getName() + " and pounded " + char2.getPronounObj().ToLower() + " in the " + rng.randomBodyPart() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.getName() + " swung " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + " with all " + char1.getPronounPosAdj().ToLower() + " might and landed a hit on " + char2.getName() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.getName() + " violently smashed " + char2.getName() + "'s " + rng.randomBodyPart() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
            }
            else if (type == "hand") //If attacker weapon type is hand
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.getName() + " ran behind " + char2.getName() + " and punched " + char2.getPronounObj().ToLower() + " hard in the " + rng.randomBodyPart() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.getName() + " swung " + char1.getPronounPosAdj().ToLower() + " fists at " + char2.getName() + " while using " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.getName() + " hit " + char2.getName() + " with a volley of punches and pounded " + char2.getPronounObj().ToLower() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
            }
            else if (type == "bow") //If attacker weapon type is bow
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.getName() + " shot " + char2.getName() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + " and barely hit.");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.getName() + " drew back " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + " and fired straight into " + char2.getName() + "'s " + rng.randomBodyPart() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.getName() + " aimed at " + char2.getName() + "'s " + rng.randomBodyPart() + " and landed a bullseye.");
                }
            }
            else if (type == "throwing") //If attacker weapon type is throwing
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.getName() + " threw a " + char1.getWeaponName() + ", which hit " + char2.getName() + " in the " + rng.randomBodyPart() + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.getName() + " concentrated on " + char1.getPronounPosAdj().ToLower() + " aim and landed a direct hit on " + char2.getName() + " using " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.getName() + " took out a " + char1.getWeaponName() + " and launched it at " + char2.getName() + ".");
                }
            }
            else if (type == "gun") //If attacker weapon type is gun
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.getName() + " aimed " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + " at " + char2.getName() + " and fired a round, making contact with " + char2.getPronounObj().ToLower() + ".");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.getName() + " drew " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + " and shot a volley of rounds at " + char2.getName() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.getName() + " took cover and shot " + char2.getName() + " with " + char1.getPronounPosAdj().ToLower() + " " + char1.getWeaponName() + ".");
                }
            }
            else if (type == "special") //If attacker weapon type is special (different results for specific weapons that fit into no category)
            {
                if (char1.getWeaponName() == "flamethrower")
                {
                    sb2.Append(char1.getName() + " used " + char1.getPronounPosAdj().ToLower() + " flamethrower on " + char2.getName() + ", engulfing " + char2.getPronounObj().ToLower() + " in flames.");
                }
                else if (char1.getWeaponName() == "slingshot")
                {
                    sb2.Append(char1.getName() + " drew back " + char1.getPronounPosAdj().ToLower() + " slingshot and flung rocks at " + char2.getName() + ".");
                }
                else if (char1.getWeaponName() == "blowgun")
                {
                    sb2.Append(char1.getName() + " blew into " + char1.getPronounPosAdj().ToLower() + " blowgun and shot darts into " + char2.getName() + "'s " + rng.randomBodyPart() + ".");
                }
                else if (char1.getWeaponName() == "whip")
                {
                    sb2.Append(char1.getName() + " cracked " + char1.getPronounPosAdj().ToLower() + " whip and then got a hit on " + char2.getName() + ".");
                }
                else if (char1.getWeaponName() == "fangs")
                {
                    sb2.Append(char1.getName() + " pierced " + char2.getName() + " in the " + rng.randomBodyPart() + " with its fangs.");
                }
            }
            else if (type == "Explosive") //If attacker weapon type is explosive
            {
                random = rng.randomInt(1, 3);

                if (random == 1)
                {
                    sb2.Append(char1.getName() + " stepped back and threw " + char1.getPronounPosAdj().ToLower() + " explosive at " + char2.getName() + ", who got caught slightly in the blast radius.");
                }
                else if (random == 2)
                {
                    sb2.Append(char1.getName() + " took out " + char1.getPronounPosAdj().ToLower() + " explosive and chucked threw it towards " + char2.getName() + "'s " + rng.randomBodyPart() + ".");
                }
                else if (random == 3)
                {
                    sb2.Append(char1.getName() + " successfully hit " + char2.getName() + " with an explosive, causing lots of damage.");
                }
            }

            return sb2.ToString();
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

                sb.AppendLine("A battle has broken out between " + battleList.ElementAt(0).getName() + " and " + battleList.ElementAt(1).getName() + ".");
            }

            if (this.getNumPlayers() == 3) //If battle is between 3 players, only first 3 passed in are added to the battle list
            {
                battleList.Add(char1);
                battleList.Add(char2);
                battleList.Add(char3);

                sb.AppendLine("A battle has broken out between " + battleList.ElementAt(0).getName() + ", " + battleList.ElementAt(1).getName() + ", and " + battleList.ElementAt(2).getName() + ".");
            }

            if (this.getNumPlayers() == 4) //If battle is between 4 players, all 4 passed in are added to the battle list
            {
                battleList.Add(char1);
                battleList.Add(char2);
                battleList.Add(char3);
                battleList.Add(char4);

                sb.AppendLine("A battle has broken out between " + battleList.ElementAt(0).getName() + ", " + battleList.ElementAt(1).getName() + 
                    ", " + battleList.ElementAt(2).getName() + ", and " + battleList.ElementAt(3).getName() + ".");
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

                if (battleList.ElementAt(1).aliveCheck() == true) //If there is more than 1 character alive in the battle
                {
                    //Decides if player will flee
                    if (battleList.ElementAt(0).getHealth() <= battleList.ElementAt(1).getHealth() / 2 && flee == true )
                    {
                        if (game.Mode == "Classic") //Classic flee, 50-50
                        {
                            int random = rng.randomInt(0, 1);
                            if (random == 0)
                            {
                                doesFlee = true;
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
                            sb.AppendLine("-- " + battleList.ElementAt(0).getName() + " attempted to flee and was successful.");
                            break;
                        }
                        else if (doesFlee == true && battleList.Count != 2) //If more than 2 players are left, player successfully flees and battle continues
                        {
                            sb.AppendLine("-- " + battleList.ElementAt(0).getName() + " attempted to flee and was successful.");
                            battleList.Remove(battleList.ElementAt(0));
                            continue;
                        }
                        else //Player fails to flee, but no damage is taken as punishment
                        {
                            if (game.DoFullBattles==true) sb.AppendLine("-- " + battleList.ElementAt(0).getName() + " attempted to flee, but " + battleList.ElementAt(1).getName() + " was too quick and cornered " + battleList.ElementAt(0).getPronounObj().ToLower() + ".");
                        }

                    }

                    //Player uses healing item if they have one stored and their health is 8 or lower
                    if (battleList.ElementAt(0).getHealth()<=8 && battleList.ElementAt(0).isHealSlotFilled()==true)
                    {
                        battleList.ElementAt(0).heal(battleList.ElementAt(0).getHealingAmount());
                        if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList.ElementAt(0).getName() + " is at low health so " + battleList.ElementAt(0).getPronounSub().ToLower()
                                                                      + " used " + battleList.ElementAt(0).getPronounPosAdj().ToLower() + " healing item to heal to " + battleList.ElementAt(0).getHealth().ToString() + " health.");
                        battleList.ElementAt(0).fillHealSlot(false);
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
                            sb.AppendLine("-- " + battleList.ElementAt(0).getName() + " saw " + battleList[1].getName() + " was weak and decided to spare " + battleList[1].getPronounPosAdj().ToLower() + " life." );
                            break;
                        }
                        else if (doesSpare == true && battleList.Count != 2) //If more than 2 players are left, attacker spares victim and battle continues
                        {
                            sb.AppendLine("-- " + battleList.ElementAt(0).getName() + " saw " + battleList[1].getName() + " was weak and decided to spare " + battleList[1].getPronounPosAdj().ToLower() + " life.");
                            continue;
                        }
                        else //Attacker does not spare victim
                        {
                            if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList.ElementAt(1).getName() + " begged for " + battleList[0].getName() + " to spare " + battleList[1].getPronounPosAdj().ToLower() + " life, but " + battleList[0].getPronounSub().ToLower() + " refused.");
                        }
                    }

                    //Decides whether player dodges
                    if (dodge == true)
                    {
                        if (crit == false) //Player dodges and does 2 damage in return
                        {
                            if (spot0Attack == true) //If classic mode or character 0 is stronger (realistic mode)
                            {
                                battleList.ElementAt(0).hurt(2);
                                battleList.ElementAt(0).Health = Math.Round(battleList.ElementAt(0).Health, 2);
                                if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList.ElementAt(1).getName() + " dodged " + battleList.ElementAt(0).getName() + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList.ElementAt(1), battleList.ElementAt(0), "Unarmed") + " " + battleList.ElementAt(0).getName() + " is at " + battleList.ElementAt(0).getHealth() + " health.");
                                continue;
                            }
                            else //If character 1 is stronger (realistic mode)
                            {
                                battleList.ElementAt(1).hurt(2);
                                battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList.ElementAt(0).getName() + " dodged " + battleList.ElementAt(1).getName() + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), "Unarmed") + " " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                                continue;
                            }
                            
                        }
                        else //Player dodges and does a critical hit for 3 damage in return
                        {
                            if (spot0Attack == true) //If classic mode or character 0 is stronger (realistic mode)
                            {
                                battleList.ElementAt(0).hurt(3);
                                battleList.ElementAt(0).Health = Math.Round(battleList.ElementAt(0).Health, 2);
                                if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList.ElementAt(1).getName() + " dodged " + battleList.ElementAt(0).getName() + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList.ElementAt(1), battleList.ElementAt(0), "Unarmed") + " Critical hit! " + battleList.ElementAt(0).getName() + " is at " + battleList.ElementAt(0).getHealth() + " health.");
                                continue;
                            }
                            else //If character 1 is stronger (realistic mode)
                            {
                                battleList.ElementAt(1).hurt(3);
                                battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                if (game.DoFullBattles == true) sb.AppendLine("-- " + battleList.ElementAt(0).getName() + " dodged " + battleList.ElementAt(1).getName() + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(0), "Unarmed") + " Critical hit! " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                                continue;
                            }

                        }
                    }
                    else if (dodge == false) //Player does not dodge
                    {
                        if (spot0Attack == true) //If classic mode or character 0 is stronger (realistic mode)
                        {
                            if (battleList.ElementAt(0).getWeaponName() == "") //If player does not have a weapon, they do an unarmed attack
                            {
                                if (useExplosive == true && battleList.ElementAt(0).HasExplosive == true) //Player is unarmed and uses explosive if value is true
                                {
                                    int damage = rng.explosionDamage();

                                    battleList.ElementAt(1).hurt(damage);
                                    battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), "Explosive") + " It did " + damage + " damage. " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                                    battleList.ElementAt(0).HasExplosive = false;
                                }
                                else if (crit == false) //Player does normal unarmed attack
                                {
                                    battleList.ElementAt(1).hurt(battleList.ElementAt(0).getWeaponAttack());
                                    battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("--- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), "Unarmed") + " " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                                }
                                else //Player does critical unarmed attack
                                {
                                    battleList.ElementAt(1).hurt(1.5 * battleList.ElementAt(0).getWeaponAttack());
                                    battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), "Unarmed") + " Critical hit! " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                                }
                            }
                            else //If player does have a weapon, they attack based on their weapon type
                            {
                                if (useExplosive == true && battleList.ElementAt(0).HasExplosive == true) //Player is armed and uses explosive if value is true
                                {
                                    int damage = rng.explosionDamage();

                                    battleList.ElementAt(1).hurt(damage);
                                    battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), "Explosive") + " It did " + damage + " damage. " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                                    battleList.ElementAt(0).HasExplosive = false;
                                }
                                else if (crit == false) //Player is armed and attacks based on their weapon type
                                {
                                    if (game.Mode=="Classic") battleList.ElementAt(1).hurt((battleList.ElementAt(0).getWeaponAttack())); //Classic mode attack
                                    else battleList.ElementAt(1).hurt((battleList.ElementAt(0).getWeaponAttack())+battleList[0].Strength/4); //Realistic mode attack, weapon attack + some strength

                                    battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("--- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), battleList.ElementAt(0).getWeaponType()) + " " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                                }
                                else //Player is armed and does critical attack based on their weapon type
                                {
                                    if (game.Mode == "Classic") battleList.ElementAt(1).hurt(1.5*(battleList.ElementAt(0).getWeaponAttack())); //Classic mode attack
                                    else battleList.ElementAt(1).hurt(1.5*((battleList.ElementAt(0).getWeaponAttack()) + battleList[0].Strength / 4)); //Realistic mode attack, weapon attack + some strength

                                    battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), battleList.ElementAt(0).getWeaponType()) + " Critical hit! " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                                }
                            }
                        }
                        else //If character 1 is stronger (realistic mode)
                        {
                            if (battleList.ElementAt(1).getWeaponName() == "") //If player does not have a weapon, they do an unarmed attack
                            {
                                if (useExplosive == true && battleList.ElementAt(1).HasExplosive == true) //Player is unarmed and uses explosive if value is true
                                {
                                    int damage = rng.explosionDamage();

                                    battleList.ElementAt(0).hurt(damage);
                                    battleList.ElementAt(0).Health = Math.Round(battleList.ElementAt(0).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList.ElementAt(1), battleList.ElementAt(0), "Explosive") + " It did " + damage + " damage. " + battleList.ElementAt(0).getName() + " is at " + battleList.ElementAt(0).getHealth() + " health.");
                                    battleList.ElementAt(1).HasExplosive = false;
                                }
                                else if (crit == false) //Player does normal unarmed attack
                                {
                                    battleList.ElementAt(0).hurt(battleList.ElementAt(1).getWeaponAttack());
                                    battleList.ElementAt(0).Health = Math.Round(battleList.ElementAt(0).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("--- " + this.getBattleText(battleList.ElementAt(1), battleList.ElementAt(0), "Unarmed") + " " + battleList.ElementAt(0).getName() + " is at " + battleList.ElementAt(0).getHealth() + " health.");
                                }
                                else //Player does critical unarmed attack
                                {
                                    battleList.ElementAt(0).hurt(1.5 * battleList.ElementAt(1).getWeaponAttack());
                                    battleList.ElementAt(0).Health = Math.Round(battleList.ElementAt(0).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList.ElementAt(1), battleList.ElementAt(0), "Unarmed") + " Critical hit! " + battleList.ElementAt(0).getName() + " is at " + battleList.ElementAt(0).getHealth() + " health.");
                                }
                            }
                            else //If player does have a weapon, they attack based on their weapon type
                            {
                                if (useExplosive == true && battleList.ElementAt(1).HasExplosive == true) //Player is armed and uses explosive if value is true
                                {
                                    int damage = rng.explosionDamage();

                                    battleList.ElementAt(0).hurt(damage);
                                    battleList.ElementAt(0).Health = Math.Round(battleList.ElementAt(0).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList.ElementAt(1), battleList.ElementAt(0), "Explosive") + " It did " + damage + " damage. " + battleList.ElementAt(0).getName() + " is at " + battleList.ElementAt(0).getHealth() + " health.");
                                    battleList.ElementAt(1).HasExplosive = false;
                                }
                                else if (crit == false) //Player is armed and attacks based on their weapon type
                                {
                                    if (game.Mode == "Classic") battleList.ElementAt(0).hurt((battleList.ElementAt(1).getWeaponAttack())); //Classic mode attack
                                    else battleList.ElementAt(0).hurt((battleList.ElementAt(1).getWeaponAttack()) + battleList[1].Strength / 4); //Realistic mode attack, weapon attack + some strength

                                    battleList.ElementAt(0).Health = Math.Round(battleList.ElementAt(0).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("--- " + this.getBattleText(battleList.ElementAt(1), battleList.ElementAt(0), battleList.ElementAt(1).getWeaponType()) + " " + battleList.ElementAt(0).getName() + " is at " + battleList.ElementAt(0).getHealth() + " health.");
                                }
                                else //Player is armed and does critical attack based on their weapon type
                                {
                                    if (game.Mode == "Classic") battleList.ElementAt(0).hurt((1.5*battleList.ElementAt(1).getWeaponAttack())); //Classic mode attack
                                    else battleList.ElementAt(0).hurt(1.5 * ((battleList.ElementAt(1).getWeaponAttack()) + battleList[1].Strength / 4)); //Realistic mode attack, weapon attack + some strength

                                    battleList.ElementAt(0).Health = Math.Round(battleList.ElementAt(0).Health, 2);
                                    if (game.DoFullBattles == true) sb.AppendLine("-- " + this.getBattleText(battleList.ElementAt(1), battleList.ElementAt(0), battleList.ElementAt(1).getWeaponType()) + " Critical hit! " + battleList.ElementAt(0).getName() + " is at " + battleList.ElementAt(0).getHealth() + " health.");
                                }
                            }
                        }
                    }
                } //End character's turn

                //Happens after the character's turn if the character they are facing has been defeated, has fled, or has been spared
                if (battleList.ElementAt(1).aliveCheck() == false) //If player 1 is defeated
                {
                    battleList.ElementAt(0).Kills++;
                    sb.AppendLine("- " + battleList.ElementAt(1).getName() + " has been defeated by " + battleList[0].Name + ".");
                    if (battleList.ElementAt(1).getWeaponType() != "Unarmed") //If defeated player has a weapon
                    {
                        if (battleList.ElementAt(0).getWeaponAttack() < battleList.ElementAt(1).getWeaponAttack() && battleList.ElementAt(0).getWeaponName() != "")//If defeated player's weapon is stronger than victor's weapon, they replace theirs with it
                        {
                            sb.AppendLine(battleList.ElementAt(0).getName() + " replaced " + battleList.ElementAt(0).getPronounPosAdj().ToLower() + " " +
                                          battleList.ElementAt(0).getWeaponName() + " with " + battleList.ElementAt(1).getName() + "'s " + battleList.ElementAt(1).getWeaponName() + ".");
                            battleList.ElementAt(0).setWeaponAttack(battleList.ElementAt(1).getWeaponAttack());
                            battleList.ElementAt(0).setWeaponName(battleList.ElementAt(1).getWeaponName());
                            battleList.ElementAt(0).setWeaponType(battleList.ElementAt(1).getWeaponType());
                        }
                        else if (battleList.ElementAt(0).getWeaponName() == "" && battleList.ElementAt(1).getWeaponName() != "")//If defeated player has weapon and victor does not, they pick up weapon
                        {
                            sb.AppendLine(battleList.ElementAt(0).getName() + " picked up " + battleList.ElementAt(1).getName() + "'s " + battleList.ElementAt(1).getWeaponName() + ".");
                            battleList.ElementAt(0).setWeaponAttack(battleList.ElementAt(1).getWeaponAttack());
                            battleList.ElementAt(0).setWeaponName(battleList.ElementAt(1).getWeaponName());
                            battleList.ElementAt(0).setWeaponType(battleList.ElementAt(1).getWeaponType());
                        }
                    }
                    battleList.Remove(battleList.ElementAt(1)); //Character is removed from the list
                }
                else if (battleList.ElementAt(0).aliveCheck() == false) //If character 0 is defeated
                {
                    battleList.ElementAt(1).Kills++;
                    sb.AppendLine("- " + battleList.ElementAt(0).getName() + " has been defeated by " + battleList[1].Name + ".");
                    if (battleList.ElementAt(0).getWeaponType() != "Unarmed") //If defeated player has a weapon
                    {
                        if (battleList.ElementAt(1).getWeaponAttack() < battleList.ElementAt(0).getWeaponAttack() && battleList.ElementAt(1).getWeaponName() != "")//If defeated player's weapon is stronger than victor's weapon, they replace theirs with it
                        {
                            sb.AppendLine(battleList.ElementAt(1).getName() + " replaced " + battleList.ElementAt(1).getPronounPosAdj().ToLower() + " " +
                                          battleList.ElementAt(1).getWeaponName() + " with " + battleList.ElementAt(0).getName() + "'s " + battleList.ElementAt(0).getWeaponName() + ".");
                            battleList.ElementAt(1).setWeaponAttack(battleList.ElementAt(0).getWeaponAttack());
                            battleList.ElementAt(1).setWeaponName(battleList.ElementAt(0).getWeaponName());
                            battleList.ElementAt(1).setWeaponType(battleList.ElementAt(0).getWeaponType());
                        }
                        else if (battleList.ElementAt(1).getWeaponName() == "" && battleList.ElementAt(0).getWeaponName() != "")//If defeated player has weapon and victor does not, they pick up weapon
                        {
                            sb.AppendLine(battleList.ElementAt(1).getName() + " picked up " + battleList.ElementAt(0).getName() + "'s " + battleList.ElementAt(0).getWeaponName() + ".");
                            battleList.ElementAt(1).setWeaponAttack(battleList.ElementAt(0).getWeaponAttack());
                            battleList.ElementAt(1).setWeaponName(battleList.ElementAt(0).getWeaponName());
                            battleList.ElementAt(1).setWeaponType(battleList.ElementAt(0).getWeaponType());
                        }
                    }
                    battleList.Remove(battleList.ElementAt(0)); //Character is removed from the list
                }
            }

            if (battleList.Count == 1) //If only one player remains, battle is over
            {
                if (battleList.ElementAt(0).Kills == 1) //If victor has 1 kill
                {
                    sb.AppendLine("*** " + battleList.ElementAt(0).getName() + " has emerged victorious with " + battleList.ElementAt(0).getHealth() +
                                  " health remaining and " + battleList.ElementAt(0).Kills + " kill. ***");
                }
                else //If victor has more than 1 kill
                {
                    sb.AppendLine("*** " + battleList.ElementAt(0).getName() + " has emerged victorious with " + battleList.ElementAt(0).getHealth() +
                                  " health remaining and " + battleList.ElementAt(0).Kills + " kills. ***");
                }
            }
            else //If battle ends because one or more players fled
            {
                sb.AppendLine("*** The battle ended with " + battleList.ElementAt(0).getName() + " at " + battleList.ElementAt(0).getHealth() +
                                 " health and " + battleList.ElementAt(1).getName() + " at " + battleList.ElementAt(1).getHealth() +
                                 " health. ***");
            }
            
            battleList.Clear();

            return sb.ToString();
        }

        /// <summary>
        /// Simulates a battle between a character and an NPC. This is the same as a normal
        /// battle event, except characters can't flee or be spared. The winner cannot pick up
        /// the loser's weapon and a kill is not given to them.
        /// </summary>
        public string NPCBattleEvent(character char1, character char2, Game game)
        {

            StringBuilder sb3 = new StringBuilder();
            bool crit = false, dodge = false,  useExplosive = false;

            battleList.Add(char1);
            battleList.Add(char2);

            sb3.AppendLine("A battle has broken out between " + battleList.ElementAt(0).getName() + " and " + battleList.ElementAt(1).getName() + ".");

            while (battleList.Count > 1) //When a character is out of the battle, they are removed, and until there is only 1 left, the loop cycles turns
            {
                battleList = rng.shuffleList(battleList);

                crit = rng.critAttack();
                dodge = rng.dodge();
                useExplosive = rng.useExplosive();

                if (battleList.ElementAt(1).aliveCheck() == true) //If both characters are alive at the beginning of the turn
                {
                    //Player uses healing item if they have one stored and their health is 8 or lower
                    if (battleList.ElementAt(0).getHealth() <= 8 && battleList.ElementAt(0).isHealSlotFilled() == true)
                    {
                        battleList.ElementAt(0).heal(battleList.ElementAt(0).getHealingAmount());
                        if (game.DoFullBattles == true) sb3.AppendLine("-- " + battleList.ElementAt(0).getName() + " is at low health so " + battleList.ElementAt(0).getPronounSub().ToLower()
                                                                       + " used " + battleList.ElementAt(0).getPronounPosAdj().ToLower() + " healing item to heal to " + battleList.ElementAt(0).getHealth().ToString() + " health.");
                        battleList.ElementAt(0).fillHealSlot(false);
                    }

                    //Decides whether player dodges
                    if (dodge == true)
                    {
                        if (crit == false) //Player dodges and does 2 damage in return
                        {
                            battleList.ElementAt(0).hurt(2);
                            battleList.ElementAt(0).Health = Math.Round(battleList.ElementAt(0).Health, 2);
                            if (game.DoFullBattles == true) sb3.AppendLine("-- " + battleList.ElementAt(1).getName() + " dodged " + battleList.ElementAt(0).getName() + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList.ElementAt(1), battleList.ElementAt(0), battleList.ElementAt(1).getWeaponType()) + " " + battleList.ElementAt(0).getName() + " is at " + battleList.ElementAt(0).getHealth() + " health.");
                            continue;
                        }
                        else //Player dodges and does a critical hit for 3 damage in return
                        {
                            battleList.ElementAt(0).hurt(3);
                            battleList.ElementAt(0).Health = Math.Round(battleList.ElementAt(0).Health, 2);
                            if (game.DoFullBattles == true) sb3.AppendLine("-- " + battleList.ElementAt(1).getName() + " dodged " + battleList.ElementAt(0).getName() + "'s attack! Then, taking advantage of the situation, " + this.getBattleText(battleList.ElementAt(1), battleList.ElementAt(0), battleList.ElementAt(1).getWeaponType()) + " Critical hit! " + battleList.ElementAt(0).getName() + " is at " + battleList.ElementAt(0).getHealth() + " health.");
                            continue;
                        }
                    }
                    else if (dodge == false) //Player does not dodge
                    {
                        if (battleList.ElementAt(0).getWeaponName() == "") //If player does not have a weapon, they do an unarmed attack
                        {
                            if (useExplosive == true && battleList.ElementAt(0).HasExplosive == true) //Player is unarmed and uses explosive if value is true
                            {
                                int damage = rng.explosionDamage();

                                battleList.ElementAt(1).hurt(damage);
                                battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                if (game.DoFullBattles == true) sb3.AppendLine("-- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), "Explosive") + " It did " + damage + " damage. " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                                battleList.ElementAt(0).HasExplosive = false;
                            }
                            else if (crit == false) //Player does normal unarmed attack
                            {
                                battleList.ElementAt(1).hurt(battleList.ElementAt(0).getWeaponAttack());
                                battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                if (game.DoFullBattles == true) sb3.AppendLine("--- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), "Unarmed") + " " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                            }
                            else //Player does critical unarmed attack
                            {
                                battleList.ElementAt(1).hurt(1.5 * battleList.ElementAt(0).getWeaponAttack());
                                battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                if (game.DoFullBattles == true) sb3.AppendLine("-- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), "Unarmed") + " Critical hit! " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                            }
                        }
                        else //If player does have a weapon, they attack based on their weapon type
                        {
                            if (useExplosive == true && battleList.ElementAt(0).HasExplosive == true) //Player is armed and uses explosive if value is true
                            {
                                int damage = rng.explosionDamage();

                                battleList.ElementAt(1).hurt(damage);
                                battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                if (game.DoFullBattles == true) sb3.AppendLine("-- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), "Explosive") + " It did " + damage + " damage. " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                                battleList.ElementAt(0).HasExplosive = false;
                            }
                            else if (crit == false) //Player is armed and attacks based on their weapon type
                            {
                                battleList.ElementAt(1).hurt((battleList.ElementAt(0).getWeaponAttack()));
                                battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                if (game.DoFullBattles == true) sb3.AppendLine("--- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), battleList.ElementAt(0).getWeaponType()) + " " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                            }
                            else //Player is armed and does critical attack based on their weapon type
                            {
                                battleList.ElementAt(1).hurt(1.5 * (battleList.ElementAt(0).getWeaponAttack()));
                                battleList.ElementAt(1).Health = Math.Round(battleList.ElementAt(1).Health, 2);
                                if (game.DoFullBattles == true) sb3.AppendLine("-- " + this.getBattleText(battleList.ElementAt(0), battleList.ElementAt(1), battleList.ElementAt(0).getWeaponType()) + " Critical hit! " + battleList.ElementAt(1).getName() + " is at " + battleList.ElementAt(1).getHealth() + " health.");
                            }
                        }
                    }
                }

                if (battleList.ElementAt(1).aliveCheck() == false) //If the attacked player is dead
                {
                    sb3.AppendLine("- " + battleList.ElementAt(1).getName() + " has been defeated.");
                    battleList.Remove(battleList.ElementAt(1));
                }
            }

            if (battleList.Count == 1) //If only one player remains, battle is over
            {
                sb3.Append("*** " + battleList.ElementAt(0).getName() + " has emerged victorious with " + battleList.ElementAt(0).Health + " health. ***");
            }
           
            battleList.Clear();

            return sb3.ToString();
        }

    }
}
