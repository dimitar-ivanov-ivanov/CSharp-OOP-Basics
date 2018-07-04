namespace ISIS.Models.Attacks
{
    using ISIS.Models.Groups;

    public abstract class Attack
    {
        public abstract int InitiateAttack(Group group);
    }
}
