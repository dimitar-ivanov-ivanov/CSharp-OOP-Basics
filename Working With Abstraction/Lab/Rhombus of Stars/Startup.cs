namespace Rhombus_of_Stars
{
    using Rhombus_of_Stars.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            Drawer.PrintFigure(n);
        }
    }
}
