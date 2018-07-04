namespace Pokemon_Trainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private const string TerminatingTrainersCommand = "Tournament";
        private const string TerminatingTournamentCommand = "End";

        public Engine()
        {
        }

        public void Run()
        {
            var trainers = GetTrainers();
            StartTournament(trainers);
            PrintTrainers(trainers);
        }

        private void StartTournament(Dictionary<string, Trainer> trainers)
        {
            var input = Console.ReadLine();

            while (input != TerminatingTournamentCommand)
            {
                foreach (var trainer in trainers)
                {
                    trainer.Value.ParticipateInTournament(input);
                }
                input = Console.ReadLine();
            }
        }

        private void PrintTrainers(Dictionary<string, Trainer> trainers)
        {
            foreach (var trainer in trainers
                .OrderByDescending(x => x.Value.NumberOfBadges))
            {
                Console.WriteLine(trainer.Value);
            }
        }

        public Dictionary<string, Trainer> GetTrainers()
        {
            var input = Console.ReadLine();
            var trainers = new Dictionary<string, Trainer>();

            while (input != TerminatingTrainersCommand)
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var trainerName = args[0];
                var pokemonName = args[1];
                var element = args[2];
                var health = int.Parse(args[3]);

                var trainer = new Trainer(trainerName);
                var pokemon = new Pokemon(pokemonName, element, health);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, trainer);
                }

                trainers[trainerName].Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            return trainers;
        }
    }
}
