namespace Test_Client
{
    using System.Globalization;
    using System.Threading;
    using Test_Client.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Execute();
        }

        public static void Execute()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}