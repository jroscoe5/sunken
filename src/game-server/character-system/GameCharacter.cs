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
            Stats = stats ?? new Stats();
            Inventory = inventory ?? new Inventory();
            Inflictions = inflictions ?? new List<Infliction>();
            Brands = brands ?? new List<Brand>();
            Dice = new DiceRoller();
        }

        public string ToJson()
        {
            // TODO: Clean this up
            string inflictions = "";
            if (Inflictions.Count > 0)
            {
                for (int i = 0; i < Inflictions.Count - 1; i++)
                {
                    inflictions += Inflictions[i].ToJson() + ", ";
                }
                inflictions += Inflictions[Inflictions.Count - 1].ToJson();
            }
            string brands = "";
            if (Brands.Count > 0)
            {
                for (int i = 0; i < Brands.Count - 1; i++)
                {
                    brands += Brands[i].ToJson() + ", ";
                }
                inflictions += Brands[Brands.Count - 1].ToJson();
            }
            return "{" +
                "\"id\" : " + "\"" + Id + "\", " +
                "\"name\" : " + "\"" + Name + "\", " +
                "\"stats\" : " + Stats.ToJson() + ", " +
                "\"inventory\" : " + Inventory.ToJson() + "," + 
                "\"inflictions\" : " + "[" + inflictions + "], " +
                "\"brands\" : " + "[" + brands + "], " +
                "\"dice\" : " + Dice.ToJson() +
                "}";
        }
    }
}