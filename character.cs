using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{
    /// <summary>
    /// This class is designed to represent a functional character in the simulation. Every value that affects
    /// what a character is doing and how it is performing is recorded in the character object. This character's
    /// variables are changed throughout the simulation as a result of the events that happen to them. Such variables include
    /// a character's name, their health (which represents whether they are alive or not), their weapon and its stats,
    /// and extra values if the gamemode is Realistic.
    /// </summary>
    public class character
    {
        private string id, name, pronounSub, pronounObj, pronounPos, pronounPosAdj, pronounRefl, healingName;
        private string weaponName = "", weaponType = "Unarmed", weaponStatus = "None", originalWeaponName = "", weaponPrefix = ""; //Weapon info
        private int kills=0, district, upgrades = 0;
        private double weaponAttack = 2, health, healingAmount;
        private double strength = 0, morality = 5.0, speed = 2.0, startSpeed = 2.0, hunger = 10.0, combatLevel = 0; //Realistic mode only
        private bool isAlive=true, healSlotFilled = false, hasExplosive = false, weaponProperName = false, isNPC = false, hasAntidote = false;
        List<string> KillList = new List<string>();
        List<string> StatusList = new List<string>();

        /// <summary>
        /// Default character instance with they pronouns and full health (20)
        /// </summary>
        public character()
        {
            PronounSub = "They";
            PronounObj = "Them";
            pronounPos = "Theirs";
            PronounPosAdj = "Their";
            PronounRefl = "Themselves";
            Health = 20;
        }

        /// <summary>
        /// Creates a character instance with a field for id and district
        /// </summary>
        public character(string id, int District, Game game)
        {
            PronounSub = "They";
            PronounObj = "Them";
            pronounPos = "Theirs";
            PronounPosAdj = "Their";
            PronounRefl = "Themselves";
            Health = game.StartHealth;
            Id = id; //ID is what identifies a player even when they are passed between different lists and shuffled around in order, it is made up of 4 digits representing the district and character number in that district
            this.District = District;
        }

        /// <summary>
        /// Creates a character instance with a field for id, name, pronoun, and district
        /// </summary>
        public character(string id, string name, string pronoun, int District, Game game)
        {
            Id=id;
            Name = name;
            this.setPronoun(pronoun);
            Health = game.StartHealth;
            this.District = District;
        }

        /// <summary>
        /// Creates a character instance with fields relating to Realistic mode attributes
        /// </summary>
        public character(string id, string name, string pronoun, double strength, double morality, double speed, int District, Game game)
        {
            Id = id;
            this.setPronoun(pronoun);
            Health = game.StartHealth;
            this.Strength = strength;
            this.Morality = morality;
            this.Speed = speed;
            this.StartSpeed = speed;
            this.District = District;
            combatLevel = Math.Round(((speed + strength) / 4),2);
            this.Name = name;
            WeaponAttack = strength / 2;

        }

        /// <summary>
        /// Creates a character instance with a field for just the name and pronounds of a character
        /// </summary>
        public character(string name, string pronoun, Game game)
        {
            Name = name;
            setPronoun(pronoun);
            Health = game.StartHealth;
        }

        //Encapsulated fields
        public bool HasExplosive { get => hasExplosive; set => hasExplosive = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public bool WeaponProperName { get => weaponProperName; set => weaponProperName = value; }
        public int District { get => district; set => district = value; }
        public double Health { get => health; set => health = value; }
        public bool IsNPC { get => isNPC; set => isNPC = value; }
        public int Kills { get => kills; set => kills = value; }
        public string Name { get => name; set => name = value; }
        public double Strength
        {
            get => strength;
            set //Ensures strength can't be more than 10 or less than 0, defaults to 0.01
            {
                if (value <= 10 && value > 0) strength = value;
                else if (value <= 0) strength = 0.01;
                else strength = 10;
            }
        }
        public double Morality
        {
            get => morality;
            set //Ensures morality can't be more than 10 or less than 0, defaults to 0.01
            {
                if (value <= 10 && value > 0) morality = value;
                else if (value <= 0) morality = 0.01;
                else morality = 10;
            }
        }
        public double Speed
        {
            get => speed;
            set //Ensures speed can't be more than 10 or less than 0, defaults to 0.01
            {
                if (value <= 10 && value > 0) speed = value;
                else if (value <= 0) speed = 0.01;
                else speed = 10;
            }
        }

        public double CombatLevel { get => combatLevel; set => combatLevel = value; }
        public double Hunger { get => hunger; set => hunger = value; }
        public string Id { get => id; set => id = value; }
        public string WeaponStatus { get => weaponStatus; set => weaponStatus = value; }
        public double StartSpeed { get => startSpeed; set => startSpeed = value; }
        public string WeaponName { get => weaponName; set => weaponName = value; }
        public double WeaponAttack { get => weaponAttack; set => weaponAttack = value; }
        public string WeaponType { get => weaponType; set => weaponType = value; }
        public string HealingName { get => healingName; set => healingName = value; }
        public bool HasAntidote { get => hasAntidote; set => hasAntidote = value; }
        public string OriginalWeaponName { get => originalWeaponName; set => originalWeaponName = value; }
        public string WeaponPrefix { get => weaponPrefix; set => weaponPrefix = value; }
        public bool HealSlotFilled { get => healSlotFilled; set => healSlotFilled = value; }
        public double HealingAmount { get => healingAmount; set => healingAmount = value; }
        public string PronounSub { get => pronounSub; set => pronounSub = value; }
        public string PronounObj { get => pronounObj; set => pronounObj = value; }
        public string PronounPos { get => pronounPos; set => pronounPos = value; }
        public string PronounPosAdj { get => pronounPosAdj; set => pronounPosAdj = value; }
        public string PronounRefl { get => pronounRefl; set => pronounRefl = value; }

        /// <summary>
        /// Sets the characters entire set of pronouns based on the one passed in
        /// </summary>
        public void setPronoun(string pronoun)
        {
            if (pronoun != null)
            {
                pronoun = pronoun.ToLower();
                if (pronoun == "he") //sets the appropriate pronoun values for the one given tense "he"
                {
                    PronounSub = "He";
                    PronounObj = "Him";
                    pronounPos = "His";
                    PronounPosAdj = "His";
                    PronounRefl = "Himself";
                }
                if (pronoun == "she") //sets the appropriate pronoun values for the one given tense "she"
                {
                    PronounSub = "She";
                    PronounObj = "Her";
                    pronounPos = "Hers";
                    PronounPosAdj = "Her";
                    PronounRefl = "Herself";
                }
                if (pronoun == "they") //sets the appropriate pronoun values for the one given tense "they"
                {
                    PronounSub = "They";
                    PronounObj = "Them";
                    pronounPos = "Theirs";
                    PronounPosAdj = "Their";
                    PronounRefl = "Themselves";
                }
            }
        }

        /// <summary>
        /// Heals a character, makes sure it can't go above the starting health
        /// </summary>
        public void heal(double amount, Game game, string item)
        {
            if (Health + amount < game.StartHealth && item == "Chug Jug") //Chug Jug item also clears statuses
            {
                this.Health = Health + amount;
                ClearStatuses();
            }
            else if (Health + amount < game.StartHealth) this.Health = Health + amount;
            else this.Health = game.StartHealth;
        }

        /// <summary>
        /// Damages a character, makes sure it can't go below 0
        /// </summary>
        public void hurt(double amount)
        {
            if (Health - amount > 0) this.Health = Health - amount;
            else //if the damage would cause a player to dip below 0 health they instead are set to not alive
            {
                this.Health = 0;
                IsAlive = false;
            }
        }

        /// <summary>
        /// Sets a character's weapon based on the name, attack, and type given
        /// </summary>
        public void SetWeapon(string name, double attack, string type)
        {
            this.WeaponName = name;
            this.OriginalWeaponName = name;
            this.WeaponType = type;
            this.WeaponAttack = attack;
        }

        /// <summary>
        /// When a character kills another character their name is added to their list of kills
        /// </summary>
        public void AddKill(string Name)
        {
            this.KillList.Add(Name);
        }

        /// <summary>
        /// Iterates through the character's list of kills and returns them in the correct format to be displayed on the winner screen
        /// </summary>
        public string GetKillList()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.KillList.Count; i++)
            {
                sb.Append(KillList[i].ToString()+", ");
            }

            string kills= sb.ToString();

            //Removes extra space and comma at the end of the sequence of names
            int charCount = kills.Length;
            kills=kills.Remove(charCount-1);
            kills=kills.Remove(charCount-2);

            return kills;
        }

        /// <summary>
        /// When a character gets a status effect inflicted on them it's added to their list of statuses
        /// </summary>
        public void AddStatus(string StatusName)
        {
            this.StatusList.Add(StatusName);
        }

        /// <summary>
        /// Checks to see if a character has a status effect
        /// </summary>
        public bool GetStatus(string StatusName)
        {
            return this.StatusList.Contains(StatusName);
        }

        /// <summary>
        /// Removes a status from their list of statuses
        /// </summary>
        public void RemoveStatus(string StatusName)
        {
            this.StatusList.Remove(StatusName);
        }

        /// <summary>
        /// Determines if a character has any status effects
        /// </summary>
        public bool HasStatuses()
        {
            if (this.StatusList.Count > 0) return true;
            else return false;
        }

        /// <summary>
        /// Clears character's status list
        /// </summary>
        public void ClearStatuses()
        {
            this.StatusList.Clear();
        }

        /// <summary>
        /// Iterates through the character's list of statuses and returns them in the correct format to be displayed on the character stats screen
        /// </summary>
        public string GetStatusList()
        {
            StringBuilder sb = new StringBuilder();
            string statuses = null;

            if (this.StatusList.Count != 0)
            {
                for (int i = 0; i < this.StatusList.Count; i++)
                {
                    sb.Append(StatusList[i].ToString() + ", ");
                }
                statuses = sb.ToString();

                //Removes extra space and comma at the end of the sequence of names
                int charCount = statuses.Length;
                statuses = statuses.Remove(charCount - 1);
                statuses = statuses.Remove(charCount - 2);
            }
            else statuses = "None";

            return statuses;
        }

        /// <summary>
        /// Takes a wepaon upgrade from the sponsor screen or forest imp exploration event and upgrades
        /// it and renames it appropriately depending on the upgrade given.
        /// </summary>
        public void upgradeWeapon(string type)
        {
            if (type == "Strength")
            {
                if (weaponPrefix == "")
                {
                    upgrades++;
                    weaponName = originalWeaponName + "+" + upgrades.ToString();
                    weaponAttack += 2;
                }
                else
                {
                    upgrades++;
                    weaponName = weaponPrefix + originalWeaponName + "+" + upgrades.ToString();
                    weaponAttack += 2;
                }

            }
            else if (type == "Poison")
            {
                if (upgrades == 0)
                {
                    weaponStatus = "Poison";
                    weaponPrefix = "poisonous ";
                    weaponName = weaponPrefix + originalWeaponName;
                }
                else
                {
                    weaponStatus = "Poison";
                    weaponPrefix = "poisonous ";
                    weaponName = weaponPrefix + originalWeaponName + "+" + upgrades.ToString();
                }
            }
            else if (type == "Burning")
            {
                if (upgrades == 0)
                {
                    weaponStatus = "Burning";
                    weaponPrefix = "firey ";
                    weaponName = weaponPrefix + originalWeaponName;
                }
                else
                {
                    weaponStatus = "Burning";
                    weaponPrefix = "fiery ";
                    weaponName = weaponPrefix + originalWeaponName + "+" + upgrades.ToString();
                }
            }
            else
            {
                if (upgrades == 0)
                {
                    weaponStatus = "Freeze";
                    weaponPrefix = "frozen ";
                    weaponName = weaponPrefix + originalWeaponName;
                }
                else
                {
                    weaponStatus = "Freeze";
                    weaponPrefix = "frozen ";
                    weaponName = weaponPrefix + originalWeaponName + "+" + upgrades.ToString();
                }
            }
        }

    }
}
