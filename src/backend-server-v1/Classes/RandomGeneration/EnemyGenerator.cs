using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sunken.Character;

namespace Sunken.RandomGeneration
{
    // TODO: Actually implement
    public static class EnemyGenerator
    {
        private static string[] adjectives = new string[] { "terrible", "angry", "wrathful", "undead", "deadly" };
        private static string[] names = new string[]{ "kalvin", "peter", "duke", "rengor", "manice" };
        private static Random random = new Random();
        public static GameCharacter GenerateDefaultSunken()
        {
            var a = random.Next(adjectives.Length);
            var n = random.Next(names.Length);
            var name = adjectives[a] + " " + names[n];
            return new GameCharacter(name);
        }
    }
}
