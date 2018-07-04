namespace Blobs.Models.Behaviors
{
    public class AggressiveBehavior : Behavior
    {
        public override void ActivateBehavior(Blob blob)
        {
            if (blob.ActivatedBehavior)
            {
                blob.Damage *= 2;
            }
        }

        public override void ApplyBehavior(Blob blob)
        {
            if (blob.ActivatedBehavior)
            {
                blob.Damage -= 5;
            }
        }
    }
}
