namespace Shapes
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var circle = new Circle(5);
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());

            var rectangle = new Rectangle(3, 2);
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
        }
    }
}