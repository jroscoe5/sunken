namespace character_system
{
    public class Trinket : InventoryItem
    {
        public Trinket(string name, string id = null, 
                       int power = 0, int weight = 0, 
                       Innate innate = null, Blessing blessing = null) : base(name, id, power, weight, innate, blessing)
        {
        }
    }
}