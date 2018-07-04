namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Constants;
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Enums;
    using DungeonsAndCodeWizards.Models.Bags;
    using System;

    public class Cleric : Character, IHealable
    {
        private const double ClericRestMultiplier = 0.5;
        private const double ClericHealth = 50;
        private const double ClericArmor = 25;
        private const double ClericAbilityPoints = 40;

        public Cleric(string name, Faction faction)
            : base(name, ClericHealth, ClericArmor, ClericAbilityPoints, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => ClericRestMultiplier;

        public void Heal(Character character)
        {

            if (!this.IsAlive || !character.IsAlive)
            {
                throw new ArgumentException(OutputMessages.CharacterIsDead);
            }

            if (!this.Faction.Equals(character.Faction))
            {
                throw new ArgumentException(string.Format(OutputMessages.CannotHealEnemy, this.Faction));
            }

            character.Health += this.AbilityPoints;
        }

        public override void ActivateAbility(string type, Character character)
        {
            if (type != "Heal")
            {
                throw new ArgumentException(string.Format(OutputMessages.CannotHeal, this.Name));
            }

            this.Heal(character);
        }
    }
}
