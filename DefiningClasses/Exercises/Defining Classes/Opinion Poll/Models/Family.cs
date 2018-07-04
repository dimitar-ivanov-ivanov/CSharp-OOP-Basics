namespace Opinion_Poll.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

        public string PrintMemebersOlderThan(int age)
        {
            var output = new StringBuilder();

            foreach (var person in this.people.Where(x => x.Age > age)
                .OrderBy(x => x.Name))
            {
                output.AppendLine(person.ToString());
            }


            return output.ToString();
        }
    }
}
