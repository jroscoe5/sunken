namespace Sunken.Character
{
    public class Armor : InventoryItem
    {
        public Armor(string name, string id = null, 
                     int power = 0, int weight = 0, 
                     Innate innate = null, Blessing blessing = null) : base(name, id, power, weight, innate, blessing)
        {
        }
    }
}