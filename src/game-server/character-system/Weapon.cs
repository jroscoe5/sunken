namespace character_system
{
    public class Weapon: InventoryItem
    {
        public bool IsOffhand { get; protected set; }
        public Innate OffInnate { get; protected set; }
        public Blessing OffBlessing { get; protected set; }
        public Weapon(string name, string id = null,
                      bool offhand = false, int power = 0, int weight = 0,
                      Innate innate = null, Blessing blessing = null,
                      Innate offInnate = null, Blessing offBlessing = null) : base(name, id, power, weight, innate, blessing)
        {
            IsOffhand = offhand;
            OffInnate = offInnate ?? new Innate();
            OffBlessing = offBlessing ?? new Blessing();
        }
    }
}