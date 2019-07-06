using System.Collections.Generic;

namespace character_system
{
    public class Inventory
    {
        public Weapon MainHandWeapon;
        public Weapon OffHandWeapon;
        public Armor Garb;
        public Trinket PrimaryTrinket;
        public Trinket SecondaryTrinket;
        public Trinket TertiaryTrinket;
        public List<InventoryItem> Rucksack;
    }
}