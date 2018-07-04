﻿namespace Point_in_Rectangle.Models
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
