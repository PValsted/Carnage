using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Net.Mime.MediaTypeNames;

namespace Carnage
{

    /// <summary>
    /// Takes a character and simulates them exploring one of two landmarks in the arena.
    /// A block of text made up of three randomly selected events is generated, and different consequences
    /// are associated with each choice. Damage is often taken, loot is found, and NPCs may be battled
    /// </summary>
    public class Exploration
    {
        RNG rng = new RNG();
        Battle battle = new Battle();
        Loot loot = new Loot();
        bool templeLootFound = false, towerLootFound = false, possession = false;

        public bool TempleLootFound { get => templeLootFound; set => templeLootFound = value; }
        public bool TowerLootFound { get => towerLootFound; set => towerLootFound = value; }

        /// <summary>
        /// Retrieves a series of events for the character passed into one of two
        /// randomly-selected landmarks.
        /// </summary>
        public string explorationEvent(character character, Game game)
        {
            int randFun, rand;

            if (game.FunValue >= 21 && game.FunValue <= 40) //Mention of rare Demon's Tomb event, but no entry
            {
                randFun = rng.randomInt(1, 10);
                if (randFun == 1) 
                {
                    return (character.Name + " ran into some strange markings on the side of the mountain. Featured in the center of the markings stood a shadowy figure that resembled a demon. " +
                        "There seemed to be the shape of a doorway around everything else, but there was clearly no way to gain entry. " + character.Name + " got an uneasy feeling and walked away.\n");
                }
                else
                {
                    rand = rng.randomInt(0, 2);

                    if (rand == 0)
                    {
                        return this.watchtower(character, game); //Watchtower selected
                    }
                    else if (rand == 1)
                    {
                        return this.encampment(character, game); //Forest Imp Encampment selected
                    }
                    else
                    {
                        return this.temple(character, game); //Abandoned Temple selected
                    }
                }
            }
            else if (game.FunValue >= 41 && game.FunValue <= 60) //Includes the rare Demon's Tomb event
            {
                int random = rng.randomInt(1, 3);

                if (possession == true) rand = rng.randomInt(0, 2);
                else if ((game.Day == 1 || game.Day == 2) && random == 1) rand = 3; //Demon's Tomb has a 1 in 3 chance of being forced on days 1 and 2
                else rand = rng.randomInt(0, 3);


                if (rand == 0)
                {
                    return this.watchtower(character, game); //Watchtower selected
                }
                else if (rand == 1)
                {
                    return this.encampment(character, game); //Forest Imp Encampment selected
                }
                else if (rand == 2)
                {
                    return this.temple(character, game); //Abandoned Temple selected
                }
                else
                {
                    return this.tomb(character, game); //Demon's Tomb selected
                }
            }
            else
            {
                rand = rng.randomInt(0, 2);

                if (rand == 0)
                {
                    return this.watchtower(character, game); //Watchtower selected
                }
                else if (rand == 1)
                {
                    return this.encampment(character, game); //Forest Imp Encampment selected
                }
                else
                {
                    return this.temple(character, game); //Abandoned Temple selected
                }
            }
            
            
            
        }

        /// <summary>
        /// Generates events corresponding to the Temple landmark for the character passed in.
        /// Characters may take damage/die and find loot in this landmark.
        /// </summary>
        public string temple(character character, Game game)
        {
            StringBuilder sb = new StringBuilder();

            //While loop that never ends naturally is used so that some of the randomly selected events may result in the event ending early with break statements
            while (true) 
            {
                int rand = rng.randomInt(1, 4);
                int damage;

                //Discovery: 1st sentence corresponds to character finding the landmark
                if (rand == 1)
                {
                    sb.AppendLine(character.Name + " stumbled upon an abandoned stone temple by a cliffside in the forest.");
                }
                else if (rand == 2)
                {
                    sb.AppendLine("An abandoned stone temple lied ahead of " + character.Name + "'s path.");
                }
                else if (rand == 3)
                {
                    sb.AppendLine("Seeing an ancient-looking temple made of stone ahead, " + character.Name + " approached quietly.");
                }
                else if (rand == 4) //character does not investigate further, break from loop
                {
                    sb.AppendLine("The empty-looking temple that stood in front of " + character.Name + " scared " + character.PronounObj.ToLower() + ", so " + character.PronounSub.ToLower() + " decided not to investigate.");
                    break;
                }

                //Examining: 2nd sentence corresponds to character looking at the entrance to the landmark
                rand = rng.randomInt(1, 5);
                if (rand == 1)
                {
                    sb.AppendLine(character.PronounSub + " looked around for traps, and then entered.");
                }
                else if (rand == 2)
                {
                    sb.AppendLine("Without any fear, " + character.PronounSub.ToLower() + " walked in blindly.");
                }
                else if (rand == 3)
                {
                    sb.AppendLine(character.PronounSub + " looked around for hidden entrances, and saw a hole that " + character.PronounSub.ToLower() + " climbed up into.");
                }
                else if (rand == 4)
                {
                    sb.AppendLine("After making sure no traps could be seen from the entrance, " + character.PronounSub.ToLower() + " tiptoed into the main room.");
                }
                else
                {
                    sb.AppendLine("Putting aside " + character.PronounPosAdj.ToLower() + " fear, " + character.Name + " took a deep breath and walked into the temple.");
                }

                //Outcome: 3rd sentence corresponds to the results of the event
                rand = rng.randomInt(1, 9);

                if (rand == 9 && character.WeaponName=="") rand = rng.randomInt(1, 8); //9 can only be an option if character has a weapon

                if (rand == 1) //Activates trap: causes damage
                {
                    damage = rng.randomInt(4,6);
                    character.hurt(damage);
                    if (character.IsAlive == true) //Character survives trap
                    {
                        sb.AppendLine(character.PronounSub + " immediately set off a trap, taking " + damage + " damage. " + character.PronounSub + " turned around and left.");
                    }
                    else //Character dies to trap
                    {
                        sb.AppendLine(character.PronounSub + " immediately set off a trap, taking " + damage + " damage. " + character.Name + " succumbed to " + character.PronounPosAdj.ToLower() + " injuries.");
                    }
                                         
                    break;
                }
                else if (rand == 2) //Activates trap: causes damage
                { 
                    damage= rng.randomInt(6,8);
                    character.hurt(damage);
                    if (character.IsAlive == true) //Character survives trap
                    {
                        sb.AppendLine(character.PronounSub + " was shot in the shoulder by a hidden arrow trap, taking " + damage + " damage. " + character.PronounSub + " stumbled out and safely removed the arrow.");
                    }
                    else //Character dies to trap
                    {
                        sb.AppendLine(character.PronounSub + " was shot in the shoulder by a hidden arrow trap, taking " + damage + " damage. " + character.Name + " succumbed to " + character.PronounPosAdj.ToLower() + " injuries.");
                    }
                                           
                    break;
                }
                else if (rand == 3) //Nothing happens
                {
                    sb.AppendLine(character.Name + " made it through many rooms before carelessly stepping on a pressure plate. Although " + character.PronounSub.ToLower() + " narrowly dodged the arrow, " + character.PronounSub.ToLower() + " decided to cut " + character.PronounPosAdj.ToLower() + " losses and turn back.");
                    break;
                }
                else if (rand == 4) //Gets common loot
                {
                    sb.Append("Reaching a treasure room unscathed, " + character.Name + " found something in a rusty chest. " + loot.lootEvent(character, "Common", game));
                    break;
                }
                else if (rand == 5) //Activates trap: causes damage
                {
                    character.hurt(2);
                    if (character.IsAlive == true) //Character survives trap
                    {
                        sb.Append(character.Name + " made it to a treasure room and activated a rock trap. Luckily, injuries were minor and " + character.PronounSub.ToLower() + " received an something from the chest. " + loot.lootEvent(character, "Common", game));
                    }
                    else //Character dies to trap
                    {
                        sb.AppendLine(character.Name + " made it to a treasure room and activated a rock trap. " + character.Name + " succumbed to " + character.PronounPosAdj.ToLower() + " injuries.");
                    }                 
                    
                    break;
                }
                else if (rand == 6) //Gets common loot
                {
                    sb.Append(character.Name + " managed to avoid every trap due to blind luck and found a treasure chest. " + loot.lootEvent(character, "Common", game));
                    break;
                }
                else if (rand == 7) //Death
                {
                    sb.AppendLine(character.Name + " found a secret passage. The door closed behind " + character.PronounObj.ToLower() + " and the floor dropped from under " + character.PronounObj.ToLower() + ", causing " + character.PronounObj.ToLower() + " to fall to " + character.PronounPosAdj.ToLower() + " death.");
                    character.hurt(100);
                    break;
                }
                else if (rand == 8) //First character to trigger this in each simulation gets rare loot, or common otherwise
                {
                    if (templeLootFound==false) //If this is the first time this option was triggered
                    {
                        sb.Append("Finding a secret and safe path, " + character.Name + " reached a secret treasure room and opened a pristine-looking chest. " + loot.lootEvent(character, "Rare", game));
                        templeLootFound = true;
                    }
                    else //If this isn't the first time this option was triggered
                    {
                        sb.Append("Finding a secret and safe path, " + character.Name + " reached a secret treasure room and opened a pristine-looking chest. The contents looked rummaged-through, but a couple leftover items still remained. " + loot.lootEvent(character, "Common", game));
                    }
                    
                    break;
                }
                else if (rand == 9) //Upgrade weapon
                {
                    if (character.Health >= 5)
                    {
                        sb.AppendLine(character.Name + " reached a large room with a shrine in the middle. Instructions engraved on the shrine read that a weapon could be strengthened with a blood sacrifice.\n" + character.PronounSub + " made a gash on " + character.PronounPosAdj.ToLower() + " arm, and placed the weapon on the shrine covered in blood. The weapon's attack went up by 2.");
                        character.upgradeWeapon("Strength");
                        character.hurt(2);
                        break;
                    }
                    else
                    {
                        sb.AppendLine(character.Name + " reached a large room with a shrine in the middle. Instructions engraved on the shrine read that a weapon could be strengthened with a blood sacrifice.\n" + character.PronounSub + " decided " + character.PronounSub.ToLower() + " was in too weakened a state to injure " + character.PronounRefl.ToLower() + " and left.");
                        break;
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Generates events corresponding to the Watchtower landmark for the character passed in.
        /// Characters may take damage/die, battle an NPC, and find loot in this landmark.
        /// </summary>
        public string watchtower(character character, Game game)
        {
            StringBuilder sb2 = new StringBuilder();
            int rand = rng.randomInt(1, 5);
            int damage;

            //While loop that never ends naturally is used so that some of the randomly selected events may result in the event ending early with break statements
            while (true)
            {
                //Discovery: 1st sentence corresponds to character finding the landmark
                if (rand == 1)
                {
                    sb2.AppendLine("At the top of the tallest hill, an old watchtower sat. Although " + character.Name + " was nervous about how much it stuck out, " + character.PronounSub.ToLower() + " approached.");
                }
                else if (rand == 2)
                {
                    sb2.AppendLine("Through the leaves of the trees, " + character.Name + " could see the top of an abandoned watchtower. " + character.PronounSub + " walked up to it quietly.");
                }
                else if (rand == 3)
                {
                    sb2.AppendLine("In the distance, an eerie-looking watchtower sat within " + character.Name + "'s view. " + character.PronounSub + " decided to go to it.");
                }
                else if (rand == 4) //character does not investigate further, break from loop
                {
                    sb2.AppendLine(character.Name + " found a 4-story watchtower near " + character.PronounPosAdj.ToLower() + " camp. Instead of investigating, " + character.PronounSub.ToLower() + " decided " + character.PronounSub.ToLower() + "'d better move " + character.PronounPosAdj.ToLower() + " spot.");
                    break;
                }
                else if (rand == 5)
                {
                    sb2.AppendLine(character.Name + " thought " + character.PronounSub.ToLower() + " saw something and climbed a hill. On top, " + character.PronounSub.ToLower() + " saw a watchtower covered in moss and ivy. " + character.PronounSub + " went up to examine it.");
                }

                //Examining: 2nd sentence corresponds to character looking at the entrance to the landmark
                rand = rng.randomInt(1, 5);
                if (rand == 1) 
                {
                    sb2.AppendLine("As " + character.PronounSub.ToLower() + " got closer, " + character.PronounSub.ToLower() + " looked around for other people and saw nobody. " + character.PronounSub + " entered the first floor of the tower.");
                }
                else if (rand == 2)
                {
                    sb2.AppendLine("There didn't appear to be any competitors around, so " + character.PronounSub.ToLower() + " walked into the tower.");
                }
                else if (rand == 3)
                {
                    sb2.AppendLine("Cautious of potential traps, " + character.PronounSub.ToLower() + " looked through the entrance and saw nothing out of the ordinary, then entered.");
                }
                else if (rand == 4)
                {
                    sb2.AppendLine(character.PronounSub + " got a strange feeling as " + character.PronounSub.ToLower() + " approached the entrance. Against " + character.PronounPosAdj.ToLower() + " better judgment, " + character.PronounSub.ToLower() + " walked through the door and onto the first floor.");
                }
                else if (rand == 5) //character does not investigate further, break from loop
                {
                    sb2.AppendLine("Hearing strange creaking sounds coming from farther up the tower, " + character.Name + " decided to turn back.");
                    break;
                }

                //Outcome: 3rd sentence corresponds to the results of the event
                rand = rng.randomInt(1, 5);

                if (rand == 1) //Takes damage
                {
                    damage = rng.randomInt(4, 5);
                    character.hurt(damage);
                    if (character.IsAlive == true) //If character survives
                    {
                        sb2.AppendLine("As " + character.PronounSub.ToLower() + " climbed the old ladder to the second floor, a rung snapped, and " + character.PronounSub.ToLower() + " fell and hit " + character.PronounPosAdj.ToLower() + " head, taking " + damage + " damage. Seeing no other way, " + character.PronounSub.ToLower() + " left injured.");
                    }
                    else //If character dies
                    {
                        sb2.AppendLine("As " + character.PronounSub.ToLower() + " climbed the old ladder to the second floor, a rung snapped, and " + character.PronounSub.ToLower() + " fell and hit " + character.PronounPosAdj.ToLower() + " head, taking " + damage + " damage. " + character.Name + " succumbed to " + character.PronounPosAdj.ToLower() + " injuries.");
                    }

                    break;
                }
                else if (rand==2) //First character to trigger this in each simulation battles NPC and gets rare loot, gets common loot otherwise
                {
                    character dummy = new character("The Living Dummy", "They", game);
                    dummy.Health = 10;
                    dummy.WeaponName = "knife";
                    dummy.WeaponAttack = 2.5;
                    dummy.WeaponType = "slash/stab";
                    dummy.IsNPC = true;

                    if (towerLootFound==false) //If this is the first time this option was triggered
                    {
                        sb2.AppendLine(character.PronounSub + " climbed 3 floors and ran into a wooden dummy holding a knife. It activated and attacked " + character.PronounObj.ToLower() + ".\n" + battle.NPCBattleEvent(character, dummy, game, true));
                        if (character.IsAlive == true) //If character wins dummy fight
                        {
                            rand = rng.randomInt(1, 2);
                            if (rand == 1) //Player gets rare loot
                            {
                                sb2.Append("After defeating the dummy, " + character.PronounSub.ToLower() + " climbed to the top floor and opened a chest. " + loot.lootEvent(character, "Rare", game));
                                towerLootFound = true;
                                break;
                            }
                            else //Player gets magic wand
                            {
                                if (character.WeaponName == "")
                                {
                                    sb2.Append("After defeating the dummy, " + character.PronounSub.ToLower() + " climbed to the top floor and saw a strange magic staff on a pedestal and took it.");
                                    character.SetWeapon("Sorcerer's Staff", 4, "special");
                                    character.WeaponStatus = rng.RandomStatus();
                                    towerLootFound = true;
                                    break;
                                }
                                else if (character.WeaponName != "" && character.WeaponAttack <=4)
                                {
                                    sb2.Append("After defeating the dummy, " + character.PronounSub.ToLower() + " climbed to the top floor and saw a strange magic staff on a pedestal and took it, replacing " + character.PronounPosAdj.ToLower() + " " + character.WeaponName + ".");
                                    character.SetWeapon("Sorcerer's Staff", 4, "special");
                                    character.WeaponStatus = rng.RandomStatus();
                                    towerLootFound = true;
                                    break;
                                }
                                else
                                {
                                    sb2.Append("After defeating the dummy, " + character.PronounSub.ToLower() + " climbed to the top floor and saw a strange magic staff on a pedestal, but decided not to touch it.");
                                    towerLootFound = true;
                                    break;
                                }
                            }

                        }
                        else break; //If character loses dummy fight
                    }
                    else //If this isn't the first time this option was triggered
                    {
                        sb2.Append(character.PronounSub + " climbed toward the top of the tower, seeing an unsettling wooden dummy on the ground of the third floor. " + character.PronounSub + " ignored it, and found a chest on the top floor. It appeared to have already been opened, but a couple less valuable items still remained inside. " + loot.lootEvent(character, "Common", game));
                        break;
                    }

                }
                else if (rand == 3) //Gets common loot
                {
                    sb2.AppendLine("On the second floor, " + character.PronounSub.ToLower() + " found an item in a hidden compartment. " + loot.lootEvent(character, "Common", game) + character.PronounSub + " heard noise from above and fled the tower quickly.");
                    break;
                }
                else if (rand == 4) //Nothing happens
                {
                    sb2.AppendLine("Seeing that the ladder was broken, " + character.Name + " took " + character.PronounObj.ToLower() + " chances and launched " + character.PronounRefl.ToLower() + " toward the rungs higher up. " + character.PronounSub + " missed and decided to turn back.");
                    break;
                }
                else if (rand == 5) //Gets a random potion effect applied to them
                {
                    sb2.AppendLine("In a random cabinet on the first floor, " + character.Name + " found a strange-looking liquid. Some unseen force compelled " + character.PronounObj.ToLower() + " to drink it, so " + character.PronounSub.ToLower() + " took a sip. " + loot.potionEvent(character, game));
                    if (character.IsAlive==true) //If potion doesn't kill character
                    {
                        sb2.AppendLine(character.PronounSub + " decided that was enough adventuring and turned away and left.");
                        break;
                    }
                    else //If potion kills character
                    {
                        sb2.AppendLine("The effects of the liquid were enough to kill " + character.PronounObj.ToLower() + ".");
                        break;
                    }                  
                }
            }
            return sb2.ToString();
        }

        /// <summary>
        /// Generates events corresponding to the Forest Imp Encampment landmark for the character passed in.
        /// Characters may take damage/die, battle an NPC, and find loot in this landmark.
        /// </summary>
        public string encampment(character character, Game game)
        {
            StringBuilder sb3 = new StringBuilder();
            int rand = rng.randomInt(1, 5);
            int randAntidote = rng.randomInt(1, 2);
            int leave = rng.randomInt(1, 4);
            int caught = rng.randomInt(1, 5);
            int randHealth = rng.randomInt(6, 10);
            int damage;
            bool music = false, hasFought = false;

            string sub = character.PronounSub; //he/she/they
            string obj = character.PronounObj; //him/her/them
            string pos = character.PronounPosAdj; //his/her/their

            character Imp = new character();
            Imp.Name = "Forest Imp Patrol";
            Imp.Health = randHealth;
            Imp.SetWeapon("blowgun", 2.5, "special");
            Imp.WeaponStatus = "Poison";
            Imp.IsNPC = true;
            if (randAntidote==1) Imp.HasAntidote = true;

            //While loop that never ends naturally is used so that some of the randomly selected events may result in the event ending early with break statements
            while (true)
            {
                //Discovery: 1st sentence corresponds to character finding the landmark
                if (rand == 1)
                {
                    sb3.Append(character.Name + " looked out from behind a tree to see a medium-sized encampment. The banner of the forest imps was hung at the entrance. ");
                    if (leave == 1)
                    {
                        sb3.AppendLine(sub + " got a bad feeling and turned around.");
                        break;
                    }
                    else sb3.AppendLine(sub + " decided to approach sneakily.");
                }
                else if (rand == 2)
                {
                    sb3.Append(character.Name + " heard some noise in the distance and saw a forest imp encampment surrounded by trees. ");
                    if (leave == 1)
                    {
                        sb3.AppendLine("Not wanting to take any chances, " + sub.ToLower() + " turned around and went the other way.");
                        break;
                    }
                    else sb3.AppendLine("Against " + pos.ToLower() + " better judgement, " + sub.ToLower() + " decided to walk up to the walls.");
                }
                else if (rand == 3)
                {
                    sb3.Append(character.Name + " nearly walked right into a small wooden gate. In front of " + obj.ToLower() + " lied a forest imp encampment, with burning torches on either side of the entrance. ");
                    if (leave == 1)
                    {
                        sb3.AppendLine("Panicked, " + sub.ToLower() + " fled the area quickly.");
                        break;
                    }
                    else sb3.AppendLine("Pledging to be more aware from now on, " + sub.ToLower() + " decided to stick around.");
                }
                else if (rand == 4)
                {
                    sb3.Append("In the middle of the first sat a forest imp encampment with walls around it. " + character.Name + " saw it and walked up to the gates. ");
                    if (leave == 1)
                    {
                        sb3.AppendLine("Upon getting a closer look, " + sub.ToLower() + " decided the risk was not worth the reward and left.");
                        break;
                    }
                    else sb3.AppendLine();
                }
                else
                {
                    sb3.Append(character.Name + " heard the sound of lively music coming from nearby. As " + sub.ToLower() + " approached, " + sub.ToLower() + " could see the short walls of a forest imp encampment through the leaves of the trees. ");
                    if (leave == 1)
                    {
                        sb3.AppendLine(sub + " listened to the music for a while before deciding not to push " + pos.ToLower() + " luck and walked away.");
                        break;
                    }
                    else
                    {
                        sb3.AppendLine(sub + " decided the music could be a distraction and approached the encampment.");
                        music = true;
                    }
                }

                //Examining: 2nd sentence corresponds to character looking at the entrance to the landmark
                rand = rng.randomInt(1, 7);
                if (music == true) rand = 4;

                if (rand == 1)
                {
                    sb3.Append("Looking around, things seemed quiet. A couple guards were in conversation while everyone else was asleep. ");
                    if (caught == 1)
                    {
                        sb3.AppendLine(sub + " ventured into the encampment and was immediately spotted by a patrol who was out of " + pos.ToLower() + " view before.\n" + battle.NPCBattleEvent(character, Imp, game, true));
                        if (character.IsAlive == true)
                        {
                            sb3.AppendLine("Luckily, " + sub.ToLower() + " was able to dispose of the patrol quietly and was able to move on.");
                            hasFought = true;
                        }
                        else break;
                    }
                    else sb3.AppendLine(sub + " walked in and moved toward a tent sneakily.");
                }
                else if (rand == 2)
                {
                    sb3.Append(sub + " stuck " + pos.ToLower() + " head barely over the wall and saw forest imps sitting in a circle enjoying a stew in the middle of the camp. ");
                    if (caught == 1)
                    {
                        sb3.AppendLine(sub + " ventured into the encampment and was immediately spotted by a patrol who was out of " + pos.ToLower() + " view before.\n" + battle.NPCBattleEvent(character, Imp, game, true));
                        if (character.IsAlive == true)
                        {
                            sb3.AppendLine("Luckily, " + sub.ToLower() + " was able to dispose of the patrol quietly while the others were eating and was able to move on.");
                            hasFought = true;
                        }
                        else break;
                    }
                    else sb3.AppendLine(sub + " walked in and moved toward a tent sneakily, using the meal as a distraction.");
                }
                else if (rand == 3)
                {
                    sb3.AppendLine("Climbing carefully over the wall on the far side, " + sub.ToLower() + " noticed a pair of forest imps guarding a prisoner while the others were fast asleep and advanced quietly toward a tent.");
                }
                else if (rand == 4)
                {
                    sb3.Append("Peering over the walls along the border of the camp, " + sub.ToLower() + " spotted a couple imps playing an upbeat tune with a fiddle and flute while the rest of the residents fluttered around to rhythm. ");
                    if (caught == 1)
                    {
                        sb3.AppendLine(sub + " ventured into the encampment and was immediately spotted by a patrol who was out of " + pos.ToLower() + " view before.\n" + battle.NPCBattleEvent(character, Imp, game, true));
                        if (character.IsAlive == true)
                        {
                            sb3.AppendLine("Luckily, " + sub.ToLower() + " was able to dispose of the patrol quietly while the music was a distraction and was able to move on.");
                            hasFought = true;
                        }
                        else break;
                    }
                    else sb3.AppendLine(sub + " walked in and moved toward a tent sneakily, using the music as a distraction.");
                }
                else if (rand == 5)
                {
                    sb3.Append("On the other side of the encampment walls sat a bunch of tents, one of which " + character.Name + " noticed held a pile of treasure and weapons. ");
                    if (caught == 1)
                    {
                        sb3.AppendLine(sub + " ventured into the encampment and was immediately spotted by a patrol who was out of " + pos.ToLower() + " view before.\n" + battle.NPCBattleEvent(character, Imp, game, true));
                        if (character.IsAlive == true)
                        {
                            sb3.AppendLine("Luckily, " + sub.ToLower() + " was able to dispose of the patrol quietly and was able to move on.");
                            hasFought = true;
                        }
                        else break;
                    }
                    else sb3.AppendLine(sub + " walked in and moved toward a tent sneakily.");
                }
                else if (rand == 6)
                {
                    sb3.Append(sub + " saw a number of tents scattered across the encampment, but one had an ancient-looking shrine in it that caught " + pos.ToLower() + " attention. ");
                    if (caught == 1)
                    {
                        sb3.AppendLine(sub + " ventured into the encampment and was immediately spotted by a patrol who was out of " + pos.ToLower() + " view before.\n" + battle.NPCBattleEvent(character, Imp, game, true));
                        if (character.IsAlive == true)
                        {
                            sb3.AppendLine("Luckily, " + sub.ToLower() + " was able to dispose of the patrol quietly and was able to move on.");
                            hasFought = true;
                        }
                        else break;
                    }
                    else sb3.AppendLine(sub + " walked in and moved toward a tent sneakily.");
                }
                else
                {
                    sb3.Append("Amidst the tents that housed the forest imps, patrols flew around slowly, making sure intruders couldn't sneak in. ");
                    if (caught == 1)
                    {
                        sb3.AppendLine(sub + " ventured into the encampment and was immediately spotted by a patrol who was out of " + pos.ToLower() + " view before.\n" + battle.NPCBattleEvent(character, Imp, game, true));
                        if (character.IsAlive == true)
                        {
                            sb3.AppendLine("Luckily, " + sub.ToLower() + " was able to dispose of the patrol quietly and was able to move on.");
                            hasFought = true;
                        }
                        else break;
                    }
                    else sb3.AppendLine(sub + " walked in and moved toward a tent sneakily.");
                }

                caught = rng.randomInt(1, 5); //Second chance to get into an imp battle
                randHealth = rng.randomInt(6, 10);

                //Outcome: 3rd sentence corresponds to the results of the event
                if (character.WeaponName == ""  && hasFought == false) rand = rng.randomInt(1, 8); //If character has no weapon, they can't do the embue event
                else if (character.WeaponName == "" && hasFought == true) rand = rng.randomInt(2, 8); //If character has no weapon and has fought a patrol, they can't do the death or embue event
                else if (character.WeaponName != "" && hasFought == true) rand = rng.randomInt(2, 10); //If character has a weapon and has fought a patrol, they can do the embue event but not the death event
                else rand = rng.randomInt(1, 10); //If character has a weapon and has not fought a patrol, they can get anything

                if (rand == 1) //Death
                {
                    sb3.AppendLine(character.Name + " ran from tent to tent, careful to avoid being spotted. About to be caught by a patrol, " + sub.ToLower() + " was forced to run into the nearest tent, " +
                        "where " + sub.ToLower() + " activated a trap that caused a loud noise to sound throughout the encampment. Imps from all over swarmed into the tent, overwhelming and killing " + obj.ToLower() + ".");
                    character.Health = 0;
                    character.IsAlive = false;
                    break;
                }
                else if (rand >= 2 && rand < 5) //Fill hunger
                {
                    sb3.Append(character.Name + " snuck around and picked the closest tent " + sub.ToLower() + " could get to, not wanting to push " + pos.ToLower() + " luck. ");
                    if (caught == 1)
                    {
                        Imp.Health = randHealth;
                        Imp.SetWeapon("blowgun", 2.5, "special");
                        Imp.WeaponStatus = "Poison";
                        Imp.IsAlive = true;
                        sb3.AppendLine("Inside the tent, there was a patrol who immediately spotted " + obj.ToLower() + ".\n" + battle.NPCBattleEvent(character, Imp, game, true));
                        if (character.IsAlive == true)
                        {
                            sb3.AppendLine("After defeating the patrol, " + character.Name + " looked around the tent and saw there was a kitchen of some sorts, and " + sub.ToLower() + " ate as much food as " + sub.ToLower() +
                                " could stomach in a short period of time and got out of the encampment.");
                            if (game.Mode == "Realistic" && game.DoHunger == true) character.Hunger += 10;
                            break;
                        }
                        else break;
                    }
                    else
                    {
                        sb3.AppendLine("Inside, " + sub.ToLower() + " could see there was a kitchen of some sorts, and " + sub.ToLower() + " ate as much food as " + sub.ToLower() +
                                " could stomach in a short period of time and got out of the encampment.");
                        if (game.Mode == "Realistic" && game.DoHunger == true) character.Hunger += 10;
                        break;
                    }
                }
                else if (rand >= 5 && rand < 9) //Loot
                {
                    sb3.Append("After picking and choosing moments to run across to different tents, " + character.Name + " found the tent that caught " + pos.ToLower() + " eye most. ");
                    if (caught == 1)
                    {
                        Imp.Health = randHealth;
                        Imp.SetWeapon("blowgun", 2.5, "special");
                        Imp.WeaponStatus = "Poison";
                        Imp.IsAlive = true;
                        sb3.AppendLine("Inside the tent, there was a patrol who immediately spotted " + obj.ToLower() + ".\n" + battle.NPCBattleEvent(character, Imp, game, true));
                        if (character.IsAlive == true)
                        {
                            sb3.Append("After defeating the patrol, " + character.Name + " looked around the tent and saw it was an armory tent. " + sub + " grabbed something and fled the premises quickly. " + loot.lootEvent(character, rng.RandomRarity(), game));
                            break;
                        }
                        else break;
                    }
                    else
                    {
                        sb3.Append("It looked like an armory tent, and " + sub.ToLower() + " grabbed something and fled the premises quickly. " + loot.lootEvent(character, rng.RandomRarity(), game));
                        break;
                    }
                }
                else //Imbue weapon
                {
                    string oldName = character.WeaponName;

                    sb3.Append("Staying close to the ground in the tall grass, " + character.Name + " was able to sneak around to a special-looking tent. ");
                    if (caught == 1)
                    {
                        Imp.Health = randHealth;
                        Imp.SetWeapon("blowgun", 2.5, "special");
                        Imp.WeaponStatus = "Poison";
                        Imp.IsAlive = true;
                        sb3.AppendLine("Inside the tent, there was a patrol who immediately spotted " + obj.ToLower() + ".\n" + battle.NPCBattleEvent(character, Imp, game, true));
                        if (character.IsAlive == true)
                        {
                            sb3.Append("After defeating the patrol, " + character.Name + " looked around and saw an ancient-looking shrine. " + sub + " got an inexplicable urge to put " + pos.ToLower() + " weapon on the top, and upon doing so the" +
                                " weapon glowed briefly and seemed to get more powerful. ");
                            character.upgradeWeapon(rng.RandomStatus());
                            sb3.AppendLine(character.Name + "'s " + oldName + " became " + loot.getWeaponArticle(character.WeaponName) + " " + character.WeaponName + ". Satisfied with the venture, " + sub.ToLower() + " snuck out the way " + sub.ToLower() + " came in.");
                            break;
                        }
                        else break;
                    }
                    else
                    {
                        sb3.AppendLine("In the tent stood an ancient-looking shrine. " + sub + " got an inexplicable urge to put " + pos.ToLower() + " weapon on the top, and upon doing so the weapon glowed briefly and seemed to get more powerful.");
                        character.upgradeWeapon(rng.RandomStatus());
                        sb3.AppendLine(character.Name + "'s " + oldName + " became " + loot.getWeaponArticle(character.WeaponName) + " " + character.WeaponName + ". Satisfied with the venture, " + sub.ToLower() + " snuck out the way " + sub.ToLower() + " came in.");
                        break;
                    }
                }
            }

            return sb3.ToString();
        }

        /// <summary>
        /// Generates events corresponding to the Demon's Tomb landmark for the character passed in.
        /// A character may be possessed by a demon in this event or leave without anything happening.
        /// </summary>
        public string tomb(character character, Game game)
        {
            StringBuilder sb4 = new StringBuilder();
            int rand = rng.randomInt(1, 3);

            if (character.WeaponName == "" || character.Health <= 3)
            {
                sb4.AppendLine(character.Name + " ran into some strange markings on the side of the mountain. Featured in the center of the markings stood a shadowy figure that resembled a demon. " +
                       "There seemed to be the shape of a doorway around everything else, and below the demon, a symbol that looked like a handprint made of blood appeared to be glowing. " + character.Name + " got an uneasy feeling and walked away.");
                return sb4.ToString();
            }
            else
            {
                sb4.AppendLine(character.Name + " ran into some strange markings on the side of the mountain. Featured in the center of the markings stood a shadowy figure that resembled a demon. " +
                       "There seemed to be the shape of a doorway around everything else, and below the demon, a symbol that looked like a handprint made of blood appeared to be glowing. " + character.Name + " slashed " + character.PronounPosAdj.ToLower() + " hand and pressed " +
                       character.PronounPosAdj.ToLower() + " bloody hand against the symbol. The outline of the doorway glowed, and two stone doors opened inward toward the center.");
                character.hurt(2);
                sb4.AppendLine("Inside, " + character.Name + " could see a small room with a large, sealed casket up against the wall straight ahead. As " + character.PronounSub.ToLower() + " ventured closer, " + character.PronounSub.ToLower() +
                    " could see a pentagram etched into the casket. A very old book sat on the ground in front of the casket, caked in dust and dirt.");
                sb4.AppendLine(character.Name + " picked up the book and opened it. Some of it was in a language " + character.PronounSub.ToLower() + " couldn't understand. There appeared to be a lot of talk about an ancient demon, and at the end " + character.PronounSub.ToLower() +
                    " could clearly make out the line \"The ghastly demon was sealed away using these words:\" followed by something in an ancient language.");
                if (rand == 1)
                {
                    string[] lines = File.ReadAllLines(@"names.txt");
                    string demonName = lines[rng.randomInt(0,9)];

                    sb4.AppendLine(character.Name + " repeated those words scribbled furiously into the book, and immediately the ground around the casket started to tremble violently as the lid to the casket popped open slowly. A large, shadowy figure " +
                        "with glowing red eyes rose out and stared at " + character.PronounObj.ToLower() + ".");
                    sb4.AppendLine("-- " + demonName + ": \"My thanks for releasing me from my slumber. Your body will be an acceptable host for me in my conquest, as I cannot exist in this form for long. Goodbye, mortal.\" ");
                    sb4.AppendLine("The demon " + demonName + " started to vanish as " + character.Name + "'s body started to reverberate violently. " + character.PronounPosAdj + " eyes began to glow the same demon-like red, and " +
                        character.PronounPosAdj.ToLower() + " body stopped shaking, born into a new form. The demon picked up the ancient weapon lying in the casket and walked out of the tomb, ready to slaughter anyone in sight.");
                    
                    //Character is turned into a version of themselves with the demon possessing their body
                    character.Name = character.Name + " (" + demonName + ")";
                    character.Health = game.StartHealth*5;
                    character.SetWeapon("Nightblood", 10, "special");
                    character.OriginalWeaponName = character.WeaponName;
                    character.WeaponStatus = "Burning";
                    character.ClearStatuses();
                    if (game.Mode == "Realistic")
                    {
                        character.Speed = 10;
                        character.Strength = 10;
                        character.Morality = 0;
                        if (game.DoHunger == true) character.Hunger = 1000;
                    }

                    this.possession = true;
                    return sb4.ToString();
                }
                else
                {
                    sb4.AppendLine(character.Name + " felt a chill go down " + character.PronounPosAdj.ToLower() + " spine and decided to immediately get out of there. Who knows what horrors were avoided here?");
                    return sb4.ToString();
                }
            }

        }
    }
}
