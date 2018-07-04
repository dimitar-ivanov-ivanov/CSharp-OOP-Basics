namespace Birthday_Celebrations.Models
{
    using Birthday_Celebrations.Contracts;

    public class Pet : IBirthable
    {
        private string birthdate;
        private string name;

        public Pet(string name, string birthdate)
        {
            this.name = name;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public string Birthdate
        {
            get { return this.birthdate; }
            private set { this.birthdate = value; }
        }
    }
}
