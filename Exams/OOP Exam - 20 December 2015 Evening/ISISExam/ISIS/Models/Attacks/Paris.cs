namespace ISIS.Models.Attacks
{
    using ISIS.Models.Groups;

    public class Paris : Attack
    {
        public override int InitiateAttack(Group group)
        {
            return group.Damage;
        }
    }
}
