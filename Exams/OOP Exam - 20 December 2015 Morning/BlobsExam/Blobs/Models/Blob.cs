namespace Blobs.Models
{
    using Blobs.Models.Attacks;
    using Blobs.Models.Behaviors;

    public class Blob
    {
        private string name;
        private int health;
        private int damage;
        private Behavior behavior;
        private Attack attack;
        private bool activatedBehavior;
        private int initialHealth;
        private int initialDamage;

        public string Name => name;
        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;
                if (health <= initialHealth / 2 && !activatedBehavior)
                {
                    this.activatedBehavior = true;
                    this.behavior.ActivateBehavior(this);
                }
            }
        }

        public int Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        public bool ActivatedBehavior => activatedBehavior;

        public Blob(string name, int health, int damage, Behavior behavior, Attack attack)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.behavior = behavior;
            this.attack = attack;
            this.activatedBehavior = false;
            this.initialHealth = health;
            this.initialDamage = damage;
        }

        public int StartAttack()
        {
            return this.attack.StartAttack(this);
        }

        public void ReceiveAttack(int damage)
        {
            this.Health -= damage;
        }

        public void ApplyBehavior()
        {
            this.behavior.ApplyBehavior(this);
            if (this.damage < initialDamage)
            {
                this.damage = initialDamage;
            }
        }

        public override string ToString()
        {
            if (this.health <= 0)
            {
                return $"Blob {this.Name} KILLED";
            }
            return $"Blob {this.name}: {this.health} HP, {this.damage} Damage";
        }
    }
}