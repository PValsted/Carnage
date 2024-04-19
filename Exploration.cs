using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Carnage
{
    public class Exploration
    {
        RNG rng = new RNG();
        Battle battle = new Battle();
        Loot loot = new Loot();
        bool templeLootFound = false, towerLootFound = false;

        public bool TempleLootFound { get => templeLootFound; set => templeLootFound = value; }
        public bool TowerLootFound { get => towerLootFound; set => towerLootFound = value; }

        public string explorationEvent(character character, Game game)
        {
            int rand = rng.randomInt(0, 1);

            if (rand == 0)
            {
                return this.watchtower(character, game);
            }
            else
            {
                return this.temple(character);
            }
            
        }

        public string temple(character character)
        {
            StringBuilder sb = new StringBuilder();
            bool isDone = false;

            while (isDone == false) {
                int rand = rng.randomInt(1, 4);
                int damage;

                //Discovery
                if (rand == 1)
                {
                    sb.AppendLine(character.getName() + " stumbled upon an abandoned stone temple by a cliffside in the forest.");
                }
                else if (rand == 2)
                {
                    sb.AppendLine("An abandoned stone temple lied ahead of " + character.getName() + "'s path.");
                }
                else if (rand == 3)
                {
                    sb.AppendLine("Seeing an ancient-looking temple made of stone ahead, " + character.getName() + " approached quietly.");
                }
                else if (rand == 4)
                {
                    sb.AppendLine("The empty-looking temple that stood in front of " + character.getName() + " scared " + character.getPronounObj().ToLower() + ", so " + character.getPronounSub().ToLower() + " decided not to investigate.");
                    break;
                }

                //Examining
                rand = rng.randomInt(1, 5);
                if (rand == 1)
                {
                    sb.AppendLine(character.getPronounSub() + " looked around for traps, and then entered.");
                }
                else if (rand == 2)
                {
                    sb.AppendLine("Without any fear, " + character.getPronounSub().ToLower() + " walked in blindly.");
                }
                else if (rand == 3)
                {
                    sb.AppendLine(character.getPronounSub() + " looked around for hidden entrances, and saw a hole that " + character.getPronounSub().ToLower() + " climbed up into.");
                }
                else if (rand == 4)
                {
                    sb.AppendLine("After making sure no traps could be seen from the entrance, " + character.getPronounSub().ToLower() + " tiptoed into the main room.");
                }
                else
                {
                    sb.AppendLine("Putting aside " + character.getPronounPosAdj().ToLower() + " fear, " + character.getName() + " took a deep breath and walked into the temple.");
                }

                //Outcome
                rand = rng.randomInt(1, 8);
                if (rand == 1)
                {
                    damage = rng.randomInt(4,6);
                    character.hurt(damage);
                    if (character.IsAlive == true) //Character survives trap
                    {
                        sb.AppendLine(character.getPronounSub() + " immediately set off a trap, taking " + damage + " damage. " + character.getPronounSub() + " turned around and left.");
                    }
                    else //Character dies to trap
                    {
                        sb.AppendLine(character.getPronounSub() + " immediately set off a trap, taking " + damage + " damage. " + character.getName() + " succumbed to " + character.getPronounPosAdj().ToLower() + " injuries.");
                    }
                                         
                    break;
                }
                else if (rand == 2)
                { 
                    damage= rng.randomInt(6,8);
                    character.hurt(damage);
                    if (character.IsAlive == true) //Character survives trap
                    {
                        sb.AppendLine(character.getPronounSub() + " was shot in the shoulder by a hidden arrow trap, taking " + damage + " damage. " + character.getPronounSub() + " stumbled out and safely removed the arrow.");
                    }
                    else //Character dies to trap
                    {
                        sb.AppendLine(character.getPronounSub() + " was shot in the shoulder by a hidden arrow trap, taking " + damage + " damage. " + character.getName() + " succumbed to " + character.getPronounPosAdj().ToLower() + " injuries.");
                    }
                                           
                    break;
                }
                else if (rand == 3)
                {
                    sb.AppendLine(character.getName() + " made it through many rooms before carelessly stepping on a pressure plate. Although " + character.getPronounSub().ToLower() + " narrowly dodged the arrow, " + character.getPronounSub().ToLower() + " decided to cut " + character.getPronounPosAdj().ToLower() + " losses and turn back.");
                    break;
                }
                else if (rand == 4)
                {
                    sb.Append("Reaching a treasure room unscathed, " + character.getName() + " found something in a rusty chest. " + loot.lootEvent(character, "Common"));
                    break;
                }
                else if (rand == 5)
                {
                    character.hurt(2);
                    if (character.IsAlive == true) //Character survives trap
                    {
                        sb.Append(character.getName() + " made it to a treasure room and activated a rock trap. Luckily, injuries were minor and " + character.getPronounSub().ToLower() + " received an something from the chest. " + loot.lootEvent(character, "Common"));
                    }
                    else //Character dies to trap
                    {
                        sb.AppendLine(character.getName() + " made it to a treasure room and activated a rock trap. " + character.getName() + " succumbed to " + character.getPronounPosAdj().ToLower() + " injuries.");
                    }                 
                    
                    break;
                }
                else if (rand == 6)
                {
                    sb.Append(character.getName() + " managed to avoid every trap due to blind luck and found a treasure chest. " + loot.lootEvent(character, "Common"));
                    break;
                }
                else if (rand == 7)
                {
                    sb.AppendLine(character.getName() + " found a secret passage. The door closed behind " + character.getPronounObj().ToLower() + " and the floor dropped from under " + character.getPronounObj().ToLower() + ", causing " + character.getPronounObj().ToLower() + " to fall to " + character.getPronounPosAdj().ToLower() + " death.");
                    character.hurt(100);
                    break;
                }
                else if (rand == 8) 
                {
                    if (templeLootFound==false) //If this is the first time this option was triggered
                    {
                        sb.Append("Finding a secret and safe path, " + character.getName() + " reached a secret treasure room and opened a pristine-looking chest. " + loot.lootEvent(character, "Rare"));
                        templeLootFound = true;
                    }
                    else //If this isn't the first time this option was triggered
                    {
                        sb.AppendLine("Finding a secret and safe path, " + character.getName() + " reached a secret treasure room and opened a pristine-looking chest. The contents looked rummaged-through, but a couple leftover items still remained. " + loot.lootEvent(character, "Common"));
                    }
                    
                    break;
                }
            }
            return sb.ToString();
        }//end temple

        public string watchtower(character character, Game game)
        {
            StringBuilder sb2 = new StringBuilder();
            int rand = rng.randomInt(1, 5);
            int damage;

            bool isDone = false;

            while (isDone == false)
            {
                //Discovery
                if (rand == 1)
                {
                    sb2.AppendLine("At the top of the tallest hill, an old watchtower sat. Although " + character.getName() + " was nervous about how much it stuck out, " + character.getPronounSub().ToLower() + " approached.");
                }
                else if (rand == 2)
                {
                    sb2.AppendLine("Through the leaves of the trees, " + character.getName() + " could see the top of an abandoned watchtower. " + character.getPronounSub() + " walked up to it quietly.");
                }
                else if (rand == 3)
                {
                    sb2.AppendLine("In the distance, an eerie-looking watchtower sat within " + character.getName() + "'s view. " + character.getPronounSub() + " decided to go to it.");
                }
                else if (rand == 4)
                {
                    sb2.AppendLine(character.getName() + " found a 4-story watchtower near " + character.getPronounPosAdj().ToLower() + " camp. Instead of investigating, " + character.getPronounSub().ToLower() + " decided " + character.getPronounSub().ToLower() + "'d better move " + character.getPronounPosAdj().ToLower() + " spot.");
                    break;
                }
                else if (rand == 5)
                {
                    sb2.AppendLine(character.getName() + " thought " + character.getPronounSub().ToLower() + " saw something and climbed a hill. On top, " + character.getPronounSub().ToLower() + " saw a watchtower covered in moss and ivy. " + character.getPronounSub() + " went up to examine it.");
                }

                //Examining
                rand = rng.randomInt(1, 5);
                if (rand == 1) 
                {
                    sb2.AppendLine("As " + character.getPronounSub().ToLower() + " got closer, " + character.getPronounSub().ToLower() + " looked around for other people and saw nobody. " + character.getPronounSub() + " entered the first floor of the tower.");
                }
                else if (rand == 2)
                {
                    sb2.AppendLine("There didn't appear to be any competitors around, so " + character.getPronounSub().ToLower() + " walked into the tower.");
                }
                else if (rand == 3)
                {
                    sb2.AppendLine("Cautious of potential traps, " + character.getPronounSub().ToLower() + " looked through the entrance and saw nothing out of the ordinary, then entered.");
                }
                else if (rand == 4)
                {
                    sb2.AppendLine(character.getPronounSub() + " got a strange feeling as " + character.getPronounSub().ToLower() + " approached the entrance. Against " + character.getPronounPosAdj().ToLower() + " better judgment, " + character.getPronounSub().ToLower() + " walked through the door and onto the first floor.");
                }
                else if (rand == 5)
                {
                    sb2.AppendLine("Hearing strange creaking sounds coming from farther up the tower, " + character.getName() + " decided to turn back.");
                    break;
                }

                //Outcome
                rand = rng.randomInt(1, 5);

                if (rand == 1)
                {
                    damage = rng.randomInt(4, 5);
                    character.hurt(damage);
                    if (character.IsAlive == true) //If character survives
                    {
                        sb2.AppendLine("As " + character.getPronounSub().ToLower() + " climbed the old ladder to the second floor, a rung snapped, and " + character.getPronounSub().ToLower() + " fell and hit " + character.getPronounPosAdj().ToLower() + " head, taking " + damage + " damage. Seeing no other way, " + character.getPronounSub().ToLower() + " left injured.");
                    }
                    else //If character dies
                    {
                        sb2.AppendLine("As " + character.getPronounSub().ToLower() + " climbed the old ladder to the second floor, a rung snapped, and " + character.getPronounSub().ToLower() + " fell and hit " + character.getPronounPosAdj().ToLower() + " head, taking " + damage + " damage. " + character.getName() + " succumbed to " + character.getPronounPosAdj().ToLower() + " injuries.");
                    }

                    break;
                }
                else if (rand==2)
                {
                    character dummy = new character("The Living Dummy", "They");
                    dummy.Health = 10;
                    dummy.setWeaponName("knife");
                    dummy.setWeaponAttack(2.5);
                    dummy.setWeaponType("slash/stab");
                    dummy.IsNPC = true;

                    if (towerLootFound==false) //If this is the first time this option was triggered
                    {
                        sb2.AppendLine(character.getPronounSub() + " climbed 3 floors and ran into a wooden dummy holding a knife. It activated and attacked " + character.getPronounObj().ToLower() + ".\n" + battle.NPCBattleEvent(character, dummy, game));
                        if (character.IsAlive == true) //If character wins dummy fight
                        {
                            sb2.Append("After defeating the dummy, " + character.getPronounSub().ToLower() + " climbed to the top floor and opened a chest. " + loot.lootEvent(character, "Rare"));
                            towerLootFound = true;
                            break;
                        }
                        else break; //If character loses dummy fight
                    }
                    else //If this isn't the first time this option was triggered
                    {
                        sb2.Append(character.getPronounSub() + " climbed toward the top of the tower, seeing an unsettling wooden dummy on the ground of the third floor. " + character.getPronounSub() + " ignored it, and found a chest on the top floor. It appeared to have already been opened, but a couple less valuable items still remained inside. " + loot.lootEvent(character, "Common"));
                        break;
                    }

                }
                else if (rand == 3)
                {
                    sb2.AppendLine("On the second floor, " + character.getPronounSub().ToLower() + " found an item in a hidden compartment. " + loot.lootEvent(character, "Common") + character.getPronounSub() + " heard noise from above and fled the tower quickly.");
                    break;
                }
                else if (rand == 4)
                {
                    sb2.AppendLine("Seeing that the ladder was broken, " + character.getName() + " took " + character.getPronounObj().ToLower() + " chances and launched " + character.getPronounRefl().ToLower() + " toward the rungs higher up. " + character.getPronounSub() + " missed and decided to turn back.");
                    break;
                }
                else if (rand == 5)
                {
                    sb2.AppendLine("In a random cabinet on the first floor, " + character.getName() + " found a strange-looking liquid. Some unseen force compelled " + character.getPronounObj().ToLower() + " to drink it, so " + character.getPronounSub().ToLower() + " took a sip. " + loot.potionEvent(character));
                    if (character.IsAlive==true) //If potion doesn't kill character
                    {
                        sb2.AppendLine(character.getPronounSub() + " decided that was enough adventuring and turned away and left.");
                        break;
                    }
                    else //If potion kills character
                    {
                        sb2.AppendLine("The effects of the liquid were enough to kill " + character.getPronounObj().ToLower() + ".");
                        break;
                    }                  
                }

            }
            return sb2.ToString();
        }
    }
}
