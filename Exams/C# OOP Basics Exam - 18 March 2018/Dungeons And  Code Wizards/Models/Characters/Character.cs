namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Constants;
    using DungeonsAndCodeWizards.Enums;
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Items;
    using System;

    public abstract class Character
    {
        private const double RestDefault = 0.2;
        private const int MinBase = 0;
        private double health;
        private double armor;
        private string name;

        protected Character(string name, double health, double armor,
            double abilityPoints, Bag bag, Faction faction)
        {
            this.BaseArmor = armor;
            this.BaseHealth = health;
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(OutputMessages.NameIsNull);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get { return this.health; }
            set
            {
                if (value > BaseHealth)
                {
                    value = BaseHealth;
                }
                if (value < MinBase)
                {
                    value = MinBase;
                }
                this.health = value;
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get { return this.armor; }
            set
            {
                if (value > BaseArmor)
                {
                    value = BaseArmor;
                }
                if (value < MinBase)
                {
                    value = MinBase;
                }
                this.armor = value;
            }
        }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public Faction Faction { get; }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier => RestDefault;

        public void TakeDamage(double hitPoints)
        {
            CheckAlive(this);
            var diff = Math.Abs(this.Armor - hitPoints);

            this.Armor -= hitPoints;

            if (this.Armor == 0)
            {
                this.Health -= diff;
                if (this.Health == 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void Rest()
        {
            CheckAlive(this);
            this.Health += this.BaseHealth * RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            CheckAlive(this);
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            CheckAlive(this);
            CheckAlive(character);
            item.AffectCharacter(character);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            CheckAlive(this);
            CheckAlive(character);
            character.Bag.AddItem(item);
        }

        private void CheckAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new ArgumentException(OutputMessages.CharacterIsDead);
            }
        }

        public abstract void ActivateAbility(string type, Character character);

        public override string ToString()
        {
            var status = IsAlive ? "Alive" : "Dead";

            return $"{this.name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}
