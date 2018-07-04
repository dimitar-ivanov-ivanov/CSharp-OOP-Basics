namespace Vehicles_Extension
{
    using System.Globalization;
    using System.Threading;
    using Vehicles_Extension.Core;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Execute();
        }

        private static void Execute()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
