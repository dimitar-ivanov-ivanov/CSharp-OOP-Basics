namespace Military_Elite.Models
{
    using Military_Elite.Contracts;

    public abstract class Soldier : ISoldier
    {
        private int id;
        private string firstName;
        private string lastName;

        protected Soldier(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set { this.lastName = value; }
        }

        public override string ToString()
        {
            return $"Name: {this.firstName} {this.lastName} Id: {this.id}";
        }
    }
}
