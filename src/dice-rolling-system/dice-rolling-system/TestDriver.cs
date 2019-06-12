using System;
using System.Collections.Generic;

namespace dice_rolling_system
{
    class TestDriver
    {
        static Random random = new Random(Guid.NewGuid().GetHashCode());

        static void Main(string[] args)
        {
            RunTest("CorrectRollCount", CorrectRollCount);
            RunTest("CorrectRollValues", CorrectRollValues);
            RunTest("CorrectRollEncapsulation", CorrectRollEncapsulation);
            RunTest("CorrectRerollEncapsulation", CorrectRerollEncapsulation);
            RunTest("CorrectRerollFunctionality", CorrectRerollFunctionality);
            Console.ReadLine();
        }

        static void RunTest(string name, Func<bool> test)
        {
            Console.WriteLine("{0} || Running test {1}", DateTime.Now.ToLongTimeString(), name);
            try
            {
                if (test.Invoke())
                {
                    Console.WriteLine("{0} || PASSED", DateTime.Now.ToLongTimeString());
                }
                else
                {
                    Console.WriteLine("{0} || FAILED", DateTime.Now.ToLongTimeString());
                }
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine("{0} || FAILED", DateTime.Now.ToLongTimeString());
            }
        }

        /*    TESTS     */
       
        static bool CorrectRollCount()
        {
            int num = random.Next(1, 9);
            return DiceRoller.Roll(num).Length == num;
        }

        static bool CorrectRollValues()
        {
            var rolls = DiceRoller.Roll(1000000);
            foreach (int roll in rolls)
                if (roll < 1 || roll > 6)
                    return false;
            return true;
        }

        static bool CorrectRollEncapsulation()
        {
            var rolls = DiceRoller.Roll(100);
            rolls[50] = -1;
            return DiceRoller.CurrentRoll()[50] != -1;
        }

        static bool CorrectRerollEncapsulation()
        {
            DiceRoller.Roll(100);
            var rolls = DiceRoller.Reroll(new int[]{0, 50, 3});
            rolls[50] = -1;
            return DiceRoller.CurrentRoll()[50] != -1;
        }

        static bool CorrectRerollFunctionality()
        {
            var rolls = DiceRoller.Roll(1000000);
            List<int> evens = new List<int>();
            for (int i = 0; i < 1000000; i += 2)
                evens.Add(i);
            var rerolls = DiceRoller.Reroll(evens.ToArray());
            for (int i = 1; i < 1000000; i += 2)
                if(rolls[i] != rerolls[i])
                    return false;
            for (int i = 0; i < 1000000; i += 2)
                if (rolls[i] != rerolls[i])
                    return true; // at least 1 value was changed
            return false; // no rerolls happened or REALLY 'lucky'
        }
    }
}
