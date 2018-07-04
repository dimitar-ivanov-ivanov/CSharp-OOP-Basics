using ISIS.Models.Attacks;
using System;

namespace ISIS.Models.Groups
{
    public class Jihad : Group
    {
        private const int damageCost = 5;
        private const int damageMultiplier = 2;
        private int initialDamage;

        public Jihad(string name, int damage, int health, Attack attack)
            : base(name, damage, health, attack)
        {
            this.initialDamage = damage;
        }

        public override void ActivateEffect()
        {
            if (this.AppliedEffect)
            {
                this.Damage *= damageMultiplier;
                if (this.ToggleEffect)
                {
                    Console.WriteLine($"Group {this.Name} toggled Jihad");
                }
            }
        }

        public override void ApplyEffect()
        {
            if (this.AppliedEffect &&
                this.Damage - damageCost >= this.initialDamage)
            {
                this.Damage -= damageCost;
            }
        }
    }
}
