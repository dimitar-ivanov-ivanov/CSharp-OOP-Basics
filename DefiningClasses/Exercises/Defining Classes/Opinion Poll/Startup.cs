namespace Opinion_Poll
{
    using Opinion_Poll.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
