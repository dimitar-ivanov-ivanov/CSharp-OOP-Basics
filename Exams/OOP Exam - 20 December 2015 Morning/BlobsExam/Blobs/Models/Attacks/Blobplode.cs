namespace Blobs.Models.Attacks
{
    using System;

    public class Blobplode : Attack
    {
        public override int StartAttack(Blob blob)
        {
            blob.Health = (int)Math.Ceiling(blob.Health / (double)2);
            if (blob.Health < 1)
            {
                blob.Health = 1;
            }
            return blob.Damage * 2;
        }
    }
}
