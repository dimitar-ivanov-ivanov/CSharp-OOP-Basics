namespace Mankind
{
    using Mankind.Models;
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
            try
            {
                var args = Console.ReadLine().Split(' ');
                var student = new Student(args[0], args[1], args[2]);

                args = Console.ReadLine().Split(' ');
                var worker = new Worker(args[0], args[1], double.Parse(args[2]), int.Parse(args[3]));

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
