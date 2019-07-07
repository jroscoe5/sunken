using System;
namespace character_system
{
    public class InventoryItem
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public int Power { get; protected set; }
        public int Weight { get; protected set; }
        public Innate Innate { get; protected set; }
        public Blessing Blessing { get; protected set; }
        public InventoryItem(string name, string id = null, 
                             int power = 0, int weight = 0, 
                             Innate innate = null, Blessing blessing = null)
        {
            Name = name;
            Id = id ?? Guid.NewGuid().ToString();
            Power = power;
            Weight = weight;
            Innate = innate ?? new Innate();
            Blessing = blessing ?? new Blessing();
        }

        public virtual string ToJson()
        {
            return "{" +
                "\"id\" : " + "\"" + Id + "\", " +
                "\"name\" : " + "\"" + Name + "\", " +
                "\"power\" : " + Power + ", " +
                "\"weight\" : " + Weight + ", " +
                "\"innate\" : " + Innate.ToJson() + ", " +
                "\"blessing\" : " + Blessing.ToJson() + "}";
        }
    }
}