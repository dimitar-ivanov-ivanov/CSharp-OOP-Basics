using System.Globalization;
using System.Threading;

public class Startup
{
    public static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        var nationBuilder = new NationsBuilder();
        var engine = new Engine(nationBuilder);

        engine.Run();
    }
}