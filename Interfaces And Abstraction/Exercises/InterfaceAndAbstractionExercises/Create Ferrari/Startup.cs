namespace Create_Ferrari
{
    using Create_Ferrari.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var name = Console.ReadLine();
            var ferrari = new Ferrari(name);
            Console.WriteLine(ferrari);
        }
    }
}
