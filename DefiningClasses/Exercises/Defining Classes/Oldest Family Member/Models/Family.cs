namespace Oldest_Family_Member.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> people;

        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

        public Family()
        {
            this.people = new List<Person>();
        }

        public Person GetOldestMember()
        {
            return this.People
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
        }
    }
}
