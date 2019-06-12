using System;
using System.Collections.Generic;
using System.Text;

namespace dice_rolling_system
{
    static class DiceRoller
    {
        static DiceRoller() { }
        
        // RNG source - to get an integer use random.Next(inclusive, exclusive);
        private static Random random = new Random(Guid.NewGuid().GetHashCode());

        // Internal array to keep track of previous roll. Do not return this - return a new array instead.
        private static int[] currentRolls;

        /// <summary>
        /// Rolls a given number of 6 sided dice and returns an array of rolls.
        /// Ex: DiceRoller.Roll(4) -> [3, 1, 6, 2]
        /// </summary>
        /// <param name="num">Number of dice to roll.</param>
        /// <returns>An array of rolls with size equal to num</returns>
        static public int[] Roll(int num)
        {
            return null;
            // TODO:
            // Generate and return an array of dice rolls
            // Store rolls in currentRolls
        }

        /// <summary>
        /// Rerolls any number of dice from the previous roll, specified by a list of 
        /// target indices.
        /// Ex: currentRolls = [1, 3, 4, 5, 6]; DiceRoller.Reroll([0, 2, 4]) -> [5, 3, 1, 5, 2]
        /// </summary>
        /// <param name="targets">Array of target dice to reroll</param>
        /// <returns>An array of rolls with size equal to previous roll size</returns>
        static public int[] Reroll(int[] targets)
        {
            return null;
            // TODO: 
            // Reroll any number of dice from the previous roll and return an array
            // Store rolls in currentRolls
        }

        /// <summary>
        /// Returns a copy of the last roll or reroll if it exists
        /// </summary>
        /// <returns>Returns a copy of the last roll or null</returns>
        static public int[] CurrentRoll()
        {
            return (currentRolls == null)? null : (int[])currentRolls.Clone();
        }
    }
}
