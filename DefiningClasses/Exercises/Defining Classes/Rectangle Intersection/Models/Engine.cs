namespace Rectangle_Intersection.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var rectangles = new List<Rectangle>();

            for (int i = 0; i < n; i++)
            {
                var rec = Rectangle.Parse(Console.ReadLine());
                rectangles.Add(rec);
            }

            for (int i = 0; i < m; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var first = rectangles.FirstOrDefault(x => x.Id == args[0]);
                var second = rectangles.FirstOrDefault(x => x.Id == args[1]);

                if (first == null || second == null)
                {
                    Console.WriteLine("false");
                }
                else
                {
                    var res = first.IntersectsRectangle(second);

                    Console.WriteLine(res.ToString().ToLower());
                }
            }
        }
    }
}
