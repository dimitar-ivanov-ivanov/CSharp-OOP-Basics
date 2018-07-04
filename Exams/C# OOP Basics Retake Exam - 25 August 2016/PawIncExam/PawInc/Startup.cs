namespace PawInc
{
    using PawInc.Core;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var engine = new Engine(new CommandCenter());
            engine.Run();
        }
    }
}
