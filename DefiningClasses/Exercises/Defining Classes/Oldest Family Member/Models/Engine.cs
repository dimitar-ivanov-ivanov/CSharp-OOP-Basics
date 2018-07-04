namespace Oldest_Family_Member.Models
{
    using System;

    public class Engine
    {
        public void Run()
        {
            var family = new Family();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = args[0];
                var age = int.Parse(args[1]);

                var person = new Person(name, age);
                family.People.Add(person);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
