namespace Blobs.Models.Attacks
{
    public class PutridFart : Attack
    {
        public override int StartAttack(Blob blob)
        {
            return blob.Damage;
        }
    }
}
