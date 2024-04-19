using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{
    public class character
    {
        private String name, pronounSub, pronounObj, pronounPos, pronounPosAdj, pronounRefl, weaponName = "", weaponType="Unarmed";
        private int kills=0, district;
        private double weaponAttack = 2, health, healingAmount;
        private double strength = 0, morality = 5.0, speed = 2.0, hunger = 10.0, combatLevel = 0; //Realistic mode only
        private bool isAlive=true, healSlotFilled = false, hasExplosive = false, weaponProperName = false, isNPC = false;

        public character()
        {
            pronounSub = "They";
            pronounObj = "Them";
            pronounPos = "Theirs";
            pronounPosAdj = "Their";
            pronounRefl = "Themselves";
            Health = 20;
        }//end empty-argument constructor

        public character(int District)
        {
            pronounSub = "They";
            pronounObj = "Them";
            pronounPos = "Theirs";
            pronounPosAdj = "Their";
            pronounRefl = "Themselves";
            Health = 20;
            this.District = District;
        }

        public character(string name, string pronoun, int District)
        {
            Name = name;
            this.setPronoun(pronoun);
            Health = 20;
            this.District = District;
        }

        public character(string name, string pronoun, double strength, double morality, double speed, int District)
        {
            
            this.setPronoun(pronoun);
            Health = 20;
            this.Strength = strength;
            this.Morality = morality;
            this.Speed = speed;
            this.District = District;
            combatLevel = (speed + strength) / 4;
            this.Name = name+"("+combatLevel+")";
            weaponAttack = strength / 2;

        } //end realistic mode constructor

        public character(string name, string pronoun)
        {
            setName(name);
            setPronoun(pronoun);
            Health = 20;
        } //end preferred constructor


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
            set
            {
                if (value <= 10 && value > 0) strength = value;
                else if (value <= 0) strength = 0.01;
                else strength = 10;
            }
        }
        public double Morality
        {
            get => morality;
            set
            {
                if (value <= 10 && value > 0) morality = value;
                else if (value <= 0) morality = 0.01;
                else morality = 10;
            }
        }
        public double Speed
        {
            get => speed;
            set
            {
                if (value <= 10 && value > 0) speed = value;
                else if (value <= 0) speed = 0.01;
                else speed = 10;
            }
        }
        public double Hunger
        {
            get => hunger;
            set
            {
                if (this.Hunger - value > 0) hunger = value;
                else IsAlive = false;
            }
        }

        public double CombatLevel { get => combatLevel; set => combatLevel = value; }

        public String getName()
        {
            return Name;
        }

        public void setName(String name)
        {
            this.Name = name;
        }

        public void setPronoun(String pronoun)
        {
            if (pronoun != null)
            {
                pronoun = pronoun.ToLower();
                if (pronoun == "he")
                {
                    pronounSub = "He";
                    pronounObj = "Him";
                    pronounPos = "His";
                    pronounPosAdj = "His";
                    pronounRefl = "Himself";
                }
                if (pronoun == "she")
                {
                    pronounSub = "She";
                    pronounObj = "Her";
                    pronounPos = "Hers";
                    pronounPosAdj = "Her";
                    pronounRefl = "Herself";
                }
                if (pronoun == "they")
                {
                    pronounSub = "They";
                    pronounObj = "Them";
                    pronounPos = "Theirs";
                    pronounPosAdj = "Their";
                    pronounRefl = "Themselves";
                }
            }
        }

        public String getPronounPos()
        {
            return pronounPos;
        }

        public String getPronounSub()
        {
            return pronounSub;
        }

        public String getPronounObj()
        {
            return pronounObj;
        }

        public String getPronounPosAdj()
        {
            return pronounPosAdj;
        }

        public String getPronounRefl()
        {
            return pronounRefl;
        }

        public String getWeaponName()
        {
            return weaponName;
        }

        public void setWeaponName(String weaponName)
        {
            this.weaponName = weaponName;
        }

        public bool aliveCheck()
        {
            return IsAlive;
        }

        public bool isHealSlotFilled()
        {
            return healSlotFilled;
        }

        public void fillHealSlot(bool isFilled)
        {
            healSlotFilled = isFilled;
        }

        public double getHealingAmount()
        {
            return healingAmount;
        }

        public void setHealingAmount(double healingAmount)
        {
            this.healingAmount=healingAmount;
        }

        public void heal(double amount)
        {
            if (Health + amount < 20) this.Health = Health + amount;
            else this.Health = 20;
        }

        public void hurt(double amount)
        {
            if (Health - amount > 0) this.Health = Health - amount;
            else
            {
                this.Health = 0;
                IsAlive = false;
            }
        }

        public double getHealth() { 
            return Health; 
        }

        public void resurrect()
        {
            IsAlive = true;
        }

        public String toString()
        {
            return "character [name=" + Name + ", health=" + Health+", pronouns=" + pronounSub + "/"
                    + pronounObj + "/" + pronounPos + "/" + pronounPosAdj
                    + "/" + pronounRefl + ", weaponName=" + weaponName + ", isAlive="
                    + IsAlive + "]";
        }//end toString method

        public void setWeaponType(String weaponType)
        {
            this.weaponType = weaponType;
        }

        public string getWeaponType()
        {
            return this.weaponType;
        }

        public void setWeaponAttack(double weaponAttack)
        {
            this.weaponAttack = weaponAttack;
        }

        public double getWeaponAttack()
        {
            return this.weaponAttack;
        }
    }
}
