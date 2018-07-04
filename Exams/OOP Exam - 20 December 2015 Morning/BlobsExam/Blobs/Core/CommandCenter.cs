namespace Blobs.Core
{
    using Blobs.Models;
    using Blobs.Models.Attacks;
    using Blobs.Models.Behaviors;
    using System.Collections.Generic;
    using System.Text;

    public class CommandCenter
    {
        private Dictionary<string, Blob> blobs;
        private Dictionary<string, Blob> deadBlobs;

        public CommandCenter()
        {
            blobs = new Dictionary<string, Blob>();
            deadBlobs = new Dictionary<string, Blob>();
        }

        public void CreateBlob(string name, int health,
            int damage, string behaviorType, string attackType)
        {
            Behavior behavior = null;
            Attack attack = null;

            if (behaviorType == "Aggressive")
            {
                behavior = new AggressiveBehavior();
            }
            else if (behaviorType == "Inflated")
            {
                behavior = new InflatedBehavior();
            }

            if (attackType == "PutridFart")
            {
                attack = new PutridFart();
            }
            else if (attackType == "Blobplode")
            {
                attack = new Blobplode();
            }

            var blob = new Blob(name, health, damage, behavior, attack);
            blobs.Add(name, blob);
            Pass();
        }

        public void Attack(string attacker, string target)
        {
            var damage = blobs[attacker].StartAttack();
            blobs[target].ReceiveAttack(damage);
            if(blobs[target].Health <= 0)
            {
                deadBlobs.Add(target, blobs[target]);
                blobs.Remove(target);
            }
        }

        public void Pass()
        {
            var blobsToRemove = new List<string>();
            foreach (var blob in blobs)
            {
                blob.Value.ApplyBehavior();
                if(blob.Value.Health <= 0)
                {
                    blobsToRemove.Add(blob.Key);
                }
            }

            foreach (var blob in blobsToRemove)
            {
                deadBlobs.Add(blob, blobs[blob]);
                blobs.Remove(blob);
            } 
        }

        public string Status()
        {
            var output = new StringBuilder();

            foreach (var blob in blobs)
            {
                output.AppendLine(blob.Value.ToString());
            }

            foreach (var deadBlob in deadBlobs)
            {
                output.AppendLine(deadBlob.Value.ToString());
            }

            Pass();
            return output.ToString();
        }
    }
}
