namespace Animals
{
    using Animals.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var input = Console.ReadLine();

            while (input != "Beast!")
            {
                var args = Console.ReadLine().Split(' ');
                var name = args[0];
                var age = int.Parse(args[1]);
                Animal animal = null;

                try
                {
                    switch (input)
                    {
                        case "Dog":
                            animal = new Dog(name, age, args[2]);
                            break;
                        case "Cat":
                            animal = new Cat(name, age, args[2]);
                            break;
                        case "Frog":
                            animal = new Frog(name, age, args[2]);
                            break;
                        case "Kitten":
                            animal = new Kitten(name, age);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(animal);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
