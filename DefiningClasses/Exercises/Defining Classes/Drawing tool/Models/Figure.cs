namespace Drawing_tool.Models
{
    using System;

    public abstract class Figure
    {
        public void Draw(int width, int height)
        {
            Console.WriteLine($"|{new string('-', width)}|");

            for (int i = 0; i < height - 2; i++)
            {
                Console.WriteLine($"|{new string(' ', width)}|");
            }

            Console.WriteLine($"|{new string('-', width)}|");
        }
    }
}