namespace Rectangle_Intersection
{
    using Rectangle_Intersection.Models;
    using System;
    using System.Globalization;
    using System.Threading;

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
