namespace ISIS
{
    using ISIS.Core;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var engine = new Engine(new CommandCenter());
            engine.Run();
        }
    }
}
