namespace PawInc.Models.Centers
{
    using PawInc.Models.Animals;
    using System.Collections.Generic;
    using System.Linq;

    public class CleansingCenter : Center
    {
        public CleansingCenter(string name)
            : base(name)
        {
        }

        public void SendAnimalsToCleanse(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                this.Animals.Add(animal);
            }
        }

        public List<Animal> CleanseAnimals()
        {
            foreach (var animal in this.Animals)
            {
                animal.CleansingStatus = true;
            }

            var res = this.Animals.ToList();
            this.Animals = new List<Animal>();
            return res;
        }
    }
}
