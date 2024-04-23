using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Carnage
{

    /// <summary>
    /// This class is designed to handle all things that are randomly-generated, which
    /// is almost everything that makes the simulator a simulator. Based on the Random
    /// object, this class includes methods to generate single numbers, lists of numbers,
    /// boolean and string values that are decided by random numbers, and a method
    /// to shuffle the order of a list randomly.
    /// </summary>
    public class RNG
    {
        Random random = new();

        /// <summary>
        /// Generates a random int between the lower and upper bounds provided
        /// </summary>
        public int randomInt(int lowerBound, int upperBound)
        {
            return random.Next(lowerBound, (upperBound+1));
        }

        /// <summary>
        /// Generates a random double between 0 and just before the upper bound provided
        /// </summary>
        public double randomDouble(double upperBound)
        {
            return Math.Round((random.NextDouble() * upperBound),2); //All doubles in this program are rounded to 2 decimal places
        }

        /// <summary>
        /// Returns a random int without bounds
        /// </summary>
        public int boundlessInt()
        {
            return random.Next();
        }

        /// <summary>
        /// Returns the number of players that will be in a battle, skewed toward 2
        /// </summary>
        public int randomPlayerCount()
        {
            int random = this.randomInt(0, 1000);

            if (random >= 0 && random <= 750) return 2;
            else if (random >= 851 && random <= 950) return 3;
            else return 4;
        }

        /// <summary>
        /// Generates a random Bloodbath event type for use in the Bloodbath
        /// </summary>
        public string randomBBEventType()
        {
            int random = this.randomInt(1, 8);

            if (random == 1 || random == 2 || random == 3) return "Regular";
            else if (random == 4 || random == 5) return "Gain";
            else if (random == 6 || random == 7) return "Battle";
            else return "Death";
        }

        /// <summary>
        /// Generates a random event type for use in a Day, at different points in the
        /// simulation the likelihood of certain types happening is changed.
        /// </summary>
        public string randomEventType(Game game)
        {
            int random = this.randomInt(0, 20);

            if (game.ActivePlayers >= game.Players / 4) //If there are more than a quarter of the total starting players left, chance of battle is lower
            {
                if (random >= 0 && random < 7) return "Regular";
                else if (random >= 7 && random < 14) return "Gain";
                else if (random >= 14 && random < 17) return "Explore";
                else if (random == 17) return "Death";
                else return "Battle";
            }
            else if (game.ActivePlayers == 2) //If there are only 2 players left, the odds of a battle are really high
            {
                if (random >= 0 && random < 3) return "Regular";
                else if (random >= 3 && random < 7) return "Gain";
                else if (random >= 7 && random < 9) return "Explore";
                else if (random == 9) return "Death";
                else return "Battle";
            }
            else //If there is a quarter of the total starting players left, the odds of a battle are increased
            {
                if (random >= 0 && random < 4) return "Regular";
                else if (random >= 4 && random < 8) return "Gain";
                else if (random >= 8 && random < 11) return "Explore";
                else if (random == 12) return "Death";
                else return "Battle";
            }
        }

        /// <summary>
        /// Generates a random Feast event type for use in the Feast
        /// </summary>
        public string randomFeastEventType() 
        {
            int random = this.randomInt(1, 4);
            if (random == 1 || random == 2) return "None";
            else if (random == 3) return "Battle";
            else return "Gain";
        }

        /// <summary>
        /// Decides if an attack will be critical; 1 in 20 chance
        /// </summary>
        public bool critAttack()
        {
            int random = this.randomInt(1, 20);

            if (random != 20) return false;
            else return true;
        }

        /// <summary>
        /// Decides if a player has the chance to dodge; 1 in 15 chance
        /// </summary>
        public bool dodge()
        {
            int random = this.randomInt(1, 15);

            if (random != 15) return false;
            else return true;
        }

        /// <summary>
        /// Decides if a player has the chance to flee (given their health is also below a certain point); 1 in 8 chance
        /// </summary>
        public bool flee() 
        {
            int random = this.randomInt(1, 8);

            if (random != 8) return false;
            else return true;
        }

        /// <summary>
        /// Decides if a player flees in realistic mode; decided at random with the odds skewed toward the player with the higher speed
        /// value--the greater the difference in speeds, the greater the chance in the quicker player's favor
        /// </summary>
        public bool advancedFlee(character char1, character char2)
        {
            bool flee = false;
            double difference, rand;

            if (char1.Speed == 10) flee = true; //Character automatically succeeds if their speed is 10
            else if (char2.Speed == 10) flee = false;
            else
            {
                difference = char2.Speed - char1.Speed;
                rand = this.randomDouble(10) + (difference / 2); //The greater the difference is, the less or more of a chance there is for player 1 to flee based on whether the difference is negative or positive

                if (rand >= 5) flee = false; //If speeds are equal, it would be 50-50, but the difference skews it in a negative or positive direction
                else flee = true;
            }

            return flee;
        }

        /// <summary>
        /// Decides if a player can use their explosive if they have one; 1 in 5 chance
        /// </summary>
        public bool useExplosive() {
            int random = this.randomInt(1, 5);

            if (random != 5) return false;
            else return true;
        }

        /// <summary>
        /// Randomly decides the damage an explosive will do; between 5 and 10
        /// </summary>
        public int explosionDamage()
        {
            int random = this.randomInt(5, 10);

            return random;
        }

        /// <summary>
        /// Decides if a player can has the opportunity to be spared; 1 in 6 chance
        /// </summary>
        public bool spare()
        {
            int random = this.randomInt(1, 6);

            if (random != 6) return false;
            else return true;
        }

        /// <summary>
        /// Decides if a player spares opponent in realistic mode; the higher their morality the greater the chance,
        /// and the lower the morality the lower the chance.
        /// </summary>
        public bool advancedSpare(character char1)
        {
            double random = this.randomDouble(10);

            if (random < char1.Morality) return true; //If random double 0-10 is less than character's morality level, character spares (better chance for higher level)
            else return false; //If double is more than character's morality level, character does not spare (better chance for lower level)

        }

        /// <summary>
        /// Decides which player attacks in a given turn of a battle in realistic mode. The character with the higher 
        /// combat level will have a better chance of being the one to attack in a battle. If the method returns true,
        /// the first character in the list attacks, and if false, the second character attacks.
        /// </summary>
        public bool player1Attack(character char1, character char2) 
        { 
            if (char1.CombatLevel > char2.CombatLevel) //If player 1 has a higher combat level, they have a 7 in 10 chance of attacking
            {
                int random = this.randomInt(0, 10);

                if (random > 3) return true;
                else return false;
            }
            else if (char1.CombatLevel < char2.CombatLevel) //If player 2 has a higher combat level, they have a 7 in 10 chance of attacking
            {
                int random = this.randomInt(0, 10);

                if (random > 3) return false;
                else return true;
            }
            else //If combat levels are equal, 50-50 chance
            {
                int random = this.randomInt(0, 1);

                if (random == 0) return true;
                else return false;
            }
        }

        /// <summary>
        /// Randomly generates an int between 1 and 1000 at the start of each
        /// simulation. This value determines if very rare events happen
        /// throughout the simulation.
        /// </summary>
        public int funValue() 
        {
            int random = this.randomInt(1, 1000);

            return random; 
        }

        /// <summary>
        /// Takes a passed in list of characters and returns it with order shuffled
        /// </summary>
        public List<character> shuffleList(List<character> list)
        {
            list = (list.OrderBy(x => this.boundlessInt())).ToList();
            return list;
        }

        /// <summary>
        /// Generates a random int and returns a corresponding
        /// body part in string form for use in battle text
        /// </summary>
        public string randomBodyPart()
        {
            int random = this.randomInt(1, 9);

            if (random == 1) return "arm";
            else if (random == 2) return "leg";
            else if (random == 3) return "chest";
            else if (random == 4) return "face";
            else if (random == 5) return "kneecaps";
            else if (random == 6) return "fingers";
            else if (random == 7) return "toes";
            else if (random == 8) return "armpit";
            else return "shoulder";

        }

        /// <summary>
        /// Generates a list of unique random ints up to a certain number
        /// and of a specified size
        /// </summary>
        public List<int> RandomIntList(int upperBound, int listSize)
        {
            List<int> list = new List<int>();
            int i = 0, rand;

            while (i < listSize)  //Ints are added to the list until it's full of unique entries
            {
                rand = this.randomInt(0, upperBound-1);

                if (list.Contains(rand)) //If list already contains this int, goes back through the cycle
                {
                    continue;
                }
                else //If this int is not already in the list, it gets added
                {
                    list.Add(rand);
                    i++;
                }
            }

            return list;
        }

    }
}
