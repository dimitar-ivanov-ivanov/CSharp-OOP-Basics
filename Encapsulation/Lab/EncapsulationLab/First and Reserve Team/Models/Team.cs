namespace First_and_Reserve_Team.Models
{
    using System.Collections.Generic;

    public class Team
    {
        private string name;
        private IList<Person> firstTeam;
        private IList<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyList<Person> FirstTeam
        {
            get { return (IReadOnlyList<Person>)this.firstTeam; }
        }

        public IReadOnlyList<Person> ReserveTeam
        {
            get { return (IReadOnlyList<Person>)this.reserveTeam; }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            return $"First team has {this.FirstTeam.Count} players.\n" +
                   $"Reserve team has {this.ReserveTeam.Count} players.";
        }
    }
}
