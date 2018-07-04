namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;

    public class PoisonPotion : Item
    {
        private const int PotionWeight = 5;
        private const int HealthDecrease = 20;

        public PoisonPotion()
            : base(PotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= HealthDecrease;
            if (character.Health == 0)
            {
                character.IsAlive = true;
            }
        }
    }
}
