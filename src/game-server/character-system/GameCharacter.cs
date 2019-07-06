using System;
using System.Collections.Generic;
using System.Text;
using roll_system;

namespace character_system
{
    public class GameCharacter
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public int Initiative { get; set; }
        public Stats Stats { get; protected set; }
        public Inventory Inventory { get; protected set; }
        public List<Infliction> Inflictions { get; protected set; }
        public List<Brand> Brands { get; protected set; }
        public DiceRoller Dice { get; protected set; }
        public GameCharacter(string name, string id = null, 
                             Stats stats = null, Inventory inventory = null, 
                             List<Infliction> inflictions = null, List<Brand> brands = null)
        {
            Name = name;
            Id = id ?? Guid.NewGuid().ToString();
            Initiative = 0;
            Stats = stats ?? new Stats();
            Inventory = inventory ?? new Inventory();
            Inflictions = inflictions ?? new List<Infliction>();
            Brands = brands ?? new List<Brand>();
            Dice = new DiceRoller();
        }
    }
}