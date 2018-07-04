namespace Point_in_Rectangle.Models
{
    using System;

    public class Engine
    {
        public void Run()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var topLeft = new Point(int.Parse(args[0]), int.Parse(args[1]));
            var bottomRight = new Point(int.Parse(args[2]), int.Parse(args[3]));
            var rec = new Rectangle(topLeft, bottomRight);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var point = new Point(int.Parse(args[0]), int.Parse(args[1]));
                Console.WriteLine(rec.Contains(point));
            }
        }
    }
}
