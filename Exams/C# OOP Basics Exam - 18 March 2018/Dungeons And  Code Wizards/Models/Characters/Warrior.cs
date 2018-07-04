namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Constants;
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Enums;
    using DungeonsAndCodeWizards.Models.Bags;
    using System;
    
    public class Warrior : Character, IAttackable
    {
        private const double WarriorHealth = 100;
        private const double WarriorArmor = 50;
        private const double WarriorAbilityPoints = 40;

        public Warrior(string name, Faction faction)
            : base(name, WarriorHealth, WarriorArmor, WarriorAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new ArgumentException(OutputMessages.CharacterIsDead);
            }

            if (this.Equals(character))
            {
                throw new InvalidOperationException(OutputMessages.CannotAttackSelf);
            }

            if (this.Faction.Equals(character.Faction))
            {
                throw new ArgumentException(string.Format(OutputMessages.FriendlyFire, this.Faction));
            }

            character.TakeDamage(this.AbilityPoints);
        }

        public override void ActivateAbility(string type, Character character)
        {
            if (type != "Attack")
            {
                throw new ArgumentException(string.Format(OutputMessages.CannotAttack, this.Name));
            }

            this.Attack(character);
        }
    }
}
