namespace Point_in_Rectangle
{
    using Point_in_Rectangle.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
