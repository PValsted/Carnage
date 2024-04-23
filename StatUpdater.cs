using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{

    /// <summary>
    /// This class is designed to update character stats for the simulation's character stat screens. It
    /// uses each character's unique ID to correctly return the values that correspond to the character in the
    /// correct spot on the stat screen. It also provides the string lists that correspond to each set of
    /// stats on the winner's screen.
    /// </summary>
    public class StatUpdater
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

        /// <summary>
        /// Searches the active characters list to get the given character's name and kills,
        /// or the death list if the character is dead
        /// </summary>
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

        /// <summary>
        /// Searches the active characters list to get the given character's health and
        /// hunger (if realistic mode), or returns "Deceased" if character is not alive
        /// </summary>
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
            else //If character not found, they must be dead
            {
                sb.Append("Deceased");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Searches the active characters list to get the given character's weapon information
        /// and strength (if realistic mode), or returns an empty string if character is dead
        /// </summary>
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

        /// <summary>
        /// Iterates through the death list backwards to list the characters in reverse order and
        /// what place they got starting with the winner. Returns as a string to the winner's screen
        /// </summary>
        public string Places(List<character> list, character winner, Game game) 
        { 
            List<string> placeList = new List<string>();
            StringBuilder sb = new StringBuilder();

            if (game.Players == 24) placeList = list24;
            else placeList = list48;

            list.Reverse(); //Reverses list

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

        /// <summary>
        /// Sorts the given list by number of kills and lists them in order, starting a new mini-header
        /// every time there's a different number of kills. Returns as a string to the winner's screen
        /// </summary>
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
                if (list[i].Kills < list[i-1].Kills) //If character has fewer kills than the one before it, enters a new header
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

        /// <summary>
        /// Collects general stats from throughout the game and lists them. Returns as a string to the winner's screen
        /// </summary>
        public string GeneralStats(List<character> list, character winner, Game game)
        {
            StringBuilder sb = new StringBuilder();

            int totalKills = 0;

            sb.AppendLine("========== General Stats ==========");
            sb.AppendLine(game.Day + " total days"); //Total days
            if (game.BloodbathDeaths!=1) //Bloodbath deaths
            {
                sb.AppendLine(game.BloodbathDeaths + " deaths in the Bloodbath");
            }
            else
            {
                sb.AppendLine(game.BloodbathDeaths + " death in the Bloodbath");
            }
            
            if (game.Events !=1 ) //Number of Arena Events
            {
                sb.AppendLine(game.Events + " Arena Events");
            }
            else
            {
                sb.AppendLine(game.Events + " Arena Event");
            }
            
            if (game.ArenaEventDeaths != 1 && game.Events != 0) //Number of Arena Event deaths (if there was one)
            {
                sb.AppendLine(game.ArenaEventDeaths + " Arena Event deaths");
            }
            else if (game.ArenaEventDeaths == 1 && game.Events != 0)
            {
                sb.AppendLine(game.ArenaEventDeaths + " Arena Event death");
            }

            if (game.FeastDeaths != 1) //Number of Feast deaths
            {
                sb.AppendLine(game.FeastDeaths + " Feast deaths");
            }
            else
            {
                sb.AppendLine(game.FeastDeaths + " Feast death");
            }
            
            list.Add(winner);

            for (int i = 0; i < list.Count; i++) //Calculates total number of kills
            {
                totalKills += list[i].Kills;
            }

            sb.AppendLine(totalKills + " total player kills"); //Total number of kills

            return sb.ToString();
        }
    }
}
