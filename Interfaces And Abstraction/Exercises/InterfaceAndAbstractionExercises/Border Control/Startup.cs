namespace Border_Control
{
    using Border_Control.Models;

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