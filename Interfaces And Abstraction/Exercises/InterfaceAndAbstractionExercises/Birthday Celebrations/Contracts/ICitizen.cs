namespace Birthday_Celebrations.Contracts
{
    public interface ICitizen : IIdentifiable,IBirthable
    {
        string Name { get; }

        int Age { get; }
    }
}
