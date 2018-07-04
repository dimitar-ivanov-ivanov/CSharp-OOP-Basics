namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            InitializeData();
        }

        private static void InitializeData()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + " " + secondName;

                if (!doctors.ContainsKey(firstName + secondName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int room = 0; room < 20; room++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool availablePlace = departments[departament]
                    .SelectMany(x => x).Count() < 60;

                if (availablePlace)
                {
                    int room = 0;
                    doctors[fullName].Add(patient);

                    for (int currentRoom = 0; room < departments[departament].Count; currentRoom++)
                    {
                        if (departments[departament][currentRoom].Count < 3)
                        {
                            room = currentRoom;
                            break;
                        }
                    }

                    departments[departament][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            Print(doctors, departments);
        }

        private static void Print(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments)
        {
            string command = Console.ReadLine();
            var room = 0;

            while (command != "End")
            {
                string[] args = command.Split();
                string first = args[0];

                if (args.Length == 1 && departments.ContainsKey(first))
                {
                    Console.WriteLine(string.Join("\n", departments[first]
                        .Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out room))
                {
                    Console.WriteLine(string.Join("\n", departments[first][room - 1]
                        .OrderBy(x => x)));
                }
                else
                {
                    var doctorName = args[0] + " " + args[1];
                    Console.WriteLine(string.Join("\n", doctors[doctorName].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}