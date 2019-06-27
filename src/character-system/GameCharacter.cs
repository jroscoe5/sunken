using System;
using System.Collections.Generic;
using System.Text;

namespace character_system
{
    class GameCharacter
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public Stats Stats { get; protected set; }
        public Inventory Inventory { get; protected set; }
        public GameCharacter(string name, string id = null, Stats stats = null, Inventory inventory = null)
        {
            Name = name;
            Id = id ?? Guid.NewGuid().ToString();
            Stats = stats ?? new Stats();
            Inventory = inventory ?? new Inventory();
        }
    }
}