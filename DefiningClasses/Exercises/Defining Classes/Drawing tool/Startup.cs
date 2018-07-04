namespace Drawing_tool
{
    using Drawing_tool.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var figureName = Console.ReadLine();
            var width = int.Parse(Console.ReadLine());

            if (figureName == "Square")
            {
                var square = new Square();
                square.Draw(width, width);
            }
            else if (figureName == "Rectangle")
            {
                var height = int.Parse(Console.ReadLine());
                var rectangle = new Rectangle();
                rectangle.Draw(width, height);
            }
        }
    }
}
