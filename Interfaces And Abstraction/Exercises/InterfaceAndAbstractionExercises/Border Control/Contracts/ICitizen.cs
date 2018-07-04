namespace Border_Control.Contracts
{
    public interface ICitizen : IIdentifiable
    {
        string Name { get; }

        int Age { get; }
    }
}
