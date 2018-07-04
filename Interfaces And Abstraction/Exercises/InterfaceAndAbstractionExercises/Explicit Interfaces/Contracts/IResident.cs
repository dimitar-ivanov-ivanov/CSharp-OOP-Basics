namespace Explicit_Interfaces.Contracts
{
    public interface IResident
    {
        string Name { get; }

        int Age { get; }

        string Country { get; }

        string GetName();
    }
}
