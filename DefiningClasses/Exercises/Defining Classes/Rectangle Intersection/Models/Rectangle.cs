namespace Rectangle_Intersection.Models
{
    using System;

    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double leftTopX;
        private double leftTopY;

        public string Id { get => id; private set => id = value; }

        public Rectangle(string id, double width, double height, double leftTopX, double leftTopY)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.leftTopX = leftTopX;
            this.leftTopY = leftTopY;
        }

        public bool IntersectsRectangle(Rectangle r)
        {
            return this.ContainsRectangleCorner(r) ||
                r.ContainsRectangleCorner(this);
        }

        public static Rectangle Parse(string input)
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var id = args[0];
            var width = double.Parse(args[1]);
            var height = double.Parse(args[2]);
            var leftTopX = double.Parse(args[3]);
            var leftTopY = double.Parse(args[4]);

            return new Rectangle(id, width, height, leftTopX, leftTopY);
        }

        private bool ContainsRectangleCorner(Rectangle r)
        {
            return this.ContainsPoint(r.leftTopX, r.leftTopY) ||
                   this.ContainsPoint(r.leftTopX, r.leftTopY + height) ||
                   this.ContainsPoint(r.leftTopX + width, r.leftTopY) ||
                   this.ContainsPoint(r.leftTopX + width, r.leftTopY + height);
        }

        private bool ContainsPoint(double x, double y)
        {
            return x >= this.leftTopX && x <= this.leftTopX + width &&
                   y >= this.leftTopY && y <= this.leftTopY + height;
        }

    }
}
