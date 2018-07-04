namespace ISIS.Models.Attacks
{
    using ISIS.Models.Groups;
    using System;

    public class SU24 : Attack
    {
        public override int InitiateAttack(Group group)
        {
            group.Health = (int)Math.Ceiling(group.Health / (double)2);
            if (group.Health < 1)
            {
                group.Health = 1;
            }
            return group.Damage * 2;
        }
    }
}
