namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * height + 2 * width;
        }
    }
}