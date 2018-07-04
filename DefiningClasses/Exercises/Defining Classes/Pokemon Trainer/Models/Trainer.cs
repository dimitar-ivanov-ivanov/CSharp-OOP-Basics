namespace Pokemon_Trainer.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private IList<Pokemon> pokemons;

        private const int HealthLoss = 10;

        public Trainer(string name)
        {
            this.numberOfBadges = 0;
            this.name = name;
            this.pokemons = new List<Pokemon>();
        }

        public IList<Pokemon> Pokemons { get => pokemons; private set => pokemons = value; }

        public int NumberOfBadges { get => numberOfBadges; set => numberOfBadges = value; }

        public string Name { get => name; private set => name = value; }

        public void ParticipateInTournament(string element)
        {
            var pokemonsWithElement = this.pokemons
                .Count(x => x.Element == element);

            if (pokemonsWithElement == 0)
            {
                AffectAllPokemons(HealthLoss);
            }
            else
            {
                this.NumberOfBadges++;
            }
        }

        private void AffectAllPokemons(int health)
        {


            foreach (var poekemon in this.Pokemons)
            {
                poekemon.Health -= health;
            }

            this.pokemons = this.pokemons
                .Where(x => x.Health > 0)
                .ToList();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}
