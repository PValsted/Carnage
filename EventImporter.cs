using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Carnage
{

    /// <summary>
    /// This class is designed to import event lines from a MySQL Database and convert them
    /// into strings. This functions by converting values recorded alongside the event text
    /// into actions that affect character variables and outcomes. The info for the MySQL server
    /// is directly listed here. It's understood that in a practical setting, this information should
    /// never be shown in the source code; this was done out of convenience for this project.
    /// </summary>
    public class EventImporter
    {
        RNG rng = new RNG();
        List<character> battleList = new List<character>();
        Loot loot = new Loot();

        /// <summary>
        /// Retrieves the number of entries contained in the MySQL Database for the 
        /// event type pased in in order to be used to randomly select an entry for that type.
        /// </summary>
        public int getNumber(string type)
        {
            //The below set of MySQL objects use the connection string to connect to the server and pass in the
            //generated MySQL command. This result is passed back in array form, and each method extracts
            //the necessary values. This happens in just about all of this class's methods.
            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            string strSQL = "SELECT COUNT(Type) FROM Events WHERE Type = '" + type + "';";

            MySqlCommand sqlComd = new MySqlCommand(strSQL, con);
            DataSet dsSQLDataSet = new DataSet();
            MySqlDataAdapter daAdapter = new MySqlDataAdapter(strSQL, con);

            con.Open();
            daAdapter.Fill(dsSQLDataSet);

            int num = Int32.Parse(dsSQLDataSet.Tables[0].Rows[0][0].ToString());

            con.Close();
            return num;
        }

        /// <summary>
        /// Takes the line passed in that was extracted from the MySQL Database and
        /// replaces placeholder values in the sentence with the appropriate values
        /// based on the character who the event applies to.
        /// </summary>
        public string replaceText(string eventText, character character)
        {
            eventText = eventText.Replace("{1}", character.Name); //For example, any instance of {1} in a sentence is replaced with the character's name
            eventText = eventText.Replace("{CapSubPro}", character.PronounSub);
            eventText = eventText.Replace("{CapObjPro}", character.PronounObj);
            eventText = eventText.Replace("{CapPosAdjPro}", character.PronounPosAdj);
            eventText = eventText.Replace("{CapPosPro}", character.PronounPos);
            eventText = eventText.Replace("{CapRefPro}", character.PronounRefl);
            eventText = eventText.Replace("{SubPro}", (character.PronounSub).ToLower());
            eventText = eventText.Replace("{ObjPro}", (character.PronounObj).ToLower());
            eventText = eventText.Replace("{PosAdjPro}", (character.PronounPosAdj).ToLower());
            eventText = eventText.Replace("{PosPro}", (character.PronounPos).ToLower());
            eventText = eventText.Replace("{RefPro}", (character.PronounRefl).ToLower());
            eventText = eventText.Replace("{BodyPart}", (rng.randomBodyPart()));
            eventText = eventText.Replace("{WasProper}", (this.ProperTense(character)));

            return eventText;
        }

        /// <summary>
        /// Takes the line passed in that was extracted from the MySQL Database and
        /// replaces placeholder values in the sentence with the appropriate values
        /// based on the two characters who the event applies to.
        /// </summary>
        public string replaceText(string eventText, character char1, character char2)
        {
            eventText = eventText.Replace("{1}", char1.Name);
            eventText = eventText.Replace("{CapSubPro}", char1.PronounSub);
            eventText = eventText.Replace("{CapObjPro}", char1.PronounObj);
            eventText = eventText.Replace("{CapPosAdjPro}", char1.PronounPosAdj);
            eventText = eventText.Replace("{CapPosPro}", char1.PronounPos);
            eventText = eventText.Replace("{CapRefPro}", char1.PronounRefl);
            eventText = eventText.Replace("{SubPro}", (char1.PronounSub).ToLower());
            eventText = eventText.Replace("{ObjPro}", (char1.PronounObj).ToLower());
            eventText = eventText.Replace("{PosAdjPro}", (char1.PronounPosAdj).ToLower());
            eventText = eventText.Replace("{PosPro}", (char1.PronounPos).ToLower());
            eventText = eventText.Replace("{RefPro}", (char1.PronounRefl).ToLower());
            eventText = eventText.Replace("{BodyPart}", (rng.randomBodyPart()));
            eventText = eventText.Replace("{WasProper}", (this.ProperTense(char1)));

            eventText = eventText.Replace("{2}", char2.Name);
            eventText = eventText.Replace("{CapSubPro2}", char2.PronounSub);
            eventText = eventText.Replace("{CapObjPro2}", char2.PronounObj);
            eventText = eventText.Replace("{CapPosAdjPro2}", char2.PronounPosAdj);
            eventText = eventText.Replace("{CapPosPro2}", char2.PronounPos);
            eventText = eventText.Replace("{CapRefPro2}", char2.PronounRefl);
            eventText = eventText.Replace("{SubPro2}", (char2.PronounSub).ToLower());
            eventText = eventText.Replace("{ObjPro2}", (char2.PronounObj).ToLower());
            eventText = eventText.Replace("{PosAdjPro2}", (char2.PronounPosAdj).ToLower());
            eventText = eventText.Replace("{PosPro2}", (char2.PronounPos).ToLower());
            eventText = eventText.Replace("{RefPro2}", (char2.PronounRefl).ToLower());

            return eventText;
        }

        /// <summary>
        /// Takes the line passed in that was extracted from the MySQL Database and
        /// replaces the placeholder value with the proper form of "was" based on the
        /// character's pronouns.
        /// </summary>
        public string ProperTense(character char1)
        {
            if (char1.PronounSub == "They") return "were"; //They were
            else return "was"; // He/she was
        }

        /// <summary>
        /// Selects a random regular event to apply to the character passed in. Takes the
        /// appropriate values associated with the text in the MySQL Database and applies
        /// any consequences to the character, and the event is returned as a string.
        /// </summary>
        public string regularEvent(character character, Game game)
        {
            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);


            string strSQL = "SELECT * FROM Events WHERE Type = 'Regular' AND ID = 'Regular" + rng.randomInt(1,this.getNumber("Regular")) + "';";

            MySqlCommand sqlComd = new MySqlCommand(strSQL, con);
            DataSet dsSQLDataSet = new DataSet();
            MySqlDataAdapter daAdapter = new MySqlDataAdapter(strSQL, con);

            con.Open();
            daAdapter.Fill(dsSQLDataSet);

            string eventText = (dsSQLDataSet.Tables[0].Rows[0][1].ToString() + "\n");
            string type = (dsSQLDataSet.Tables[0].Rows[0][6].ToString());

            if (type=="Damage") //If the regular event results in the character taking damage, that is taken into effect here
            {
                character.hurt(Math.Round(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()), 2));
                
                if (character.IsAlive==false) //If the character is dead after this damage, this is tacked on after the event message to indicate that the character died
                {
                    eventText = this.replaceText(eventText, character) + character.Name + " succumbed to " + character.PronounPosAdj.ToLower() + " injuries.\n";
                    return eventText;
                }
            }

            con.Close();

            if (type=="Morality" && game.Mode=="Realistic") //If the regular event results in the character's morality changing (if realistic mode), that is taken into effect here
            {
                character.Morality -= 2;
                eventText = this.replaceText(eventText, character) + character.Name + "'s morality level dropped by 2.\n";
                return eventText;
            }

            eventText = this.replaceText(eventText, character);

            return eventText;
        }

        /// <summary>
        /// Selects a random gain event to apply to the character passed in. Takes the
        /// appropriate values associated with the text in the MySQL Database and applies
        /// any consequences to the character, and the event is returned as a string.
        /// </summary>
        public string gainEvent(character character, Game game)
        {
            StringBuilder sb = new StringBuilder();

            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            string strSQL = "SELECT * FROM Events WHERE Type = 'Gain' AND ID = 'Gain" + rng.randomInt(1, this.getNumber("Gain")) + "';";

            MySqlCommand sqlComd = new MySqlCommand(strSQL, con);
            DataSet dsSQLDataSet = new DataSet();
            MySqlDataAdapter daAdapter = new MySqlDataAdapter(strSQL, con);

            con.Open();
            daAdapter.Fill(dsSQLDataSet);

            string type = dsSQLDataSet.Tables[0].Rows[0][6].ToString();

            string eventText = dsSQLDataSet.Tables[0].Rows[0][1].ToString();
            eventText = this.replaceText(eventText, character);

            if (type == "Healing") //If the event results in a character gaining a healing item, character is either healed, or if at full health the item is saved for later use
            {
                if (character.Health + Math.Round(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()), 2) <= game.StartHealth) //If the healing item would not put the character past full health, they use it
                {
                    character.heal(Math.Round(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()),2), game, dsSQLDataSet.Tables[0].Rows[0][4].ToString());
                }
                else if (character.Health + Math.Round(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()), 2) > game.StartHealth && character.HealSlotFilled == false) //If item would put them over full health, they save it
                {
                    character.HealingAmount = Math.Round(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()),2);
                }
            }
            else if (type =="Food") //If the event results in a character getting food, character increases hunger
            {
                sb.AppendLine(eventText);
                character.Hunger += Math.Round(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()),2);
            }
            else if (type == "IfHungry") //Character only performs action if hunger is at a certain level
            {
                if (character.Hunger > 2 && game.Mode == "Realistic") //If character hunger is above 2, another event is recursively selected
                {
                    sb.Append(gainEvent(character, game));
                    return sb.ToString();
                }
                else
                {
                    sb.AppendLine(eventText);
                    if (game.Mode=="Realistic") character.Hunger += Math.Round(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()), 2);
                }
            }
            else if (type=="Loot") //If the event results in loot, the character goes through a common loot event
            {
                sb.Append(eventText + " " + loot.lootEvent(character, "Common", game));
            }
            else if (type=="Antidote") //If the event results in finding an antidote
            {
                if (character.GetStatus("Poison") == true)
                {
                    sb.AppendLine(eventText + " " + character.Name + " uses them to cure " + character.PronounPosAdj.ToLower() + " Poison.");
                    character.RemoveStatus("Poison");
                }
                else if (character.GetStatus("Poison") == false && character.HasAntidote == false)
                {
                    sb.AppendLine(eventText + " " + character.Name + " saves them for later.");
                    character.HasAntidote = true;
                }
                else sb.AppendLine(eventText);
            }
            else //If the event results in gaining a weapon, the appropriate values pertaining to this weapon are changed to reflect the new values
            {
                if (character.WeaponName == "") //If character has no weapon this weapon is equipped
                {
                    character.WeaponName = dsSQLDataSet.Tables[0].Rows[0][4].ToString();
                    character.OriginalWeaponName = character.WeaponName;
                    character.WeaponAttack = Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString());
                    character.WeaponType = dsSQLDataSet.Tables[0].Rows[0][6].ToString();
                    sb.AppendLine(eventText + " " + character.Name + " gained a " + character.WeaponName + ".");
                }
                else if (character.WeaponAttack < Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()) && character.WeaponName != "") //If new weapon does more damage than current weapon, this weapon is equipped
                {
                    sb.AppendLine(eventText + " " + character.Name + " replaced " + character.PronounPosAdj.ToLower() + " " + character.WeaponName + ".");
                    character.WeaponName = dsSQLDataSet.Tables[0].Rows[0][4].ToString();
                    character.OriginalWeaponName = character.WeaponName;
                    character.WeaponAttack = Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString());
                    character.WeaponType = dsSQLDataSet.Tables[0].Rows[0][6].ToString();
                }
                else //If new weapon is worse than current, the weapon is not equipped
                {
                    sb.AppendLine(eventText);
                }
            }

            con.Close();

            if (type == "Healing") 
            {
                if (character.Health + Math.Round(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()), 2) <= game.StartHealth) sb.AppendLine(eventText + " " + character.Name + " healed to " + character.Health + " health.");
                else if (character.Health + Math.Round(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()), 2) > game.StartHealth && character.HealSlotFilled == false)
                {
                    sb.AppendLine(eventText + " " + character.Name + " does not need it currently, so they save it for later.");
                    character.HealingName = dsSQLDataSet.Tables[0].Rows[0][4].ToString();
                    character.HealSlotFilled = true;
                }
                else sb.AppendLine(eventText);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Selects a random death event to apply to the character passed in. Takes the
        /// appropriate values associated with the text in the MySQL Database and applies
        /// any consequences to the character, and the event is returned as a string.
        /// </summary>
        public string deathEvent(character character, Game game)
        {
            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);


            string strSQL = "SELECT * FROM Events WHERE Type = 'Death' AND ID = 'Death" + rng.randomInt(1, this.getNumber("Death")) + "';";

            MySqlCommand sqlComd = new MySqlCommand(strSQL, con);
            DataSet dsSQLDataSet = new DataSet();
            MySqlDataAdapter daAdapter = new MySqlDataAdapter(strSQL, con);

            con.Open();
            daAdapter.Fill(dsSQLDataSet);

            string eventText = (dsSQLDataSet.Tables[0].Rows[0][1].ToString() + "\n");
            string type = (dsSQLDataSet.Tables[0].Rows[0][6].ToString());

            con.Close();

            if (type=="IfHungry" && character.Hunger>2 && game.Mode=="Realistic") //The IfHungry death event is only performed if a character's hunger is below 2, otherwise another death event is selected recursively
            {
                eventText = deathEvent(character, game);
                return eventText;
            }
            else //Death event selected, character is killed
            {
                eventText = this.replaceText(eventText, character);

                character.hurt(100);              
            }

            return eventText;
        }

    }
}
