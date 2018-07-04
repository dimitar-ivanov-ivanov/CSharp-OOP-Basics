using ISIS.Models.Attacks;
using System;

namespace ISIS.Models.Groups
{
    public class Kamikaze : Group
    {
        private const int healthCost = 10;
        private const int healthAddition = 50;

        public Kamikaze(string name, int damage, int health, Attack attack)
            : base(name, damage, health, attack)
        {
        }

        public override void ActivateEffect()
        {
            if (this.AppliedEffect)
            {
                this.Health += healthAddition;
                if (this.ToggleEffect)
                {
                    Console.WriteLine($"Group {this.Name} toggled Kamikaze");
                }
            }
        }

        public override void ApplyEffect()
        {
            if (this.AppliedEffect)
            {
                this.Health -= healthCost;
            }
        }
    }
}
