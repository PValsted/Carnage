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
    public class EventImporter
    {
        RNG rng = new RNG();
        List<character> battleList = new List<character>();

        public int getNumber(string type)
        {
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

        public string replaceText(string eventText, character character)
        {
            eventText = eventText.Replace("{1}", character.getName());
            eventText = eventText.Replace("{CapSubPro}", character.getPronounSub());
            eventText = eventText.Replace("{CapObjPro}", character.getPronounObj());
            eventText = eventText.Replace("{CapPosAdjPro}", character.getPronounPosAdj());
            eventText = eventText.Replace("{CapPosPro}", character.getPronounPos());
            eventText = eventText.Replace("{CapRefPro}", character.getPronounRefl());
            eventText = eventText.Replace("{SubPro}", (character.getPronounSub()).ToLower());
            eventText = eventText.Replace("{ObjPro}", (character.getPronounObj()).ToLower());
            eventText = eventText.Replace("{PosAdjPro}", (character.getPronounPosAdj()).ToLower());
            eventText = eventText.Replace("{PosPro}", (character.getPronounPos()).ToLower());
            eventText = eventText.Replace("{RefPro}", (character.getPronounRefl()).ToLower());

            return eventText;
        }

        public string replaceText(string eventText, character char1, character char2)
        {
            eventText = eventText.Replace("{1}", char1.getName());
            eventText = eventText.Replace("{CapSubPro}", char1.getPronounSub());
            eventText = eventText.Replace("{CapObjPro}", char1.getPronounObj());
            eventText = eventText.Replace("{CapPosAdjPro}", char1.getPronounPosAdj());
            eventText = eventText.Replace("{CapPosPro}", char1.getPronounPos());
            eventText = eventText.Replace("{CapRefPro}", char1.getPronounRefl());
            eventText = eventText.Replace("{SubPro}", (char1.getPronounSub()).ToLower());
            eventText = eventText.Replace("{ObjPro}", (char1.getPronounObj()).ToLower());
            eventText = eventText.Replace("{PosAdjPro}", (char1.getPronounPosAdj()).ToLower());
            eventText = eventText.Replace("{PosPro}", (char1.getPronounPos()).ToLower());
            eventText = eventText.Replace("{RefPro}", (char1.getPronounRefl()).ToLower());

            eventText = eventText.Replace("{2}", char2.getName());
            eventText = eventText.Replace("{CapSubPro2}", char2.getPronounSub());
            eventText = eventText.Replace("{CapObjPro2}", char2.getPronounObj());
            eventText = eventText.Replace("{CapPosAdjPro2}", char2.getPronounPosAdj());
            eventText = eventText.Replace("{CapPosPro2}", char2.getPronounPos());
            eventText = eventText.Replace("{CapRefPro2}", char2.getPronounRefl());
            eventText = eventText.Replace("{SubPro2}", (char2.getPronounSub()).ToLower());
            eventText = eventText.Replace("{ObjPro2}", (char2.getPronounObj()).ToLower());
            eventText = eventText.Replace("{PosAdjPro2}", (char2.getPronounPosAdj()).ToLower());
            eventText = eventText.Replace("{PosPro2}", (char2.getPronounPos()).ToLower());
            eventText = eventText.Replace("{RefPro2}", (char2.getPronounRefl()).ToLower());

            return eventText;
        }

        public string regularEvent(character character)
        {
            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);


            string strSQL = "SELECT Text FROM Events WHERE Type = 'Regular' AND ID = 'Regular" + rng.randomInt(1,this.getNumber("Regular")) + "';";

            MySqlCommand sqlComd = new MySqlCommand(strSQL, con);
            DataSet dsSQLDataSet = new DataSet();
            MySqlDataAdapter daAdapter = new MySqlDataAdapter(strSQL, con);

            con.Open();
            daAdapter.Fill(dsSQLDataSet);

            string eventText = (dsSQLDataSet.Tables[0].Rows[0][0].ToString());
            con.Close();

            eventText = this.replaceText(eventText, character);

            return eventText;
        }

        public string gainEvent(character character)
        {
            string sql = "Server=sql5.freesqldatabase.com;Database=sql5693000;Uid=sql5693000;Pwd=yD7AbEqn2I;";
            MySqlConnection con = new MySqlConnection(sql);

            string strSQL = "SELECT * FROM Events WHERE Type = 'Gain' AND ID = 'Gain" + rng.randomInt(1, this.getNumber("Gain")) + "';";

            MySqlCommand sqlComd = new MySqlCommand(strSQL, con);
            DataSet dsSQLDataSet = new DataSet();
            MySqlDataAdapter daAdapter = new MySqlDataAdapter(strSQL, con);

            con.Open();
            daAdapter.Fill(dsSQLDataSet);

            string type = dsSQLDataSet.Tables[0].Rows[0][6].ToString();

            StringBuilder sb = new StringBuilder();

            string eventText = dsSQLDataSet.Tables[0].Rows[0][1].ToString();
            eventText = this.replaceText(eventText, character);

            if (type == "Healing")
            {
                if (character.getHealth() < 20)
                {
                    character.heal(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()));
                }
                else if (character.getHealth() == 20 && character.isHealSlotFilled() == false)
                {
                    character.setHealingAmount(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()));
                }
            }
            else
            {
                if (character.getWeaponName() == "")
                {
                    character.setWeaponName(dsSQLDataSet.Tables[0].Rows[0][4].ToString());
                    character.setWeaponAttack(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()));
                    character.setWeaponType(dsSQLDataSet.Tables[0].Rows[0][6].ToString());
                    sb.AppendLine(eventText + " " + character.getName() + " gained a " + character.getWeaponName() + ".");
                }
                else if (character.getWeaponAttack() < Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()) && character.getWeaponName() != "")
                {
                    sb.AppendLine(eventText + " " + character.getName() + " replaced " + character.getPronounPosAdj().ToLower() + " " + character.getWeaponName() + ".");
                    character.setWeaponName(dsSQLDataSet.Tables[0].Rows[0][4].ToString());
                    character.setWeaponAttack(Double.Parse(dsSQLDataSet.Tables[0].Rows[0][5].ToString()));
                    character.setWeaponType(dsSQLDataSet.Tables[0].Rows[0][6].ToString());
                }
                else
                {
                    sb.AppendLine(eventText);
                }
            }

            con.Close();

            if (type == "Healing")
            {
                if (character.getHealth() < 20) sb.AppendLine(eventText + " " + character.getName() + " healed to " + character.getHealth() + " health.");
                else if (character.getHealth() == 20 && character.isHealSlotFilled() == false)
                {
                    sb.AppendLine(eventText + " " + character.getName() + " is at full health so they save it for later.");
                    character.fillHealSlot(true);
                }
                else sb.AppendLine(eventText);
            }

            return sb.ToString();
        }

    }
}
