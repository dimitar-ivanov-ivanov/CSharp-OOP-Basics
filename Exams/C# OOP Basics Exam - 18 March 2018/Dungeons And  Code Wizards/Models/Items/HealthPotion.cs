namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;

    public class HealthPotion : Item
    {
        private const int PotionWeight = 5;
        private const int HealthIncrease = 20;

        public HealthPotion()
            : base(PotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += HealthIncrease;
        }
    }
}
