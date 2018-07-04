namespace Food_Shortage.Contracts
{
    public interface ICitizen : IBuyer
    {
        string Name { get; }

        int Age { get; }
    }
}
