namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Constants;
    using DungeonsAndCodeWizards.Models.Characters;
    using System;

    public abstract class Item
    {
        protected Item(int weight)
        {
            Weight = weight;
        }

        public int Weight { get; }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new ArgumentException(OutputMessages.CharacterIsDead);
            }
        }
    }
}
