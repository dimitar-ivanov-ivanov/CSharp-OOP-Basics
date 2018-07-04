namespace PawInc.Core
{
    using PawInc.Models.Animals;
    using PawInc.Models.Centers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandCenter
    {
        private Dictionary<string, CleansingCenter> cleansingCenters;
        private Dictionary<string, AdoptionCenter> adoptionCenters;
        private List<string> adoptedAnimals;
        private List<string> cleansedAnimals;

        public CommandCenter()
        {
            this.cleansedAnimals = new List<string>();
            this.adoptedAnimals = new List<string>();
            this.cleansingCenters = new Dictionary<string, CleansingCenter>();
            this.adoptionCenters = new Dictionary<string, AdoptionCenter>();
        }

        public void RegisterCleansingCenter(string name)
        {
            cleansingCenters.Add(name, new CleansingCenter(name));
        }

        public void RegisterAdoptionCenter(string name)
        {
            adoptionCenters.Add(name, new AdoptionCenter(name));
        }

        public void RegisterDog(string name, int age, int learnedCommands, string adoptionCenterName)
        {
            var dog = new Dog(name, age, adoptionCenterName, learnedCommands);
            adoptionCenters[adoptionCenterName].Animals.Add(dog);
        }

        public void RegisterCat(string name, int age, int intelligenceCoefficient, string adoptionCenterName)
        {
            var cat = new Cat(name, age, adoptionCenterName, intelligenceCoefficient);
            adoptionCenters[adoptionCenterName].Animals.Add(cat);
        }

        public void SendForCleansing(string adoptionCenterName, string cleasingCenterName)
        {
            var uncleansedAnimals = adoptionCenters[adoptionCenterName]
                    .Animals
                    .Where(x => !x.CleansingStatus)
                    .ToList();

            adoptionCenters[adoptionCenterName]
                .Animals
                .RemoveAll(x => !x.CleansingStatus);

            cleansingCenters[cleasingCenterName]
                .SendAnimalsToCleanse(uncleansedAnimals);
        }

        public void Cleanse(string cleasingCenterName)
        {
            var res = cleansingCenters[cleasingCenterName]
                .CleanseAnimals();

            cleansedAnimals.AddRange(res.Select(x => x.Name));

            foreach (var animal in res)
            {
                adoptionCenters[animal.AdoptionCenter].Animals.Add(animal);
            }
        }

        public void Adopt(string adoptionCenterName)
        {
            var animalsCleansed = adoptionCenters[adoptionCenterName]
                   .Animals
                   .Where(x => x.CleansingStatus)
                   .ToList();

            adoptionCenters[adoptionCenterName]
                .Animals
                .RemoveAll(x => x.CleansingStatus);

            adoptedAnimals.AddRange(animalsCleansed.Select(x => x.Name));
        }

        public string Output()
        {
            var output = new StringBuilder();

            var animalsAwaitingAdoption = adoptionCenters
                .Sum(x => x.Value.Animals.Where(y => y.CleansingStatus).Count());

            var animalsAwaitingCleansing = cleansingCenters
                .Sum(x => x.Value.Animals.Where(y => !y.CleansingStatus).Count());

            output.AppendLine($"Paw Incorporative Regular Statistics");
            output.AppendLine($"Adoption Centers: {this.adoptionCenters.Count}");
            output.AppendLine($"Cleansing Centers: {this.cleansingCenters.Count}");

            if (adoptedAnimals.Count > 0)
            {
                adoptedAnimals = adoptedAnimals.OrderBy(x => x).ToList();
                output.AppendLine($"Adopted Animals: {string.Join(", ", adoptedAnimals)}");
            }
            else
            {
                output.AppendLine($"Adopted Animals: None");
            }

            if (cleansedAnimals.Count > 0)
            {
                cleansedAnimals = cleansedAnimals.OrderBy(x => x).ToList();
                output.AppendLine($"Cleansed Animals: {string.Join(", ", cleansedAnimals)}");
            }
            else
            {
                output.AppendLine($"Cleansed Animals: None");
            }

            output.AppendLine($"Animals Awaiting Adoption: {animalsAwaitingAdoption}");
            output.AppendLine($"Animals Awaiting Cleansing: {animalsAwaitingCleansing}");

            return output.ToString();
        }
    }
}
