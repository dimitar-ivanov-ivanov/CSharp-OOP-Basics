namespace First_and_Reserve_Team
{
    using First_and_Reserve_Team.Models;
    using System;
    using System.Globalization;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var team = new Team("Softuni");

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstName = args[0];
                var lastName = args[1];
                var age = int.Parse(args[2]);
                var salary = decimal.Parse(args[3]);

                var person = new Person(firstName, lastName, age, salary);
                team.AddPlayer(person);
            }

            Console.WriteLine(team);
        }
    }
}
