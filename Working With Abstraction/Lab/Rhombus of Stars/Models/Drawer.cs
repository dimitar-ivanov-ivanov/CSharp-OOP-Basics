namespace Rhombus_of_Stars.Models
{
    using System;

    public class Drawer
    {
        private static void PrintRow(int n, int starCount)
        {
            Console.Write(new string(' ', n - starCount));

            for (int i = 0; i < starCount; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine(new string(' ', n - starCount));
        }

        public static void PrintFigure(int n)
        {
            PrintHalf(1, n, 1, n);
            PrintHalf(n - 1, 1, -1, n);
        }

        private static void PrintHalf(int start, int end, int val, int n)
        {
            for (int i = start; i <= n && i >= 1; i += val)
            {
                PrintRow(n, i);
            }
        }
    }
}
