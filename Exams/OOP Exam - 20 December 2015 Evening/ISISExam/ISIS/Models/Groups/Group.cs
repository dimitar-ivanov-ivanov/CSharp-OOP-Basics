using ISIS.Models.Attacks;

namespace ISIS.Models.Groups
{
    public abstract class Group
    {
        private string name;
        private int damage;
        private Attack attack;
        private int health;
        private int initialHealth;
        private bool appliedEffect;
        private bool toggleEffect;

        public string Name => name;
        public bool ToggleEffect
        {
            get { return this.toggleEffect; }
            set { this.toggleEffect = value; }
        }

        public int Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;
                if (this.health <= initialHealth / 2 && 
                   !this.appliedEffect)
                {
                    if(this.health <= 0)
                    {
                        this.health = 0;
                    }
                    this.appliedEffect = true;
                    ActivateEffect();
                }
            }
        }

        public Attack Attack => attack;
        public int InitialHealth => initialHealth;
        public bool AppliedEffect => appliedEffect;

        public Group(string name, int damage, int health, Attack attack)
        {
            this.name = name;
            this.damage = damage;
            this.attack = attack;
            this.health = health;
            this.initialHealth = this.health;
            this.appliedEffect = false;
        }

        public abstract void ActivateEffect();

        public abstract void ApplyEffect();

        public int InitiateAttack()
        {
            var initiateAttack = Attack.InitiateAttack(this);
            return initiateAttack;
        }

        public void ReceiveAttack(int damage)
        {
            this.Health -= damage;
        }

        public override string ToString()
        {
            if (this.health <= 0)
            {
                return $"Group {this.name} AMEN";
            }

            return $"Group {this.name}: {this.health} HP, {this.damage} Damage";
        }
    }
}
