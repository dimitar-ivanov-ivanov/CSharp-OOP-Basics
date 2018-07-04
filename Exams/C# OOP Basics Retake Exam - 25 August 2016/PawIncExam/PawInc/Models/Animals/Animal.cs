namespace PawInc.Models.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private bool cleansingStatus;
        private string adoptionCenter;

        public string Name => name;
        public int Age => age;
        public string AdoptionCenter => adoptionCenter;
        public bool CleansingStatus
        {
            get { return this.cleansingStatus; }
            set { this.cleansingStatus = value; }
        }

        public Animal(string name,int age,string adoptionCenter)
        {
            this.name = name;
            this.age = age;
            this.adoptionCenter = adoptionCenter;
        }
    }
}
