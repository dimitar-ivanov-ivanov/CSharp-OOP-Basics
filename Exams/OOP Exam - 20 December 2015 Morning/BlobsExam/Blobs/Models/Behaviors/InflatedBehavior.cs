namespace Blobs.Models.Behaviors
{
    public class InflatedBehavior : Behavior
    {
        public override void ActivateBehavior(Blob blob)
        {
            if (blob.ActivatedBehavior)
            {
                if(blob.Health <= 0)
                {
                    blob.Health = 0;
                }
                blob.Health += 50;
            }
        }

        public override void ApplyBehavior(Blob blob)
        {
            if (blob.ActivatedBehavior)
            {
                blob.Health -= 10;
            }
        }
    }
}
