using System;
using System.Collections.Generic;

namespace Sunken.Character
{
    public class Inventory
    {
        public Weapon MainHandWeapon;
        public Weapon OffHandWeapon;
        public Armor Garb;
        public Trinket PrimaryTrinket;
        public Trinket SecondaryTrinket;
        public Trinket TertiaryTrinket;
        public List<InventoryItem> Rucksack { get; protected set; }

        public Inventory()
        {
            Rucksack = new List<InventoryItem>();
        }

        public string ToJson()
        {
            // TODO: Clean this up
            string rucksackContents = "";
            if (Rucksack.Count > 0)
            {
                for (int i = 0; i < Rucksack.Count - 1; i++)
                {
                    rucksackContents += Rucksack[i].ToJson() + ", ";
                }
                rucksackContents += Rucksack[Rucksack.Count - 1].ToJson();
            }
            return "{" +
                "\"mainHandWeapon\" : " + ((MainHandWeapon == null) ? "\"null\", " : MainHandWeapon.ToJson()) +
                "\"offHandWeapon\" : " + ((OffHandWeapon == null) ? "\"null\", " : OffHandWeapon.ToJson()) +
                "\"garb\" : " + ((Garb == null) ? "\"null\", " : Garb.ToJson()) +
                "\"primaryTrinket\" : " + ((PrimaryTrinket == null) ? "\"null\", " : PrimaryTrinket.ToJson()) +
                "\"secondaryTrinket\" : " + ((SecondaryTrinket == null) ? "\"null\", " : SecondaryTrinket.ToJson()) +
                "\"tertiaryTrinket\" : " + ((TertiaryTrinket == null) ? "\"null\", " : TertiaryTrinket.ToJson()) +
                "\"rucksack\" : [" + rucksackContents + "]" +
                "}";
        }
    }
}
