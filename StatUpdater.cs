using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{
    public class StatUpdater
    {

        public string UpdateName(string id, List<character> list, List<character> deathList)
        {
            StringBuilder sb = new StringBuilder();

            if (list.Find(x => x.Id == id) != null)
            {
                if (list.Find(x => x.Id == id).Kills != 1) //If character has plural number of kills
                {
                    sb.Append(list.Find(x => x.Id == id).Name + ": " + list.Find(x => x.Id == id).Kills.ToString() + " kills");
                }
                else //If character has 1 kill
                {
                    sb.Append(list.Find(x => x.Id == id).Name + ": " + list.Find(x => x.Id == id).Kills.ToString() + " kill");
                }
            }
            else
            {
                if (deathList.Find(x => x.Id == id).Kills != 1) //If character has plural number of kills
                {
                    sb.Append(deathList.Find(x => x.Id == id).Name + ": " + deathList.Find(x => x.Id == id).Kills.ToString() + " kills");
                }
                else //If character has 1 kill
                {
                    sb.Append(deathList.Find(x => x.Id == id).Name + ": " + deathList.Find(x => x.Id == id).Kills.ToString() + " kill");
                }
            }


            return sb.ToString();
        }

        public string UpdateHealth(string id, List<character> list, Game game)
        {
            StringBuilder sb = new StringBuilder();

            if (list.Find(x => x.Id == id) != null)
            {
                if (game.Mode == "Classic") //If classic mode
                {
                    sb.Append(list.Find(x => x.Id == id).Health.ToString() + " health");
                }
                else //If realistic mode
                {
                    sb.Append(list.Find(x => x.Id == id).Health.ToString() + " health, " + list.Find(x => x.Id == id).Hunger.ToString() + " hunger");
                }
            }
            else
            {
                sb.Append("Deceased");
            }

            return sb.ToString();
        }

        public string UpdateWeapon(string id, List<character> list, Game game)
        {
            StringBuilder sb = new StringBuilder();

            if (list.Find(x => x.Id == id) != null)
            {
                if (game.Mode == "Classic" && list.Find(x => x.Id == id).getWeaponName() != "") //If realistic mode and character has weapon
                {
                    sb.Append(list.Find(x => x.Id == id).getWeaponName() + ": " + list.Find(x => x.Id == id).getWeaponAttack().ToString() + " damage");
                }
                else if (game.Mode == "Classic" && list.Find(x => x.Id == id).getWeaponName() == "") //If classic mode and character has no weapon
                {
                    sb.Append("Unarmed");
                }
                else if (game.Mode == "Realistic" && list.Find(x => x.Id == id).getWeaponName() != "") //If realistic mode and character has weapon
                {
                    sb.Append(list.Find(x => x.Id == id).getWeaponName() + ": " + list.Find(x => x.Id == id).getWeaponAttack().ToString() + " damage, " + list.Find(x => x.Id == id).Strength.ToString() + " strength");

                }
                else if (game.Mode == "Realistic" && list.Find(x => x.Id == id).getWeaponName() == "") //If realistic mode and character has no weapon
                {
                    sb.Append("Unarmed, " + list.Find(x => x.Id == id).Strength.ToString() + " strength");
                }
            }
            else //If character is not alive
            {
                return string.Empty;
            }

            return sb.ToString();
        }

        public string Places(List<character> list, character winner, Game game) 
        { 
            List<string> placeList = new List<string>();
            StringBuilder sb = new StringBuilder();

            if (game.Players == 24) placeList = this.PlacesList(24);
            else placeList = this.PlacesList(48);

            list.Reverse();

            sb.AppendLine("======== How Did Each Player Do? ========");
            sb.AppendLine("---1st Place---");
            sb.AppendLine(winner.Name + " from District " + winner.District + " with " + winner.Kills + " kills");

            for (int i = 0; i < placeList.Count; i++)
            {
                sb.AppendLine("---"+placeList[i]+"---");
                if (list[i].Kills!=1)
                {
                    sb.AppendLine(list[i].Name + " from District " + list[i].District + " with " + list[i].Kills + " kills");
                }
                else
                {
                    sb.AppendLine(list[i].Name + " from District " + list[i].District + " with " + list[i].Kills + " kill");
                }               
            }

            return sb.ToString();
        }

        public string Kills(List<character> list, character winner, Game game)
        {
            StringBuilder sb = new StringBuilder();

            list.Add(winner);
            list.Sort((q, p) => p.Kills.CompareTo(q.Kills));

            sb.AppendLine("======== Who Had The Most Kills? ========");
            sb.AppendLine("---" + list[0].Kills + " kills---");
            sb.AppendLine(list[0].Name + ": " + list[0].Kills + " kills");

            for (int i = 1;i < list.Count-1;i++)
            {
                if (list[i].Kills < list[i-1].Kills)
                {
                    if (list[i].Kills!=1)
                    {
                        sb.AppendLine("---" + list[i].Kills + " kills---");
                    }
                    else
                    {
                        sb.AppendLine("---" + list[i].Kills + " kill---");
                    }
                    
                }
                if (list[i].Kills != 1)
                {
                    sb.AppendLine(list[i].Name + ": " + list[i].Kills + " kills");
                }
                else
                {
                    sb.AppendLine(list[i].Name + ": " + list[i].Kills + " kill");
                }
                    
            }

            return sb.ToString();
        }

        public string GeneralStats(List<character> list, character winner, Game game)
        {
            StringBuilder sb = new StringBuilder();

            int totalKills = 0;

            sb.AppendLine("========== General Stats ==========");
            sb.AppendLine(game.Day + " total days");
            if (game.BloodbathDeaths!=1)
            {
                sb.AppendLine(game.BloodbathDeaths + " deaths in the Bloodbath");
            }
            else
            {
                sb.AppendLine(game.BloodbathDeaths + " death in the Bloodbath");
            }
            
            if (game.Events !=1 )
            {
                sb.AppendLine(game.Events + " Arena Events");
            }
            else
            {
                sb.AppendLine(game.Events + " Arena Event");
            }
            
            if (game.ArenaEventDeaths != 1 && game.Events != 0)
            {
                sb.AppendLine(game.ArenaEventDeaths + " Arena Event deaths");
            }
            else if (game.ArenaEventDeaths == 1 && game.Events != 0)
            {
                sb.AppendLine(game.ArenaEventDeaths + " Arena Event death");
            }

            if (game.FeastDeaths != 1)
            {
                sb.AppendLine(game.FeastDeaths + " Feast deaths");
            }
            else
            {
                sb.AppendLine(game.FeastDeaths + " Feast death");
            }
            
            

            list.Add(winner);

            for (int i = 0; i < list.Count; i++)
            {
                totalKills += list[i].Kills;
            }

            sb.AppendLine(totalKills + " total player kills");

            return sb.ToString();
        }

        private List<string> PlacesList(int numPlayers)
        {
            List<string> list24 = new List<string>
            {
                "2nd Place", "3rd Place", "4th Place",
                "5th Place", "6th Place", "7th Place", "8th Place",
                "9th Place", "10th Place", "11th Place", "12th Place",
                "13th Place", "14th Place", "15th Place", "16th Place",
                "17th Place", "18th Place", "19th Place", "20th Place",
                "21st Place", "22nd Place", "23rd Place", "24th Place"
            };
            List<string> list48 = new List<string>
            {
                "2nd Place", "3rd Place", "4th Place",
                "5th Place", "6th Place", "7th Place", "8th Place",
                "9th Place", "10th Place", "11th Place", "12th Place",
                "13th Place", "14th Place", "15th Place", "16th Place",
                "17th Place", "18th Place", "19th Place", "20th Place",
                "21st Place", "22nd Place", "23rd Place", "24th Place",
                "25th Place", "26th Place", "27th Place", "28th Place",
                "29th Place", "30th Place", "31st Place", "32nd Place",
                "33rd Place", "34th Place", "35th Place", "36th Place",
                "37th Place", "38th Place", "39th Place", "40th Place",
                "41st Place", "42nd Place", "43rd Place", "44th Place",
                "45th Place", "46th Place", "47th Place", "48th Place"
            };

            if (numPlayers == 24) return list24;
            else return list48;
        }
    }
}
