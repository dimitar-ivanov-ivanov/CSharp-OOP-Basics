public interface IRaceFactory
{
    IRace CreateRace(string type, int length, string route, int prizePool);
}
