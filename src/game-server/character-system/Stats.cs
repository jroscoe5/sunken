using System;

namespace character_system
{
    public class Stats
    {
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public int Tenacity { get; protected set; }
        public int MaxTenacity { get; protected set; }
        public int Defence { get; protected set; }
        public int MaxDefence { get; protected set; }
        public int Initiative { get; protected set; }
        public int MaxInitiative { get; protected set; }
        public int Faith { get; protected set; }
        public int MaxFaith { get; protected set; }

        public Stats(int health = 5, int maxHealth = 5, 
                     int tenacity = 3, int maxTenacity = 3, 
                     int defence = 3, int maxDefence = 3, 
                     int initiative = 3, int maxInitiative = 3, 
                     int faith = 3, int maxFaith = 3)
        {
            Health = health; MaxHealth = maxHealth;
            Tenacity = tenacity; MaxTenacity = maxTenacity;
            Defence = defence; MaxDefence = maxDefence;
            Initiative = initiative; MaxInitiative = maxInitiative;
            Faith = faith; MaxFaith = maxFaith;
        }

        public void Modify(int health = 0, int maxHealth = 0,
                     int tenacity = 0, int maxTenacity = 0,
                     int defence = 0, int maxDefence = 0,
                     int initiative = 0, int maxInitiative = 0,
                     int faith = 0, int maxFaith = 0)
        {
            Health += health; MaxHealth += maxHealth;
            Tenacity += tenacity; MaxTenacity += maxTenacity;
            Defence += defence; MaxDefence += maxDefence;
            Initiative += initiative; MaxInitiative += maxInitiative;
            Faith += faith; MaxFaith += maxFaith;
        }

        public string ToJson()
        {
            return "{" +
                "\"health\" : " + Health + ", " +
                "\"maxHealth\" : " + MaxHealth + ", " +
                "\"tenacity\" : " + Tenacity + ", " +
                "\"maxTenacity\" : " + MaxTenacity + ", " +
                "\"defence\" : " + Defence + ", " +
                "\"maxDefence\" : " + MaxDefence + ", " +
                "\"initiative\" : " + Initiative + ", " +
                "\"maxInitiative\" : " + MaxInitiative + ", " +
                "\"faith\" : " + Faith + ", " +
                "\"maxFaith\" : " + MaxFaith + "}";
        }
    }
}