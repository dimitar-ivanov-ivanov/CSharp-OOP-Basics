public class Startup
{
    public static void Main(string[] args)
    {
        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();
        var carManager = new CarManager();

        var engine = new Engine(reader, writer, carManager);

        engine.Run();
    }
}
