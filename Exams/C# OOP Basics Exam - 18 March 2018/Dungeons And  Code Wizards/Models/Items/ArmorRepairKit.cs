namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;

    public class ArmorRepairKit : Item
    {
        private const int ArmorWeight = 10;
        private const int HealthDecrease = 20;

        public ArmorRepairKit()
            : base(ArmorWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
    }
}
