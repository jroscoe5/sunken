using System;
using System.Collections.Generic;
using System.Text;

namespace roll_system
{
    public class DiceRoller
    {
        public DiceRoller() { }

        // RNG source - to get an integer use random.Next(inclusive, exclusive);
        private readonly Random random = new Random(Guid.NewGuid().GetHashCode());

        // Array to keep track of previous roll.
        public int[] CurrentRoll
        {
            get
            {
                return (CurrentRoll == null) ? null : (int[])CurrentRoll.Clone();
            }
            private set
            {
                CurrentRoll = value;
            }
        }

        /// <summary>
        /// Rolls a given number of 6 sided dice and returns an array of rolls.
        /// Ex: DiceRoller.Roll(4) -> [3, 1, 6, 2]
        /// </summary>
        /// <param name="num">Number of dice to roll.</param>
        /// <returns>An array of rolls with size equal to num</returns>
        public int[] Roll(int num)
        {
            if (num <= 0) return null;
            CurrentRoll = new int[num];
            for (int i = 0; i < num; i++)
                CurrentRoll[i] = RollOne();
            return (int[])CurrentRoll.Clone();
        }

        public int RollOne()
        {
            return random.Next(1, 7);
        }

        /// <summary>
        /// Rerolls any number of dice from the previous roll, specified by a list of 
        /// target indices.
        /// Ex: currentRolls = [1, 3, 4, 5, 6]; DiceRoller.Reroll([0, 2, 4]) -> [5, 3, 1, 5, 2]
        /// </summary>
        /// <param name="targets">Array of target dice to reroll</param>
        /// <returns>An array of rolls with size equal to previous roll size</returns>
        public int[] Reroll(int[] targets)
        {
            foreach (int target in targets)
            {
                if(target > -1 && target < CurrentRoll.Length)
                {
                    CurrentRoll[target] = RollOne();
                }
            }
            return (int[])CurrentRoll.Clone();
        }
    }

}
