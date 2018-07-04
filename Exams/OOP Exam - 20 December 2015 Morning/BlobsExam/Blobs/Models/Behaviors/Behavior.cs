namespace Blobs.Models.Behaviors
{
    public abstract class Behavior
    {
        public abstract void ActivateBehavior(Blob blob);

        public abstract void ApplyBehavior(Blob blob);
    }
}
