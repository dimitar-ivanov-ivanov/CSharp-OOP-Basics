namespace Date_Modifier
{
    using Date_Modifier.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var input1 = Console.ReadLine();
            var input2 = Console.ReadLine();

            Console.WriteLine(DateModifier.CalculateDifferenceInDays(input1, input2));
        }
    }
}