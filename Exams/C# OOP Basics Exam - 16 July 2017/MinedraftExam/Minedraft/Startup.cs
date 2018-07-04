public class Startup
{
    public  static void Main(string[] args)
    {
        var draftManager = new DraftManager();
        var engine = new Engine(draftManager);
        engine.Run();
    }
}
