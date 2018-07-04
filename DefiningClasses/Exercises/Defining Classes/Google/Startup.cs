namespace Google
{
    using System;
    using Google.Models;
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
            var engine = new Engine();
            engine.Run();

            var name = Console.ReadLine();
            engine.PrintPerson(name);
        }
    }
}
